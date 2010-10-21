using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;
using EventBrokerSample.UI.Services;

namespace EventBrokerSample.UI.Infrastructure
{
    public class EventBrokerContributor : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            if (model.ImplementationIsAListener() == false) return;

            var broker = kernel.Resolve<IEventRegister>();
            model.Lifecycle.Add(new RegisterWithEventBroker(broker));
            model.Lifecycle.Add(new UnregisterWithEventBroker(broker));
        }
    }
}