using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputFeature.Runtime
{

    public class OnMoveEventArgs : EventArgs
    {
        public Vector2 m_direction;
    }

    public class InputManager : MonoBehaviour
    {
        #region Public Members

        public static InputManager m_instance;

        public EventHandler<OnMoveEventArgs> m_onMove;
        public EventHandler m_onUse;
        public EventHandler m_onTake;
        public EventHandler m_onDash;

        #endregion


        #region Unity API

        private void Awake()
        {
            m_instance = this;
        }

        #endregion


        #region Main Methods

        public void OnMoveEventHandler(InputAction.CallbackContext context)
        {
            m_onMove?.Invoke(this, new OnMoveEventArgs() { m_direction = Vector2.ClampMagnitude(context.ReadValue<Vector2>(), 1) });
        }

        public void OnUseEventHandler(InputAction.CallbackContext context)
        {
            if (!context.started) return;

            m_onUse?.Invoke(this,EventArgs.Empty);
            
        }

        public void OnTakeEventHandler(InputAction.CallbackContext context)
        {
            if (!context.started) return;

            m_onTake?.Invoke(this, EventArgs.Empty);
        }

        public void OnDashEventHandler(InputAction.CallbackContext context)
        {
            if (!context.started) return;

            m_onDash?.Invoke(this, EventArgs.Empty);
        }

        #endregion


        #region Utils



        #endregion


        #region Private and Protected Members



        #endregion
    }
}