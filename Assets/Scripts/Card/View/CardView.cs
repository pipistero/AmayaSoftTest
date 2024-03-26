using System;
using Card.Data;
using Pool.Abstraction;
using UnityEngine;
using UnityEngine.UI;

namespace Card.View
{
    public class CardView : MonoBehaviour, IPoolElement
    {
        public event Action<CardView, CardData> Clicked;  
        
        [Header("Visual")]
        [SerializeField] private Image _icon;

        [Header("Animations")] 
        [SerializeField] private CardViewAnimation _cardViewAnimation;

        [Header("Button")] 
        [SerializeField] private Button _button;
        
        private CardData _cardData;

        public void Initialize(CardData cardData)
        {
            _cardData = cardData;

            UpdateView();
            InitializeButton();
        }

        public void PlayCorrectAnimation()
        {
            _cardViewAnimation.PlayCorrectAnimation();
        }

        public void PlayIncorrectAnimation()
        {
            _cardViewAnimation.PlayIncorrectAnimation();
        }
        
        private void InitializeButton()
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => Clicked?.Invoke(this, _cardData));
        }

        private void UpdateView()
        {
            _icon.sprite = _cardData.Sprite;
        }
    }
}