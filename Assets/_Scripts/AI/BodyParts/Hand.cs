using UnityEngine;

namespace _Scripts.AI.BodyParts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Hand : BodyPart
    {
        public override void Punch(Vector3 forceDirection)
        {
            forceDirection.y = 0f;
            forceDirection.Normalize();
            transform.GetComponent<Rigidbody>().AddForce(forceDirection * 20, ForceMode.Impulse);
            
            _targetHealth.ApplyDamage(1);
        }
    }
}