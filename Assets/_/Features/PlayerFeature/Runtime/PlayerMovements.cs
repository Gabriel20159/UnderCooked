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

        private void FixedUpdate()
        {
	        MovePlayer();
        }

        #endregion


    	#region Main Methods

        private void MovePlayer()
        {
	        float horizontalInput = Input.GetAxisRaw("Horizontal");
	        float verticalInput = Input.GetAxisRaw("Vertical");

	        Vector3 movementDirection = new Vector3(verticalInput, 0, -horizontalInput);

	        _rigidbody.velocity += movementDirection * (_speed * Time.deltaTime);

	        if (movementDirection != Vector3.zero)
	        {
		        transform.forward = Vector3.Lerp(transform.forward, movementDirection, _smoothness);
	        }
        }
        
    	#endregion
        
        
    	#region Private and Protected Members

        [SerializeField] private float _speed;
        [Range(0.01f, 1f)]
        [SerializeField] private float _smoothness;
        
        private Rigidbody _rigidbody;

        #endregion
    }
}