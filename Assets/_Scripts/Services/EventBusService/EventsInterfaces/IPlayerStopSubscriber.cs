namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IPlayerStopSubscriber : IGlobalSubscriber
    {
        public void OnPlayerStopped();
    }
}