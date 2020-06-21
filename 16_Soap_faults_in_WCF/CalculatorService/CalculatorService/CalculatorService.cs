using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalculatorService" in both code and config file together.
    //[ServiceBehavior(IncludeExceptionDetailInFaults = true)] // use config much better to avoid redeployment...
    public class CalculatorService : ICalculatorService
    {
      
        public int Divide(int Numerator, int Denomirator)
        {
            Console.WriteLine("Divide's been remotely called ");
            return Numerator / Denomirator;
        }
    }
}
