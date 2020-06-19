using System;

namespace CompanyClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       protected void Button1_Click(object sender, EventArgs e)
        {
            CompanyServiceRef.CompanyPublicServiceClient client =
                new CompanyServiceRef.CompanyPublicServiceClient("BasicHttpBinding_ICompanyPublicService");
            Label1.Text = client.GetPublicInformation();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CompanyServiceRef.CompanyConfidentialServiceClient client =
                new CompanyServiceRef.CompanyConfidentialServiceClient("NetTcpBinding_ICompanyConfidentialService");
            Label2.Text = client.GetConfidentialInformation();
        }
    }
}