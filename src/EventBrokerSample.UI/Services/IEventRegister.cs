namespace EventBrokerSample.UI.Services
{
    public interface IEventRegister
    {
        void Register(object listener);
        void Unregister(object listener);
    }
}