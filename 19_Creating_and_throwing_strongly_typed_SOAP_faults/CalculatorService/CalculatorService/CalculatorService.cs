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

        public int Divide(int Numerator, int Denominator)
        {
            Console.WriteLine("Divide's been remotely called ");
            try
            {
                return Numerator / Denominator;
            }
            catch (DivideByZeroException ex)
            {
                DividedByZeroFault dividedByZeroFault = new DividedByZeroFault();
                dividedByZeroFault.error = ex.Message;
                dividedByZeroFault.details = "Denominator cannot be divided by ZERO";
                throw new FaultException<DividedByZeroFault>(dividedByZeroFault);
            }

            //if (Denominator == 0)
            //{
            //    ////throw new DivideByZeroException(); it's a .net exception , (1) cause the channel to turn down and (2) only understood by .Net plateform (Java plateform will have PB to understand this EX)
            //    ////Better to use exception
            //    //throw new FaultException("Denominator cannot be divided by ZERO", new FaultCode("DivideByZeroFault"));
            //}

        }
    }
}
