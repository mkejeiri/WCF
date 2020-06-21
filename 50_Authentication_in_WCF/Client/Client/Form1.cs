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

        SimpleService.SimpleServiceClient client;

        public Form1()
        {
            InitializeComponent();
            client = new SimpleService.SimpleServiceClient();
        }

        private void btnCallService_Click(object sender, EventArgs e)
        {
            MessageBox.Show(client.GetUserName());
        }
    }
}
