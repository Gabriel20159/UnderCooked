using System;
using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Sink : Furniture
    {
        
        public EventHandler<float> m_onDirtyValueChanged;
        public EventHandler m_onNewPlate;
        
        #region Unity API

        private void Update()
        {
            HandleCleaning();
        }

        #endregion

        #region Main Methods

        public override bool Interact(Pickable pickable)
        {
            if (pickable is not Plate plate || plate.DirtyPercentage <= 0) return false;
            
            pickable.transform.SetParent(_containerAnchor);
            pickable.transform.localPosition = Vector3.up * 0.1f * (_containerAnchor.childCount - 1);
            m_onNewPlate?.Invoke(null, null);
            return true;

        }

        public void StartCleaning()
        {
            if (GetTopDirtyPlate() is null) return;

            _isCleaning = true;
        }

        public void StopCleaning()
        {
            _isCleaning = false;
        }

        private void HandleCleaning()
        {
            if (!_isCleaning) return;

            Plate currentPlate = GetTopDirtyPlate();
            
            if (currentPlate is null)
            {
                _isCleaning = false;
                return;
            }
            
            currentPlate.Wash( 1 / _timeToClean * Time.deltaTime);
            
            m_onDirtyValueChanged?.Invoke(this, currentPlate.DirtyPercentage);
            
            if (currentPlate.DirtyPercentage != 0) return;
            
            StopCleaning();
            currentPlate.transform.SetParent(_cleanPlatesAnchor);
            currentPlate.transform.localPosition = Vector3.up * 0.1f * (_cleanPlatesAnchor.childCount - 1);
        }

        public override Pickable GetPickable()
        {
            Plate[] plates = _cleanPlatesAnchor.GetComponentsInChildren<Plate>();

            if (plates.Length == 0) return null;
            
            return plates[^1];
        }

        private Plate GetTopDirtyPlate()
        {
            Plate[] plates = _containerAnchor.GetComponentsInChildren<Plate>();

            if (plates.Length == 0) return null;
            
            return plates[^1];
        }

        #endregion

        #region Private and Protected Members

        // The anchor for dirty plates is _containerAnchor
        [SerializeField] private Transform _cleanPlatesAnchor;

        [SerializeField] private float _timeToClean;
        
        private bool _isCleaning;

        #endregion
    }
}