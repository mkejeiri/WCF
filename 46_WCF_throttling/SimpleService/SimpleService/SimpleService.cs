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
    [ServiceBehavior(InstanceContextMode= InstanceContextMode.PerCall, ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class SimpleService : ISimpleService
    {
        public void DoWork()
        {

            Thread.Sleep(100);
            Console.WriteLine("Thread {0} is processing request @ {1}",Thread.CurrentThread.ManagedThreadId,DateTime.Now.ToString());
        }
    }
}
