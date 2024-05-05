using UnityEngine;

namespace MemoryGame.Gameplay
{
    public class GameStateSaver : MonoBehaviour
    {
        private const string LevelVarName = "Level";
        private const string ScoreVarName = "Score";

        [SerializeField] private ScoreTracker _scoreTracker;
        [SerializeField] private LevelManager _levelManager;
        
        private void Start()
        {
            int score = PlayerPrefs.HasKey(ScoreVarName) ? PlayerPrefs.GetInt(ScoreVarName) : 0;
            int level = PlayerPrefs.HasKey(LevelVarName) ? PlayerPrefs.GetInt(LevelVarName) : 1;
            
            _scoreTracker.SetScore(score);
            _levelManager.StartGame(level);
        }

        public void SaveState()
        {
            PlayerPrefs.SetInt(LevelVarName, _levelManager.Level);
            PlayerPrefs.SetInt(ScoreVarName, _scoreTracker.StoredScore);
            
            PlayerPrefs.Save();
        }

        public void ResetSave()
        {
            PlayerPrefs.DeleteKey(LevelVarName);
            PlayerPrefs.DeleteKey(ScoreVarName);
            
            PlayerPrefs.Save();
        }
        
        private void OnApplicationQuit()
        {
            SaveState();
        }
    }
}