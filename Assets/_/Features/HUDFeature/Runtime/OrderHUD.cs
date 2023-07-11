using System;
using InteractableFeature.Runtime;
using OrderFeature.Runtime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using OrderFeature;

namespace HUDFeature.Runtime
{
    public class OrderHUD : MonoBehaviour
    {
        #region Public Members

        public Image m_orderImage;
        public Image m_orderIngredientOne;
        public Image m_orderIngredientTwo;
        public Slider m_timeSlider;

        #endregion Public Members

        #region Unity API

        private void Start()
        {
            var ingredientOne = OrderManager.m_instance.m_orderList[OrderManager.m_instance.m_orderList.Count -1].Recipe[0];
            var ingredientTwo = OrderManager.m_instance.m_orderList[OrderManager.m_instance.m_orderList.Count-1].Recipe[1];;

            var time = OrderManager.m_instance.m_orderList[OrderManager.m_instance.m_orderList.Count - 1].TimeRemaining;
            
            m_timeSlider.minValue = 0;
            m_timeSlider.maxValue = time;
            m_timeSlider.value = m_timeSlider.maxValue;
            
            switch (ingredientOne)
            {
                case IngredientType.Tomato:
                    m_orderIngredientOne.sprite = _tomatoIngredient;
                    break;

                case IngredientType.Salad:
                    m_orderIngredientOne.sprite = _saladIngredient;
                    break;
            }
            
            switch (ingredientTwo)
            {
                case IngredientType.Tomato:
                    m_orderIngredientTwo.sprite = _tomatoIngredient;
                    break;

                case IngredientType.Salad:
                    m_orderIngredientTwo.sprite = _saladIngredient;
                    break;
            }

            if (ingredientOne == IngredientType.Tomato ||ingredientTwo == IngredientType.Tomato )
            {
                m_orderImage.sprite = _saladTomato;

            }
            else
            {
                m_orderImage.sprite = _salad;
            }
            
        }

        private void Update()
        {
            m_timeSlider.value -= Time.deltaTime;
            if (m_timeSlider.value<=0)
            {
                Destroy(gameObject);
            }
        }

        #endregion Unity API

        #region Main Methods

        #endregion Main Methods

        #region Utils

        #endregion Utils

        #region Private and Protected Members

        [SerializeField] private Sprite _tomatoIngredient; 
        [SerializeField] private Sprite _saladIngredient;
        [SerializeField] private Sprite _salad;
        [SerializeField] private Sprite _saladTomato;

        #endregion Private and Protected Members
    }
}