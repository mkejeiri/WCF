using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;

namespace WindowsServiceHost
{
    public partial class HelloServiceHost : ServiceBase
    {
        private ServiceHost host;
        public HelloServiceHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
             host = new ServiceHost(typeof(HelloService.HelloService));
            host.Open();

        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
