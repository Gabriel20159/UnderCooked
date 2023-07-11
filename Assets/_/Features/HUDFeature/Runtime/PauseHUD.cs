using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HUDFeature.Runtime
{
    public class PauseHUD : MonoBehaviour
    {
        #region Public Members


        #endregion Public Members

        #region Unity API

        #endregion Unity API

        #region Main Methods
        private void OnPauseEventHandler(bool state)
        {
            _PauseMenu.SetActive(state);
        }
        #endregion Main Methods

        #region Utils

        #endregion Utils

        #region Private and Protected Members

        [SerializeField] private GameObject _PauseMenu;

        #endregion Private and Protected Members
    }
}
