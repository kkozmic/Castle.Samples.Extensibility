using System.Windows.Forms;
using Castle.Windsor;
using EventBrokerSample.UI.Installers;
using EventBrokerSample.UI.UI;

namespace EventBrokerSample.UI
{
    internal class WindsorContext : ApplicationContext
    {
        private readonly IWindsorContainer container;

        public WindsorContext()
        {
            container = new WindsorContainer().Install(new EventBrokerInstaller(), new FormsInstaller());
            MainForm = container.Resolve<ApplicationShell>();
        }

        protected override void Dispose(bool disposing)
        {
            container.Dispose();
            base.Dispose(disposing);
        }
    }
}