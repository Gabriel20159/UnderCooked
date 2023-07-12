using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagerFeature.Runtime
{
    public class ScoreManager : MonoBehaviour
    {

        #region Public Members

        public static ScoreManager m_instance;

        public event Action<int> OnScoreChanged;

        public int Score { get { return _score; } }

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

        #endregion
        
        #region Main Methods

        public void AddScore(int amount)
        {
           _score += amount;
            OnScoreChanged?.Invoke(_score);
        }

        public void SubtractScore(int amount)
        {
            _score -= amount;
            OnScoreChanged?.Invoke(_score);
        }

        #endregion

        #region Utils
        #endregion

        #region Private and Protected Members

        private int _score = 0;

    #endregion


    }
}
