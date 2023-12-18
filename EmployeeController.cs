using Microsoft.AspNetCore.Mvc;
using WebDemo.Models;
using System.Linq;

namespace WebDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {

            return View(Repository.AllEmployees);
        }

       

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Employee employee)
        {
            Repository.Create(employee);
            return View("Success",employee);
        }

        [HttpPost]

        public IActionResult Delete(string empname)
        {
            Employee employee = Repository.AllEmployees.Where(e => e.name == empname).FirstOrDefault();
            Repository.Delete(employee);
            return RedirectToAction("Index");

        }

        public IActionResult Update(string empname)
        {
            Employee employee = Repository.AllEmployees.Where(e => e.name == empname).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]

        public IActionResult Update(Employee employee,string empname)
        {
            Repository.AllEmployees.Where(e => e.name == empname).FirstOrDefault().age = employee.age;
            Repository.AllEmployees.Where(e => e.name == empname).FirstOrDefault().salary = employee.salary;
            Repository.AllEmployees.Where(e => e.name == empname).FirstOrDefault().department = employee.department;
            Repository.AllEmployees.Where(e => e.name == empname).FirstOrDefault().gender = employee.gender;
            return RedirectToAction("Index");
        }


    }
}
