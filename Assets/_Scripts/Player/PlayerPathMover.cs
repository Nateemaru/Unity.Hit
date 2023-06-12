using System;
using _Scripts.CodeSugar;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using PathCreation;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerPathMover : MovementBase
    {
        [SerializeField] private PathCreator _pathCreator;
        [SerializeField] private EndOfPathInstruction _endOfPathInstruction;
        private float _distanceTravelled;

        void Update()
        {
            if (_pathCreator != null)
            {
                _distanceTravelled += _speed * Time.deltaTime;
                transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
            }
        }

        public override void SetSpeed(float value)
        {
            _speed = value;
        }
    }
}