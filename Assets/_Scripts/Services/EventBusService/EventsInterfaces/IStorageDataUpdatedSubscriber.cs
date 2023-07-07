namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IStorageDataUpdatedSubscriber : IGlobalSubscriber
    {
        public void OnDataUpdated();
    }
}