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
using WpfSampleService.SampleService;

namespace WpfSampleService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SampleService.SampleServiceClient client;

        public MainWindow()
        {
            InitializeComponent();
            client = new SampleService.SampleServiceClient();
        }

        private void BtnCheckValue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblMessage.Content = "Service call @ " + DateTime.Now.ToLongTimeString();
                lblMessage.Content += "\nCurrent value after 1st call is : " + client.InCrementNumber().ToString();
                lblMessage.Content += "\nCurrent value after 2nd call is : " + client.InCrementNumber().ToString();
                lblMessage.Content += "\nCurrent value after 3th call is : " + client.InCrementNumber().ToString();
            }
            catch (CommunicationException)
            {
                if (client.State == CommunicationState.Faulted)
                {
                    string message = "Session time out. Your existing session will be lost. A new session will be created";
                    MessageBox.Show(message);
                    client = new SampleService.SampleServiceClient();
                }
            }

        }
    }
}
