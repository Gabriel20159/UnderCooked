using System;
using _.Features.PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Saucepan : Dish
    {
        #region Public Members

        public EventHandler<float> m_onCookValueChanged;
        
        public Ingredient Ingredient
        {
            get => _ingredient;
            set => _ingredient = value;
        }

        public bool IsCooked
        {
            get => _isCooked;
            set => _isCooked = value;
        }

        #endregion
        

        #region Main Methods

        private void Awake()
        {
            _meshRenderer = _sauce.GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            _meshRenderer.material.color = _sauceColor;
        }

        public override void AddIngredient(Ingredient ingredientToAdd)
        {
            if (Ingredient == null && ingredientToAdd.Type != IngredientType.Tomato) return;
            if (ingredientToAdd.State != IngredientState.Chopped) return;

            Fill(ingredientToAdd);
        }

        public override void Empty()
        {
            if (Ingredient is null) return;
            Clear();
        }

        public void Cook()
        {
            _cookPercentage += Time.deltaTime / _timeToCook;
            m_onCookValueChanged?.Invoke(this, _cookPercentage);

            if (_cookPercentage >= 1 + 0.5f)
            {
                Burn();
            }
            else if (_cookPercentage >= 1)
            {
                IsCooked = true;
            }
        }

        private void Fill(Ingredient ingredientToAdd)
        {
            Ingredient = ingredientToAdd;
            Destroy(Ingredient.gameObject);
            _sauce.SetActive(true);
        }
        
        private void Clear()
        {
            Ingredient = null;
            _cookPercentage = 0;
            _meshRenderer.material.color = _sauceColor;
            m_onCookValueChanged?.Invoke(this, _cookPercentage);
            _sauce.SetActive(false);
        }

        private void Burn()
        {
            IsCooked = false;
            _meshRenderer.material.color = _burnedColor;
        }

        public Ingredient GetSoup()
        {
            Clear();
            return Instantiate(_soupPrefab).GetComponent<Ingredient>();
        }
        
        #endregion

        
        #region Private and Protected Members
        
        [SerializeField] private GameObject _soupPrefab; 

        [SerializeField] private GameObject _sauce;
        [SerializeField] private Color _sauceColor;
        [SerializeField] private Color _burnedColor;
        
        [Tooltip("In seconds")]
        [SerializeField] private float _timeToCook;
        [Tooltip("In seconds")]
        [SerializeField] private float _timeToBurn;

        private bool _isCooked;

        private float _cookPercentage;
        
        private Ingredient _ingredient;

        private MeshRenderer _meshRenderer;

        #endregion
    }
}