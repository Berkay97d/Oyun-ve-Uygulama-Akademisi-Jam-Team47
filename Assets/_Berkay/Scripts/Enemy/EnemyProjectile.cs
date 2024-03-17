using System;
using System.Collections;
using _Berkay.Scripts.Common;
using UnityEngine;
using Collision2D = UnityEngine.Collision2D;

namespace _Berkay.Scripts.Enemy
{
    public class EnemyProjectile : MonoBehaviour
    {
        [SerializeField] private CircleArea2D _damageCollider;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _destroyTimeAfterBoom;
        
        private bool m_isDamagedAlready = false;
        private bool isStartedBoom = false;

        
        private void Update()
        {
            var player = _damageCollider.Overlap<Player>();

            if (player && !m_isDamagedAlready)
            {
                _rb.velocity = Vector2.zero;
                _rb.gravityScale = 0;
                var healthSystem = player.GetHealthSystem();
                healthSystem.TakeDamage(1);
                StartCoroutine(Boom());
                m_isDamagedAlready = true;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!isStartedBoom)
            {
                StartCoroutine(Boom());
                isStartedBoom = true;   
                _rb.velocity = Vector2.zero;
                _rb.gravityScale = 0;
            }
        }

        public void Fire(Vector3 direction)
        {
            _rb.AddForce(direction * _bulletSpeed);
        }

        private IEnumerator Boom()
        {
            _animator.SetTrigger("boom");
            yield return new WaitForSeconds(_destroyTimeAfterBoom);
            Destroy(gameObject);
        }
        
    }
}