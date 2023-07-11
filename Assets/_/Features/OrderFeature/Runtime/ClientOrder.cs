
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OrderFeature.Runtime
{
    [CreateAssetMenu(fileName = "ClientOrder",menuName = "ClientOrder")]
    public class ClientOrder : ScriptableObject
    {
        #region Public Members

        [SerializeField] string[] _possibleIngredientsList;
        [SerializeField] string[] _recipe;
        public float m_timeRemaining;
        
        #endregion
        
        
        #region Unity API
        
        private void OnEnable()
        {
            _possibleIngredientsList = new []{"tomato","salad"};
            _recipe = new string[2];
            
            for (var index = 0; index < _recipe.Length; index++)
            {
                int randInt = Random.Range(0, 2);
                _recipe[index] = _possibleIngredientsList[randInt];
            }
        }

        #endregion
    }
}
