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

        private void Start()
        {
	       // _ingredient.m_onChopValueChanged += OnGaugeHUDEventHandler;
	        gameObject.SetActive(false);
        }

        #endregion


    	#region Main Methods

        private void OnGaugeHUDEventHandler(object sender, float chopPercentage)
        {
	        gameObject.SetActive(true);
	        m_gauge.value = chopPercentage;

	        if (chopPercentage >= 1)
	        {
		        gameObject.SetActive(false);
	        }
        }

    	#endregion


    	#region Private and Protected Members

      //  [SerializeField] private Ingredient _saucepan;

        #endregion
    }
}