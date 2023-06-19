using _Scripts.Services.Database;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using UnityEngine;
using UnityEngine.Audio;

namespace _Scripts.Services.AudioSystem
{
    public class AudioController : IGameRunSubscriber, IGamePauseSubscriber
    {
        private AudioMixer _mixer;
        private const float _SNAPSHOT_TRANSITION_TIME = 0.1f;
        private IDataContainer _dataContainer;

        public AudioController(IDataContainer dataContainer)
        {
            _dataContainer = dataContainer;
            _mixer = Resources.Load<AudioMixer>("AudioMixer");
            SwitchSnapshot(GlobalConstants.RUNNING_SNAPSHOT);
            
            EventBus.Subscribe(this);
            
            ChangeVolume(-80);
        }

        public float GetVolume()
        {
            if (_mixer.GetFloat("Volume", out var volume))
                return volume;

            return 0;
        }

        public void SwitchSnapshot(string snapshotName)
        {
            _mixer.FindSnapshot(snapshotName).TransitionTo(_SNAPSHOT_TRANSITION_TIME);
        }

        public void ChangeVolume(float volumeLevel)
        {
            _mixer.SetFloat("Volume", volumeLevel);
            _dataContainer.SaveDataChanges();
        }
        
        public AudioMixerGroup FindSubgroup(string subgroupName)
        {
            AudioMixerGroup[] groups = _mixer.FindMatchingGroups(string.Empty);
    
            foreach (AudioMixerGroup group in groups)
            {
                AudioMixerGroup[] subGroups = group.audioMixer.FindMatchingGroups(group.name);
                foreach (AudioMixerGroup subGroup in subGroups)
                {
                    if (subGroup.name == subgroupName)
                        return subGroup;
                }
            }
            return null;
        }

        public void OnGameRan()
        {
            SwitchSnapshot(GlobalConstants.RUNNING_SNAPSHOT);
        }

        public void OnGamePaused()
        {
            SwitchSnapshot(GlobalConstants.PAUSE_SNAPSHOT);
        }
    }
}