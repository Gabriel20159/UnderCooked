﻿using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class IngredientSpawner : Furniture
    {
        #region Public Members


        #endregion

        #region Unity API


        #endregion

        #region Main Methods

        public override bool Interact(Pickable pickable)
        {
            base.Interact(pickable);
            
            if (_containerAnchor.childCount != 0) return false;
            
            CurrentPickable = Instantiate(_ingredientPrefab, _containerAnchor).GetComponent<Ingredient>();
            return true;
        }

        #endregion

        #region Utils


        #endregion

        #region Private and Protected Members

        [SerializeField] private GameObject _ingredientPrefab;

        #endregion
    }
}