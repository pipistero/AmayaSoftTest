using System.Collections.Generic;
using Card.Data;
using Card.View;
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

        [Header("Animation")] 
        [SerializeField] private GridViewAnimation _viewAnimation;

        private List<CardView> _instatiatedViews = new List<CardView>();
        private LevelData _levelData;
        
        public void Initialize(LevelData levelData)
        {
            _levelData = levelData;
            
            UpdateView();
        }

        public void PlayAppearAnimation()
        {
            _viewAnimation.PlayAppearAnimation();
        }

        private void UpdateView()
        {
            ClearView();
            
            _gridLayoutGroup.constraintCount = _levelData.ColumnsCount;
            
            foreach (var cardData in _levelData.GetCardsData())
            {
                InitializeCardView(cardData);
            }
        }

        private void ClearView()
        {
            foreach (var view in _instatiatedViews)
            {
                _objectPool.ReturnElement(view);
            }
            
            _instatiatedViews.Clear();
        }

        private void InitializeCardView(CardData cardData)
        {
            var cardView = _objectPool.GetElement();
                
            cardView.gameObject.SetActive(true);
            cardView.transform.SetParent(_holder);
                
            cardView.Initialize(cardData);
            
            cardView.Clicked += OnCardViewClicked;
            
            _instatiatedViews.Add(cardView);
        }

        private void OnCardViewClicked(CardView cardView, CardData cardData)
        {
            _levelData.OnCardClicked(cardView, cardData);
        }
    }
}