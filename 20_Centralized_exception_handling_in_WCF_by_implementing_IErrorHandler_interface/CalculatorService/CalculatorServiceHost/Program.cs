using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using CalculatorService;

namespace CalculatorServiceHost
{
    class Program
    {
        static void Main()
        {

            using (ServiceHost host = new ServiceHost(typeof(CalculatorService.CalculatorService)))
            {
                host.Open();
                Console.WriteLine("Service Host started @ : " + DateTime.Now);
                 Console.WriteLine("Service Host's Running @ : " + host.BaseAddresses[0].ToString());
                Console.ReadLine();
            }

        }
    }
}
