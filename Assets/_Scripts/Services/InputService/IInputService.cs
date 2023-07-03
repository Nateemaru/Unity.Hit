using System;
using UnityEngine;

namespace _Scripts.Services.InputService
{
    public interface IInputService
    {
        public Action<Vector3> OnTouched { get; set; }
        public void Reset();
    }
}