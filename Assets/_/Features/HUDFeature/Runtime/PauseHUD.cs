using UnityEngine;

namespace HUDFeature.Runtime
{
    public class PauseHUD : MonoBehaviour
    {
        #region Public Members

        #endregion Public Members

        #region Unity API

        #endregion Unity API

        #region Main Methods

        public void OnPauseEventHandler()
        {
            _PauseMenu.SetActive(!_PauseMenu.activeSelf);
        }

        #endregion Main Methods

        #region Utils

        #endregion Utils

        #region Private and Protected Members

        [SerializeField] private GameObject _PauseMenu;

        #endregion Private and Protected Members
    }
}
