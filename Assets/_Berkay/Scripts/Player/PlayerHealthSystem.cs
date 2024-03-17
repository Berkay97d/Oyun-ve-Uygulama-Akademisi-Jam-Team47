using System;
using System.Collections;
using UnityEngine;

namespace _Berkay.Scripts
{
    public class PlayerHealthSystem : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private SpriteRenderer _renderer;
        
        public event Action OnDeath;
        public event Action<int> OnDamage;
        
        private int _currentHeath;
        private bool _isDead;

        private void Start()
        {
            _currentHeath = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (_currentHeath == 0) return;
            
            _currentHeath -= damage;
            
            OnDamage?.Invoke(_currentHeath);
            StartCoroutine(ShowTakeDamage());

            if (_currentHeath <= 0)
            {
                _isDead = true;
                OnDeath?.Invoke();
            }
        }

        private IEnumerator ShowTakeDamage()
        {
            _renderer.color = Color.red;
            yield return new WaitForSeconds(0.05f);
            _renderer.color = Color.white;
        }

        public bool GetIsDead()
        {
            return _isDead;
        }
    }
}