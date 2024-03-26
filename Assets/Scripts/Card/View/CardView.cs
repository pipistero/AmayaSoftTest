using System;
using System.Threading.Tasks;
using Card.Data;
using Pool.Abstraction;
using UnityEngine;
using UnityEngine.UI;

namespace Card.View
{
    public class CardView : MonoBehaviour, IPoolElement
    {
        #region Consts

        private readonly Color CorrectColor = Color.green;
        private readonly Color IncorrectColor = Color.red;
        private readonly Color BaseColor = Color.white;

        #endregion
        
        public event Action<CardView, CardData> Clicked;  
        
        [Header("Visual")]
        [SerializeField] private Image _icon;
        [SerializeField] private Image _background;

        [Header("Button")] 
        [SerializeField] private Button _button;
        
        private CardData _cardData;
        private bool _isDone;

        public void Initialize(CardData cardData)
        {
            _cardData = cardData;

            ClearView();
            UpdateView();
            InitializeButton();
        }

        public async Task PlayCorrectAnimation()
        {
            if (_isDone)
                return;
            
            _background.color = CorrectColor;
            
            _isDone = true;
        }

        public async Task PlayIncorrectAnimation()
        {
            if (_isDone)
                return;
            
            _background.color = IncorrectColor;
            
            await Task.Delay(TimeSpan.FromMilliseconds(500));

            _background.color = BaseColor;
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

        private void ClearView()
        {
            _isDone = false;
            _background.color = BaseColor;
        }
    }
}