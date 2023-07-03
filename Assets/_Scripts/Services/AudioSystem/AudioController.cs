using System;
using _Scripts.Services.Database;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace _Scripts.Services.AudioSystem
{
    public class AudioController : IInitializable
    {
        private AudioMixer _mixer;
        private const float _SNAPSHOT_TRANSITION_TIME = 0.1f;
        private IDataReader _dataReader;

        public AudioController(IDataReader dataReader)
        {
            _dataReader = dataReader;
            _mixer = Resources.Load<AudioMixer>("AudioMixer");
        }

        public void Initialize()
        {
        }

        public void SwitchSnapshot(string snapshotName)
        {
            _mixer.FindSnapshot(snapshotName).TransitionTo(_SNAPSHOT_TRANSITION_TIME);
        }

        public void ChangeVolume(float volumeLevel)
        {
            _mixer.SetFloat("Volume", volumeLevel);
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
    }
}