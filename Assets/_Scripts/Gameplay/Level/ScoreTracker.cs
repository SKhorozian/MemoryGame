using UnityEngine;

namespace MemoryGame.Gameplay
{
    public class ScoreTracker : MonoBehaviour
    {
        [SerializeField] private ScoreView _scoreView;
        
        [SerializeField] private int _scorePerMatch = 100;
        [SerializeField] private int _comboBonus = 25;

        private int _score = 0;
        private int _combo = 0;

        private int _storedScore = 0;

        public void SetScore(int score)
        {
            _score = score;
            
            _scoreView.SetScore(_score);

            StoreScore();
        }

        public void AddScore()
        {
            _score += _scorePerMatch + (_combo * _comboBonus);
            _combo++;
            
            _scoreView.SetScore(_score);
            _scoreView.SetCombo(_combo);
        }

        public void ResetCombo()
        {
            _combo = 0;
            
            _scoreView.SetCombo(_combo);
        }

        public void StoreScore()
        {
            _storedScore = _score;
        }

        public int Combo => _combo;
        public int StoredScore => _storedScore;
    }
}
