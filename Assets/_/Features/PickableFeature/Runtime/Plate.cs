using System;
using System.Collections.Generic;
using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Plate : Pickable
    {
        #region Public Members

        private EventHandler<float> m_onDirtyValueChanged;

        public List<Ingredient> IngredientCombo => _ingredientCombo;

        #endregion

        #region Unity API


        #endregion

        #region Main Methods

        public void AddIngredient(Ingredient ingredientToAdd)
        {
            if (_dirtyPercentage > 0) return;
            
            IngredientCombo.Add(ingredientToAdd);
            ingredientToAdd.transform.SetParent(_containerAnchor);
            ingredientToAdd.transform.localPosition = new Vector3(0, (IngredientCombo.Count - 1) * 1, 0);
        }

        public void Empty()
        {
            if (_dirtyPercentage > 0) return;
            
            for (int i = 0; i < _containerAnchor.childCount; i++)
            {
                Destroy(_containerAnchor.GetChild(i).gameObject);
            }

            IngredientCombo.Clear();
        }

        public void Wash()
        {
            if (_dirtyPercentage <= 0) return;
            
            _dirtyPercentage -= 0.2f;

            if (_dirtyPercentage < 0)
            {
                _dirtyPercentage = 0;
            }
            
            m_onDirtyValueChanged
        }

        #endregion

        #region Private and Protected Members

        [SerializeField] private Transform _containerAnchor;
        
        private readonly List<Ingredient> _ingredientCombo = new();

        private float _dirtyPercentage;

        #endregion
    }
}