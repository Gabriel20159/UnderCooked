using GameManagerFeature.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HUDFeature.Runtime
{
    public class EndScreen : MonoBehaviour
    {
        private void Start()
        {
            TimeManager.m_instance.m_onTimeUp += ShowEndScreen;
        }

        private void ShowEndScreen()
        {
            foreach (var t in _inGameHUD)
            {
                t.SetActive(false);
            }
            
            _endScreen.SetActive(true);
            for (int i = 0; i < StarsManager.m_instance.StarCount; i++)
            {
                _stars[i].SetActive(true);
            }
        }

        public void GetNextScene()
        {
            int index = SceneManager.GetActiveScene().buildIndex + 1;
            if (index > 2)
            {
                index = 0;
            }

            SceneManager.LoadScene(index);
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }

        [SerializeField] private GameObject[] _inGameHUD;
        [SerializeField] private GameObject _endScreen;
        [SerializeField] private GameObject[] _stars;
    }
}