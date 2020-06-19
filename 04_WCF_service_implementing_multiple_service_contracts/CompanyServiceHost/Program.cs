using System;
using System.ServiceModel;

namespace CompanyServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(
                //note we are getting the type of the class that implements the contacts (interfaces)
                //and not the contract itself
                typeof(CompanyServiceNamespace.CompanyService)))
            {
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now);
                Console.ReadLine();
            }
        }
    }
}
