using UnityEngine;

namespace Card.Data
{
    [CreateAssetMenu(fileName = "New CardBundleData", menuName = "Cards/Bundle")]
    public class CardBundleData : ScriptableObject
    {
        [SerializeField] private CardData[] _cardsData;

        public CardData[] CardsData => _cardsData;
    }
}