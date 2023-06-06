namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IGameLoseSubscriber : IGlobalSubscriber
    {
        public void OnGameLost();
    }
}