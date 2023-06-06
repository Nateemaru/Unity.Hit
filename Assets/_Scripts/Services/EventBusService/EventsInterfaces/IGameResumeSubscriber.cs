namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IGameResumeSubscriber : IGlobalSubscriber
    {
        public void OnGameResumed();
    }
}