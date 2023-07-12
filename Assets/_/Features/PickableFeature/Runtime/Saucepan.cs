using System;
using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Saucepan : Pickable
    {
        #region Public Members

        public EventHandler<float> m_onCookValueChanged;
        
        public Ingredient Ingredient
        {
            get => _ingredient;
            set => _ingredient = value;
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

        public void AddIngredient(Ingredient ingredientToAdd)
        {
            if (Ingredient != null && ingredientToAdd.Type != IngredientType.Tomato) return;
            Fill(ingredientToAdd);
        }

        public void Empty()
        {
            if (Ingredient is null) return;
            Clear();
        }

        public void Cook()
        {
            _cookPercentage += Time.deltaTime / _timeToCook;
            m_onCookValueChanged?.Invoke(this, _cookPercentage);

            if (_cookPercentage >= 1 + _cookPercentage * _timeToCook / _timeToBurn)
            {
                Burn();
            }
            else if (_cookPercentage >= 1)
            {
                _isCooked = true;
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
            _sauce.SetActive(false);
        }

        private void Burn()
        {
            _isCooked = false;
            _meshRenderer.material.color = _burnedColor;
        }
        
        #endregion

        
        #region Private and Protected Members

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