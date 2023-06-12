namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IPlayerJumpSubscriber : IGlobalSubscriber
    {
        public void OnPlayerJumped();
    }
}