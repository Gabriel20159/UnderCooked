using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

namespace HUDFeature.Runtime
{
    public class TimerHUD : MonoBehaviour
    {
        #region Public Members

        public float m_timeRemaining = 60;

        #endregion Public Members

        #region Unity API

        void Update()
        {
            m_timeRemaining -= Time.deltaTime;


            if (m_timeRemaining <= 0)
            {
                m_timeRemaining = 0;
                Debug.Log("Temps écoulé");
            }

            float minutes = Mathf.FloorToInt(m_timeRemaining / 60);
            float seconds = Mathf.FloorToInt(m_timeRemaining % 60);

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