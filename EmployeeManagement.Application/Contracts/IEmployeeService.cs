using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees();
        EmployeeDto GetEmployeeById(int employeeId);
        bool InsertEmployee(EmployeeDto insertEmployee);
        bool UpdateEmployee(EmployeeDto UpdateEmployee);
        bool DeleteEmployee(int id);
    }
}
