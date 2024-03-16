using System;
using System.Collections;
using UnityEngine;

namespace _Berkay.Scripts
{
    public class Dasher : MonoBehaviour
    {
        [SerializeField] private float _dashForce;
        [SerializeField] private Rigidbody2D _rb;

        public event Action OnDashed;
        
        private bool m_isDashing;
        private int m_currentDirection = 1;


        private void Update()
        {
            CheckGravityScale();
            CheckDirection();
            
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(Dash(m_currentDirection));
            }
        }

        private void CheckDirection()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                m_currentDirection = -1;
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                m_currentDirection = 1;
            }
        }

        private IEnumerator Dash(int direction)
        {
            m_isDashing = true;
            yield return new WaitForSeconds(0.05f);

            _rb.velocity = new Vector2(_rb.velocity.x + _dashForce * direction, _rb.velocity.y);
            OnDashed?.Invoke();

            yield return new WaitForSeconds(.2f);
            m_isDashing = false;
        }

        public bool GetIsDashing()
        {
            return m_isDashing;
        }

        private void CheckGravityScale()
        {
            if (m_isDashing)
            {
                _rb.gravityScale = 0;
                return;
            }

            _rb.gravityScale = 1;
        }


    }
}