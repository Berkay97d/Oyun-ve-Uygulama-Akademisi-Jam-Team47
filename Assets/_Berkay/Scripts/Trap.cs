using System;
using UnityEngine;

namespace _Berkay.Scripts
{
    public class Trap : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerHealthSystem playerHealthSystem))
            {
                if (playerHealthSystem.GetIsDead())
                {
                    return;
                }
                
                playerHealthSystem.TakeDamage(100);
            }
        }
    }
}