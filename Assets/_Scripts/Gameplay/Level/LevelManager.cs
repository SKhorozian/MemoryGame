using UnityEngine;

namespace MemoryGame.Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelData[] _levels;
        [SerializeField] private CardGrid _grid;
        [SerializeField] private LevelView _levelView;
        [SerializeField] private GameStateSaver _gameStateSaver;
        
        private int _currentLevel = 0;

        public void StartGame(int startingLevel)
        {
            _currentLevel = startingLevel - 1;
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
            _gameStateSaver.ResetSave();
        }

        public int Level => _currentLevel;
    }
}
