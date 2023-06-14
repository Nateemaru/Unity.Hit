using UnityEngine;

namespace _Scripts.AI.BodyParts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Leg : BodyPart
    {
        public override void Punch(Vector3 forceDirection)
        {
            forceDirection.Normalize();
            transform.GetComponent<Rigidbody>().AddForce(forceDirection * 50, ForceMode.Impulse);
            
            _targetHealth.ApplyDamage(1);
        }
    }
}