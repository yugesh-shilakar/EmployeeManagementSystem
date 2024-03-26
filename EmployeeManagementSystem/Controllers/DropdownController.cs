using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EmployeeManagementSystem.Controllers
{
    public class DropdownController : Controller
    {
        private readonly string _connectionString;
        public DropdownController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("conn");
        }
        public ActionResult Index()
        {
            List<District> districts = new List<District>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Name FROM District";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    districts.Add(new District
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString()
                    });
                }
                reader.Close();
            }
            return View(districts);
        }
    }
}
