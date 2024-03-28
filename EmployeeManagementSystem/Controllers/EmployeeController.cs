using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //GET /EMPLOYEES
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }

        //GET /EMPLOYEE/CREATE

        public IActionResult Create()
        {
            var dropdown= _employeeRepository.GetAllDistricts();
            return View(dropdown);
      
        }

        //POST: /Employee/Create
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public IActionResult Delete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetEmployeeDetail(id);
            var districtList=_employeeRepository.GetAllDistricts();
            employee.DistrictList = districtList.DistrictList;
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        [HttpPost]
        public JsonResult GetCityByDistrictId(string district)
        {
            var cities = _employeeRepository.GetCityByDistrictId(district);
            return Json(cities);
        }

    }
}

