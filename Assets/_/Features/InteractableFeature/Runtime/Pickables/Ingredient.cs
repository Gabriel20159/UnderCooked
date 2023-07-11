using System;
using UnityEngine;
using UnityEngine.Serialization;

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
        
        [HideInInspector] public float m_chopPercentage;

    	#endregion

    	#region Unity API

    	#endregion

    	#region Main Methods

        public void Chop()
        {
	        if (_state is not IngredientState.Raw) return;

	        _gauge.gameObject.SetActive(true);
	        m_chopPercentage += 0.2f;
	        m_onChopValueChanged?.Invoke(this, m_chopPercentage);

	        if (m_chopPercentage >= 1)
	        {
		        _state = IngredientState.Chopped;
		        _gauge.SetActive(false);
	        }
        }

    	#endregion

    	#region Utils

    	#endregion

    	#region Private and Protected Members

        [SerializeField] private IngredientType _ingredientType;
        [FormerlySerializedAs("_canvas")] [SerializeField] private GameObject _gauge;
        
        private IngredientState _state;

        #endregion
    }
}