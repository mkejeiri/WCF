using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WpfClientSimpleService.SimpleService;

namespace WpfClientSimpleService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SimpleServiceClient client;
        private StringBuilder msg = new StringBuilder();
        public MainWindow()
        {
            InitializeComponent();
            client = new SimpleServiceClient();
            listBox.Items.Clear();
        }

        private void btnCheckValue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                msg.AppendLine("Calling service @" + DateTime.Now);
                msg.AppendLine("call IncrementNumber " + client.IncrementNumber().ToString());
                msg.AppendLine("SessionID " + client.InnerChannel.SessionId);

                //lblMessage.Content = "Calling service @" + DateTime.Now;
                //lblMessage.Content += "\n1st call value " + client.IncrementNumber().ToString();
                //lblMessage.Content += "\n2nd call value " + client.IncrementNumber().ToString();
                //lblMessage.Content += "\n3rd call value " + client.IncrementNumber().ToString();
                //lblMessage.Content += "\n4th call value " + client.IncrementNumber().ToString();
                //lblMessage.Content += "\n\n\nSessionID " + client.InnerChannel.SessionId;
                //lblMessage.Content = msg.ToString();
                listBox.Items.Add(msg.ToString());
            }
            catch (CommunicationException)
            {
                if (client.InnerChannel.State == CommunicationState.Faulted  )
                {
                    msg.AppendLine("\nSession timed out. Your existing session will be lost. A new session will be created!");
                    client = new SimpleServiceClient();


                }
            }
        }
    }
}
