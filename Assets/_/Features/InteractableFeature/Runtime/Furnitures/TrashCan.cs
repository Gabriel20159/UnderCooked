using _.Features.PickableFeature.Runtime;
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

        public override void Interact(Pickable pickable)
        {
            if (pickable is null) return;
            
            if (pickable is Dish dish)
            {
                dish.Empty();
            }
            else
            {
                Destroy(pickable.gameObject);
            }
        }

        #endregion

        #region Utils


        #endregion

        #region Private and Protected Members


        #endregion
    }
}