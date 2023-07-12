using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MenuFeature.Runtime
{
    public class MainMenu : MonoBehaviour
    {
        #region Public Members
        #endregion


        #region Main Methods

        public void LoadFirstLevel()
        {
            SceneManager.LoadScene(1);
        }

        public void SetMasterVolume()
        {
            _master.audioMixer.SetFloat("MasterVolume", _masterSlider.value * 20f );
        }
        
        public void SetSFXVolume()
        {
            _SFXMaster.volume = _SFXSlider.value;
        }
        
        public void SetBGMVolume()
        {
            _BGMMaster.volume = _BGMSlider.value;
        }
        #endregion


        #region Private and Protected

        [SerializeField] private AudioMixerGroup _master;
        [SerializeField] private Slider _masterSlider;
        [SerializeField] private AudioSource _SFXMaster;
        [SerializeField] private Slider _SFXSlider;
        [SerializeField] private AudioSource _BGMMaster;
        [SerializeField] private Slider _BGMSlider;

        #endregion
    }
}
