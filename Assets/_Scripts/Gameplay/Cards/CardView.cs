using UnityEngine;
using UnityEngine.UI;

namespace MemoryGame.Gameplay
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image _frontSprite;
        [SerializeField] private GameObject _cardBack;

        private int _indexInGrid;

        public void UpdateView(CardData data, int indexInGrid)
        {
            _frontSprite.sprite = data.CardArt;
            _indexInGrid = indexInGrid;
        }

        public void Reveal()
        {
            
        }

        public void Hide()
        {
            
        }
    }
}
