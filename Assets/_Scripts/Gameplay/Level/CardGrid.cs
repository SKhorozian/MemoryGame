using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MemoryGame.Gameplay
{
    public class CardGrid : MonoBehaviour
    {
        [SerializeField] private CardView _cardViewPrefab;
        [SerializeField] private GameObject _columnPrefab;
        [SerializeField] private Transform _rowRoot;
        
        private GameObject[] _columns = Array.Empty<GameObject>();
        private CardModel[] _models = Array.Empty<CardModel>();
        private CardView[] _views = Array.Empty<CardView>();

        public void UpdateGrid(LevelData levelData)
        {
            foreach (CardView view in _views) 
            {
                Destroy(view);
            }

            int gridSize = levelData.Cards.Length * 2;

            if (gridSize > (levelData.Width * levelData.Height)) 
            {
                Debug.LogError("Grid dimensions cannot fit all cards.");
            }

            _models = new CardModel[gridSize];
            _views = new CardView[gridSize];

            HashSet<int> usedIndex = new();

            PrepareViews(levelData.Width, levelData.Height);

            foreach (CardData data in levelData.Cards) 
            {
                for (int i = 0; i < 2; i++) 
                {
                    int randomIndex;
                    
                    do 
                    {
                        randomIndex = Random.Range(0, gridSize);
                    } 
                    while (usedIndex.Contains(randomIndex));

                    usedIndex.Add(randomIndex);
                    
                    _models[randomIndex] = new CardModel(data);
                    
                    _views[randomIndex].UpdateView(data, randomIndex);
                }
            }
            
        }

        private void PrepareViews(int width, int height)
        {
            int viewIndex = 0;
            
            for (int i = 0; i < width; i++) 
            {
                GameObject column = Instantiate(_columnPrefab, _rowRoot);

                for (int j = 0; j < height; j++) 
                {
                    if (viewIndex >= _views.Length) 
                    {
                        return;
                    }

                    _views[viewIndex] = Instantiate(_cardViewPrefab, column.transform);

                    viewIndex++;
                }
            }
        }

    }
}
