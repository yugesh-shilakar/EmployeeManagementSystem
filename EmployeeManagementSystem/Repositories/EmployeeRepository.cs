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
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT emp.EmployeeID, emp.FirstName, emp.LastName, emp.Contact, emp.Address, emp.Age, emp.Salary, d.Name District, c.Name City FROM Employee as emp left join District as d on d.Id=emp.District " +
                        "Left Join City as c on c.Id=emp.City";
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
                            Salary = reader["Salary"].ToString(),
                            District = reader["District"].ToString(),
                            City = reader["City"].ToString(),
                        };
                        employees.Add(employee);
                    }
                    reader.Close();
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return employees;
        }
        public void AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Employee (FirstName, LastName, Contact, Address, Age, Salary, District, City) " + "VALUES (@FirstName, @LastName, @Contact, @Address, @Age, @Salary, @District, @City)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Contact", employee.Contact);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Age", employee.Age);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@District", employee.District);
                    command.Parameters.AddWithValue("@City", employee.City);


                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void DeleteEmployee(int employeeId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmployeeID", employeeId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, " +
                                   "Contact = @Contact, Address = @Address, Age = @Age, Salary = @Salary, District = @District, City = @City " +
                                   "WHERE EmployeeID = @EmployeeID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Contact", employee.Contact);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Age", employee.Age);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    command.Parameters.AddWithValue("@District", employee.District);
                    command.Parameters.AddWithValue("@City", employee.City);
                    

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        public Employee GetAllDistricts()
        {
            var employee = new Employee();
            employee.DistrictList = new List<District>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT Id, Name FROM District";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        employee.DistrictList.Add(new District
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = reader["name"].ToString()
                        });
                    }
                    reader.Close();
                }
            }
            catch(Exception ex) 
            {
                
                Console.WriteLine(ex.ToString());

            }
            return employee;
        }

        public Employee GetCityByDistrictId(string districtId)
        {
            var employee = new Employee();
            employee.CityList = new List<City>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT Id, Name From City WHERE DistrictId = "+ districtId;
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        employee.CityList.Add(new City
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return employee;
        }
        
        public Employee GetEmployeeDetail(int employeeId)
        {
            var employee = new Employee();
            try
            {                
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT EmployeeID, FirstName, LastName, Contact, Address, Age, Salary, District, City FROM Employee where EmployeeId ="+employeeId;
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open ();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employee.EmployeeID = (int)reader["EmployeeID"];
                        employee.FirstName = reader["FirstName"].ToString();
                        employee.LastName = reader["LastName"].ToString();
                        employee.Contact = reader["Contact"].ToString();
                        employee.Address = reader["Address"].ToString();
                        employee.Age = (int)reader["Age"];
                        employee.Salary = reader["Salary"].ToString();
                        employee.District = reader["District"].ToString();
                        employee.City = reader["City"].ToString();

                    }
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return employee;

        }
    }
}
