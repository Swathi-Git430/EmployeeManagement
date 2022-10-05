using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Providers.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Controllers.InternalAPI
{
    [Route("api/internal/employee")]
    [ApiController]
    public class EmployeeInternalApiController : ControllerBase
    {
        private readonly IEmployeeApiClient _employeeApiClient;

        public EmployeeInternalApiController(IEmployeeApiClient employeeApiClient)
        {
            _employeeApiClient = employeeApiClient;
        }

        [HttpGet]
        [Route("get-employees/{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute] int employeeId)
        {
            try
            {
                var employee = _employeeApiClient.GetEmployeeById(employeeId);

                return Ok(employee);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            try
            {
                var employee = _employeeApiClient.DeleteEmployee(id);

                return Ok(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDetailedViewModel updateEmployee)
        {
            try
            {
                var employee = _employeeApiClient.UpdateEmployee(updateEmployee);

                return Ok(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult InsertEmployee([FromBody] EmployeeDetailedViewModel insertEmployee)
        {
            try
            {
                var employee = _employeeApiClient.InsertEmployee(insertEmployee);

                return Ok(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
