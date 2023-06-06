namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IGameRunSubscriber : IGlobalSubscriber
    {
        public void OnGameRan();
    }
}