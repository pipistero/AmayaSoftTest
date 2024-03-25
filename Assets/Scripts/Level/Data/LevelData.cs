using System;
using System.Collections.Generic;
using Card.Data;
using Extensions;
using UnityEngine;

namespace Level.Data
{
    [Serializable]
    public class LevelData
    {
        [Header("Cards data")]
        [SerializeField] private CardBundleData[] _bundlesData;
        
        [Header("Layout settings")]
        [SerializeField] private int _columnsCount;
        [SerializeField] private int _linesCount;
        
        public int ColumnsCount => _columnsCount;

        private List<string> _levelIdentifiers;

        public CardData[] GetCardsData()
        {
            var cardsDataCount = _columnsCount * _linesCount;
            var result = new CardData[cardsDataCount];
            
            _levelIdentifiers = new List<string>();

            for (var i = 0; i < cardsDataCount; i++)
            {
                var cardData = GetRandomCardData();

                while (_levelIdentifiers.Contains(cardData.Identifier))
                {
                    cardData = GetRandomCardData();
                }
                
                _levelIdentifiers.Add(cardData.Identifier);
                
                result[i] = cardData;
            }

            return result;
        }

        private CardData GetRandomCardData()
        {
            return _bundlesData.GetRandomElement().GetRandomCardData();
        }
    }
}