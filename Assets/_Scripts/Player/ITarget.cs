using System;
using Sirenix.Serialization;
using UnityEngine;

namespace _Scripts.Player
{
    public interface ITarget
    {
        public Transform GetTarget();
    }
}