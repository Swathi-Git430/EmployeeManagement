using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using EmployeeManagement.UI.Providers.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

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
            using (var response = _httpClient.GetAsync("https://localhost:5001/api/employee/get-all").Result)
            {
                var getEmployee = JsonConvert.DeserializeObject<IEnumerable<EmployeeViewModel>>(response.Content.ReadAsStringAsync().Result);
                return getEmployee;
            }
                                    
        }

        public EmployeeDetailedViewModel GetEmployeeById(int id)
        {
            using (var response = _httpClient.GetAsync("https://localhost:5001/api/employee/" + id).Result)
            {
                var getEmployeeById = JsonConvert.DeserializeObject<EmployeeDetailedViewModel>(response.Content.ReadAsStringAsync().Result);
                return getEmployeeById;
            };
        }

        public bool DeleteEmployee(int id)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(id));
            using (var response = _httpClient.DeleteAsync("https://localhost:5001/api/employee/" + id).Result)
            {
                return true;
            }
        }

        public bool UpdateEmployee(EmployeeDetailedViewModel updateEmployee)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateEmployee), Encoding.UTF8, "application/json");
            using (var response = _httpClient.PutAsync("https://localhost:5001/api/employee/update", stringContent).Result)
            {
                response.Content.ReadAsStringAsync();
                return true;

            }
        }

        public bool InsertEmployee(EmployeeDetailedViewModel insertEmployee)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(insertEmployee), Encoding.UTF8, "application/json");
            using (var response = _httpClient.PostAsync("https://localhost:5001/api/employee/insert", stringContent).Result)//Consume /employee endpoint in the EmployeeManagementApi using _httpClient
            {
                response.Content.ReadAsStringAsync();
                return true;
            }
        }
    }
}
