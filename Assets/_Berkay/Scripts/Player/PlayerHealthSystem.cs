using System;
using UnityEngine;

namespace _Berkay.Scripts
{
    public class PlayerHealthSystem : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;

        public event Action OnDeath;
        
        private int _currentHeath;
        private bool _isDead;


        public void TakeDamage(int damage)
        {
            _currentHeath -= damage;

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