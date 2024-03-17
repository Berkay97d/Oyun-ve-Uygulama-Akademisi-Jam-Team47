using System;
using _Berkay.Scripts.Common;
using UnityEngine;

namespace _Berkay.Scripts
{
    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private CircleArea2D attackArea;

        public event Action OnPlayerAttack;
        
        private void Update()
        {
            var enemies = attackArea.OverlapAll<Enemy.Enemy>();
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnPlayerAttack?.Invoke();

                foreach (var enemy in enemies)
                {
                    enemy.TakeDamage();
                }
            }
        }
    }
}