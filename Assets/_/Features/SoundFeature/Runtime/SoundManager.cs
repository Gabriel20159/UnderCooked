using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundFeature.Runtime
{
    public class SoundManager : MonoBehaviour
    {

    #region Public Members

        public static SoundManager m_instance;
        #endregion

        #region Unity API

        private void Awake()
        {
            m_instance = this;
        }

        #endregion
        #region Main Methods

        private void PlayCutSound()
        {
            _audioSource.clip = _cutSound;
            _audioSource.Play();
        }

        private void PlayLoserSound()
        {
            _audioSource.clip = _loserSound;
            _audioSource.Play();
        }

        private void PlayRunningSound()
        {
            _audioSource.clip = _runningSound;
            _audioSource.Play();
        }

        private void PlayYeahboySound()
        {
            _audioSource.clip = _yeahboySound;
            _audioSource.Play();
        }

        private void PlaySuccessSound()
        {
            _audioSource.clip = _successSound;
            _audioSource.Play();
        }

        private void PlayBackgroundMusicSound()
        {
            _audioSource.clip = _backgroundMusicSound;
            _audioSource.Play();
        }

        private void PlayPlateOnTableSound()
        {
            _audioSource.clip = _plateOnTableSound;
            _audioSource.Play();
        }
        private void PlayNewTicketSound()
        {
            _audioSource.clip = _newTicketSound;
            _audioSource.Play();
        }

        #endregion

        #region Utils
        #endregion

        #region Private and Protected Members

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _cutSound;

        [SerializeField]
        private AudioClip _loserSound;

        [SerializeField]
        private AudioClip _runningSound;

        [SerializeField]
        private AudioClip _yeahboySound;

        [SerializeField]
        private AudioClip _successSound;

        [SerializeField]
        private AudioClip _backgroundMusicSound;

        [SerializeField]
        private AudioClip _plateOnTableSound;

        [SerializeField]
        private AudioClip _newTicketSound;



        #endregion


    }
}
