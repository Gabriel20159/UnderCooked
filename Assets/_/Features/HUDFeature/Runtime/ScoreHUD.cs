using GameManagerFeature.Runtime;
using TMPro;
using UnityEngine;

namespace HUDFeature.Runtime
{
    public class ScoreHUD : MonoBehaviour
    {
        #region Public Members

        #endregion Public Members

        #region Unity API

        private void Start()
        {
            ScoreManager.m_instance.OnScoreChanged += OnScoreChangeEventHandler;
        }

        #endregion Unity API

        #region Main Methods

        private void OnScoreChangeEventHandler(int value)
        {
            _scoreText.text = value.ToString();
        }

        #endregion Main Methods

        #region Utils

        #endregion Utils

        #region Private and Protected Members

        [SerializeField]
        private TMP_Text _scoreText;

        #endregion Private and Protected Members
    }
}