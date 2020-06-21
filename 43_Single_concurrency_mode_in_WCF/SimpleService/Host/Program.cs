using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace Host
{
    class Program
    {
        static void Main()
        {

            using (ServiceHost host = new ServiceHost(typeof(SimpleService.SimpleService)))
            {
                host.Open();
                Console.WriteLine("Service started @ " + DateTime.Now.ToString());
                Console.ReadLine();                
            }
        }
    }
}
