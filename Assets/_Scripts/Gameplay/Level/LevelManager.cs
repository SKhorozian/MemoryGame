using UnityEngine;

namespace MemoryGame.Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelData[] _levels;
        [SerializeField] private CardGrid _grid;
        [SerializeField] private LevelView _levelView;

        private int _currentLevel = 0;
        
        private void Start()
        {
            GoToNextLevel();
        }

        public void GoToNextLevel()
        {
            _currentLevel++;

            int dataIndex = _currentLevel - 1;

            if (dataIndex >= _levels.Length) 
            {
                GameCompleted();
                return;
            }

            LevelData nextLevelData = _levels[dataIndex];
            
            _grid.UpdateGrid(nextLevelData);
            _levelView.UpdateLevel(_currentLevel);
        }

        private void GameCompleted()
        {
            
        }
    }
}
