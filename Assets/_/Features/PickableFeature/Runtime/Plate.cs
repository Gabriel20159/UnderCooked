using System.Collections.Generic;
using _.Features.PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Plate : Dish
    {
        #region Public Members

        public List<Ingredient> IngredientCombo => _ingredientCombo;

        #endregion

        #region Unity API


        #endregion

        #region Main Methods

        public override void AddIngredient(Ingredient ingredientToAdd)
        {
            IngredientCombo.Add(ingredientToAdd);
            ingredientToAdd.transform.SetParent(_containerAnchor);
            ingredientToAdd.transform.localPosition = new Vector3(0, (IngredientCombo.Count - 1) * 1, 0);
        }

        public override void Empty()
        {
            for (int i = 0; i < _containerAnchor.childCount; i++)
            {
                Destroy(_containerAnchor.GetChild(i).gameObject);
            }

            IngredientCombo.Clear();
        }

        #endregion

        #region Private and Protected Members

        [SerializeField] private Transform _containerAnchor;
        
        private readonly List<Ingredient> _ingredientCombo = new();

        #endregion
    }
}