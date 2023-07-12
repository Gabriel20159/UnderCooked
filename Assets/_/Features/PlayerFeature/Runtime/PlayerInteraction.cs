using System;
using System.Collections.Generic;
using InputFeature.Runtime;
using InteractableFeature.Runtime;
using PickableFeature.Runtime;
using UnityEngine;

namespace PlayerFeature.Runtime
{
    public class PlayerInteraction : MonoBehaviour
    {
	    #region Public Members

	    public EventHandler<bool> m_onHoldPickable;
	    public EventHandler m_onCutIngredient;

	    #endregion
	    
	    #region Unity API

	    private void Start()
	    {
		    InputManager.m_instance.m_onTake += OnInteractionEventHandler;
		    InputManager.m_instance.m_onUse += OnUseEventHandler;
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
			    case Furniture furniture:
				    InteractWithFurniture(furniture);
				    break;
		    }
	    }

	    private void OnUseEventHandler(object sender, EventArgs e)
	    {
		    Interactable closestInteractable = GetClosestInteractable();

		    if (closestInteractable is ChoppingBoard choppingBoard)
		    {
			    UseChoppingBoard(choppingBoard);
		    }
		    // else if (closestInteractable is Sink sink)
		    // {
			   //  UseSink(sink);
		    // }
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

	    private void InteractWithFurniture(Furniture furniture)
	    {
		    if (furniture is IngredientSpawner && furniture.CurrentPickable is null && _currentPickable is null)
		    {
			    furniture.Interact(_currentPickable);
			    m_onHoldPickable?.Invoke(this, true);
		    }
		    if (furniture.CurrentPickable is not null && _currentPickable is null)
		    {
			    _currentPickable = furniture.GetPickable();
			    _currentPickable.transform.SetParent(_holdAnchor);
			    _currentPickable.transform.localPosition = Vector3.zero;
			    m_onHoldPickable?.Invoke(this, true);
		    }
		    else if (_currentPickable is not null)
		    {
			    switch (furniture.CurrentPickable)
			    {
				    case Plate plate when _currentPickable is Ingredient ingredient:
					    plate.AddIngredient(ingredient);
					    _currentPickable = null;
					    m_onHoldPickable?.Invoke(this, false);
					    break;
				    case null:
					    furniture.Interact(_currentPickable);
					    if (furniture is TrashCan && _currentPickable is Plate)
					    {
						    return;
					    }
					    _currentPickable = null;
					    m_onHoldPickable?.Invoke(this, false);
					    break;
			    }
		    }
	    }

	    private void UseChoppingBoard(ChoppingBoard choppingBoard)
	    {
		    if (!choppingBoard.ChopIngredient()) return;
		    m_onCutIngredient?.Invoke(this, EventArgs.Empty);
	    }

	    // private void UseSink(Sink sink)
	    // {
		   //  sink.
	    // }
	    
	    #endregion
	    
	    
	    #region Private and Protected Members
	    
	    [SerializeField] private Transform _holdAnchor;

	    private readonly List<Interactable> _interactablesInRange = new();
	    private Pickable _currentPickable;

	    #endregion
    }
}