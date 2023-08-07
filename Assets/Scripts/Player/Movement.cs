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
        
        [Header("Sounds")]
        [SerializeField] private AudioSource _jump;

        [Header("Inputs")]
        [SerializeField] private KeyCode _rotateDirectionKey;
        [SerializeField] private float _cooldown;
        [SerializeField] private bool _canJump;
        
        [Header("Pointer properties")]
        [SerializeField] private Rotate _pointerRotation;
        
        // [Header("Animations")]
        // [SerializeField] private Animator _animator;

        private float _currentCooldown;
        private bool _isGrounded;

        private void Start() => _currentCooldown = _cooldown;
        
        private void Update()
        {
            this.IsGrounded();
            this.MakeJump();
            this.ChangeRotationDirection();
        }

        private void FixedUpdate()
        {
            this.SpeedLimitation();
            this.JumpRotationCooldown();
        }

        private void MakeJump()
        {
            if (!Input.GetKeyDown(KeyCode.Space) || !this.GetCanJump()) return;
            
            Vector2 normalizedDirectionToTarget = (_pointer.position - transform.position).normalized;
            _rigidbody2D.AddForce(-normalizedDirectionToTarget * _jumpForce, (ForceMode2D)ForceMode.Impulse);
            _jump.Play();
                
            this.ResetJumpCooldown();
        }

        private void IsGrounded() => _isGrounded = Physics2D.OverlapPoint(_groundCheckPosition.position, _whatIsGround);

        private void SpeedLimitation()
        {
            if(_rigidbody2D.velocity.magnitude >= _maxSpeed)
                _rigidbody2D.velocity = Vector2.ClampMagnitude(_rigidbody2D.velocity, _maxSpeed);
        }

        private void SetCanJump(bool state) => _canJump = state;
        
        private bool GetCanJump() => _canJump;

        private void ResetJumpCooldown() => _currentCooldown = 0f;

        private void JumpRotationCooldown()
        {
            if (!this.GetCanJump() && _currentCooldown < _cooldown)
                _currentCooldown += Time.deltaTime;

            this.SetCanJump(!(_currentCooldown < _cooldown));
        }

        private void ChangeRotationDirection()
        {
            float rotationSpeed = this._pointerRotation.GetRotationSpeed();
            this._pointerRotation.SetRotationSpeed(Input.GetKeyDown(_rotateDirectionKey) ? -rotationSpeed : rotationSpeed);
        }
    }
}