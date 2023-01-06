 using EmployeeManagement.API.Models;
using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/employees")] 

    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeApiController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]

        public IActionResult Get()

        {
            try
            {
                var employees = _employeeService.GetAllEmployees();

                return Ok(employees);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]

        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {

                var employees = _employeeService.GetEmployeeById(id);

                return Ok(employees);

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
                var employees = _employeeService.InsertEmployees(MapToEmployee(employee));

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]

        public IActionResult UpdateEmployee( [FromBody] EmployeeDetailedViewModel employee)
        {
            try
            {
                    var students = _employeeService.UpdateEmployees(MapToEmployee(employee));

                    return StatusCode(StatusCodes.Status200OK);
               
            }
            catch (Exception ex)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private EmployeeDto MapToEmployee(EmployeeDetailedViewModel employee)
        {
            try
            {
                var employees = new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Department = employee.Department,
                    Age=employee.Age,
                    Address=employee.Address
                };
                return employees;
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]

        [Route("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employees = _employeeService.DeleteEmployees(id);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
