using System;
using System.Collections;
using System.Collections.Generic;
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
            if (m_instance is not null)
            {
                Destroy(gameObject);
                return;
            }

            m_instance = this;
        }

        #endregion
        #region Main Methods

        public void UpdateStarCount(int score)
        {
            if (score >= _thirdThreshold)
                _starCount = 3;
            else if (score >= _secondThreshold)
                _starCount = 2;
            else if (score >= _firstThreshold)
                _starCount = 1;
            else
                _starCount = 0;

            OnStarCountChanged?.Invoke(_starCount);
        }

        #endregion

        #region Utils
        #endregion

        #region Private and Protected Members

        private int _starCount = 0;

        #endregion


    }
}
