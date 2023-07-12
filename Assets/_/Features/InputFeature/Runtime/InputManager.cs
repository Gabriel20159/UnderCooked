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

        public EventHandler<OnMoveEventArgs> m_onMove;
        public EventHandler m_onUseStarted;
        public EventHandler m_onUseCanceled;
        public EventHandler m_onTake;
        public EventHandler m_onDash;

        #endregion

        #region Main Methods

        public void OnMoveEventHandler(InputAction.CallbackContext context)
        {
            m_onMove?.Invoke(this, new OnMoveEventArgs() { m_direction = Vector2.ClampMagnitude(context.ReadValue<Vector2>(), 1) });
        }

        public void OnUseEventHandler(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                m_onUseStarted?.Invoke(this,EventArgs.Empty);
            }
            else if (context.canceled)
            {
                m_onUseCanceled?.Invoke(this,EventArgs.Empty);
            }
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
    }
}