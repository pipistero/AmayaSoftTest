using System;
using JetBrains.Annotations;
using Level.Data;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "New GameData", menuName = "Game/Data")]
    public class GameData : ScriptableObject
    {
        public event Action LevelCompleted;
        
        [SerializeField] private LevelData[] _levelsData;

        private int _currentLevelIndex;
        private LevelData _currentLevel;

        public LevelData GetFirstLevel()
        {
            _currentLevelIndex = 0;
            _currentLevel = _levelsData[_currentLevelIndex];

            _currentLevel.Completed += OnLevelCompleted;
            
            return _currentLevel;
        }

        [CanBeNull]
        public LevelData GetNextLevel()
        {
            _currentLevel.Completed -= OnLevelCompleted;
            
            _currentLevelIndex++;
            
            if (_currentLevelIndex == _levelsData.Length)
                return null;
            
            _currentLevel = _levelsData[_currentLevelIndex];
            _currentLevel.Completed += OnLevelCompleted;

            return _currentLevel;
        }

        private void OnLevelCompleted()
        {
            LevelCompleted?.Invoke();
        }
    }
}