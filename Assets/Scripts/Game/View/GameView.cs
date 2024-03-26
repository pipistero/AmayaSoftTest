using System;
using Card.Data;
using Game.Data;
using Game.Grid;
using Level.Data;
using TMPro;
using UnityEngine;

namespace Game.View
{
    public class GameView : MonoBehaviour
    {
        [Header("Grid")] 
        [SerializeField] private GridView _gridView;

        [Header("Target")] 
        [SerializeField] private TextMeshProUGUI _targetText;

        private GameData _gameData;
        private LevelData _currentLevel;
        
        public void SetData(GameData gameData)
        {
            _gameData = gameData;
        }

        public void StartGame()
        {
            if (_gameData == null)
                throw new NullReferenceException("Missing GameData in GameView; See SetData method");

            _currentLevel = _gameData.GetFirstLevel();

            InitializeEvents();
            _gameData.LevelCompleted += OnLevelCompleted;
            
            _gridView.Initialize(_currentLevel);
        }

        private void OnTargetChanged(CardData cardData)
        {
            _targetText.text = $"Find {cardData.Identifier}";
        }

        private void OnLevelCompleted()
        {
            _currentLevel.TargetChanged -= OnTargetChanged;
            _currentLevel = _gameData.GetNextLevel();

            if (_currentLevel == null)
            {
                Debug.Log("Done");
                return;
            }
            
            InitializeEvents();
            
            _gridView.Initialize(_currentLevel);
        }

        private void InitializeEvents()
        {
            _currentLevel.TargetChanged += OnTargetChanged; 
        }
    }
}