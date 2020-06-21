using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace WindowsClientCalculator
{
    public partial class Form1 : Form
    {
        private CalculatorService.CalculatorServiceClient client;
        public Form1()
        {

            InitializeComponent();
            client = new CalculatorService.CalculatorServiceClient();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            try
            {
                lblResult.Text = client.Divide(Convert.ToInt32(TxtNumerator.Text), Convert.ToInt32(txtDenomirator.Text)).ToString();
            }
            catch (FaultException faultException)
            {
                lblResult.Text = faultException.Message;
            }

        }

        private void btnNewProxy_Click(object sender, EventArgs e)
        {
            client = new CalculatorService.CalculatorServiceClient();
        }
    }
}
