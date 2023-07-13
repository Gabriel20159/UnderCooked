namespace InteractableFeature.Runtime
{
    public class Stove : Furniture
    {
    	#region Public Members

    	#endregion


    	#region Unity API

    	#endregion


    	#region Main Methods

        private void Update()
        {
            if (GetPickable() is not Saucepan saucepan
                || !saucepan.HasIngredient) return;
            saucepan.Cook();
        }

    	#endregion


    	#region Utils

    	#endregion


    	#region Private and Protected Members

    	#endregion
    }
}
