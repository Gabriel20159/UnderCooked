using PickableFeature.Runtime;
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
            
            Pickable currentPickable = GetPickable();
            if (currentPickable is not null) return true;
            
            Instantiate(_ingredientPrefab, _containerAnchor);
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