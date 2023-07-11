using UnityEngine;
using TMPro;

namespace GameManagerFeature.Runtime
{
    public class ScoreAndTimeDisplay : MonoBehaviour
    {

        #region Public Members

        public ScoreManager scoreManager;
        public TimeManager timeManager;

        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI timeText;

        #endregion

        #region Unity API
        private void Start()
        {
            scoreManager.OnScoreChanged += UpdateScoreDisplay;
            timeManager.m_onTimeUp += UpdateTimeDisplay;
        }

        private void Update()
        {
            UpdateTimeDisplay();
        }
        #endregion
        #region Main Methods

        private void UpdateScoreDisplay(int newScore)
        {
            scoreText.text = "Score: " + newScore.ToString();
        }

        private void UpdateTimeDisplay()
        {
            float timeLeft = timeManager.TimeLeft;
            int minutes = Mathf.FloorToInt(timeLeft / 60F);
            int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
            // timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            timeText.text = $"{minutes:00}:{seconds:00}";
        }

        #endregion

        #region Utils
        #endregion

        #region Private and Protected Members
        #endregion


    }
}
