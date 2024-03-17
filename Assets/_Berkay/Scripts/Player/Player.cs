using UnityEngine;

namespace _Berkay.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private PlayerHealthSystem _healthSystem;


        public CharacterMovement GetCharacterMovement()
        {
            return _movement;
        }

        public PlayerHealthSystem GetHealthSystem()
        {
            return _healthSystem;
        }
        
        
    }
}