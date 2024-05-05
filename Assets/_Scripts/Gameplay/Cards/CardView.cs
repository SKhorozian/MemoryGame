using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MemoryGame.Gameplay
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image _frontSprite;
        [SerializeField] private GameObject _cardBack;
        [SerializeField] private Button _button;
        [SerializeField] private Animator _animator;
        
        private int _indexInGrid;

        public void UpdateView(CardData data, int indexInGrid, Action onClick)
        {
            _frontSprite.sprite = data.CardArt;
            _indexInGrid = indexInGrid;

            _frontSprite.gameObject.SetActive(false);
            _cardBack.SetActive(true);
            
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(new UnityAction(onClick));
        }

        public void Reveal()
        {
            _animator.Play("Reveal");
        }

        public void Hide()
        {
            _animator.Play("Hide");
        }

        public void RevealAndDisable()
        {
            Reveal();
            Disable();
        }

        public void Disable()
        {
            _button.enabled = false;

            StartCoroutine(DelayedDisable());
        }

        private IEnumerator DelayedDisable()
        {
            yield return new WaitForSeconds(1f);
            _cardBack.gameObject.SetActive(false);
        }
        
        public void RevealAndHide()
        {
            _animator.Play("RevealAndHide");
        }
    }
}
