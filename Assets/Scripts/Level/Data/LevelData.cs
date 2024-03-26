using System;
using System.Collections.Generic;
using System.Linq;
using Card.Data;
using Card.View;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level.Data
{
    [Serializable]
    public class LevelData
    {
        public event Action<CardData> TargetChanged;
        public event Action Completed;
        
        [Header("Cards data")]
        [SerializeField] private CardBundleData _bundleData;
        
        [Header("Layout settings")]
        [SerializeField] private int _columnsCount;
        [SerializeField] private int _linesCount;
        
        public int ColumnsCount => _columnsCount;

        private List<CardData> _availableCards;
        private CardData _currentTarget;

        [ItemCanBeNull]
        public List<CardData> GetCardsData()
        {
            var cardsDataCount = _columnsCount * _linesCount;

            if (cardsDataCount > _bundleData.CardsData.Length)
                throw new Exception($"There is not enough CardsData for level with {cardsDataCount} cards count");
            
            _availableCards = _bundleData.CardsData
                .OrderBy(_ => Guid.NewGuid())
                .Take(cardsDataCount)
                .ToList();

            SelectCurrentTarget();
            
            return _availableCards;
        }

        public void OnCardClicked(CardView cardView, CardData cardData)
        {
            if (cardData.Identifier != _currentTarget.Identifier)
            {
                cardView.PlayIncorrectAnimation();
                return;
            }
            
            cardView.PlayCorrectAnimation();
            _availableCards.Remove(_currentTarget);
            
            SelectCurrentTarget();
        }

        private void SelectCurrentTarget()
        {
            if (_availableCards.Count == 0)
            {
                Completed?.Invoke();
                return;
            }
            
            _currentTarget = _availableCards[Random.Range(0, _availableCards.Count)];
            
            TargetChanged?.Invoke(_currentTarget);
        }
    }
}