using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace EventBrokerSample.UI.Installers
{
    public class FormsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes
                                   .FromAssembly(GetType().Assembly)
                                   .BasedOn<Form>()
                                   .Configure(c => c.Named(c.Implementation.Name).LifeStyle.Transient)
                                   .BasedOn<UserControl>()
                                   .Configure(c => c.Named(c.Implementation.Name).LifeStyle.Transient));
        }
    }
}