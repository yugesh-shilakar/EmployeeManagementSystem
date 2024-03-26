using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key] 
        public int EmployeeID { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Contact { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public int Age { get; set; }

        [Range(10000, int.MaxValue, ErrorMessage = "Minimum salary must be 10000.")]
        public string? Salary { get; set; } 

        public List<District> DistrictList { get; set; }

        public List<City> CityList { get; set; }

    }
}
