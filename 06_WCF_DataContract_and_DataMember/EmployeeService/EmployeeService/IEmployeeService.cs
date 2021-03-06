﻿using System.ServiceModel;

namespace EmployeeServiceNamespace
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.
    [ServiceContract(Name = "IEmployeeService")]
    public interface IEmployeeService
    {

        [OperationContract(Name = "GetEmployee")]
        Employee GetEmployee(int id);

        [OperationContract(Name = "SaveEmployee")]
        void SaveEmployee(Employee employee);
    }
}
