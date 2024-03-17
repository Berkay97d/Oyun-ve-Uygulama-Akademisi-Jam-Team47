using System;
using UnityEngine;

namespace _Berkay.Scripts
{
    public class PlayerHealthSystem : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;

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
            _currentHeath -= damage;
            
            OnDamage?.Invoke(_currentHeath);

            if (_currentHeath <= 0)
            {
                _isDead = true;
                OnDeath?.Invoke();
            }
        }

        public bool GetIsDead()
        {
            return _isDead;
        }
    }
}