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

        public void UpdateView(CardData data, Action onClick)
        {
            _frontSprite.sprite = data.CardArt;

            _frontSprite.gameObject.SetActive(true);
            _cardBack.SetActive(true);
            _button.enabled = false;

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(new UnityAction(onClick));
        }

        public void Enable()
        {
            _button.enabled = true;
        }

        public void Reveal()
        {
            _animator.Play("Reveal");
        }

        public void Hide()
        {
            _animator.Play("Hide");
        }
        
        public void HideInstant()
        {
            _animator.Play("Hidden");
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
