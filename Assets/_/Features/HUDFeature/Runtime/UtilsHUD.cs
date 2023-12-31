using System;
using UnityEngine;

namespace HUDFeature.Runtime
{
    public class UtilsHUD : MonoBehaviour
    {
    	#region Unity API

        private void Awake()
        {
	        _cameraTransform = Camera.main.transform;
        }

        private void LateUpdate()
        {
	        transform.LookAt(transform.position + _cameraTransform.forward);
        }

        #endregion
        
        
    	#region Private and Protected Members

        private Transform _cameraTransform;

        #endregion
    }
}