using System;
using System.Collections.Generic;
using OrderFeature.Runtime;
using UnityEngine;

namespace HUDFeature.Runtime
{
    public class OrderSpawnerHUD : MonoBehaviour
    {
        #region Public Members

        public List<GameObject> m_ordersHUD = new List<GameObject>();

        #endregion Public Members

        #region Unity API

        void Start()
        {
            OrderManager.m_instance.m_onOrder += OnNewOrderEventHandler;

            //OrderManager.m_instance.m_onOrder += ;
        }

        #endregion Unity API

        #region Main Methods

        void OnNewOrderEventHandler(object sender, EventArgs eventArgs)
        {
            GameObject order = Instantiate(_orderPrefab, _orderCanvas.transform, true);
            order.transform.localScale = Vector3.one;
            m_ordersHUD.Add(order);
        }

        void OnOrder(object sender, EventArgs eventArgs)
        {
         //  GameObject order = m_ordersHUD[];
         //  m_ordersHUD.Remove(order);
         //  Destroy(order);
        }

        #endregion Main Methods

        #region Utils

        #endregion Utils

        #region Private and Protected Members

        [SerializeField]
        GameObject _orderPrefab;
        [SerializeField]
        GameObject _orderCanvas;

        #endregion Private and Protected Members
    }
}
