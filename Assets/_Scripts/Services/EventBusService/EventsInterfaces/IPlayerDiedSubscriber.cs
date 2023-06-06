namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IPlayerDieSubscriber : IGlobalSubscriber
    {
        public void OnPlayerDied();
    }
}