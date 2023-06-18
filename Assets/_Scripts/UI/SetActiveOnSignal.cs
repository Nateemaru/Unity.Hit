using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using Sirenix.Utilities;
using UnityEngine;

namespace _Scripts.UI
{
    public class SetActiveOnSignal : MonoBehaviour, IGameWinSubscriber,
                                                    IGameLoseSubscriber,
                                                    IGamePauseSubscriber,
                                                    IGameRunSubscriber
    {
        [SerializeField] private bool _toggleToActive = true;
        
        [SerializeField] private GameObject[] _onRunning;
        [SerializeField] private GameObject[] _onWin;
        [SerializeField] private GameObject[] _onLose;
        [SerializeField] private GameObject[] _onGamePause;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        private void UpdateActivity(GameObject[] parent)
        {
            if (parent.IsNullOrEmpty()) 
                return;
            
            foreach (GameObject o in parent)
            {
                if (o == null)
                    continue;
                
                o.SetActive(_toggleToActive);
            }
        }

        public void OnGameWon()
        {
            UpdateActivity(_onWin);
        }

        public void OnGameLost()
        {
            UpdateActivity(_onLose);
        }

        public void OnGamePaused()
        {
            UpdateActivity(_onGamePause);
        }

        public void OnGameRan()
        {
            UpdateActivity(_onRunning);
        }
    }
}
