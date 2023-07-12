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

        #region Unity API


        #endregion

        #region Main Methods

        public void StartUsingSink(Sink sink)
        {
            if (_isUsingSink || sink is null) return;
            
            sink.StartCleaning();
            // Start Washing Animation
            IsUsingSink = true;
        }

        public void StopUsingSink(Sink sink)
        {
            if (!_isUsingSink || sink is null) return;
            
            sink.StopCleaning();
            // Stop Washing Animation
            IsUsingSink = false;
        }

        #endregion

        #region Utils


        #endregion

        #region Private and Protected Members

        private bool _isUsingSink;

        #endregion
    }
}