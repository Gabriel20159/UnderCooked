using InteractableFeature.Runtime;
using UnityEngine;

namespace PlayerFeature.Runtime
{
    public class PlayerChoppingBoardInteraction : MonoBehaviour
    {
        #region Public Members


        #endregion

        #region Unity API


        #endregion

        #region Main Methods

        public void UseChoppingBoard(ChoppingBoard choppingBoard)
        {
            choppingBoard.ChopIngredient();
        }

        #endregion

        #region Utils


        #endregion

        #region Private and Protected Members


        #endregion
    }
}