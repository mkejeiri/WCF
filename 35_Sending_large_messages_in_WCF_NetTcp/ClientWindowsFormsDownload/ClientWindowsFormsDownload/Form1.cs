using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using ClientWindowsFormsDownload.DownloadService;

namespace ClientWindowsFormsDownload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DownloadServiceClient client = new DownloadServiceClient();
            MyFile file = client.Download();           
            System.IO.File.WriteAllBytes(@"C:\PGM\Executables\" + file.Name, file.content);
            MessageBox.Show(file.Name + " downloaded");
        }
    }
}
