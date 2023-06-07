using System;
using Animancer;
using UnityEngine;

namespace _Scripts
{
    public class RagdollTransition : MonoBehaviour
    {
        [SerializeField] private AnimationClip _clip;
        private AnimancerComponent _animancer;
        private RagdollEnabler _ragdollEnabler;

        private void Start()
        {
            _animancer = GetComponent<AnimancerComponent>();
            _ragdollEnabler = GetComponent<RagdollEnabler>();
        }
    }
}