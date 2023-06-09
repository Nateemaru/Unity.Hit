using System;
using _Scripts.Gameplay.FSM;
using PathCreation;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerController : MonoBehaviour, ITarget
    {
        private FSM _fsm;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _fsm = new FSM();
        }

        public Transform GetTarget()
        {
            return transform;
        }
    }
}
