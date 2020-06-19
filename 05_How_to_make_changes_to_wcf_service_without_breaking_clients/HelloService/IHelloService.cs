using System.ServiceModel;

namespace HelloServiceNamespace
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHelloService" in both code and config file together.
    //PortType in WSDL will keep the contract name of "IHelloService" so the client won't break
    [ServiceContract(Name = "IHelloService")]
    public interface IHelloServiceChanged
    {
        //PortType=>operation in WSDL will keep the OperationContract name of "GetMessage" so the client won't break!
        [OperationContract(Name = "GetMessage")]
        string GetMessageChanged(string name);
    }
}
