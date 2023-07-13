using System;
using _.Features.PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Saucepan : Dish
    {
        #region Public Members

        public EventHandler<float> m_onCookValueChanged;

        public bool IsCooked
        {
            get => _isCooked;
            set => _isCooked = value;
        }

        public bool HasIngredient
        {
            get => _hasIngredient;
            set => _hasIngredient = value;
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

        public override bool AddIngredient(Ingredient ingredientToAdd)
        {
            if (HasIngredient
                || ingredientToAdd.Type != IngredientType.Tomato
                || ingredientToAdd.State != IngredientState.Chopped) return false;

            Fill(ingredientToAdd);
            return true;
        }

        public override void Empty()
        {
            if (!HasIngredient) return;
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
            HasIngredient = true;
            Destroy(ingredientToAdd.gameObject);
            _sauce.SetActive(true);
        }
        
        private void Clear()
        {
            HasIngredient = false;
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

        private bool _isCooked;

        private float _cookPercentage;
        
        private bool _hasIngredient;

        private MeshRenderer _meshRenderer;

        #endregion
    }
}