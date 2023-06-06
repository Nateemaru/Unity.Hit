namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface INoEnemiesSubscriber : IGlobalSubscriber
    {
        public void OnNoEnemies();
    }
}