using System;
using UnityEngine;

namespace _Berkay.Scripts.Platform
{
    public class ParentChanger : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out CharacterMovement characterMovement))
            {
                characterMovement.transform.SetParent(_parent);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out CharacterMovement characterMovement))
            {
                characterMovement.transform.SetParent(null);
            }
        }
    }
}