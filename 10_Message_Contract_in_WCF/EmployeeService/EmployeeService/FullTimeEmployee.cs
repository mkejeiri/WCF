using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeeService
{
    public class FullTimeEmployee:Employee
    {
             public int AnnualSalary { get; set; }
    }
}
