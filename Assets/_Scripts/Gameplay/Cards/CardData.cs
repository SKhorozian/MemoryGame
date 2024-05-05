using UnityEngine;

namespace MemoryGame.Gameplay
{
    [System.Serializable]
    public struct CardData
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _art;

        public Sprite CardArt => _art;

        public bool DoCardsMatch(CardData other)
        {
            return other._id.Equals(_id);
        }
    }
}
