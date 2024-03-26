using System;
using System.Linq;
using Card.Data;
using UnityEngine;

namespace Level.Data
{
    [Serializable]
    public class LevelData
    {
        [Header("Cards data")]
        [SerializeField] private CardBundleData _bundleData;
        
        [Header("Layout settings")]
        [SerializeField] private int _columnsCount;
        [SerializeField] private int _linesCount;
        
        public int ColumnsCount => _columnsCount;

        public CardData[] GetCardsData()
        {
            var cardsDataCount = _columnsCount * _linesCount;

            if (cardsDataCount > _bundleData.CardsData.Length)
                throw new Exception($"There is not enough CardsData for level with {cardsDataCount} cards count");

            var result = _bundleData.CardsData
                .OrderBy(_ => Guid.NewGuid())
                .Take(cardsDataCount)
                .ToArray();

            return result;
        }
    }
}