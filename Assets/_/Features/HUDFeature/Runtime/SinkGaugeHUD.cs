using System;
using InteractableFeature.Runtime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HUDFeature.Runtime
{
    public class SinkGaugeHUD : MonoBehaviour
    {
    	#region Public Members

        public Slider m_gauge;

    	#endregion


    	#region Unity API

        void Start()
        {
	        _sink.m_onDirtyValueChanged += OnGaugeHUDEventHandler;
	        _sink.m_onNewPlate += OnNewPlateEventHandler;
            gameObject.SetActive(false);
        }

        #endregion


    	#region Main Methods

        void OnGaugeHUDEventHandler(object sender, float CleanPercentage)
        {
            CleanPercentage = 1 - CleanPercentage;
            m_gauge.value = CleanPercentage;

            gameObject.SetActive(CleanPercentage is not (>= 1 or 0));
        }

        void OnNewPlateEventHandler(object sender, EventArgs e)
        {
	        gameObject.SetActive(false);
        }

    	#endregion


    	#region Private and Protected Members

	    
        [SerializeField]
        Sink _sink;

        #endregion
    }
}
