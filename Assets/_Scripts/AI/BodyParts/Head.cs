using UnityEngine;

namespace _Scripts.AI.BodyParts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Head : MonoBehaviour, IBodyPart
    {
        public void Punch()
        {
        }
    }
}