using System;
using System.Collections.Generic;
using InputFeature.Runtime;
using InteractableFeature.Runtime;
using UnityEngine;

namespace PlayerFeature.Runtime
{
    public class PlayerInteraction : MonoBehaviour
    {
	    #region Unity API

	    private void Start()
	    {
		    InputManager.m_instance.m_onTake += OnInteractionEventHandler;
	    }

	    private void OnTriggerEnter(Collider other)
	    {
		    if (other.TryGetComponent(out Interactable interactable))
		    {
			    _interactablesInRange.Add(interactable);
		    }
	    }

	    private void OnTriggerExit(Collider other)
	    {
		    if (other.TryGetComponent(out Interactable interactable))
		    {
			    _interactablesInRange.Remove(interactable);
		    }
	    }

	    #endregion


	    #region Main Methods

	    private void OnInteractionEventHandler(object sender, EventArgs e)
	    {
		    Interactable closestInteractable = GetClosestInteractable();

		    if (closestInteractable is null) return;

		    switch (closestInteractable)
		    {
			    case Pickable pickable:
				    HoldPickable(pickable);
				    break;
			    case Furniture furniture:
				    InteractWithFurniture(furniture);
				    break;
		    }
	    }

	    private Interactable GetClosestInteractable()
	    {
		    if (_interactablesInRange.Count == 0) return null;

		    Interactable closestInteractable = _interactablesInRange[0];
		    
		    foreach (var interactable in _interactablesInRange)
		    {
			    if (Vector3.Distance(interactable.transform.position, transform.position) <
			        Vector3.Distance(closestInteractable.transform.position, transform.position))
			    {
				    closestInteractable = interactable;
			    }
		    }
		    
		    return closestInteractable;
	    }

	    private void HoldPickable(Pickable pickable)
	    {
		    if (_currentPickable is not null) return;

		    _interactablesInRange.Remove(pickable);
		    _currentPickable = pickable;
		    _currentPickable.transform.SetParent(_holdAnchor);
		    _currentPickable.transform.position = _holdAnchor.position;
		    _currentPickable.GetComponent<Rigidbody>().isKinematic = true;
	    }

	    private void InteractWithFurniture(Furniture furniture)
	    {
		    if (furniture.CurrentPickable && _currentPickable is null)
		    {
			    _currentPickable = furniture.GetPickable();
			    _currentPickable.transform.SetParent(_holdAnchor);
			    _currentPickable.transform.localPosition = Vector3.zero;
		    }
		    else if (_currentPickable is not null)
		    {
			    furniture.Interact(_currentPickable);
			    _currentPickable = null;
		    }
	    }
	    
	    #endregion
	    
	    
	    #region Private and Protected Members
	    
	    [SerializeField] private Transform _holdAnchor;

	    private List<Interactable> _interactablesInRange = new();
	    private Pickable _currentPickable;

	    #endregion
    }
}