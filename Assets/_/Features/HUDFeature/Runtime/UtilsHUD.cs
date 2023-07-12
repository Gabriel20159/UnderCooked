using UnityEngine;

namespace HUDFeature.Runtime
{
    public class UtilsHUD : MonoBehaviour
    {
    	#region Unity API

        private void LateUpdate()
        {
	        transform.LookAt(transform.position + _cameraTransform.forward);
        }

        #endregion
        
        
    	#region Private and Protected Members

        [SerializeField] private Transform _cameraTransform;

        #endregion
    }
}