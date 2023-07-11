using System;
using OrderFeature.Runtime;
using UnityEngine;

namespace HUDFeature.Runtime
{
    public class OrderSpawnerHUD : MonoBehaviour
    {
        #region Public Members

        #endregion Public Members

        #region Unity API

        private void Start()
        {
         //   OrderManager.m_instance
        }

        #endregion Unity API

        #region Main Methods

        public void OnNewOrderEventHandler(Sprite orderImage, Sprite orderRecipe)
        {
            GameObject order = Instantiate(_orderPrefab, _orderCanvas.transform, true);
            var orderScript = order.GetComponent<OrderHUD>();
            orderScript.m_orderImage.sprite = orderImage;
            orderScript.m_orderRecipe.sprite = orderRecipe;
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