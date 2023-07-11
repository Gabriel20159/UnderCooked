using System.Collections.Generic;
using UnityEngine;

namespace PlayerFeature.Runtime
{
    public class PlayerInteraction : MonoBehaviour
    {
	    #region Public Members

		

	    #endregion


	    #region Unity API

	    // private void FixedUpdate()
	    // {
		   //  if (Input.GetButtonDown("Fire1"))
		   //  {
			  //   Interact();
		   //  }
	    // }

	    private void OnTriggerEnter(Collider other)
	    {
		    _interactibleObjectInRange.Add(other.gameObject);
	    }

	    private void OnTriggerExit(Collider other)
	    {
		    _interactibleObjectInRange.Remove(other.gameObject);
	    }

	    #endregion


	    #region Main Methods

	    // private void Interact()
	    // {
		   //  if (_interactibleObjectInRange is null) return;
	    //
		   //  foreach (var VARIABLE in COLLECTION)
		   //  {
			  //   
		   //  }
		   //  
		   //  _currentInteractibleObject = _interactibleObjectInRange;
	    // }

	    #endregion


	    #region Utils



	    #endregion


	    #region Private and Protected Members

	    private List<GameObject> _interactibleObjectInRange;
	    private GameObject _currentInteractibleObject;

	    #endregion
    }
}