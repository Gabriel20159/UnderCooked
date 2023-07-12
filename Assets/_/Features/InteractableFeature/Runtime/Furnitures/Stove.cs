using System;
using System.Collections;
using System.Collections.Generic;
using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public class Stove : Furniture
    {
    	#region Public Members

    	#endregion


    	#region Unity API

    	#endregion


    	#region Main Methods

        void Update()
        {
            if (_currentPickable is not Saucepan saucepan) return;
            if (!saucepan.HasIngredient) return;
            saucepan.Cook();
        }

    	#endregion


    	#region Utils

    	#endregion


    	#region Private and Protected Members

    	#endregion
    }
}
