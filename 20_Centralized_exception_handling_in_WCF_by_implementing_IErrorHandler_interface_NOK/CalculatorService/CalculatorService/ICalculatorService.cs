using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
   //Step 3: Decorate CalculatorService class in CalculatorService.cs file with GlobalErrorHandlerBehaviourAttribute.
    [GlobalErrorHandlerBehaviour(typeof(GlobalErrorHandler))]
    public interface ICalculatorService
    {
        [OperationContract]
        [FaultContract(typeof(DividedByZeroFault))]
        int Divide(int Numerator, int Denomirator);
    }
}
