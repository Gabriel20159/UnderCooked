using System;
using System.Collections.Generic;
using InputFeature.Runtime;
using UnityEngine;

namespace PlayerFeature.Runtime
{
    public class PlayerInteraction : MonoBehaviour
    {
	    #region Public Members

	    #endregion


	    #region Unity API

	    private void Start()
	    {
		    InputManager.m_instance.m_onTake += OnInteractionEventHandler;
	    }

	    private void OnTriggerEnter(Collider other)
	    {
		    _interactableObjectInRange.Add(other.gameObject);
	    }

	    private void OnTriggerExit(Collider other)
	    {
		    _interactableObjectInRange.Remove(other.gameObject);
	    }

	    #endregion


	    #region Main Methods

	    private void OnInteractionEventHandler(object sender, EventArgs e)
	    {
		    if (_interactableObjectInRange.Count == 0
		        || _currentInteractable is not null) return;

		    GameObject closestGameObject = _interactableObjectInRange[0];
		    
		    foreach (var interactable in _interactableObjectInRange)
		    {
			    if (Vector3.Distance(interactable.transform.position, transform.position) < 
			        Vector3.Distance(closestGameObject.transform.position, transform.position))
			    {
				    closestGameObject = interactable;
			    }
		    }
		    _currentInteractable = closestGameObject;
		    _currentInteractable.transform.SetParent(_holdAnchor);
		    _currentInteractable.transform.position = _holdAnchor.position;
		    _currentInteractable.GetComponent<Rigidbody>().isKinematic = true;
		    
		    // else if (_currentInteractable is not null)
		    // {
			   //  
		    // }
	    }
	    
	    #endregion
	    
	    
	    #region Private and Protected Members
	    
	    [SerializeField] private Transform _holdAnchor;

	    private List<GameObject> _interactableObjectInRange = new();
	    private GameObject _currentInteractable;

	    #endregion
    }
}