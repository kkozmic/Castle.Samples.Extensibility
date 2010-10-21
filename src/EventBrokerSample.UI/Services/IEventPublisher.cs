namespace EventBrokerSample.UI.Services
{
    public interface IEventPublisher
    {
        void Publish<T>(T message);
    }
}