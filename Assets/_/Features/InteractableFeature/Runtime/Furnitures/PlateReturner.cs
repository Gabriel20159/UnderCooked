using OrderFeature.Runtime;
using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class PlateReturner : Furniture
    {
        #region Unity API

        private void Start()
        {
            OrderManager.m_instance.m_onPlateSpawned += OnPlateSpawnedEventHandler;
        }

        #endregion

        #region Main Methods

        public override bool Interact(Pickable pickable)
        {
            return false;
        }

        public override Pickable GetPickable()
        {
            Plate[] plates = _containerAnchor.GetComponentsInChildren<Plate>();

            if (plates.Length == 0) return null;
            
            return plates[^1];
        }

        private void OnPlateSpawnedEventHandler(object sender, bool e)
        {
            AddPlate(e);
        }

        public void AddPlate(bool isDirty)
        {
            Plate plate = Instantiate(_platePrefab,
                _containerAnchor.position + Vector3.up * 0.1f * _containerAnchor.childCount,
                _containerAnchor.rotation,
                _containerAnchor)
                .GetComponent<Plate>();
            if (isDirty)
            {
                plate.DirtyPercentage = 1;
                plate.SetModelToDirty();
            }
            else
            {
                plate.DirtyPercentage = 0;
                plate.SetModelToClean();
            }
        }

        #endregion

        #region Private and Protected Members

        [SerializeField] private GameObject _platePrefab;

        #endregion
    }
}