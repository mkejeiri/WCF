using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using WindowsClientReportService.ServiceReport;
namespace WindowsClientReportService
{
   //[CallbackBehavior(UseSynchronizationContext=false)]
    public partial class Form1 : Form, IReportServiceCallback
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcessReport_Click(object sender, EventArgs e)
        {

            InstanceContext instanceContext = new InstanceContext(this);
            ReportServiceClient client = new ReportServiceClient(instanceContext);
            client.ProgressReport();

        }

        public void Progress(int PercentageCompleted)
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;            
            textBox1.Text = PercentageCompleted.ToString() + " % Completed";
        }


    }
}
