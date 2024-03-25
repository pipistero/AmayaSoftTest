using Game.Data;
using Game.View;
using UnityEngine;

namespace Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("Game Data")] 
        [SerializeField] private GameData _gameData;

        [Header("Game View")] 
        [SerializeField] private GameView _gameView;

        private void Start()
        {
            _gameView.Initialize(_gameData);
            _gameView.StartGame();
        }
    }
}