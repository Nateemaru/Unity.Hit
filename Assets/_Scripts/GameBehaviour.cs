using _Scripts.Services.PauseHandlerService;
using UnityEngine;

namespace _Scripts
{
    public class GameBehaviour : MonoBehaviour, IPauseHandler
    {
        public bool IsPaused { get; private set; }
        
        public virtual void SetPause(bool isPaused)
        {
            IsPaused = isPaused;
        }
    }
}