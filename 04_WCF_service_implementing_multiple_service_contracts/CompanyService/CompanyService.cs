namespace CompanyServiceNamespace
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompanyService" in both code and config file together.
    public class CompanyService : ICompanyPublicService, ICompanyConfidentialService
    {
        public string GetPublicInformation()
        {
            return "this is public information and available over HTTP to all general public outside the firewall";
        }

        public string GetConfidentialInformation()
        {
            return "this is confidential information and only available over TCP behind the firewall";
        }
    }
}
