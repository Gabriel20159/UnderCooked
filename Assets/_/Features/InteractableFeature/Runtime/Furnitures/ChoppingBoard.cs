namespace InteractableFeature.Runtime
{
    public class ChoppingBoard : Furniture
    {
        #region Public Members


        #endregion

        #region Unity API


        #endregion

        #region Main Methods

        public bool ChopIngredient()
        {
            return GetPickable() is Ingredient ingredient && ingredient.Chop();
        }

        #endregion

        #region Utils


        #endregion

        #region Private and Protected Members

        

        #endregion
    }
}