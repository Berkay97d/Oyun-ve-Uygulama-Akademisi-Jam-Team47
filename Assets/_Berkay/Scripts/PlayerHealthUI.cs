using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Berkay.Scripts
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] private PlayerHealthSystem _healthSystem;
        [SerializeField] private Image _healthImage;
        [SerializeField] private Sprite[] healthSprites;
        
        

        private void Start()
        {
            _healthSystem.OnDamage += OnDamage;
        }

        private void OnDestroy()
        {
            _healthSystem.OnDamage -= OnDamage;
        }

        private void OnDamage(int health)
        {
            _healthImage.sprite = healthSprites[health];
        }
    }
}