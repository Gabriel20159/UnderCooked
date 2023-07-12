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

	        _state = IngredientState.Chopped;
        }

    	#endregion

    	#region Utils

    	#endregion

    	#region Private and Protected Members

        [SerializeField] private IngredientType _ingredientType;
        
        private IngredientState _state;

        #endregion
    }
}