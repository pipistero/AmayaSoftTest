using Card.Data;
using Level.Data;
using Pool;
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

        [Header("Pool")] 
        [SerializeField] private CardObjectPool _objectPool;

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
            
            for (var i = 0; i < itemsCount; i++)
            {
                InitializeCardView(_levelData.BundlesData[0].CardsData[0]);
            }
        }

        private void InitializeCardView(CardData cardData)
        {
            var cardView = _objectPool.GetElement();
                
            cardView.gameObject.SetActive(true);
            cardView.transform.SetParent(_holder);
                
            cardView.Initialize(cardData);
        }
    }
}