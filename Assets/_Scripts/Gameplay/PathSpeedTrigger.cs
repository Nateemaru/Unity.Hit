using System;
using _Scripts.Player;
using PathCreation;
using UnityEngine;

namespace _Scripts.Gameplay
{
    public class PathSpeedTrigger : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PathFollow follow))
                follow.SetSpeed(_speed);
        }
    }
}