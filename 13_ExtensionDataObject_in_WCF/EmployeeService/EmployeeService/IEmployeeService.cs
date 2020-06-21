using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.
    //(option-2) know type are only visible for this contract
    //[ServiceKnownType(typeof(PartTimeEmployee))]
    //[ServiceKnownType(typeof(FullTimeEmployee))]
    [ServiceContract]
    public interface IEmployeeService
    {

        //(option-3) more granular know type are only visible at GetEmployee methods: the SaveEmployee will crash since doesn't know the derived types!!!!. 
        //[ServiceKnownType(typeof(PartTimeEmployee))]
        //[ServiceKnownType(typeof(FullTimeEmployee))]
        [OperationContract]
        Employee GetEmployee(int id);

        [OperationContract]
        void SaveEmployee(Employee employee);
    }
}
