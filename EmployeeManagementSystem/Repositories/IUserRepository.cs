namespace EmployeeManagementSystem.Repositories
{
    public interface IUserRepository
    {
        bool IsValidUser(string username, string password);

    }
}
