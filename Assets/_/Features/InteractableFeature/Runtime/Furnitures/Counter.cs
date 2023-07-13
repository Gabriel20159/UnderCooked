using OrderFeature.Runtime;
using PickableFeature.Runtime;

namespace InteractableFeature.Runtime
{
    public class Counter : Furniture
    {
        #region Public Members


        #endregion

        #region Unity API


        #endregion

        #region Main Methods

        public override bool Interact(Pickable pickable)
        {
            if (pickable is not Plate plate || plate.IsEmpty()) return false;
            
            OrderManager.m_instance.CheckPlate(plate);
            return true;

        }

        #endregion

        #region Utils


        #endregion

        #region Private and Protected Members


        #endregion
    }
}