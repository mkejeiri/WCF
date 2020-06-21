using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace Client
{
    public partial class Form1 : Form
    {

        HelloService.HelloServiceClient client;

        public Form1()
        {
            InitializeComponent();
            client = new HelloService.HelloServiceClient();
        }

        private void btnGetMessage_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(client.GetMessageWithoutAnyProtection());
        }

        private void btnGetSignedMessageWithoutEncryption_Click(object sender, EventArgs e)
        {

           
            MessageBox.Show(client.GetSignedMessage());
        }

        private void btnGetSignedMessageWithEncryption_Click(object sender, EventArgs e)
        {

            MessageBox.Show(client.GetSignedMessageAndEncrypted());
        }
    }
}
