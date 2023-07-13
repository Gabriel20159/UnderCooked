using InteractableFeature.Runtime;
using UnityEngine;

namespace OrderFeature.Runtime
{
    [CreateAssetMenu(fileName = "ClientOrder",menuName = "ClientOrder")]
    public class ClientOrder : ScriptableObject
    {
        #region Public Members

        public float TimeRemaining
        {
            get => _timeRemaining;
            set => _timeRemaining = value;
        }

        public IngredientType[] Recipe
        {
            get => _recipe;
            set => _recipe = value;
        }
        
        #endregion
        

        #region Unity API
        
        private void OnEnable()
        {
            int randomRecipe = Random.Range(0, OrderManager.m_instance.m_soupChance);
            Recipe = (randomRecipe < 1 && OrderManager.m_instance.m_canDoSoup) ? new IngredientType[1] : new IngredientType[2];
            
            for (var index = 0; index < Recipe.Length; index++)
            {
                if (Recipe.Length == 1)
                {
                    Recipe[0] = IngredientType.TomatoSoup;
                }
                else
                {
                    int randInt = Random.Range(0, 2);
                    Recipe[index] = _possibleIngredientsList[randInt];
                }
            }
        }
        
        #endregion
        
        
        #region Private and Protected
        
        [SerializeField] private IngredientType[] _recipe;

        private float _timeRemaining;

        private readonly IngredientType[] _possibleIngredientsList = { IngredientType.Tomato,IngredientType.Salad };
        
        #endregion
    }
}
