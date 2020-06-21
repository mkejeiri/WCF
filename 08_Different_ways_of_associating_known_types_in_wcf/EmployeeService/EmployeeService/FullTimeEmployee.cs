using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeeService
{
    public class FullTimeEmployee:Employee
    {
        [DataMember(Order = 6)]
        public int AnnualSalary { get; set; }
    }
}
