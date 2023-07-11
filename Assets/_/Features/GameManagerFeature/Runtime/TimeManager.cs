using System;
using UnityEngine;

namespace GameManagerFeature.Runtime
{
    public class TimeManager : MonoBehaviour
    {

        #region Public Members

        public static TimeManager m_instance;

        public event Action m_onTimeUp;

        public float m_gameTime = 180f;

        public float TimeLeft { get => _timeLeft; }

        #endregion

        #region Unity API

        private void Awake()
        {
            if (m_instance is not null)
            {
                Destroy(gameObject);
                return;
            }

            m_instance = this;
        }

        private void Start()
        {
            _timeLeft = m_gameTime;
        }

        private void Update()
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                if (_timeLeft <= 0)
                {
                    m_onTimeUp?.Invoke();
                }
            }
        }

        #endregion
        #region Main Methods

        #endregion

        #region Utils
        #endregion

        #region Private and Protected Members

        private float _timeLeft;

        #endregion


    }
}
