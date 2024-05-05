using System.Collections;
using TMPro;
using UnityEngine;

namespace MemoryGame.Gameplay
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private GameObject _levelCompleteNotif;

        public void UpdateLevel(int level)
        {
            _levelText.text = level.ToString();
        }

        public void CompletedLevel()
        {
            _levelCompleteNotif.SetActive(true);
            StartCoroutine(HideNotif());
        }

        private IEnumerator HideNotif()
        {
            yield return new WaitForSeconds(2);
            _levelCompleteNotif.SetActive(false);
        }
    }
}
