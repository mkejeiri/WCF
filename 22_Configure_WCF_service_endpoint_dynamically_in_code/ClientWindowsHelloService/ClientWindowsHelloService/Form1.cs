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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHello_Click(object sender, EventArgs e)
        {
            HelloServiceClient client = new HelloServiceClient();
            lblMessage.Text = client.Hello(txtName.Text);
        }
    }
}
