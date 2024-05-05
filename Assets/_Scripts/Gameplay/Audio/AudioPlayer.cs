using UnityEngine;

namespace MemoryGame.Gameplay
{
    public class AudioPlayer : MonoBehaviour
    {
        private static AudioPlayer _instance;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource _pitchAudioSource;
        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else 
            {
                Destroy(this);
            }
        }

        public void PlayClip(AudioClip clip)
        { 
            _audioSource.PlayOneShot(clip);
        }
        
        public void PlayClip(AudioClip clip, float pitch)
        {
            _pitchAudioSource.pitch = pitch;
            _pitchAudioSource.PlayOneShot(clip);
        }

        public static AudioPlayer Instance => _instance;
    }
}
