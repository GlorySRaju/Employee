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
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _employeeRepository.GetEmployees();

            var listEmployees = employees.Select(employee => new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Department = employee.Department
                });

            return listEmployees;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            try
            {
                var employeeDetail = _employeeRepository.GetEmployeeDetail(id);

                return MapToEmployeeById(employeeDetail);
            }
            catch 
            {

                throw;
            }
        }


        private EmployeeDto MapToEmployeeById(EmployeeData employee)
        {
            try
            {
                var employees = new EmployeeDto
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
        public bool InsertEmployees(EmployeeDto employee)
        {
            try
            {
                var insertEmployee = _employeeRepository.InsertEmployee(MapToEmployee(employee));

                return insertEmployee;
            }
            catch 
            {
                throw;
            }

        }

        private EmployeeData MapToEmployee(EmployeeDto employee)
        {
            try
            {
                var employees = new EmployeeData
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

        public bool UpdateEmployees(EmployeeDto employee)
        {
            try
            {
                var updateEmployee = _employeeRepository.UpdateEmployee(MapToEmployee(employee));

                return updateEmployee;
            }
            catch
            {

                throw;
            }
        }

        public bool DeleteEmployees(int id)
        {
            try
            {
                var employees = _employeeRepository.DeleteEmployee(id);

                return employees;
            }
            catch
            {
                throw;
            }
        }

    }
}
