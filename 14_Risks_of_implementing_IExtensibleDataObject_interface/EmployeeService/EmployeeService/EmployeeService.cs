﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IgnoreExtensionDataObject = true)]
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class EmployeeService : IEmployeeService
    {
        private Employee _lastSavedEmployee;

        public Employee GetEmployee(int id)
        {
            Console.WriteLine("GetEmployee Called @: " + DateTime.Now);
            Employee employee = null;
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@Id";
                parameterId.Value = id;
                cmd.Parameters.Add(parameterId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((EmployeeType)reader["EmployeeType"] == EmployeeType.FullTimeEmployee)
                    {
                        employee = new FullTimeEmployee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            //Gender = reader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Type = EmployeeType.FullTimeEmployee,
                            AnnualSalary = Convert.ToInt32(reader["AnnualSalary"])
                        };
                    }
                    else
                    {
                        employee = new PartTimeEmployee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            //Gender = reader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Type = EmployeeType.PartTimeEmployee,
                            HourlyPay = Convert.ToInt32(reader["HourlyPay"]),
                            HoursWorked = Convert.ToInt32(reader["HoursWorked"]),
                        };
                    }
                }
            }

            if (_lastSavedEmployee !=null && _lastSavedEmployee.Id == id )
            {
                employee.ExtensionData = _lastSavedEmployee.ExtensionData;
            }

            return employee;
        }

        public void SaveEmployee(Employee employee)
        {
            Console.WriteLine("SaveEmployee Called @: " + DateTime.Now);
            _lastSavedEmployee = employee;
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = employee.Id
                };
                cmd.Parameters.Add(parameterId);

                SqlParameter parameterName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = employee.Name
                };
                cmd.Parameters.Add(parameterName);

                //SqlParameter parameterGender = new SqlParameter
                //{
                //    ParameterName = "@Gender",
                //    Value = employee.Gender
                //};
                //cmd.Parameters.Add(parameterGender);

                SqlParameter parameterDateOfBirth = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = employee.DateOfBirth
                };
                cmd.Parameters.Add(parameterDateOfBirth);

                SqlParameter parameterEmployeeType = new SqlParameter
                {
                    ParameterName = "@EmployeeType",
                    Value = employee.Type
                };
                cmd.Parameters.Add(parameterEmployeeType);

                if (employee.GetType() == typeof(FullTimeEmployee))
                {
                    SqlParameter parameterAnnualSalary = new SqlParameter
                    {
                        ParameterName = "@AnnualSalary",
                        Value = ((FullTimeEmployee)employee).AnnualSalary
                    };
                    cmd.Parameters.Add(parameterAnnualSalary);
                }
                else if (employee.GetType() == typeof(PartTimeEmployee))
                {
                    SqlParameter parameterHourlyPay = new SqlParameter
                    {
                        ParameterName = "@HourlyPay",
                        Value = ((PartTimeEmployee)employee).HourlyPay,
                    };
                    cmd.Parameters.Add(parameterHourlyPay);

                    SqlParameter parameterHoursWorked = new SqlParameter
                    {
                        ParameterName = "@HoursWorked",
                        Value = ((PartTimeEmployee)employee).HoursWorked
                    };
                    cmd.Parameters.Add(parameterHoursWorked);
                }

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    
    }
}
