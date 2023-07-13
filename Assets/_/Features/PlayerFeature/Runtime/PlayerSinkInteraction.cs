using InteractableFeature.Runtime;
using UnityEngine;

namespace PlayerFeature.Runtime
{
    public class PlayerSinkInteraction : MonoBehaviour
    {
        #region Public Members

        public bool IsUsingSink
        {
            get => _isUsingSink;
            set => _isUsingSink = value;
        }

        #endregion

        #region Main Methods

        private void Awake()
        {
            _playerMovements = GetComponentInParent<PlayerMovements>();
            _playerDash = GetComponentInParent<PlayerDash>();
        }

        public void StartUsingSink(Sink sink)
        {
            if (_isUsingSink || sink is null) return;
            
            sink.StartCleaning();
            // Start Washing Animation
            IsUsingSink = true;
            _currentSink = sink;
            _playerMovements.enabled = false;
            _playerDash.enabled = false;
        }

        public void StopUsingSink()
        {
            if (!_isUsingSink || _currentSink is null) return;
            
            _currentSink.StopCleaning();
            // Stop Washing Animation
            IsUsingSink = false;
            _currentSink = null;
            _playerMovements.enabled = true;
            _playerDash.enabled = true;
        }

        #endregion

        #region Private and Protected Members

        private PlayerMovements _playerMovements;
        private PlayerDash _playerDash;

        private Sink _currentSink;
        
        private bool _isUsingSink;

        #endregion
    }
}