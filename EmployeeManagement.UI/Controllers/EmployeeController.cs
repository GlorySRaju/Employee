using EmployeeManagement.Application.Contracts;
using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Providers.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeApiClient _employeeApiClient;

        public EmployeeController(IEmployeeApiClient employeeApiClient)
        {
            this._employeeApiClient = employeeApiClient;
        }

       public IActionResult Index()
        {
            try
            {
                var employees = _employeeApiClient.GetEmployee();

                return View(MapToEmployee(employees));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        
        }

        private object MapToEmployee(IEnumerable<EmployeeData> employees)
        {
            try
            {
                var employeeList = employees.Select(employee=> new EmployeeViewModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Department = employee.Department,
                    
                });
                return employeeList;
            }
            catch
            {
                throw;
            }
        }
     }
 }

