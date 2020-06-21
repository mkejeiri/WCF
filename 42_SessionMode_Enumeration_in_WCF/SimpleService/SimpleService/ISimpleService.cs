using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // binding and session mode enumeration
    //[ServiceContract(SessionMode=SessionMode.Allowed)]
    [ServiceContract(SessionMode = SessionMode.Required)]
    //[ServiceContract(SessionMode = SessionMode.NotAllowed)]

    public interface ISimpleService
    {
        [OperationContract]
        int IncrementNumber();
    }
}
