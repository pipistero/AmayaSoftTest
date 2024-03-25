using System;
using Card.Data;
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

        public CardBundleData[] BundlesData => _bundlesData;
        
        public int ColumnsCount => _columnsCount;
        public int LinesCount => _linesCount;
    }
}