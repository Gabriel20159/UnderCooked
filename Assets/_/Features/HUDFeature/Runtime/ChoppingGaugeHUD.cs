using System;
using InteractableFeature.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace HUDFeature.Runtime
{
    public class ChoppingGaugeHUD : MonoBehaviour
    {
    	#region Public Members

        public Slider m_gauge;


    	#endregion


    	#region Unity API

        private void Start()
        {
	        _ingredient.m_onChopValueChanged += OnGaugeHUDEventHandler;
        }

        #endregion


    	#region Main Methods

        private void OnGaugeHUDEventHandler(object sender, float chopPercentage)
        {
	        m_gauge.value = chopPercentage;
        }

    	#endregion


    	#region Utils



    	#endregion


    	#region Private and Protected Members

        [SerializeField] private Ingredient _ingredient;

        #endregion
    }
}