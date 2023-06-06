namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IGameWinSubscriber : IGlobalSubscriber
    {
        public void OnGameWon();
    }
}