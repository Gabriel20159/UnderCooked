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

        void Start()
        {
            int ingredientsCount = OrderManager.m_instance.m_orderList[^1].Recipe.Length;
            IngredientType ingredientOne = OrderManager.m_instance.m_orderList[^1].Recipe[0];
            
            
            
            m_orderImage.sprite = _tomatoSoup;
            
            switch (ingredientOne)
            {
                case IngredientType.Tomato:
                    m_orderIngredientOne.sprite = _tomatoIngredient;
                    break;

                case IngredientType.Salad:
                    m_orderIngredientOne.sprite = _saladIngredient;
                    break;
            }
            
            if (ingredientsCount > 1)
            {

                IngredientType ingredientTwo = OrderManager.m_instance.m_orderList[^1].Recipe[1];

                switch (ingredientTwo)
                {
                    case IngredientType.Tomato:
                        m_orderIngredientTwo.sprite = _tomatoIngredient;
                        break;

                    case IngredientType.Salad:
                        m_orderIngredientTwo.sprite = _saladIngredient;
                        break;
                }
                
                
                if (ingredientOne == IngredientType.Tomato || ingredientTwo == IngredientType.Tomato)
                {
                    m_orderImage.sprite = _saladTomato;

                }
                
                else
                {
                    m_orderImage.sprite = _salad;
                }
            }


          


            float time = OrderManager.m_instance.m_orderList[OrderManager.m_instance.m_orderList.Count - 1].TimeRemaining;

            m_timeSlider.minValue = 0;
            m_timeSlider.maxValue = time;
            m_timeSlider.value = m_timeSlider.maxValue;


          

            


           

        }

        void Update()
        {
            m_timeSlider.value -= Time.deltaTime;

            Color color = _colorGood;
            switch (m_timeSlider.value / m_timeSlider.maxValue)
            {
                case < 0.25f:
                    color = _colorBad;
                    break;
                case < 0.5f:
                    color = _colorBof;
                    break;

            }
            m_timeSlider.fillRect.GetComponent<Image>().color = color;


        }

        #endregion Unity API

        #region Main Methods

        #endregion Main Methods

        #region Utils

        #endregion Utils

        #region Private and Protected Members

        [SerializeField]
        Sprite _tomatoIngredient;
        [SerializeField]
        Sprite _saladIngredient;
        [SerializeField]
        Sprite _salad;
        [SerializeField]
        Sprite _saladTomato;
        [SerializeField]
        Sprite _tomatoSoup;

        [Header("Colors")]
        [SerializeField]
        Color _colorGood;
        [SerializeField]
        Color _colorBof;
        [SerializeField]
        Color _colorBad;

        #endregion Private and Protected Members
    }
}
