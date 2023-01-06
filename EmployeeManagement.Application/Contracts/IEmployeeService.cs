using EmployeeManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees();

        EmployeeDto GetEmployeeById(int id);

        bool InsertEmployees(EmployeeDto employee);

        bool UpdateEmployees(EmployeeDto employee);

        bool DeleteEmployees(int id);

    }
}
