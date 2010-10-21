using System.Windows.Forms;

namespace EventBrokerSample.UI.UI
{
    public partial class ApplicationShell : Form
    {
        public ApplicationShell(Input input, Output output)
        {
            InitializeComponent();

            flowLayoutPanel1.Controls.Add(input);
            flowLayoutPanel1.Controls.Add(output);
        }
    }
}