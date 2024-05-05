using UnityEngine;

namespace MemoryGame.Gameplay
{
    [CreateAssetMenu(fileName = "New Level Data", menuName = "Memory Game/Create Level Data")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private CardData[] _cards;

        public int Width => _width;
        public int Height => _height;
        public CardData[] Cards => _cards;

        private void OnValidate()
        {
            if ((_cards.Length * 2) > (_width * _height)) 
            {
                Debug.LogError("Grid dimensions cannot fit all cards.");
            }
        }
    }
}
