using System;
using _Berkay.Scripts.Common;
using UnityEngine;

namespace _Berkay.Scripts
{
    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private BoxArea2D attackArea;

        public event Action OnPlayerAttack;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnPlayerAttack?.Invoke();

                var enemy = attackArea.Overlap<Enemy.Enemy>();
                if (enemy)
                {
                    enemy.TakeDamage();
                }
            }
        }
    }
}