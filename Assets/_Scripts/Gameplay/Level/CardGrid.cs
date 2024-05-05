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
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private ScoreTracker _scoreTracker;
        [SerializeField] private GameObject _startButton;
        [SerializeField] private LevelView _levelView;

        [Space(10)]
        [SerializeField] private AudioClip _matchAudioClip;
        [SerializeField] private AudioClip _failAudioClip;
        [SerializeField] private float _pitchPerCombo = 0.1f;
        
        private GameObject[] _columns = Array.Empty<GameObject>();
        private CardModel[] _models = Array.Empty<CardModel>();
        private CardView[] _views = Array.Empty<CardView>();

        
        private CardModel _firstSelection = null;

        private int _matchesToWin = 0;
        private int _matches = 0;

        public void UpdateGrid(LevelData levelData)
        {
            foreach (GameObject column in _columns) 
            {
                Destroy(column);
            }

            _matches = 0;
            _matchesToWin = levelData.Cards.Length;
            
            int gridSize = levelData.Cards.Length * 2;

            if (gridSize > (levelData.Width * levelData.Height)) 
            {
                Debug.LogError("Grid dimensions cannot fit all cards.");
                return;
            }

            _scoreTracker.ResetCombo();

            _models = new CardModel[gridSize];

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
                    
                    _models[randomIndex] = new CardModel(data, randomIndex);
                    
                    _views[randomIndex].UpdateView(data, () => Select(randomIndex));
                }
            }
            
            _startButton.SetActive(true);
        }

        public void HideAll()
        {
            foreach (CardView cardView in _views) 
            {
                cardView.Enable();
                cardView.HideInstant();
            }
            
            _startButton.SetActive(false);
        }

        private void Select(int cardIndex)
        {
            if (cardIndex >= _models.Length) 
            {
                Debug.LogWarning("Index out of card array bounds.");
                return;
            }

            if (_firstSelection == null) 
            {
                _firstSelection = _models[cardIndex];
                
                _views[cardIndex].Reveal();
                
                return;
            }

            if (_firstSelection.Index == cardIndex) 
            {
                return;
            }

            CardModel secondSelection = _models[cardIndex];

            if (secondSelection.CardData.DoCardsMatch(_firstSelection.CardData)) 
            {
                _views[_firstSelection.Index].Disable();
                _views[cardIndex].RevealAndDisable();

                _scoreTracker.AddScore();
                
                _matches++;
                CheckIfLevelCompleted();
                
                AudioPlayer.Instance.PlayClip(_matchAudioClip, _scoreTracker.Combo * _pitchPerCombo + 1f);
            }
            else 
            {
                _views[_firstSelection.Index].Hide();
                _views[cardIndex].RevealAndHide();
                
                _scoreTracker.ResetCombo();
                AudioPlayer.Instance.PlayClip(_failAudioClip);
            }

            _firstSelection = null;
        }
        
        private void PrepareViews(int width, int height)
        {
            _views = new CardView[width * height];
            _columns = new GameObject[width];
            
            for (int i = 0; i < width; i++) 
            {
                GameObject column = Instantiate(_columnPrefab, _rowRoot);

                _columns[i] = column;
                
                for (int j = 0; j < height; j++) 
                {
                    int index = height * i + j;
                    _views[index] = Instantiate(_cardViewPrefab, column.transform);
                }
            }
        }

        private void CheckIfLevelCompleted()
        {
            if (_matches >= _matchesToWin) 
            {
                _levelView.CompletedLevel();
                _scoreTracker.StoreScore();
                _levelManager.GoToNextLevel();
            }
        }

    }
}
