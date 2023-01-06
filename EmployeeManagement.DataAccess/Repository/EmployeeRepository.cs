using EmployeeConfiguration;
using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EmployeeManagement.DataAccess.Repository
{
    /// <summary>
    /// Connect To Database and Perforum CRUD operations
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly SqlConnection _sqlConnection;

        public EmployeeRepository(IOptions<ConnectionString> connectionStringOption)
        {
            var connectionString = connectionStringOption.Value;

            _sqlConnection = new SqlConnection(connectionString.EmployeeDb);
        }


        public IEnumerable<EmployeeData> GetEmployees()
        {

            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand("select * from EMPLOYEE", _sqlConnection);

                var sqlDataRead = sqlCommand.ExecuteReader();

                var employeeList = new List<EmployeeData>();

                while (sqlDataRead.Read())
                {
                    employeeList.Add(new EmployeeData
                    {
                        Id = (int)sqlDataRead["Id"],
                        Name = (string)sqlDataRead["Name"],
                        Department = (string)sqlDataRead["Department"],
                    });
                }
                return employeeList;
            }

            catch 
            {
                throw;

            }
            finally
            {
                _sqlConnection.Close();
            }

        }

        public EmployeeData GetEmployeeDetail(int id)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand("select * from EMPLOYEE where Id=@id", _sqlConnection);

                sqlCommand.Parameters.AddWithValue("id", id);

                var sqlDataRead = sqlCommand.ExecuteReader();

                var employeeList = new List<EmployeeData>();

                while (sqlDataRead.Read())
                {
                    employeeList.Add(new EmployeeData
                    {
                        Id = (int)sqlDataRead["Id"],
                        Name = (string)sqlDataRead["Name"],
                        Department = (string)sqlDataRead["Department"],
                        Age = (int)sqlDataRead["Age"],
                        Address = (string)sqlDataRead["Address"],
                    });
                }
                return employeeList.FirstOrDefault();
            }

            catch
            {
                throw;

            }
            finally
            {
                _sqlConnection.Close();
            }

        }

        public bool InsertEmployee(EmployeeData employee)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand("INSERT INTO EMPLOYEE VALUES(@name,@dep,@age,@address)", _sqlConnection);

                sqlCommand.Parameters.AddWithValue("name", employee.Name);

                sqlCommand.Parameters.AddWithValue("dep", employee.Department);

                sqlCommand.Parameters.AddWithValue("age", employee.Age);

                sqlCommand.Parameters.AddWithValue("address", employee.Address);

                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }

        }

        public bool UpdateEmployee(EmployeeData employee)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand("UPDATE EMPLOYEE SET Name=@name,Department=@dep,Age=@age,Address=@address WHERE Id=@id", _sqlConnection);

                sqlCommand.Parameters.AddWithValue("id", employee.Id);

                sqlCommand.Parameters.AddWithValue("name", employee.Name);

                sqlCommand.Parameters.AddWithValue("dep", employee.Department);

                sqlCommand.Parameters.AddWithValue("age", employee.Age);

                sqlCommand.Parameters.AddWithValue("address", employee.Address);

                sqlCommand.ExecuteNonQuery();

                return true;

            }

            catch
            {
                throw;
            }

            finally
            {
                _sqlConnection.Close();
            }

        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand("DELETE FROM EMPLOYEE WHERE Id=@id;", _sqlConnection);

                sqlCommand.Parameters.AddWithValue("id", id);

                sqlCommand.ExecuteNonQuery();

                return true;
            }

            catch
            {
                throw;
            }

            finally
            {
                _sqlConnection.Close();
            }

        }
    }
}
