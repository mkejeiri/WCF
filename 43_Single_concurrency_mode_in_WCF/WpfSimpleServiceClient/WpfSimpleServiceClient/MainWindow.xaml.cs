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
using System.ComponentModel;

namespace WpfSimpleServiceClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker bgw1;
        BackgroundWorker bgw2;
        SimpleService.SimpleServiceClient client;

        public MainWindow()
        {
            InitializeComponent();
            client = new SimpleService.SimpleServiceClient();
            bgw1 = new BackgroundWorker();
            bgw2 = new BackgroundWorker();
            bgw1.DoWork += bgw1_DoWork;
            bgw1.RunWorkerCompleted += bgw1_RunWorkerCompleted;
            bgw2.DoWork += bgw2_DoWork;
            bgw2.RunWorkerCompleted += bgw2_RunWorkerCompleted;

        }


        private void btnGetEvenNumbers_Click(object sender, RoutedEventArgs e)
        {
            if (!bgw1.IsBusy)
            {
                bgw1.RunWorkerAsync();
            }

        }

        private void btnGetOddNumbers_Click(object sender, RoutedEventArgs e)
        {
            if (!bgw2.IsBusy)
            {
                bgw2.RunWorkerAsync();
            }

        }

        void bgw1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = client.GetEvenNumbers();
        }

        void bgw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBoxEvenNumbers.ItemsSource = (int[])e.Result;
        }


        void bgw2_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = client.GetOddNumbers();
        }

        void bgw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBoxOddNumbers.ItemsSource = (int[])e.Result;
        }

        private void btnClearResult_Click(object sender, RoutedEventArgs e)
        {
            listBoxEvenNumbers.ItemsSource = null;
            listBoxOddNumbers.ItemsSource = null;

        }
    }
}
