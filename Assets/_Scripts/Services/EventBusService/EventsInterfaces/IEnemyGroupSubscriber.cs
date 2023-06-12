namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IEnemyGroupSubscriber : IGlobalSubscriber
    {
        public void OnGroupIsEmpty();
    }
}