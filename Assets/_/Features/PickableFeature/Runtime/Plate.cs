using System;
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
            set
            {
                _dirtyPercentage = value;
                if (_dirtyPercentage < 0)
                {
                    _dirtyPercentage = 0;
                }
            }
        }

        #endregion

        #region Main Methods

        public override bool AddIngredient(Ingredient ingredientToAdd)
        {
            if (DirtyPercentage > 0 || ingredientToAdd.State is IngredientState.Raw) return false;
            
            IngredientCombo.Add(ingredientToAdd);
            ingredientToAdd.transform.SetParent(_containerAnchor);
            ingredientToAdd.transform.localPosition = new Vector3(0, (IngredientCombo.Count - 1) * 1, 0);
            ingredientToAdd.transform.localRotation = Quaternion.identity;
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
            if (DirtyPercentage == 0) return;
            
            DirtyPercentage -= amount;
            

            
            if (DirtyPercentage == 0)
            {
                SetModelToClean();
            }
        }

        public void SetModelToDirty()
        {
            _cleanModel.SetActive(false);
            _dirtyModel.SetActive(true);
        }

        public void SetModelToClean()
        {
            _cleanModel.SetActive(true);
            _dirtyModel.SetActive(false);
        }

        #endregion

        #region Private and Protected Members

        [SerializeField] private Transform _containerAnchor;

        [SerializeField] private float _dirtyPercentage;

        [SerializeField] private GameObject _cleanModel; 
        [SerializeField] private GameObject _dirtyModel; 
        
        private readonly List<Ingredient> _ingredientCombo = new();

        #endregion
    }
}