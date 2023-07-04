using System;
using UnityEngine;

namespace _Scripts.SO
{
    [Serializable]
    public class WeaponMetaData
    {
        [SerializeField] private string _name;
        [SerializeField] private bool _isAvailable;
        [SerializeField] private int _cost;

        public string Name => _name;

        public bool IsAvailable => _isAvailable;

        public int Cost => _cost;
    }
}