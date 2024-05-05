using UnityEngine;
using UnityEngine.SceneManagement;

namespace MemoryGame.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private int _gameSceneIndex;

        public void StartGame()
        {
            SceneManager.LoadScene(_gameSceneIndex);
        }
    }
}
