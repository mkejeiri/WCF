using System;
using System.Runtime.Serialization;

namespace EmployeeServiceNamespace
{
    //With .NET 3.5 SP1 and above, we don't have to explicitly use DataContract or DataMember attributes.
    //[DataContract (Namespace="http://kejeiri.com/13/03/2016")]

    //decorate with Employee with [Serializable] (i.e. Serializable into xml) and we get private fields in the wsdl instead of properties
    //using [Serializable] we have no control on which field to include/exclude from wsdl(serialization) and also we cannot manage order 
    //of the field in the serializable xml


    //By default DataContract is used, we don't need to specify it!
    //BUT: In order to use data member to include/exclude properties from wsdl(serialization),
    //we have to decorate with DataContract!!!, otherwise DataMember attribute is ignored 
    //We could also specify the namespace that we want in the wsdl (xsd http://localhost:8080/?xsd=xsd2)
    [DataContract(Namespace = "http://kejeiri.com/13/03/2016")]
    public class Employee
    {
        private int _id; 
        //[DataMember] //'_name' will be also serialized even if it's private!
        private string _name;
        private string _gender;
        private DateTime _dateOfBirth;

        [DataMember(Name = "ID", Order = 1)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember(Order = 2)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember(Order = 3)]
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        [DataMember(Order = 4)]
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
    }
}
