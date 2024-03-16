using System;
using UnityEngine;

namespace _Berkay.Scripts
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float nonGroundedSpeedReduceRatio;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float speed;
        [SerializeField] private float jumpingPower;
        
        private float horizontal;
        private bool isFacingRight = true;
        
        
        private void Update()
        {
            horizontal = Input.GetAxisRaw("Horizontal");   
            
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpingPower);
            }

            if (Input.GetKeyDown(KeyCode.Space) && _rb.velocity.y > 0f)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
            }

            Flip();
        }

        private void FixedUpdate()
        {
            if (IsGrounded())
            {
                _rb.velocity = new Vector2(horizontal * speed, _rb.velocity.y);    
                return;
            }
            
            _rb.velocity = new Vector2(horizontal * speed/nonGroundedSpeedReduceRatio, _rb.velocity.y);
        }

        public bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(_groundCheck.position, _groundCheckRadius);
        }

        private void Flip()
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                isFacingRight = !isFacingRight;
                transform.rotation = Quaternion.Euler(isFacingRight ? Vector3.zero : new Vector3(0, 180, 0));
            }
        }

        public float GetHorizontalSpeed()
        {
            return _rb.velocity.x;
        }
        
        public float GetVerticalSpeed()
        {
            return _rb.velocity.y;
        }
    }
}