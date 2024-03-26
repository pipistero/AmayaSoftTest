using JetBrains.Annotations;
using Level.Data;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "New GameData", menuName = "Game/Data")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private LevelData[] _levelsData;

        private int _currentLevelIndex;
        private LevelData _currentLevel;

        public LevelData GetFirstLevel()
        {
            _currentLevelIndex = 0;
            _currentLevel = _levelsData[_currentLevelIndex];

            return _currentLevel;
        }

        [CanBeNull]
        public LevelData GetNextLevel()
        {
            _currentLevelIndex++;
            _currentLevel = _levelsData[_currentLevelIndex];

            if (_currentLevelIndex == _levelsData.Length - 1)
                return null;

            return _currentLevel;
        }
    }
}