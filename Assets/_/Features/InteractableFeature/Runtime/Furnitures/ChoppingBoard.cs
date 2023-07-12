namespace InteractableFeature.Runtime
{
    public class ChoppingBoard : Furniture
    {
        #region Public Members


        #endregion

        #region Unity API


        #endregion

        #region Main Methods

        public void ChopIngredient()
        {
            if (_currentPickable is Ingredient ingredient)
            {
                ingredient.Chop();
            }
        }

        #endregion

        #region Utils


        #endregion

        #region Private and Protected Members

        

        #endregion
    }
}