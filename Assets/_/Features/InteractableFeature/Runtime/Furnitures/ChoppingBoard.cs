using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class ChoppingBoard : Furniture
    {
        #region Public Members


        #endregion

        #region Unity API


        #endregion

        #region Main Methods

        public override void Interact(Pickable pickable)
        {
            base.Interact(pickable);
            if (pickable is Ingredient ingredient)
            {
                ingredient.Chop();
            }
                
            // TODO Chopchopchop if time
        }

        #endregion

        #region Utils


        #endregion

        #region Private and Protected Members


        #endregion
    }
}