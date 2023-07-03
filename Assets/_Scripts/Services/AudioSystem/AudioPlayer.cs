using _Scripts.AudioSystem;
using UnityEngine;

namespace _Scripts.Services.AudioSystem
{
    public class AudioPlayer : MonoBehaviour
    {
        private static AudioPlayer _instance;
        private AudioStorage[] _audioStorages;

        public static AudioPlayer Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                _audioStorages = FindObjectsOfType<AudioStorage>();
            }
        }

        private void OnDisable()
        {
            _instance = null;
        }

        public void Play(string name)
        {
            Sound foundClip;

            foreach (var storage in _audioStorages)
            {
                foundClip = storage.GetSound(name);
                
                if (foundClip != null)
                {
                    if (foundClip.IsRandomPitch)
                        foundClip.Source.pitch = Random.Range(0.9f, 1.1f);
                    
                    foundClip.Source.Play();
                    return;
                }
            }
        }
    }
}