using GameManagerFeature.Runtime;
using TMPro;
using UnityEngine;

namespace HUDFeature.Runtime
{
    public class TimerHUD : MonoBehaviour
    {
        #region Public Members
        

        #endregion Public Members

        #region Unity API

        private void Start()
        {
            TimeManager.m_instance.m_onTimeChanged += OnTimeChangedEventHandler;
        }

        private void OnTimeChangedEventHandler(float time)
        {
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);

            _TimerText.text = $"{minutes:00}:{seconds:00}";
        }

        #endregion Unity API

        #region Main Methods

        #endregion Main Methods

        #region Utils

        #endregion Utils

        #region Private and Protected Members

        [SerializeField] private TMP_Text _TimerText;

        #endregion Private and Protected Members
    }
}