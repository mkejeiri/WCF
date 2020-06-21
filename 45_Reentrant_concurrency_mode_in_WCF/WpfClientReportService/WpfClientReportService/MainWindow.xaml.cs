using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using System.Threading;

namespace WpfClientReportService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class MainWindow : Window, ReportService.IReportServiceCallback
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnProgressReport_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            ReportService.ReportServiceClient client = new ReportService.ReportServiceClient(instanceContext);
            client.ProcessReport();
        }


        public void ReportProgress(int percentageCompleted)
        {
           // txtProgress.Text = percentageCompleted.ToString() + "% completed"; //--> Exception The calling thread cannot access this object because a different thread owns it (CallBack thread try to access the UI Thread)
           // this.Dispatcher.Invoke(() => txtProgress.Text = percentageCompleted.ToString() + "% completed");//Doesn't work because sync and create a deadlock
            this.Dispatcher.InvokeAsync(() => txtProgress.Text = percentageCompleted.ToString() + "% completed"); //subscription to UI dispatcher and Asynch call to delegate which update the Progress.                     
        }
      }
}
