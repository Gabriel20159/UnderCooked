using System.Collections.Generic;
using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Sink : Furniture
    {
        #region Public Members

        #endregion
        

        #region Unity API

        private void Update()
        {
            HandleCleaning();
        }

        #endregion
        
        
        #region Main Methods

        public override bool Interact(Pickable pickable)
        {
            if (pickable is not Plate plate) return false;
            
            if (plate.DirtyPercentage > 0)
            {
                _dirtyPlates.Add(plate);
                pickable.transform.SetParent(_containerAnchor);
                pickable.transform.localPosition = Vector3.zero;
            }

            return true;
        }

        public void StartCleaning()
        {
            if (_dirtyPlates.Count == 0) return;

            _isCleaning = true;
        }

        public void StopCleaning()
        {
            _isCleaning = false;
        }

        private void HandleCleaning()
        {
            if (!_isCleaning) return;
            
            if (_dirtyPlates.Count == 0)
            {
                _isCleaning = false;
                return;
            }

            Plate currentPlate = _dirtyPlates[0];
            currentPlate.Wash( 1 / _timeToClean * Time.deltaTime);
            if (currentPlate.DirtyPercentage == 0)
            {
                StopCleaning();
                _dirtyPlates.Remove(currentPlate);
                _cleanPlates.Add(currentPlate);
                currentPlate.transform.SetParent(_cleanPlatesAnchor);
                currentPlate.transform.localPosition = Vector3.zero;
            }
        }

        public override Pickable GetPickable()
        {
            if (_cleanPlates.Count == 0) return null;
            
            Plate currentPlate = _cleanPlates[^1];
            _cleanPlates.Remove(currentPlate);
            
            return currentPlate;
        }

        #endregion
        

        #region Utils
        
        #endregion
        

        #region Private and Protected Members

        // The anchor for dirty plates is _containerAnchor
        [SerializeField] private Transform _cleanPlatesAnchor;

        [SerializeField] private float _timeToClean;

        private List<Plate> _dirtyPlates = new();
        private List<Plate> _cleanPlates = new();
        
        private bool _isCleaning;

        #endregion
    }
}