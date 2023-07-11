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

        public override void Interact(Pickable pickable)
        {
            base.Interact(pickable);

            if (_container.childCount != 0) return;

            Instantiate(_ingredientPrefab, _container);
        }

        #endregion

        #region Utils


        #endregion

        #region Private and Protected Members

        [SerializeField] private GameObject _ingredientPrefab;

        #endregion
    }
}