using Castle.Core;
using EventBrokerSample.UI.Services;

namespace EventBrokerSample.UI.Infrastructure
{
    public class RegisterWithEventBroker : ICommissionConcern
    {
        private readonly IEventRegister broker;

        public RegisterWithEventBroker(IEventRegister broker)
        {
            this.broker = broker;
        }

        public void Apply(ComponentModel model, object component)
        {
            broker.Register(component);
        }
    }
}