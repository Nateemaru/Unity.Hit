namespace _Scripts.Services.EventBusService.EventsInterfaces
{
    public interface IInputTriggerSubscriber : IGlobalSubscriber
    {
        public void OnInputTriggered();
    }
}