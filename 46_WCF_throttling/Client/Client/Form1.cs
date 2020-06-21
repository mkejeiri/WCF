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
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartMultiThread_Click(object sender, EventArgs e)
        {

            SimpleService.SimpleServiceClient client = new SimpleService.SimpleServiceClient();

            for (int i = 0; i < 100; i++)
            {
                Thread thread = new Thread(client.DoWork);
                thread.Start();
            }
        }
    }
}
