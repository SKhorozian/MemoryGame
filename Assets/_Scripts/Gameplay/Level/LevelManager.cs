using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryGame.Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;
        [SerializeField] private CardGrid _grid;
        
        private void Start()
        {
            _grid.UpdateGrid(_levelData);
        }
    }
}
