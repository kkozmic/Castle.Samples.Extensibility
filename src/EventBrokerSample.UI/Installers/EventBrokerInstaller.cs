using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EventBrokerSample.UI.Infrastructure;

namespace EventBrokerSample.UI.Installers
{
    public class EventBrokerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<EventBrokerFacility>();
        }
    }
}