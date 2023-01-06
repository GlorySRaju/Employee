using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using EmployeeManagement.UI.Providers.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<EmployeeData> GetEmployee()
        {
            var response = _httpClient.GetAsync("https://localhost:5000/api/employees").Result;

            var employeeResponse = response.Content.ReadAsStringAsync().Result;

            var employee = JsonConvert.DeserializeObject<IEnumerable<EmployeeData>>(employeeResponse);

            return employee;
        }

        public EmployeeData GetEmployeeById(int id)
        {
            var url = $"https://localhost:5000/api/employees/{id}";

            var response = _httpClient.GetAsync(url).Result;

            var employeeResponse = response.Content.ReadAsStringAsync().Result;

            var employee = JsonConvert.DeserializeObject<EmployeeData>(employeeResponse);

            return employee;

        }

        

        public bool InsertEmployee(EmployeeData employee)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

                var response = _httpClient.PostAsync("https://localhost:5000/api/employees", stringContent).Result;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateEmployee(EmployeeData employee)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

                var response = _httpClient.PutAsync($"https://localhost:5000/api/employees", stringContent).Result;

                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(employeeId));

                var response = _httpClient.DeleteAsync("https://localhost:5000/api/employees/" + employeeId).Result;

                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }
    }
}
