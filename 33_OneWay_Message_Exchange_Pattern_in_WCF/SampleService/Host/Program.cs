using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Host
{
    class Program
    {
        static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(SampleService.SampleService)))
            {
                host.Open();
                Console.WriteLine("Server started @ " + DateTime.Now);
                Console.ReadLine();
            }
        }
    }
}
