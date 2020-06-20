using System;
using System.ServiceModel;
using EmployeeServiceNamespace;

namespace EmployeeServiceHost
{
    class Program
    {
        static void Main()
        {
            //Don't forget to add System.ServiceModel assembly!
            using (ServiceHost host = new ServiceHost(
                //note we are getting the type of the class that implements the contacts (interfaces)
                //and not the contract itself
                serviceType: typeof(EmployeeService)))
            {

                host.Open();
                Console.WriteLine("Employee Service Host Started @ " + DateTime.Now);
                Console.ReadLine();
            }
        }
    }
}
