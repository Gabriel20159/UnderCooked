using System;
using UnityEngine;

namespace GameManagerFeature.Runtime
{
    public class TimeManager : MonoBehaviour
    {

        #region Public Members

        public static TimeManager m_instance;

        public event Action m_onTimeUp;
        public event Action<float> m_onTimeChanged;

        public float m_gameTime = 180f;

        public float TimeLeft { get => _timeLeft; }

        #endregion

        #region Unity API

        private void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _timeLeft = m_gameTime;
        }

        private void Update()
        {
            if (!(_timeLeft > 0)) return;
            
            _timeLeft -= Time.deltaTime;
            m_onTimeChanged?.Invoke(_timeLeft);
            if (_timeLeft <= 0)
            {
                m_onTimeUp?.Invoke();
            }
        }

        #endregion
        

        #region Private and Protected Members

        private float _timeLeft;

        #endregion


    }
}
