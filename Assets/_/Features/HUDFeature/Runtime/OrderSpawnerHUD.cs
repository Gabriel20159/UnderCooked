using System;
using System.Collections.Generic;
using OrderFeature.Runtime;
using UnityEngine;

namespace HUDFeature.Runtime
{
    public class OrderSpawnerHUD : MonoBehaviour
    {
        #region Public Members

        public List<GameObject> m_ordersHUD = new();

        #endregion Public Members

        #region Unity API

        private void Start()
        {
            OrderManager.m_instance.m_onOrder += OnNewOrderEventHandler;
        }

        #endregion Unity API

        #region Main Methods

        public void OnNewOrderEventHandler(object sender, EventArgs eventArgs)
        {
            GameObject order = Instantiate(_orderPrefab, _orderCanvas.transform, true);
        }

        #endregion Main Methods

        #region Utils

        #endregion Utils

        #region Private and Protected Members

        [SerializeField] private GameObject _orderPrefab;
        [SerializeField] private GameObject _orderCanvas;

        #endregion Private and Protected Members
    }
}