using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class TrashCan : Furniture
    {
        #region Public Members


        #endregion

        #region Unity API


        #endregion

        #region Main Methods

        public override bool Interact(Pickable pickable)
        {
            if (pickable is null) return false;
            
            if (pickable is Plate plate)
            {
                plate.Empty();
            }
            else
            {
                Destroy(pickable.gameObject);
            }

            return true;
        }

        #endregion

        #region Utils


        #endregion

        #region Private and Protected Members


        #endregion
    }
}