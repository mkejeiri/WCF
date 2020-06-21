using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace SimpleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SimpleService" in both code and config file together.
    [ServiceBehavior(ConcurrencyMode= ConcurrencyMode.Multiple,InstanceContextMode= InstanceContextMode.Single)]
    public class SimpleService : ISimpleService
    {

      
        public List<int> GetEvenNumbers()
        {
            Console.WriteLine("Thread {0} started processing GetEvenNumbers at {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            Thread.Sleep(5000);
            List<int> listEvenNumbers = new List<int>();
            for (int i = 0; i <=10; i++)
            {                if (i%2==0)
                {
                    listEvenNumbers.Add(i);
                }               
            }
            Console.WriteLine("Thread {0} Completed processing GetEvenNumbers at {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            return listEvenNumbers;
        }

        public List<int> GetOddNumbers()
        {

            Console.WriteLine("Thread {0} started processing GetOddNumbers at {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            Thread.Sleep(5000);
            List<int> listOddNumbers = new List<int>();
            for (int i = 0; i <= 10; i++)
            {
                if (i % 2 != 0)
                {
                    listOddNumbers.Add(i);

                }

            }
            Console.WriteLine("Thread {0} Completed processing GetOddNumbers at {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            return listOddNumbers;
        }
    }
}
