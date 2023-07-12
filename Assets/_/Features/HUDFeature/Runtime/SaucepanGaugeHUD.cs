using InteractableFeature.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace HUDFeature.Runtime
{
    public class SaucepanGaugeHUD : MonoBehaviour
    {
    	#region Public Members

        public Slider m_gauge;

    	#endregion


    	#region Unity API

        void Start()
        {
            _saucepan.m_onCookValueChanged += OnGaugeHUDEventHandler;
            gameObject.SetActive(false);
        }

        #endregion


    	#region Main Methods

        void OnGaugeHUDEventHandler(object sender, float chopPercentage)
        {
            m_gauge.value = chopPercentage;

            gameObject.SetActive(chopPercentage is not (>= 1 or 0));
        }

    	#endregion


    	#region Private and Protected Members

        [SerializeField]
        Saucepan _saucepan;

        #endregion
    }
}
