using Microsoft.AspNetCore.Mvc;
using RepositoryPatternMohit.Repository.Contract;
using RepositoryPatternMohit.Models;

namespace RepositoryPatternMohit.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;   // Inject Service
        }
        public IActionResult Index()
        {
            var employees = _employee.getEmployees();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee empObj)
        {
           bool b= _employee.addEmployee(empObj);
            if (b == true)
            {
                TempData["insert"] = "<script>alert('Employee Added SuccessFully!!');</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["insert"] = "<script>alert('Employee Failed!!');</script>";
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
          Employee employee=_employee.getEmployeeId(id);
            return View(employee);   
        }

        [HttpPost]
        public IActionResult Edit(Employee empObj)
        {
            bool b=_employee.updateEmployee(empObj);
            if (b == true)
            {
                TempData["update"] = "<script>alert('Employee Updated SuccessFully!!');</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["update"] = "<script>alert('Employee Failed!!');</script>";
            }
            return View();
        }
        public IActionResult Details(int id)
        {
            Employee employee = _employee.getEmployeeId(id);
            return View(employee);
        }
        public IActionResult Delete(int id)
        {
            bool b=_employee.deleteEmployee(id);
            if (b == true)
            {
                TempData["delete"] = "<script>alert('Employee Deleted SuccessFully!!');</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["delete"] = "<script>alert('Employee Failed!!');</script>";
            }
            return View();
        }
    }
}
