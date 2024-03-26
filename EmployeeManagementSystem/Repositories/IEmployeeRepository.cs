using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        void UpdateEmployee(Employee employee);
        Employee GetAllDistricts();
        Employee GetAllCities(string districtId);
    }
}
