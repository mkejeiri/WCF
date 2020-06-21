using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeeService
{
    //With .NET 3.5 SP1 and above, we don't have to explicitly use DataContract or DataMember attributes.
    [DataContract (Namespace="http://kejeiri.com/13/03/2016"), ]
    //(option-1)known type are global here
    [KnownType(typeof(FullTimeEmployee))]
    [KnownType(typeof(PartTimeEmployee))]
    public class Employee :  IExtensibleDataObject
    {
        
        [DataMember(Name = "ID", Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        //[DataMember(Order = 3)]
        //public string Gender { get; set; }

        [DataMember(Order = 4)]
        public DateTime DateOfBirth { get; set; }

        [DataMember(Order = 5)]
        public EmployeeType Type { get; set; }


        public ExtensionDataObject ExtensionData  { get; set; }
    }
    public enum EmployeeType
    {
        FullTimeEmployee = 1,
        PartTimeEmployee = 2
    }
}

