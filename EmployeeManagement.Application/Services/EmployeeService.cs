using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeDto GetEmployeeById(int employeeId)
        {
            try
            {
                var employee = _employeeRepository.GetEmployeeById(employeeId);

                return MapEmployeeByIdToEmployeeDto(employee);
            }
            catch (Exception)
            {

                throw;
            }            
        }

        private EmployeeDto MapEmployeeByIdToEmployeeDto(EmployeeData employeeById)
        {
            try
            {
                var employee = new EmployeeDto()
                {
                    Id = employeeById.Id,
                    Name = employeeById.Name,
                    Department = employeeById.Department,
                    Age = employeeById.Age,
                    Address = employeeById.Address
                };
                return employee;
            }
            catch (Exception)
            {

                throw;
            }          
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            try
            {
                var ListOfEmployee = _employeeRepository.GetEmployees();
                return MapGetEmployeeToEmployeesDto(ListOfEmployee);
            }
            catch (Exception)
            {

                throw;
            }           
        }

        private IEnumerable<EmployeeDto> MapGetEmployeeToEmployeesDto(IEnumerable<EmployeeData> ListOfEmployee)
        {
            try
            {
                var employeeList = new List<EmployeeDto>();
                foreach (var item in ListOfEmployee)
                {
                    var employee = new EmployeeDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Department = item.Department,
                        Age = item.Age,
                        Address = item.Address
                    };
                    employeeList.Add(employee);
                }
                return employeeList;
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public bool InsertEmployee(EmployeeDto insertEmployee)
        {
            try
            {
                var employee = _employeeRepository.InsertEmployee(MapInsertEmployeeData(insertEmployee));
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private EmployeeData MapInsertEmployeeData(EmployeeDto insertEmployee)
        {
            try
            {
                var employeeData = new EmployeeData()
                {
                    Name = insertEmployee.Name,
                    Department = insertEmployee.Department,
                    Age = insertEmployee.Age,
                    Address = insertEmployee.Address
                };
                return employeeData;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateEmployee(EmployeeDto UpdateEmployee)
        {
            try
            {
                var employee = _employeeRepository.UpdateEmployee(MapUpdateEmployeeToEmployeedto(UpdateEmployee));
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private EmployeeData MapUpdateEmployeeToEmployeedto(EmployeeDto updateEmployee)
        {
            try
            {
                var updateEmployees = new EmployeeData()
                {
                    Id = updateEmployee.Id,
                    Name = updateEmployee.Name,
                    Department = updateEmployee.Department,
                    Age = updateEmployee.Age,
                    Address = updateEmployee.Address
                };
                return updateEmployees;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var deleteEmployee = _employeeRepository.DeleteEmployee(id);
                return deleteEmployee;
            }
            catch (Exception)
            {

                throw;
            }            
        }        
    }
}
