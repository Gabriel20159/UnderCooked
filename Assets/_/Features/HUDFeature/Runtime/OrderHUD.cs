using UnityEngine;
using UnityEngine.UI;

namespace HUDFeature.Runtime
{
    public class OrderHUD : MonoBehaviour
    {
        #region Public Members

        public Image m_orderImage;
        public Image m_orderRecipe;
        public Slider m_timeSlider;

        #endregion Public Members

        #region Unity API

        private void Start()
        {
        
        }

        #endregion Unity API

        #region Main Methods

        #endregion Main Methods

        #region Utils

        #endregion Utils

        #region Private and Protected Members

        [SerializeField] private Sprite _tomato;
        [SerializeField] private Sprite _salad;

        #endregion Private and Protected Members
    }
}