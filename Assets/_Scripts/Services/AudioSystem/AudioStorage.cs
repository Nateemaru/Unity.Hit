using System.Linq;
using _Scripts.AudioSystem;
using _Scripts.SO;
using UnityEngine;
using Zenject;

namespace _Scripts.Services.AudioSystem
{
    public class AudioStorage : MonoBehaviour
    {
        [SerializeField] private AudioDataConfig _dataConfig;
        private AudioController _mixer;

        [Inject]
        private void Construct(AudioController mixer)
        {
            _mixer = mixer;
        }

        private void Awake()
        {
            foreach (var sound in _dataConfig.Sounds.ToList())
            {
                sound.Source = gameObject.AddComponent<AudioSource>();

                switch (_dataConfig.Type)
                {
                    case SoundType.Sfx:
                        sound.Source.outputAudioMixerGroup = _mixer.FindSubgroup("Sfx");
                        break;
                    case SoundType.UI:
                        sound.Source.outputAudioMixerGroup = _mixer.FindSubgroup("UI");
                        break;
                    case SoundType.Background:
                        sound.Source.outputAudioMixerGroup = _mixer.FindSubgroup("Background");
                        break;
                }

                if(sound.PlayOnAwake)
                    sound.Source.Play();
            }
        }

        public Sound GetSound(string name)
        {
            var sound = _dataConfig.Sounds.FirstOrDefault(sound => sound.Name == name);
            
            if (sound != null)
                return sound;

            return null;
        }
    }
}