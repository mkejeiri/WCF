using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientWindowsHelloService.HelloService;

namespace ClientWindowsHelloService
{
    public partial class Form1 : Form
    {
        private HelloServiceClient client;
        public Form1()
        {
            InitializeComponent();
            client = new HelloServiceClient();
        }

        private void btnHello_Click(object sender, EventArgs e)
        {
            lblMessage.Text = client.Hello(txtName.Text);
        }
    }
}
