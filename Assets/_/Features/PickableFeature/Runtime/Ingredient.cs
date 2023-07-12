using System;
using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
	public enum IngredientType
	{
		Salad,
		Tomato
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

        #endregion

    	#region Unity API

    	#endregion

    	#region Main Methods

        public void Chop()
        {
	        if (_state is not IngredientState.Raw) return;
	        
	        _chopPercentage += 0.2f;
	        m_onChopValueChanged?.Invoke(this, _chopPercentage);

	        if (_chopPercentage >= 1)
	        {
		        _state = IngredientState.Chopped;
	        }
        }

    	#endregion

    	#region Utils

    	#endregion

    	#region Private and Protected Members

        [SerializeField] private IngredientType _ingredientType;
        
        private IngredientState _state;
        
        private float _chopPercentage;

        #endregion
    }
}