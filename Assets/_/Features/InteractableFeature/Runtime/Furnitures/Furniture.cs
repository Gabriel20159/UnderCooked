using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Furniture : Interactable
    {
        #region Public Members

        public Pickable m_pickable;

        #endregion

        #region Unity API


        #endregion

        #region Main Methods

        public override void Interact(Pickable pickable)
        {
            if (m_pickable is not null) return;
                
            m_pickable = pickable;
            pickable.transform.parent = _container;
            pickable.transform.localPosition = Vector3.zero;
        }

        public Pickable GetPickable()
        {
            return _container.GetComponentInChildren<Pickable>();
        }

        #endregion

        #region Utils

        #endregion

        #region Private and Protected Members

        [SerializeField] protected Transform _container;

        #endregion
    }
}