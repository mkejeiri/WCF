using System.ServiceModel;

namespace CompanyServiceNamespace
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICompanyService" in both code and config file together.
    [ServiceContract]
    public interface ICompanyPublicService
    {
        [OperationContract]
        string GetPublicInformation();
    }

    [ServiceContract]
    public interface ICompanyConfidentialService
    {
        [OperationContract]
        string GetConfidentialInformation();
    }
}
