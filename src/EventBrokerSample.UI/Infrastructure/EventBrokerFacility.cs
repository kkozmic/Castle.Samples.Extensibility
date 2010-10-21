using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using EventBrokerSample.UI.Services;

namespace EventBrokerSample.UI.Infrastructure
{
    public class EventBrokerFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(Component
                                .For<SynchronizationContext>()
                                .ImplementedBy<WindowsFormsSynchronizationContext>()
                                .LifeStyle.Singleton,
                            Component
                                .For<IEventPublisher, IEventRegister>()
                                .ImplementedBy<EventBroker>()
                                .DependsOn(new { listeners = new List<object>()})
                                .LifeStyle.Singleton);

            Kernel.ComponentModelBuilder.AddContributor(new EventBrokerContributor());
        }
    }
}