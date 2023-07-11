using System;
using Codice.CM.Common;
using UnityEngine;
using UnityEngine.Serialization;

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

        public override void Interact(Pickable pickable)
        {
            if (CurrentPickable is not null) return;
                
            CurrentPickable = pickable;
            pickable.transform.parent = _containerAnchor;
            pickable.transform.localPosition = Vector3.zero;
        }

        public Pickable GetPickable()
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

        private Pickable _currentPickable;

        #endregion
    }
}