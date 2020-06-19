using System;
using System.Windows.Forms;
using WinClient.HelloServiceRef;

namespace WinClient
{
    public partial class WinClient : Form
    {
        public WinClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HelloServiceRef.HelloServiceClient client = new HelloServiceClient("NetTcpBinding_IHelloService");
            label1.Text = client.GetMessage(textBox1.Text);
        }
    }
}
