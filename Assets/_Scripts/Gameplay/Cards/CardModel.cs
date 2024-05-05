namespace MemoryGame.Gameplay
{
    public class CardModel
    {
        public CardModel(CardData data, int index)
        {
            Index = index;
            CardData = data;
        }

        public CardData CardData { get; }
        public int Index { get; }
    }
}
