using Card.View;
using Level.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Grid
{
    public class GridView : MonoBehaviour
    {
        [Header("Grid")] 
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;

        [Header("Holder")] 
        [SerializeField] private Transform _holder;

        [Header("Prefab")] 
        [SerializeField] private CardView _cardPrefab;

        private LevelData _levelData;
        
        public void Initialize(LevelData levelData)
        {
            _levelData = levelData;
            
            UpdateView();
        }

        private void UpdateView()
        {
            _gridLayoutGroup.constraintCount = _levelData.ColumnsCount;

            var itemsCount = _levelData.ColumnsCount * _levelData.LinesCount;
            
            for (int i = 0; i < itemsCount; i++)
            {
                var cardView = Instantiate(_cardPrefab, _holder);
                cardView.Initialize(_levelData.BundlesData[0].CardsData[0]);
            }
        }
    }
}