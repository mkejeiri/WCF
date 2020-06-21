using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SampleService
{
    //So, what's happening? Why is the number not incremented beyond 1?
    //The reason for this is simple. We have set instance context mode of the WCF service to PerCall. This means that, every time we call IncrementNumber() method from the client application, 
    //1. A new instance of SimpleService is created
    //2. Private variable _number in the wcf service is initialized to ZERO. The method returns the incremented value 1 to the client and the service instance object is destroyed.
    //3. When a subsequent call is made either from the same client or different client, the above steps are repeated. Hence the number always stays at 1.

    //What are the implications of a PerCall WCF service?
    //1. Better memory usage as service objects are freed immediately after the method call returns
    //2. Concurrency not an issue
    //3. Application scalability is better 
    //4. State not maintained between calls.
    //5. Performance could be an issue as there is overhead involved in reconstructing the service instance state on each and every method call. 
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SampleService : ISampleService
    {
        private int _number;
        public int InCrementNumber()
        {
            _number++;
            return _number;
        }
    }
}
