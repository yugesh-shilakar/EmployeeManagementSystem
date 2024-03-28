using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Repositories
{
    public class UserRepository:IUserRepository
    {
        public UserRepository()
        {
        }

        public bool IsValidUser(string username, string password)
        {
            return username == "admin" && password == "password";
        }
    }
}
