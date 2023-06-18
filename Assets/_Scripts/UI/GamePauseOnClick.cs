using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;

namespace _Scripts.UI
{
    public class GamePauseOnClick : ButtonBase
    {
        protected override void OnClick()
        {
            EventBus.RaiseEvent<IGamePauseSubscriber>(item => item.OnGamePaused());;
        }
    }
}
