using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeeService
{
    public class PartTimeEmployee :Employee
    {
        [DataMember(Order = 7)]
        public int HourlyPay  { get; set; }
        [DataMember(Order = 8)]
        public int HoursWorked { get; set; }
    }
}
