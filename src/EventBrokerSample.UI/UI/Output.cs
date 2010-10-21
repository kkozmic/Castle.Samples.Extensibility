using System;
using System.Windows.Forms;
using EventBrokerSample.UI.Services;

namespace EventBrokerSample.UI.UI
{
    public partial class Output : UserControl, IListener<DateTimeMessage>
    {
        public Output()
        {
            InitializeComponent();
        }

        void IListener<DateTimeMessage>.Handle(DateTimeMessage message)
        {
            Result.Text = string.Format("The messages was sent at {0:F}", message.DateAndTime);
        }
    }
}