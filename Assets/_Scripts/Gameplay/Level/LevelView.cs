using TMPro;
using UnityEngine;

namespace MemoryGame.Gameplay
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;

        public void UpdateLevel(int level)
        {
            _levelText.text = level.ToString();
        }
    }
}
