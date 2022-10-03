using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private SqlConnection _sqlConnection;

        public EmployeeRepository()
        {
            _sqlConnection = new SqlConnection("data source=(localdb)\\mssqllocaldb; database=NewDataBase;");
            
        }

        public EmployeeData GetEmployeeById(int employeeId)
        {
            try
            {
                _sqlConnection.Open();

                var sqlcommand = new SqlCommand("select * from Employee where Id=@id", _sqlConnection);

                sqlcommand.Parameters.AddWithValue("id", employeeId);

                var sqlReader = sqlcommand.ExecuteReader();

                var employeeById = new EmployeeData();

                while(sqlReader.Read())
                {
                    employeeById.Id = (int)sqlReader["Id"];
                    employeeById.Name = (string)sqlReader["Name"];
                    employeeById.Age = (int)sqlReader["Age"];
                    employeeById.Department = (string)sqlReader["Department"];
                    employeeById.Address = (string)sqlReader["Address"];
                }
                return employeeById;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public IEnumerable<EmployeeData> GetEmployees()
        {
            try
            {
                _sqlConnection.Open();

                var sqlcommand = new SqlCommand(cmdText:"select * from Employee",_sqlConnection);

                var sqlReader = sqlcommand.ExecuteReader();

                var listOfEmployee = new List<EmployeeData>();

                while(sqlReader.Read())
                {
                    listOfEmployee.Add(new EmployeeData()
                    {
                        Id = (int)sqlReader["Id"],
                        Name=(string)sqlReader["Name"],
                        Department=(string)sqlReader["Department"]
                    });                   
                }
                return listOfEmployee;
            }
            catch (Exception)
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

                var sqlcommand = new SqlCommand(cmdText: "insert into Employee(Name, Age, Department, Address) values(@name, @age, @department, @address)", _sqlConnection);

                sqlcommand.Parameters.AddWithValue("name", employee.Name);
                sqlcommand.Parameters.AddWithValue("age", employee.Age);
                sqlcommand.Parameters.AddWithValue("department", employee.Department);
                sqlcommand.Parameters.AddWithValue("address", employee.Address);

                sqlcommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
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

                var sqlcommand = new SqlCommand(cmdText: "update Employee set Name=@name, Age=@age, Department=@department, Address=@address where Id=@id", _sqlConnection);

                sqlcommand.Parameters.AddWithValue("id", employee.Id);
                sqlcommand.Parameters.AddWithValue("name", employee.Name);
                sqlcommand.Parameters.AddWithValue("age", employee.Age);
                sqlcommand.Parameters.AddWithValue("department", employee.Department);
                sqlcommand.Parameters.AddWithValue("address", employee.Address);

                sqlcommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
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

                var sqlcommand = new SqlCommand(cmdText: "delete from Employee where Id=@id", _sqlConnection);

                sqlcommand.Parameters.AddWithValue("id", id);

                sqlcommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
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
