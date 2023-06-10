using System;
using _Scripts.CodeSugar;
using PathCreation;
using UnityEngine;

namespace _Scripts.Player
{
    public class PathFollow : MonoBehaviour
    {
        [SerializeField] private PathCreator _pathCreator;
        [SerializeField] private EndOfPathInstruction _endOfPathInstruction;
        [SerializeField] private float _speed = 5;
        private float _distanceTravelled;

        void Update()
        {
            if (_pathCreator != null)
            {
                _distanceTravelled += _speed * Time.deltaTime;
                transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
            }
        }

        public void SetSpeed(float speed) => _speed = speed;
    }
}