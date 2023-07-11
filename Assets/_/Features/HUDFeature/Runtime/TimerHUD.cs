using System;
using System.Collections;
using System.Collections.Generic;
using GameManagerFeature.Runtime;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

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

            _TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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