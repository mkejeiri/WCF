using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace WindowsHost
{
    public partial class Form1 : Form
    {
        private ServiceHost host; 
        public Form1()
        {
            InitializeComponent();
            host = new ServiceHost(typeof(HelloService.HelloService));
            host.Open();
            btnStart.Enabled = false;
            BtnStop.Enabled = true;
            lblMessage.Text = "The service started @ " + DateTime.Now;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(HelloService.HelloService));
            host.Open();
            btnStart.Enabled = false;
            BtnStop.Enabled = true;
            lblMessage.Text = "The service started @ " + DateTime.Now;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (host !=null)
            {
                host.Close();
                lblMessage.Text = "The service stopped @ " + DateTime.Now;
                btnStart.Enabled = true;
                BtnStop.Enabled = false;
            }            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            host.Close();
        }
    }
}
