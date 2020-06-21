using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    [MessageContract(IsWrapped = true,WrapperName = "EmployeeRequestObject",WrapperNamespace = "http://MyCompany.com/Employee")]
    public class EmployeeRequest
    {
        [MessageBodyMember(Namespace = "http://MyCompany.com/Employee")]
        public int EmployeeId { get; set; }

        [MessageHeader(Namespace = "http://MyCompany.com/Employee")]
        public string LicenseKey { get; set; }
    }
    
    [MessageContract(IsWrapped = true, WrapperName = "EmployeeInfoObject", WrapperNamespace = "http://MyCompany.com/Employee")]
    public class EmployeeInfo
    {
        public EmployeeInfo() { }

        public EmployeeInfo(Employee employee) 
        {
            this.Id = employee.Id;
            this.Name = employee.Name;
            this.Gender = employee.Gender;
            this.DOB = employee.DateOfBirth;
            this.Type = employee.Type;
            if (this.Type == EmployeeType.FullTimeEmployee)
            {
                this.AnnualSalary = ((FullTimeEmployee)employee).AnnualSalary;
            }
            else
            {
                this.HourlyPay = ((PartTimeEmployee)employee).HourlyPay;
                this.HoursWorked = ((PartTimeEmployee)employee).HoursWorked;
            }          
        }

        [MessageBodyMember(Order = 1, Namespace = "http://MyCompany.com/Employee")]
        public int Id { get; set; }

        [MessageBodyMember(Order = 2, Namespace = "http://MyCompany.com/Employee")]
        public string Name { get; set; }

        [MessageBodyMember(Order = 3, Namespace = "http://MyCompany.com/Employee")]
        public string Gender { get; set; }

        [MessageBodyMember(Order = 4, Namespace = "http://MyCompany.com/Employee")]
        public DateTime DOB { get; set; }

        [MessageBodyMember(Order = 5, Namespace = "http://MyCompany.com/Employee")]
        public EmployeeType Type { get; set; }

        [MessageBodyMember(Order = 6, Namespace = "http://MyCompany.com/Employee")]
        public int AnnualSalary { get; set; }

        [MessageBodyMember(Order = 7, Namespace = "http://MyCompany.com/Employee")]
        public int HourlyPay { get; set; }

        [MessageBodyMember(Order = 8, Namespace = "http://MyCompany.com/Employee")]
        public int HoursWorked { get; set; }
    }

    
    //With .NET 3.5 SP1 and above, we don't have to explicitly use DataContract or DataMember attributes.    
    [KnownType(typeof(FullTimeEmployee))]
    [KnownType(typeof(PartTimeEmployee))]
    public class Employee
    {
        private int _id;
        private string _name;
        private string _gender;
        private DateTime _dateOfBirth;

       public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public EmployeeType Type { get; set; }
        
    }
    public enum EmployeeType
    {
        FullTimeEmployee = 1,
        PartTimeEmployee = 2
    }
}

