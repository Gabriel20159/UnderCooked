using System;
using InteractableFeature.Runtime;
using UnityEngine;

namespace PlayerFeature.Runtime
{
    public class PlayerChoppingBoardInteraction : MonoBehaviour
    {
        #region Public Members
        
        public EventHandler m_onCutIngredient;

        #endregion

        #region Main Methods

        public void UseChoppingBoard(ChoppingBoard choppingBoard)
        {
            if (!choppingBoard.ChopIngredient()) return;
            
            m_onCutIngredient?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}