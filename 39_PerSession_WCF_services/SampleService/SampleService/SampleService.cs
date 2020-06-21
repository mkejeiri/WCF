using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SampleService
{
    //httpBinding support PerCall only
    //What are the implications of a PerSession WCF service?
    //1. State maintained between calls.
    //2. Greater memory consumption as service objects remain in memory until the client session times out. This negatively affects application scalability.
    //3. Concurrency is an issue for multi-threaded clients

    //Common interview question: How do you design a WCF service? Would you design it as a PerCall service or PerSession service?
    //This is a tricky question. We can't blindly say one is better over the other. 
    //1. PerCall and PerSession services have different strengths and weaknesses. 
    //2. If you prefer using object oriented programming style, then PerSession is your choice. On the other hand if you prefer SOA (Service Oriented Architecture) style, then PerCall is your choice.
    //3. In general, all things being equal, the trade-off is performance v/s scalability. PerSession services perform better because the service object does not have to be instantiated on subsequent requests. 
    //PerCall services scale better because the service objects are destroyed immediately after the method call returns.
    //So the decision really depends on the application architecture, performance & scalability needs. 
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
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
