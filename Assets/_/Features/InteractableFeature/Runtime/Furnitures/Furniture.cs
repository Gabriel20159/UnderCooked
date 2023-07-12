using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Furniture : Interactable
    {
        #region Public Members

        public Pickable CurrentPickable
        {
            get => _currentPickable;
            set => _currentPickable = value;
        }

        #endregion

        #region Unity API

        private void Awake()
        {
            _currentPickable = _containerAnchor.GetComponentInChildren<Pickable>();
        }

        #endregion

        #region Main Methods

        public override bool Interact(Pickable pickable)
        {
            if (CurrentPickable is not null || pickable is null) return false;
            
            CurrentPickable = pickable;
            pickable.transform.parent = _containerAnchor;
            pickable.transform.localPosition = Vector3.zero;
            return true;
        }

        public virtual Pickable GetPickable()
        {
            Pickable pickable = _containerAnchor.GetComponentInChildren<Pickable>();
            CurrentPickable = null;
            return pickable;
        }

        #endregion

        #region Utils

        #endregion

        #region Private and Protected Members

        [SerializeField] protected Transform _containerAnchor;

        protected Pickable _currentPickable;

        #endregion
    }
}