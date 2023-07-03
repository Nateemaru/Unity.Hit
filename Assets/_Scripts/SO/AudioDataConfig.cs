using System;
using System.Collections.Generic;
using _Scripts.AudioSystem;
using UnityEngine;

namespace _Scripts.SO
{
    [Serializable]
    public enum SoundType
    {
        Sfx,
        UI,
        Background,
    }
    
    [CreateAssetMenu(fileName = "AudioDataConfig", menuName = "SO/Audio Data Config")]
    public class AudioDataConfig : ScriptableObject
    {
        [SerializeField] private List<Sound> _sounds = new List<Sound>();
        [SerializeField] private SoundType _type;

        public List<Sound> Sounds => _sounds;

        public SoundType Type => _type;
    }
}