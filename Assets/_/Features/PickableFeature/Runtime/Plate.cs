using System.Collections.Generic;
using _.Features.PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Plate : Dish
    {
        #region Public Members

        public List<Ingredient> IngredientCombo => _ingredientCombo;

        public float DirtyPercentage
        {
            get => _dirtyPercentage;
            set => _dirtyPercentage = value;
        }

        #endregion

        #region Unity API


        #endregion

        #region Main Methods

        public bool AddIngredient(Ingredient ingredientToAdd)
        {
            if (DirtyPercentage > 0) return false;
            
            IngredientCombo.Add(ingredientToAdd);
            ingredientToAdd.transform.SetParent(_containerAnchor);
            ingredientToAdd.transform.localPosition = new Vector3(0, (IngredientCombo.Count - 1) * 1, 0);
            return true;
        }

        public override void Empty()
        {
            if (DirtyPercentage > 0) return;
            
            for (int i = 0; i < _containerAnchor.childCount; i++)
            {
                Destroy(_containerAnchor.GetChild(i).gameObject);
            }

            IngredientCombo.Clear();
        }

        public bool IsEmpty()
        {
            return _ingredientCombo.Count == 0;
        }

        public void Wash(float amount)
        {
            if (DirtyPercentage <= 0) return;
            
            DirtyPercentage -= amount;

            if (DirtyPercentage < 0)
            {
                DirtyPercentage = 0;
            }
        }

        #endregion

        #region Private and Protected Members

        [SerializeField] private Transform _containerAnchor;

        [SerializeField] private float _dirtyPercentage;
        
        private readonly List<Ingredient> _ingredientCombo = new();

        #endregion
    }
}