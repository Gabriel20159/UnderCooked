using System;
using InputFeature.Runtime;
using UnityEngine;

namespace PlayerFeature.Runtime
{
    public class PlayerMovements : MonoBehaviour
    {
    	#region Unity API

        private void Awake()
        {
	        _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
	        InputManager.m_instance.m_onMove += MovePlayerEventHandler;
        }

        private void Update()
        {
	        HandleMovements();
        }

        #endregion


    	#region Main Methods

        private void MovePlayerEventHandler(object sender, OnMoveEventArgs e)
        {
	        _moveInput = e.m_direction;
        }

        private void HandleMovements()
        {
	        Vector3 movementDirection = new Vector3(_moveInput.x, 0, _moveInput.y);

	        _rigidbody.velocity += movementDirection * (_speed * Time.deltaTime);

	        if (_rigidbody.velocity != Vector3.zero)
	        {
		        transform.rotation = Quaternion.LookRotation(Vector3.Lerp(transform.forward, _rigidbody.velocity, _smoothness));
	        }
        }

        #endregion
        
        
    	#region Private and Protected Members

        [SerializeField] private float _speed;
        [Range(0.01f, 1f)]
        [SerializeField] private float _smoothness;
        
        private Rigidbody _rigidbody;

        private Vector2 _moveInput;

        #endregion
    }
}