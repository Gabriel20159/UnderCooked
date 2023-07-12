using System;
using System.Collections;
using System.Collections.Generic;
using GameManagerFeature.Runtime;
using InteractableFeature.Runtime;
using UnityEngine;

namespace OrderFeature.Runtime
{
    public class OrderIndexEventArg : EventArgs
    {
        public int m_index;
    }
    public class OrderManager : MonoBehaviour
    {
        #region Public Members

        public static OrderManager m_instance;
        public EventHandler<EventArgs> m_onOrder;
        public EventHandler<OrderIndexEventArg> m_onOrderEnded;

        public List<ClientOrder> m_orderList;

        #endregion


        #region Unity API

        private void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            
        }

        private void Start()
        {
            StartCoroutine(SpawnOrder());
        }

        private void Update()
        {
            List<ClientOrder> ordersToDelete = new();
            
            foreach (var order in m_orderList)
            {
                order.TimeRemaining -= Time.deltaTime;
                if (order.TimeRemaining > -5f) return;
                ordersToDelete.Add(order);
            }

            foreach (var order in ordersToDelete)
            {
               m_orderList.RemoveAt(m_orderList.IndexOf(order));
            }
        }

        #endregion
        
        #region Main Methods

        private IEnumerator SpawnOrder()
        {
            ClientOrder order = Instantiate(_orderTemplate, transform);
            order.TimeRemaining = _orderTimer;
            m_orderList.Add(order);
            
            m_onOrder?.Invoke(this, EventArgs.Empty);
            
            yield return new WaitForSeconds(_orderSpawnRate);
            StartCoroutine(SpawnOrder());

        }

        public void CheckPlate(Plate plate)
        {
            foreach (var order in m_orderList)
            {
                List<IngredientType> requiredCombo = new List<IngredientType>(order.Recipe);
                foreach (var ingredientInPlate in plate.IngredientCombo)
                {
                    if (requiredCombo.Count == 0)
                    {
                        FailPlate(plate);
                        return;
                    }
                    
                    if (!requiredCombo.Contains(ingredientInPlate.Type)) continue;
                    
                    requiredCombo.Remove(ingredientInPlate.Type);
                }

                if (requiredCombo.Count != 0) continue;
                
                ValidatePlate(plate);
                return;
            }

            FailPlate(plate);
        }

        private void ValidatePlate(Plate plate)
        {
            Destroy(plate.gameObject);
            ScoreManager.m_instance.AddScore(3);
        }

        private void FailPlate(Plate plate)
        {
            Destroy(plate.gameObject);
            ScoreManager.m_instance.SubtractScore(1);
        }

        public void StopSpawnOrder()
        {
            StopCoroutine(SpawnOrder());
        }
        
        public void RemoveFromWaitList(ClientOrder order)
        {
            int index = m_orderList.IndexOf(order);
            m_orderList.Remove(order);

            m_onOrderEnded?.Invoke(this, new OrderIndexEventArg() { m_index = index });
        }

        #endregion

        #region Private and Protected

        [SerializeField] private float _orderSpawnRate;
        [SerializeField] private float _orderTimer;

        [SerializeField] private ClientOrder _orderTemplate;

        #endregion
    }
}
