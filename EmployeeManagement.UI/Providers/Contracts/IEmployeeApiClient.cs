using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using System.Collections.Generic;

namespace EmployeeManagement.UI.Providers.Contracts
{
    public interface IEmployeeApiClient
    {
        IEnumerable<EmployeeViewModel> GetAllEmployee();
        EmployeeDetailedViewModel GetEmployeeById(int employeeId);
        bool DeleteEmployee(int id);
        bool UpdateEmployee(EmployeeDetailedViewModel updateEmployee);
        bool InsertEmployee(EmployeeDetailedViewModel insertEmployee);
    }
}
