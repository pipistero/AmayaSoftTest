using System;
using Card.Data;
using DG.Tweening;
using Game.Data;
using Game.Grid;
using Level.Data;
using TMPro;
using UnityEngine;
using Window;

namespace Game.View
{
    public class GameView : MonoBehaviour
    {
        #region Consts

        private readonly Color TargetTextClearColor = new Color(0.1f, 0.1f, 0.1f, 0f);
            
        #endregion
        
        [Header("Grid")] 
        [SerializeField] private GridView _gridView;

        [Header("Target")] 
        [SerializeField] private TextMeshProUGUI _targetText;
        [SerializeField] private float _targetTextFadeDuration;

        [Header("Windows")] 
        [SerializeField] private EndGameWindow _endGameWindow;
        [SerializeField] private LoadingWindow _loadingWindow;
        
        private GameData _gameData;
        private LevelData _currentLevel;

        private void Start()
        {
            _loadingWindow.Close();
            _endGameWindow.Close();
            
            _endGameWindow.Restart += OnRestart;
        }

        public void SetData(GameData gameData)
        {
            _gameData = gameData;
        }

        public void StartGame()
        {
            if (_gameData == null)
                throw new NullReferenceException("Missing GameData in GameView; See SetData method");

            _currentLevel = _gameData.GetFirstLevel();

            InitializeLevelEvents();
            _gameData.LevelCompleted += OnLevelCompleted;
            
            _gridView.Initialize(_currentLevel);
            PlayAppearAnimation();
        }

        private async void RestartGame()
        {
            await _endGameWindow.Close();
            await _loadingWindow.Open();
            
            _currentLevel = _gameData.GetFirstLevel();
            
            InitializeLevelEvents();
            
            _gridView.Initialize(_currentLevel);
            PlayAppearAnimation();
            
            await _loadingWindow.Close();
        }

        private async void EndGame()
        {
            await _endGameWindow.Open();
        }

        private void PlayAppearAnimation()
        {
            _gridView.PlayAppearAnimation();
            _targetText.color = TargetTextClearColor;
            _targetText.DOFade(1f, _targetTextFadeDuration);
        }
        
        private void InitializeLevelEvents()
        {
            _currentLevel.TargetChanged += OnTargetChanged; 
        }

        private void OnRestart()
        {
            RestartGame();
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
                EndGame();
                return;
            }
            
            InitializeLevelEvents();
            
            _gridView.Initialize(_currentLevel);
        }
    }
}