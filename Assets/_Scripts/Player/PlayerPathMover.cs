using System;
using _Scripts.CodeSugar;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using _Scripts.Services.PauseHandlerService;
using PathCreation;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public class PlayerPathMover : MovementBase
    {
        [SerializeField] private PathCreator _pathCreator;
        [SerializeField] private EndOfPathInstruction _endOfPathInstruction;
        private float _distanceTravelled;

        [Inject]
        private void Construct(PauseHandler pauseHandler)
        {
            pauseHandler.Register(this);
        }

        void Update()
        {
            if (_pathCreator != null && !IsPaused)
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