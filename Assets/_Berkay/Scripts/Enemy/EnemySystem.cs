using System;
using _Berkay.Scripts.Common;
using UnityEngine;

namespace _Berkay.Scripts.Enemy
{
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField] private BoxArea2D _onPlayerEnterTriggerArea;
        
        public event Action<Player> OnPlayerDetected;
        
        private Player m_player;
        private bool _isPlayerDetected = false;


        private void Update()
        {
            SearchPlayer();
        }

        private void SearchPlayer()
        {
            m_player = _onPlayerEnterTriggerArea.Overlap<Player>();

            if (m_player && !_isPlayerDetected)
            {
                _isPlayerDetected = true;
                OnPlayerDetected?.Invoke(m_player);
            }
        }

        public Player GetPlayer()
        {
            return m_player;
        }
    }
}