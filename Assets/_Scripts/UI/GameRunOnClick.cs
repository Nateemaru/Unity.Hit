using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;

namespace _Scripts.UI
{
    public class GameRunOnClick : ButtonBase
    {
        protected override void OnClick()
        {
            EventBus.RaiseEvent<IGameRunSubscriber>(item => item.OnGameRan());;
        }
    }
}
