using OrderFeature.Runtime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

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
            // var ingredientOne = OrderManager.m_instance.m_orderList[OrderManager.m_instance.m_orderList.Count]
            //     .recipes[0];
            // var ingredientTwo = OrderManager.m_instance.m_orderList[OrderManager.m_instance.m_orderList.Count]
            //     .recipes[0];

            switch (ingredientOne)
            {
                case "tomato":
                    m_orderIngredientOne.sprite = _tomatoIngredient;
                    break;

                case "salad":
                    m_orderIngredientOne.sprite = _saladIngredient;
                    break;
            }
            
            switch (ingredientTwo)
            {
                case "tomato":
                    m_orderIngredientTwo.sprite = _tomatoIngredient;
                    break;

                case "salad":
                    m_orderIngredientTwo.sprite = _saladIngredient;
                    break;
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