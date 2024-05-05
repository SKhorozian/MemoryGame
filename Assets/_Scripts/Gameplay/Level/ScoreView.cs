using TMPro;
using UnityEngine;

namespace MemoryGame.Gameplay
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _comboText;
        
        public void SetScore(int score)
        {
            _scoreText.text = score.ToString();
        }

        public void SetCombo(int combo)
        {
            _comboText.text = combo.ToString();
        }
    }
}
