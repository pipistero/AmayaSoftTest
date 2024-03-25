using Level.Data;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "New GameData", menuName = "Game/Data")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private LevelData[] _levelsData;

        public LevelData[] LevelsData => _levelsData;
    }
}