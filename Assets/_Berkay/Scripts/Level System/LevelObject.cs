using System;
using UnityEngine;

namespace _Berkay.Scripts.Level_System
{
    public class LevelObject : MonoBehaviour
    {
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private Transform _finishLevelTransform;
        [SerializeField] private Player _player;
        [SerializeField] private float _completeLevelDistance;
        [SerializeField] private int _levelNumber;
        
        
        public event Action<int> OnLevelCompleted;

        private bool _isFinishedAlready;

        private void Update()
        {
            if (_isFinishedAlready) return;

            if (CheckDistancePlayerAndFinishLine() < _completeLevelDistance)
            {
                OnLevelCompleted?.Invoke(_levelNumber);
            }
        }

        private float CheckDistancePlayerAndFinishLine()
        {
            return Vector3.Distance(_player.transform.position, _finishLevelTransform.position);
        }

        public void MovePlayerToSpawnPoint()
        {
            _player.transform.position = _spawnTransform.position;
        }

        public Transform GetSpawnPoint()
        {
            return _spawnTransform;
        }
    }
}