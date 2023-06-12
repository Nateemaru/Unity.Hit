namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IPlayerMoveSubscriber : IGlobalSubscriber
    {
        public void OnPlayerMove();
    }
}