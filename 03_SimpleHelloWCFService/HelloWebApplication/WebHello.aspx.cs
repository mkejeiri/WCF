using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWebApplication.HelloServiceRef;

namespace HelloWebApplication
{
    public partial class WebHello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HelloServiceRef.HelloServiceClient client = new HelloServiceClient("BasicHttpBinding_IHelloService");
            Label1.Text = client.GetMessage(TextBox1.Text);
        }
    }
}