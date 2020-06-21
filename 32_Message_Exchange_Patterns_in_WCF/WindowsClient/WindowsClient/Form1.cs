using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsClient.SampleService;

namespace WindowsClient
{
    public partial class Form1 : Form
    {
        private SampleServiceClient client;
        public Form1()
        {
            InitializeComponent();
            client = new SampleServiceClient();
        }

        private void BtnRequestReplyOperation_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add("Request-Reply Operation Started @ " + DateTime.Now.ToString());
                BtnRequestReplyOperation.Enabled = false;
                listBox1.Items.Add(client.RequestReplyOperation());
                BtnRequestReplyOperation.Enabled = true;
                listBox1.Items.Add("Request-Reply Operation Completed @ " + DateTime.Now.ToString());
                listBox1.Items.Add("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRequestReplyOperationThrowsException_Click(object sender, EventArgs e)
        {
            try
            {
    listBox1.Items.Add("RequestReplyOperation_ThrowsException Started @ " + DateTime.Now.ToString());
            BtnRequestReplyOperationThrowsException.Enabled = false;
            listBox1.Items.Add(client.RequestReplyOperation_ThrowsException());
            
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                         
             
            }
            finally 
            {
                BtnRequestReplyOperationThrowsException.Enabled = true;
                listBox1.Items.Add("RequestReplyOperation_ThrowsException Completed @ " + DateTime.Now.ToString());
                listBox1.Items.Add("");  
            }

            
        

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
