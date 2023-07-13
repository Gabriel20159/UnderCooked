using System;
using UnityEngine;

namespace GameManagerFeature.Runtime
{
    public class StarsManager : MonoBehaviour
    {

        #region Public Members

        public static StarsManager m_instance;

        public event Action<int> OnStarCountChanged;

        public int StarCount { get { return _starCount; } }

        [SerializeField]
        private int _firstThreshold;
        [SerializeField]
        private int _secondThreshold;
        [SerializeField]
        private int _thirdThreshold;

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
            ScoreManager.m_instance.OnScoreChanged += OnScoreChangeEvent;
        }

        #endregion
        #region Main Methods

        private void OnScoreChangeEvent(int value)
        {
            UpdateStarCount(value);
        }
        
        private void UpdateStarCount(int score)
        {
            if (score >= _thirdThreshold)
                _starCount = 3;
            else if (score >= _secondThreshold)
                _starCount = 2;
            else if (score >= _firstThreshold)
                _starCount = 1;
            else
                _starCount = 0;
        }

        #endregion


        #region Private and Protected Members

        private int _starCount;

        #endregion


    }
}
