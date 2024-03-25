using System;
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
        
        public void SetData(GameData gameData)
        {
            _gameData = gameData;
        }

        public void StartGame()
        {
            if (_gameData == null)
                throw new NullReferenceException("Missing GameData in GameView; See SetData method");
            
            _gridView.Initialize(_gameData.GetFirstLevel());
        }
    }
}