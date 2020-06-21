using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SimpleService" in both code and config file together.
    public class SimpleService : ISimpleService
    {
        public string GetUserName()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Is Authenticated: " + ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated.ToString());
            Console.WriteLine("Athentication Type: " + ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType);
            Console.WriteLine("UserName : " + ServiceSecurityContext.Current.PrimaryIdentity.Name);
            Console.WriteLine("----------------------------------------");
            return "Authenticated UserName: " + ServiceSecurityContext.Current.PrimaryIdentity.Name;
        }
    }
}
