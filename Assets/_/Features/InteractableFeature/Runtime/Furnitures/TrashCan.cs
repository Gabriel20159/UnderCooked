using _.Features.PickableFeature.Runtime;
using PickableFeature.Runtime;

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
            switch (pickable)
            {
                case null:
                    return false;
                case Dish dish:
                    dish.Empty();
                    break;
                default:
                    Destroy(pickable.gameObject);
                    break;
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