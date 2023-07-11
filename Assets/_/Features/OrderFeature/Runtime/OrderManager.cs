using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OrderFeature.Runtime
{
    public class OrderManager : MonoBehaviour
    {
        #region Public Members

        public static OrderManager m_instance;
        
        public List<ClientOrder> m_orderList;

        #endregion


        #region Unity API

        private void Awake()
        {
            if (m_instance is not null)
            {
                Destroy(this);
                return;
            }
            m_instance = this;
        }

        private void Start()
        {
            StartCoroutine(SpawnOrder());
        }

        #endregion


        #region Main Methods

        private IEnumerator SpawnOrder()
        {
            ClientOrder order = Instantiate(_orderTemplate, transform);
            order.m_timeRemaining = _orderTimer;
            m_orderList.Add(order);
            
            yield return new WaitForSeconds(_orderSpawnRate);
            StartCoroutine(SpawnOrder());

        }

        public void StopSpawnOrder()
        {
            StopCoroutine(SpawnOrder());
        }
        public void RemoveFromWaitList(ClientOrder order)
        {
            m_orderList.Remove(order);
        }

        #endregion

        #region Private and Protected

        [SerializeField] private float _orderSpawnRate;
        [SerializeField] private float _orderTimer;

        [SerializeField] private ClientOrder _orderTemplate;

        #endregion
    }
}
