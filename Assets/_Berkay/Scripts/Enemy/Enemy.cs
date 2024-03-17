using System;
using System.Collections;
using _Berkay.Scripts.Common;
using UnityEngine;

namespace _Berkay.Scripts.Enemy
{
    public enum EnemyState
    {
        Idle,
        Walk,
        Fire,
        Death
    }
    
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemySystem _enemySystem;
        [SerializeField] private EnemyProjectile _projectile;
        [SerializeField] private Transform _projectileExitPos;
        [SerializeField] private float _fireWaitTime;
        [SerializeField] private BoxArea2D _fireArea;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _maxHealth;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Animator animator;
        [SerializeField] private int m_type;
        
        
        private float m_currentHealth;

        private bool isDead;
        private Player m_player;
        private EnemyState m_enemyState = EnemyState.Idle;
        
        private void Start()
        {
            m_currentHealth = _maxHealth;
            _enemySystem.OnPlayerDetected += OnPlayerDetected;
        }

        private void OnDestroy()
        {
            _enemySystem.OnPlayerDetected -= OnPlayerDetected;
        }

        private void Update()
        {
            if (isDead)
            {
                if (m_type == 1)
                {
                    transform.position = new Vector3(transform.position.x, -1.75f, transform.position.z);
                }
                StopAllCoroutines();
                return;
            }
            
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (m_type == 1)
                {
                    isDead = true;
                    animator.SetTrigger("dead");   
                }
            }
            
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (m_type == 2)
                {
                    isDead = true;
                    animator.SetTrigger("dead");   
                }
            }
            
            if (Input.GetKeyDown(KeyCode.L))
            {
                if (m_type == 3)
                {
                    isDead = true;
                    animator.SetTrigger("dead");   
                }
            }
            
            if (_enemySystem.GetPlayer() == null)
            {
                return;
            }
            
            AdjustFlip(_enemySystem.GetPlayer().transform.position);
        }

        private void OnPlayerDetected(Player obj)
        {
            m_player = obj;
            ChangeEnemyState(EnemyState.Walk);
        }

        private void OnEnemyStateChanged(EnemyState enemyState)
        {
            switch (enemyState)
            {
                case EnemyState.Walk:
                    StartCoroutine(StartWalkToPlayerRoutine(m_player.transform));
                    break;
                case EnemyState.Fire:
                    StartCoroutine(FireRoutine());
                    break;
                case EnemyState.Death:
                    break;
            }
        }

        private IEnumerator FireRoutine()
        {
            while (true)
            {
                if (isDead)
                {
                    Debug.Log("AAAAAAAA");
                    yield break;
                }
                
                var projectile = Instantiate(_projectile, _projectileExitPos.position, Quaternion.identity);
                var direction = Vector3.Normalize(m_player.transform.position - transform.position); 
                projectile.Fire(direction);
                yield return new WaitForSeconds(_fireWaitTime);
            }
        }

        private IEnumerator StartWalkToPlayerRoutine(Transform target)
        {
            while (true)
            {
                yield return null;
                var direction = Vector3.Normalize(target.position - transform.position);
                direction.y = 0;
                transform.position += direction * (_moveSpeed * Time.deltaTime);

                var playerInFireArea = _fireArea.Overlap<Player>();
                
                if (playerInFireArea)
                {
                    ChangeEnemyState(EnemyState.Fire);
                    yield break;
                }
            }
        }
        
        private void ChangeEnemyState(EnemyState enemyState)
        {
            m_enemyState = enemyState;
            OnEnemyStateChanged(enemyState);
        }

        private void AdjustFlip(Vector3 playerPos)
        {
            if (playerPos.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,180, 0));
                return;
            }
            transform.rotation = Quaternion.Euler(new Vector3(0,0, 0));
        }

        public void TakeDamage()
        {
            m_currentHealth--;
            Debug.Log(m_currentHealth);
            StartCoroutine(ShowTakeDamage());
        }
        
        private IEnumerator ShowTakeDamage()
        {
            yield return new WaitForSeconds(.5f);
            _renderer.color = Color.red;
            yield return new WaitForSeconds(0.05f);
            _renderer.color = Color.white;
        }
    }
}