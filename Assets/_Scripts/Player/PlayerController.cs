using _Scripts.Gameplay.FSM;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerController : MonoBehaviour
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
    }
}
