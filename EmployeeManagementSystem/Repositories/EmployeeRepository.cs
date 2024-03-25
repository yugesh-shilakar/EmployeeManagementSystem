using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;


namespace EmployeeManagementSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly string _connectionString;
        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT EmployeeID, FirstName, LastName, Contact, Address, Age, Salary FROM Employee";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        EmployeeID = (int)reader["EmployeeID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Contact = reader["Contact"].ToString(),
                        Address = reader["Address"].ToString(),
                        Age = (int)reader["Age"],
                        Salary = reader["Salary"].ToString()
                    };
                    employees.Add(employee);
                }
                reader.Close();
            }
            return employees;
        }
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Employee (FirstName, LastName, Contact, Address, Age, Salary) " + "VALUES (@FirstName, @LastName, @Contact, @Address, @Age, @Salary)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Contact", employee.Contact);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@Age", employee.Age);
                command.Parameters.AddWithValue("@Salary", employee.Salary);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", employeeId);

                connection.Open();
                command.ExecuteNonQuery ();
            }
        }
    }
}
