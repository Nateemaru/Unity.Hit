namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IGamePauseSubscriber : IGlobalSubscriber
    {
        
        public void OnGamePaused();
    }
}