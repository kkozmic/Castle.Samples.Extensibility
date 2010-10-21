using Castle.Core;
using EventBrokerSample.UI.Services;

namespace EventBrokerSample.UI.Infrastructure
{
    public class UnregisterWithEventBroker : IDecommissionConcern
    {
        private readonly IEventRegister broker;

        public UnregisterWithEventBroker(IEventRegister broker)
        {
            this.broker = broker;
        }

        public void Apply(ComponentModel model, object component)
        {
            broker.Unregister(component);
        }
    }
}