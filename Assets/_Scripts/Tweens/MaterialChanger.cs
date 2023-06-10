using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.Tweens
{
    public class MaterialChanger : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Material _targetMaterial;
        [SerializeField] private List<Renderer> _renderers = new List<Renderer>();

        

        [Button("Reset renderers")]
        private void Reset()
        {
            _renderers.Clear();
            _renderers = GetComponentsInChildren<Renderer>().ToList();
        }

        private void Start()
        {
            _target ??= transform;
        }


        public void Play()
        {
            Kill();

            foreach (var renderer in _renderers)
                renderer.material = _targetMaterial;
        }

        public void Kill()
        {
            
        }
    }
}