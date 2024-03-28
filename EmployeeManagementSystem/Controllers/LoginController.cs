using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            if(_userRepository.IsValidUser(username, password))
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Username or Password";
                return View();
            }
        }
    }

}
