using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloService" in both code and config file together.
    public class HelloService : IHelloService
    {
        public string GetMessageWithoutAnyProtection()
        {
            return "Message Without Any Protection";
        }

        public string GetSignedMessage()
        {
            return "Message Signed and without encryption";
        }

        public string GetSignedMessageAndEncrypted()
        {
            return "Message Signed And Encrypted";
        }
    }
}
