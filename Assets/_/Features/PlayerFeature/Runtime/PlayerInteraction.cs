using UnityEngine;

namespace PlayerFeature.Runtime
{
    public class PlayerInteraction : MonoBehaviour
    {
	    #region Public Members

		

	    #endregion


	    #region Unity API

	    private void FixedUpdate()
	    {
		    if (Input.GetButtonDown("Fire1"))
		    {
			    Interact();
		    }
	    }

	    private void OnTriggerEnter(Collider other)
	    {
		    _interactibleObjectInRange = other.gameObject;
	    }

	    private void OnTriggerExit(Collider other)
	    {
		    _interactibleObjectInRange = null;
	    }

	    #endregion


	    #region Main Methods

	    private void Interact()
	    {
		    if (_interactibleObjectInRange is null) return;
		    _currentInteractibleObject = _interactibleObjectInRange;
	    }

	    #endregion


	    #region Utils



	    #endregion


	    #region Private and Protected Members

	    private GameObject _interactibleObjectInRange;
	    private GameObject _currentInteractibleObject;

	    #endregion
    }
}