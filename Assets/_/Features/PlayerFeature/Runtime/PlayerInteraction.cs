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
	    #region Unity API

	    private void Awake()
	    {
		    _choppingInteraction = GetComponent<PlayerChoppingBoardInteraction>();
		    _sinkInteraction = GetComponent<PlayerSinkInteraction>();
	    }

	    private void Start()
	    {
		    InputManager.m_instance.m_onTake += OnInteractionEventHandler;
		    InputManager.m_instance.m_onUseStarted += OnUseStartedEventHandler;
		    InputManager.m_instance.m_onUseCanceled += OnUseCanceledEventHandler;
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

	    private void OnUseStartedEventHandler(object sender, EventArgs e)
	    {
		    Interactable closestInteractable = GetClosestInteractable();

		    if (closestInteractable is ChoppingBoard choppingBoard)
		    {
			    _choppingInteraction.UseChoppingBoard(choppingBoard);
		    }
		    else if (closestInteractable is Sink sink)
		    {
			    _sinkInteraction.StartUsingSink(sink);
			    _currentSink = sink;
		    }
	    }

	    private void OnUseCanceledEventHandler(object sender, EventArgs e)
	    {
		    _sinkInteraction.StopUsingSink(_currentSink);
		    _currentSink = null;
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
		    }
		    if ((furniture.CurrentPickable is not null && _currentPickable is null) || (furniture is Sink && _currentPickable is null))
		    {
			    _currentPickable = furniture.GetPickable();
			    _currentPickable.transform.SetParent(_holdAnchor);
			    _currentPickable.transform.localPosition = Vector3.zero;
		    }
		    else if (_currentPickable is not null)
		    {
			    switch (furniture.CurrentPickable)
			    {
				    case Plate plate when _currentPickable is Ingredient ingredient:
					    if (plate.AddIngredient(ingredient))
					    {
						    _currentPickable = null;
					    }
					    break;
				    case null:
					    if (furniture is Sink && _currentPickable is not Plate)
					    {
						    return;
					    }
					    bool destroyCurrentPickable = furniture.Interact(_currentPickable);
					    if (furniture is TrashCan && _currentPickable is Plate)
					    {
						    return;
					    }

					    if (destroyCurrentPickable)
					    {
						    _currentPickable = null;
					    }
					    break;
			    }
		    }
	    }
	    
	    #endregion
	    
	    
	    #region Private and Protected Members
	    
	    [SerializeField] private Transform _holdAnchor;

	    private readonly List<Interactable> _interactablesInRange = new();
	    private Pickable _currentPickable;

	    private Sink _currentSink;

	    private PlayerChoppingBoardInteraction _choppingInteraction;
	    private PlayerSinkInteraction _sinkInteraction;

	    #endregion
    }
}