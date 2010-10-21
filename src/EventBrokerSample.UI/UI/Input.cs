using System;
using System.Threading;
using System.Windows.Forms;
using EventBrokerSample.UI.Services;

namespace EventBrokerSample.UI.UI
{
    public partial class Input : UserControl
    {
        private readonly IEventPublisher publisher;

        public Input(IEventPublisher publisher)
        {
            this.publisher = publisher;
            InitializeComponent();
        }

        private void Publisher_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(state => publisher.Publish(new DateTimeMessage(DateTime.Now)));
        }
    }
}