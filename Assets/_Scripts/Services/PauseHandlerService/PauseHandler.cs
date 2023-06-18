using System.Collections.Generic;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;

namespace _Scripts.Services.PauseHandlerService
{
    public class PauseHandler : IPauseHandler, IGameRunSubscriber, IGamePauseSubscriber
    {
        private List<IPauseHandler> _pauseHandlers = new List<IPauseHandler>();

        public bool IsPaused { get; private set; }

        public PauseHandler()
        {
            EventBus.Subscribe(this);
        }

        public void Register(IPauseHandler handler)
        {
            if (_pauseHandlers.Contains(handler))
                return;
            
            _pauseHandlers.Add(handler);
        }

        public void Unregister(IPauseHandler handler)
        {
            if (!_pauseHandlers.Contains(handler))
                return;

            _pauseHandlers.Remove(handler);
        }

        public void SetPause(bool isPaused)
        {
            IsPaused = isPaused;
            foreach (var handler in _pauseHandlers)
            {
                if (handler == null && _pauseHandlers.Contains(handler))
                {
                    _pauseHandlers.Remove(handler);
                    continue;
                }
                handler.SetPause(IsPaused);
            }
        }

        public void OnGameRan()
        {
            SetPause(false);
        }

        public void OnGamePaused()
        {
            SetPause(true);
        }
    }
}