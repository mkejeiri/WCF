using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DownloadHost
{
    class Program
    {
        static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(DownloadService.DownloadService)))
            {
                host.Open();
                Console.WriteLine("Service Started @ " + DateTime.Now);
                Console.ReadLine();
            }
        }
    }
}
