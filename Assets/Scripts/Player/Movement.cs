using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [Header("Physics properties")]
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _maxSpeed;

        [Header("Pointer properties")]
        [SerializeField] private Transform _pointer;
        
        [Header("Ground check properties")]
        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private Transform _groundCheckPosition;

        // [Header("Animations")]
        // [SerializeField] private Animator _animator;
        
        // [Header("Sounds")]
        // [SerializeField] private AudioSource _jump;

        private bool _isGrounded;

        private void Update()
        {
            this.IsGrounded();
            
            Vector3 directionToFlag = _pointer.position - transform.position;
            Vector3 normalizedDirection = directionToFlag.normalized;

            if (Input.GetKeyDown(KeyCode.Space))
                _rigidbody2D.AddForce(-normalizedDirection * _jumpForce, (ForceMode2D)ForceMode.Impulse);
        }

        private void FixedUpdate() => this.SpeedLimitation();

        private void IsGrounded() => _isGrounded = Physics2D.OverlapPoint(_groundCheckPosition.position, _whatIsGround);

        private void SpeedLimitation()
        {
            if(_rigidbody2D.velocity.magnitude >= _maxSpeed)
                _rigidbody2D.velocity = Vector3.ClampMagnitude(_rigidbody2D.velocity, _maxSpeed);
        }
    }
}