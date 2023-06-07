using UnityEngine;

namespace _Scripts
{
    public class LookAtCamera : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.LookAt(new Vector3(transform.position.x, Camera.main.transform.transform.position.y,
                Camera.main.transform.position.z));
            transform.Rotate(0, 180, 0);
        }
    }
}
