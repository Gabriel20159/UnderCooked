using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuFeature.Runtime
{
    public class PauseMenu : MonoBehaviour
    {
        #region Public Members
        #endregion


        #region Main Methods

        private void Update()
        {
            if (_isPaused)
            {
                Time.timeScale = 0f;
                _pausePanel.SetActive(true);
                _isPaused = true;
            }
            else
            {
                Time.timeScale = 1f;
                _pausePanel.SetActive(false);
                _isPaused = false;
            }
            
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                _isPaused = !_isPaused;
            }
        }

        public void Resume()
        {
            _isPaused = false;
        }

        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void Quit()
        {
            Application.Quit();
        }
        #endregion


        #region Private and Protected

        private bool _isPaused;

        [SerializeField] private GameObject _pausePanel;

        #endregion
    }
}
