using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using EmployeeManagement.UI.Providers.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace EmployeeManagement.UI.Providers.ApiClients
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _httpClient;

        public EmployeeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            var response = _httpClient.GetAsync("https://localhost:5001/api/employee/get-all").Result;           
            var getEmployee = JsonConvert.DeserializeObject<IEnumerable<EmployeeViewModel>>(response.Content.ReadAsStringAsync().Result);
            return getEmployee;                       
        }

        public EmployeeDetailedViewModel GetEmployeeById(int employeeId)
        {

            var response = _httpClient.GetAsync("https://localhost:5001/api/employee/"+employeeId).Result;
            var getEmployeeById = JsonConvert.DeserializeObject<EmployeeDetailedViewModel>(response.Content.ReadAsStringAsync().Result);
            return getEmployeeById;
        }
    }
}
