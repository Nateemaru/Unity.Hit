using System;
using UnityEngine;

namespace _Scripts.AI.BodyParts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Hand : BodyPart
    {
        public override void Punch(Vector3 forceDirection, Action callback = null)
        {
            base.Punch(forceDirection, callback);
            
            forceDirection.Normalize();
            transform.GetComponent<Rigidbody>().AddForce(forceDirection * 20, ForceMode.Impulse);
            
            _targetHealth.ApplyDamage(1);
        }
    }
}