using Game.Data;
using Game.Grid;
using UnityEngine;

namespace Game.View
{
    public class GameView : MonoBehaviour
    {
        [Header("Grid")] 
        [SerializeField] private GridView _gridView;

        private GameData _gameData;
        
        public void Initialize(GameData gameData)
        {
            _gameData = gameData;
        }

        public void StartGame()
        {
            _gridView.Initialize(_gameData.LevelsData[2]);
        }
    }
}