using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace SampleServiceHost
{
    class Program
    {
        static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(SampleService.SampleService)))
            {
                host.Open();
                Console.WriteLine("Service Started @ " + DateTime.Now);
                Console.ReadLine();                               
            }
        }
    }
}
