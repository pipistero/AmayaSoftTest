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

        public LevelData GetFirstLevel()
        {
            _currentLevelIndex = 0;

            return _levelsData[_currentLevelIndex];
        }

        [CanBeNull]
        public LevelData GetNextLevel()
        {
            _currentLevelIndex++;

            if (_currentLevelIndex == _levelsData.Length - 1)
                return null;

            return _levelsData[_currentLevelIndex];
        }
    }
}