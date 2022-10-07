using EmployeeManagement.API.Models;
using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeApiController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute] int employeeId)
        {          
                /// get employee by calling GetEmployeeById() in IEmployeeService and store it in a variable and Map that variable to EmployeeDetailedViewModel.                              
                var getEmployeeById = _employeeService.GetEmployeeById(employeeId);

                return Ok(MapToEmployeeIdDetailedViewModel(getEmployeeById));                       
        }

        private EmployeeDetailedViewModel MapToEmployeeIdDetailedViewModel(EmployeeDto getEmployeeById)
        {            
                var employeeDetailedViewModel = new EmployeeDetailedViewModel
                {
                    Id = getEmployeeById.Id,
                    Name = getEmployeeById.Name,
                    Department = getEmployeeById.Department,
                    Age = getEmployeeById.Age,
                    Address = getEmployeeById.Address
                };
                return employeeDetailedViewModel;            
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetEmployees()
        {
            var listOfEmployeeViewModel = _employeeService.GetEmployees();
            return Ok(MapGetEmployee(listOfEmployeeViewModel));
        }

        private IEnumerable<EmployeeDetailedViewModel> MapGetEmployee(IEnumerable<EmployeeDto> listOfEmployeeViewModel)
        {
                var getEmployee = new List<EmployeeDetailedViewModel>();
                foreach (var item in listOfEmployeeViewModel)
                {
                    var employee = new EmployeeDetailedViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Department = item.Department,
                        Age = item.Age,
                        Address = item.Address
                    };
                    getEmployee.Add(employee);
                }
                return getEmployee;
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult InsertEmployee([FromBody] EmployeeDetailedViewModel insertEmployee)
        {           
                var isInsertedemployee = _employeeService.InsertEmployee(MapToEmployeeDetailedViewModel(insertEmployee));
                if (isInsertedemployee)
                {
                    return Ok(isInsertedemployee);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update details");
                }            
        }

        private EmployeeDto MapToEmployeeDetailedViewModel(EmployeeDetailedViewModel insertEmployee)
        {
            var employeeDto = new EmployeeDto()
            {
                Name = insertEmployee.Name,
                Department = insertEmployee.Department,
                Age = insertEmployee.Age,
                Address = insertEmployee.Address
            };
            return employeeDto;
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDetailedViewModel updateEmployee)
        {
            var isUpdateEmployee = _employeeService.UpdateEmployee(MapUpdateEmployee(updateEmployee));

            if (isUpdateEmployee)
            {
                return Ok(isUpdateEmployee);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update details");
            }
        }

        private EmployeeDto MapUpdateEmployee(EmployeeDetailedViewModel updateEmployee)
        {
            var employeeDto = new EmployeeDto()
            {
                Id = updateEmployee.Id,
                Name = updateEmployee.Name,
                Department = updateEmployee.Department,
                Age = updateEmployee.Age,
                Address = updateEmployee.Address
            };
            return employeeDto;
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
                var deleteEmployee = _employeeService.DeleteEmployee(id);
                return Ok(deleteEmployee);            
        }
    }
}
