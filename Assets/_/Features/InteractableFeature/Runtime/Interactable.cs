using PickableFeature.Runtime;
using UnityEngine;

namespace InteractableFeature.Runtime
{
    public abstract class Interactable : MonoBehaviour
    {
    	#region Public Members

    	#endregion

    	#region Unity API

    	#endregion

    	#region Main Methods

        public abstract bool Interact(Pickable pickable);

        #endregion

        #region Utils

        #endregion

        #region Private and Protected Members

        #endregion
    }
}