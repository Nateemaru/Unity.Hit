using System;
using _Scripts.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.AI.BodyParts
{
    public class BodyPartsHandler : MonoBehaviour
    {
        [SerializeField] private HealthComponent _targetHealth;
        [SerializeField] private BodyPart[] _bodyParts;

        private void Start()
        {
            if(_bodyParts.Length == 0)
                Reset();

            if (_targetHealth != null)
            {
                for (int i = 0; i < _bodyParts.Length; i++)
                    _bodyParts[i].SetTargetHealth(_targetHealth);
            }
        }

        [Button]
        private void Reset()
        {
            _bodyParts = transform.GetComponentsInChildren<BodyPart>();
        }
    }
}