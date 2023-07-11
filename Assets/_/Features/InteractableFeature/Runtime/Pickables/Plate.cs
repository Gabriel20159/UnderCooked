using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Plate : Dish
    {
        #region Public Members


        #endregion

        #region Unity API


        #endregion

        #region Main Methods

        private void AddIngredient(Ingredient ingredient)
        {
            
        }

        public void Empty()
        {
            foreach (var ingredientAnchor in _ingredientAnchors)
            {
                if (ingredientAnchor is null) continue;
                Destroy(ingredientAnchor.GetChild(0).gameObject);
            }

            for (var i = 0; i < _ingredientCombo.Length; i++)
            {
                _ingredientCombo[i] = null;
            }
        }

        #endregion

        #region Utils


        #endregion

        #region Private and Protected Members

        [SerializeField] private Transform[] _ingredientAnchors = new Transform[2];
        
        private readonly Ingredient[] _ingredientCombo = new Ingredient[2];

        #endregion
    }
}