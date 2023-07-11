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

    	#endregion

    	#region Unity API

    	#endregion

    	#region Main Methods

        public void Chop()
        {
	        if (_state is not IngredientState.Raw) return;

	        _chopPercentage += 0.2f;

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

        private float _chopPercentage;
        
        private IngredientState _state;

        #endregion
    }
}