using System;
using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
	public enum IngredientType
	{
		Salad,
		Tomato,
		TomatoSoup
	}
	
	public enum IngredientState
	{
		Raw,
		Chopped
	}
	
    public class Ingredient : Pickable
    {
    	#region Public Members

        public EventHandler<float> m_onChopValueChanged;

        public IngredientType Type
        {
	        get => _ingredientType;
	        set => _ingredientType = value;
        }

        public IngredientState State
        {
	        get => _state;
	        set => _state = value;
        }

        #endregion

    	#region Unity API

    	#endregion

    	#region Main Methods

        public bool Chop()
        {
	        if (_state is not IngredientState.Raw) return false;
	        
	        _chopPercentage += 0.2f;
	        m_onChopValueChanged?.Invoke(this, _chopPercentage);

	        if (_chopPercentage >= 1)
	        {
		        State = IngredientState.Chopped;
		        _meshFilter.mesh = _meshChopped;
	        }
	        return true;
        }

    	#endregion

    	#region Utils

    	#endregion

    	#region Private and Protected Members

        [SerializeField] private IngredientType _ingredientType;
        
        [Space]
        [SerializeField] private MeshFilter _meshFilter;
        [SerializeField] private Mesh _meshChopped;
        
        private IngredientState _state;
        
        private float _chopPercentage;

        #endregion
    }
}