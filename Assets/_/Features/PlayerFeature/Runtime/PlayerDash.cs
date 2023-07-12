using System;
using InputFeature.Runtime;
using UnityEngine;

namespace PlayerFeature.Runtime
{
    public class PlayerDash : MonoBehaviour
    {
    	#region Public Members

    	#endregion


    	#region Unity API

        private void Awake()
        {
	        _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void Start()
        {
	        InputManager.m_instance.m_onMove += MovePlayerEventHandler;
	        InputManager.m_instance.m_onDash += HandleDash;
        }

    	#endregion


    	#region Main Methods
        
        private void MovePlayerEventHandler(object sender, OnMoveEventArgs e)
        {
	        _moveInput = e.m_direction;
        }

        private void HandleDash(object sender, EventArgs e)
        {
	        _rigidbody.AddForce(new Vector3(_moveInput.x, 0, _moveInput.y) * _dashStrength, ForceMode.Impulse);
        }
        
    	#endregion


    	#region Private and Protected Members
        
        [SerializeField] private float _dashStrength;

        private Rigidbody _rigidbody;
        
        private Vector2 _moveInput;

    	#endregion
    }
}