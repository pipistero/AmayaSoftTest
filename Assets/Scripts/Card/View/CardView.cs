using Card.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Card.View
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image _icon;

        private CardData _cardData;

        public void Initialize(CardData cardData)
        {
            _cardData = cardData;

            UpdateView();
        }

        private void UpdateView()
        {
            _icon.sprite = _cardData.Sprite;
        }
    }
}