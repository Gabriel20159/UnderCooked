using System;
using InputFeature.Runtime;
using UnityEngine;

namespace PlayerFeature.Runtime
{
    public class PlayerDash : MonoBehaviour
    {
    	#region Public Members

        public EventHandler m_onPlayerDash;
        
    	#endregion

        #region Unity API

        private void Awake()
        {
	        _rigidbody = GetComponent<Rigidbody>();
	        _inputManager = GetComponent<InputManager>();
        }
        
        private void Start()
        {
	        _inputManager.m_onMove += MovePlayerEventHandler;
	        _inputManager.m_onDash += HandleDash;
        }

    	#endregion

        #region Main Methods
        
        private void MovePlayerEventHandler(object sender, OnMoveEventArgs e)
        {
	        _moveInput = e.m_direction;
        }

        private void HandleDash(object sender, EventArgs e)
        {
	        if (_moveInput == Vector2.zero) return;
	        _rigidbody.AddForce(new Vector3(_moveInput.x, 0, _moveInput.y) * _dashStrength, ForceMode.Impulse);
	        m_onPlayerDash?.Invoke(this, EventArgs.Empty);
        }
        
    	#endregion

        #region Private and Protected Members

        private InputManager _inputManager;
        
        [SerializeField] private float _dashStrength;

        private Rigidbody _rigidbody;
        
        private Vector2 _moveInput;

    	#endregion
    }
}