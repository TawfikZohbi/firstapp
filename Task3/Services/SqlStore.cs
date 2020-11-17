using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3.Controllers;
using Task3.Models;
using System.Data.SqlClient;
using System.Data;

namespace Task3.Services
{
    public class SqlStore : IStore
    {
      private readonly string connectionString;
        private readonly SqlQuery sqlQuery;
        public SqlStore(SqlQuery sqlQuery)
        {
            this.connectionString = @"Data Source=(local);Initial Catalog=test1;Integrated Security=True";
            this.sqlQuery = sqlQuery;
        }
        public SubmissionResponse SaveEmployee(Employee employee)
        {
            /*    using (var connection = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand("INSERT INTO Employeetab (Id , Name, CountryId) Values (@Id, @Name, @CountryId) ", connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", employee.Id);
                        cmd.Parameters.AddWithValue("@Name", employee.Name);
                        cmd.Parameters.AddWithValue("@CountryId", employee.CountryId);
                        connection.Open();

                        cmd.ExecuteNonQuery();

                        return new SubmissionResponse { Success = true };
                    }
                }*/
            return sqlQuery.QuerySave("INSERT INTO Employee (Id , NameEmployee, CountryId) Values (@Id, @Name, @CountryId) ",
                    new[] {
                    new SqlParameter ("@Id", employee.Id),
                    new SqlParameter ("@Name", employee.Name),
                    new SqlParameter ("@CountryId", employee.CountryId)
                    });
        }

        // public List<Employee> GetEmployee(string employeeName)
        public List<Employee> GetEmployee(string employeeName)
        {
            SqlQuery sqlQuery = new SqlQuery();

            DataTable Employees = sqlQuery.ExecuteReader("Select * From Employee WHERE NameEmployee = @name ",
                    new SqlParameter("@name", employeeName) );

            var employe = new List<Employee>();
            foreach (DataRow row in Employees.Rows)
            {

                employe.Add(new Employee
                {

                    Id = (Guid)row["Id"],
                    Name = (string)row["NameEmployee"],
                    CountryId = (Guid)row["CountryId"]

                });
            }
            return employe;

          





        }

        }
      


     


    }





