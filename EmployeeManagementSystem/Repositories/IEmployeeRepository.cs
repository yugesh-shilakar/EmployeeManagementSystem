using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        void DeleteEmployee(int employeeId);

    }
}
