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

namespace WindowsClientReportService
{
    [CallbackBehavior(UseSynchronizationContext=false)]
    public partial class Form1 : Form, ReportService.IReportServiceCallback
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProgressReport_Click(object sender, EventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            ReportService.ReportServiceClient client = new ReportService.ReportServiceClient(instanceContext);
            client.ProcessReport();
        }


        public void ReportProgress(int percentageCompleted)
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;
            textBox1.Text = percentageCompleted.ToString() + "% completed";
           // this.BeginInvoke(new MethodInvoker (()=>{ textBox1.Text = percentageCompleted.ToString() + "% completed"; }));

           //Invoke(new MethodInvoker(delegate
           // {
           //     textBox1.Text = percentageCompleted.ToString() + "% completed";
           // }));

            //BeginInvoke(new MethodInvoker(delegate
            //{
            //    textBox1.Text = percentageCompleted.ToString() + "% completed";
            //}));          

            //this.SetText(percentageCompleted.ToString() + "% completed");

        }

        //delegate void SetTextCallback(string text);
        //private void SetText(string text)
        //{
        //    // InvokeRequired required compares the thread ID of the
        //    // calling thread to the thread ID of the creating thread.
        //    // If these threads are different, it returns true.
        //    if (this.textBox1.InvokeRequired)
        //    {
        //        SetTextCallback d = new SetTextCallback(SetText);
        //        this.Invoke(d, new object[] { text });
        //    }
        //    else
        //    {
        //        this.textBox1.Text = text;
        //    }
        //}

        
    }
}
