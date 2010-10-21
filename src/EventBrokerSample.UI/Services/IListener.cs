namespace EventBrokerSample.UI.Services
{
    public interface IListener<T>
    {
        void Handle(T message);
    }
}