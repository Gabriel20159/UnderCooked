using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Furniture : Interactable
    {
        #region Public Members

        #endregion

        #region Unity API

        #endregion

        #region Main Methods

        public override bool Interact(Pickable pickable)
        {
            Pickable currentPickable = GetPickable();
            if (currentPickable is not null || pickable is null) return false;
            
            pickable.transform.parent = _containerAnchor;
            pickable.transform.localPosition = Vector3.zero;
            pickable.transform.localRotation = _containerAnchor.rotation;
            return true;
        }

        public virtual Pickable GetPickable()
        {
            return _containerAnchor.GetComponentInChildren<Pickable>();
        }

        #endregion

        #region Utils

        #endregion

        #region Private and Protected Members

        [SerializeField] protected Transform _containerAnchor;

        #endregion
    }
}