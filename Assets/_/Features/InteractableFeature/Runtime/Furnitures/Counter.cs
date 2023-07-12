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

        public override void Interact(Pickable pickable)
        {
            if (pickable is Plate plate)
            {
                OrderManager.m_instance.CheckPlate(plate);
            }
        }

        #endregion

        #region Utils


        #endregion

        #region Private and Protected Members


        #endregion
    }
}