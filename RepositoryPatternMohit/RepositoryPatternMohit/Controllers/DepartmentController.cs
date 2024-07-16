using Microsoft.AspNetCore.Mvc;
using RepositoryPatternMohit.Repository.Contract;
using RepositoryPatternMohit.Models;

namespace RepositoryPatternMohit.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartment _dp;
        public DepartmentController(IDepartment dp)
        {
            _dp = dp;
        }
        public IActionResult Index()
        {
            var departments = _dp.GetDepartments();
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department dptObj)
        {
            bool b=_dp.addDepartment(dptObj);
            if (b == true)
            {
                TempData["insert"] = "<script>alert('Department Added SuccessFully!!');</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["insert"] = "<script>alert('Department Failed!!');</script>";
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var dept = _dp.getDepartmentById(id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Edit(Department dptObj)
        {
            bool b = _dp.updateDepartment(dptObj);
            if (b == true)
            {
                TempData["update"] = "<script>alert('Department Updated SuccessFully!!');</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["update"] = "<script>alert('Department Failed!!');</script>";
            }
            return View();
        }
        public IActionResult Details(int id)
        {
            var dept = _dp.getDepartmentById(id);
            return View(dept);
        }
        public IActionResult Delete(int id)
        {
            bool b = _dp.deleteDepartment(id);
            if (b == true)
            {
                TempData["delete"] = "<script>alert('Department Deleted SuccessFully!!');</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["delete"] = "<script>alert('Department Failed!!');</script>";
            }
            return View();
        }

    }
}
