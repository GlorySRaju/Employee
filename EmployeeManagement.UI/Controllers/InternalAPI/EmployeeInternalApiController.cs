using EmployeeManagement.DataAccess.Models;
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
    [Route("api/employees")]

    [ApiController]
    public class EmployeeInternalApiController : ControllerBase
    {
        private readonly IEmployeeApiClient _employeeApiClient;

        public EmployeeInternalApiController(IEmployeeApiClient employeeApiClient)
        {
            _employeeApiClient = employeeApiClient;
        }

        [HttpGet]

        [Route("{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute] int employeeId)
        {
            try
            {
                var employee = _employeeApiClient.GetEmployeeById(employeeId) ;

                return Ok(employee);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

       
        [HttpPost]
        public IActionResult InsertEmployee([FromBody] EmployeeDetailedViewModel employee)
        {
            try
            {
                _employeeApiClient.InsertEmployee(MapToEmployee(employee));

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        private Models.Provider.EmployeeData MapToEmployee(EmployeeDetailedViewModel employee)
        {
            try
            {
                var employees = new Models.Provider.EmployeeData
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Department = employee.Department,
                    Age = employee.Age,
                    Address = employee.Address
                };
                return employees;
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]

        [Route("{id}")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDetailedViewModel employee,[FromRoute] int id)
        {
            try
            {
                employee.Id = id;

                _employeeApiClient.UpdateEmployee(MapToEmployee(employee));

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete]

        [Route("{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            try
            {
                _employeeApiClient.DeleteEmployee(id);

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        
    }
}
