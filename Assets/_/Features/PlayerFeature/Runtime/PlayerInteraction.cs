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

	    #endregion
	    
	    #region Unity API

	    private void Awake()
	    {
		    _choppingInteraction = GetComponent<PlayerChoppingBoardInteraction>();
		    _sinkInteraction = GetComponent<PlayerSinkInteraction>();
		    _inputManager = GetComponentInParent<InputManager>();
	    }

	    private void Start()
	    {
		    _inputManager.m_onTake += OnInteractionEventHandler;
		    _inputManager.m_onUseStarted += OnUseStartedEventHandler;
		    _inputManager.m_onUseCanceled += OnUseCanceledEventHandler;
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
				    TryInteractWithFurniture(furniture);
				    break;
		    }
	    }

	    private void OnUseStartedEventHandler(object sender, EventArgs e)
	    {
		    Interactable closestInteractable = GetClosestInteractable();

		    switch (closestInteractable)
		    {
			    case ChoppingBoard choppingBoard:
				    if (GetCurrentPickable() is not null) break;
				    _choppingInteraction.UseChoppingBoard(choppingBoard);
				    break;
			    case Sink sink:
				    _sinkInteraction.StartUsingSink(sink);
				    break;
		    }
	    }

	    private void OnUseCanceledEventHandler(object sender, EventArgs e)
	    {
		    _sinkInteraction.StopUsingSink();
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

	    /// <summary>
	    /// This whole method is pure garbage.
	    /// </summary>
	    /// <param name="furniture"></param>
	    private void TryInteractWithFurniture(Furniture furniture)
	    {
		    Pickable furniturePickable = furniture.GetPickable();
		    Pickable currentPickable = GetCurrentPickable();
		    if (furniture is IngredientSpawner && furniturePickable is null && currentPickable is null)
		    {
			    furniture.Interact(null);
			    furniturePickable = furniture.GetPickable();
		    }
		    if ((furniturePickable is not null && currentPickable is null))
		    {
			    GetPickableFromFurniture(furniturePickable);
			    m_onHoldPickable?.Invoke(this, true);
		    }
		    else if (currentPickable is not null)
		    {
			    UseCurrentPickableOnFurniture(currentPickable, furniturePickable, furniture);
		    }
	    }

	    private void GetPickableFromFurniture(Pickable furniturePickable)
	    {
		    furniturePickable.transform.SetParent(_holdAnchor);
		    furniturePickable.transform.localPosition = Vector3.zero;
		    furniturePickable.transform.localRotation = _holdAnchor.rotation;
		    m_onHoldPickable?.Invoke(this, true);
	    }

	    /// <summary>
	    /// This one as well.
	    /// </summary>
	    /// <param name="currentPickable"></param>
	    /// <param name="furniturePickable"></param>
	    /// <param name="furniture"></param>
	    private void UseCurrentPickableOnFurniture(Pickable currentPickable, Pickable furniturePickable, Furniture furniture)
	    {
		    switch (furniturePickable)
		    {
			    case Plate plate when currentPickable is Ingredient ingredient:
				    if (plate.AddIngredient(ingredient))
					    m_onHoldPickable?.Invoke(this, false);
				    break;
				    
			    case Plate plate when currentPickable is Saucepan pan:
				    if (!pan.HasIngredient
				        || !pan.IsCooked) return;
				    plate.AddIngredient(pan.GetSoup());
				    m_onHoldPickable?.Invoke(this, false);
				    break;
				    
			    case Saucepan pan when currentPickable is Ingredient ingredient:
				    if (pan.HasIngredient
				        || ingredient.State != IngredientState.Chopped) break;
				    pan.AddIngredient(ingredient);
				    m_onHoldPickable?.Invoke(this, false);
				    break;
				    
			    case null:
				    InteractWithFurniture(furniture, currentPickable);
				    break;
		    }
	    }

	    private void InteractWithFurniture(Furniture furniture, Pickable currentPickable)
	    {
		    bool isInteractionValidated = furniture.Interact(currentPickable);

		    if (isInteractionValidated || GetCurrentPickable() is not null)
		    {
			    m_onHoldPickable?.Invoke(this, false);
		    }
	    }

	    private Pickable GetCurrentPickable()
	    {
		    return _holdAnchor.GetComponentInChildren<Pickable>();
	    }
	    
	    #endregion

	    #region Private and Protected Members
	    
	    [SerializeField] private Transform _holdAnchor;

	    private InputManager _inputManager;

	    private readonly List<Interactable> _interactablesInRange = new();

	    private PlayerChoppingBoardInteraction _choppingInteraction;
	    private PlayerSinkInteraction _sinkInteraction;

	    #endregion
    }
}