using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeCrud.Models;

namespace EmployeeCrud.Controllers
{
    public class EmployeeController : Controller
    {
        RecordsContext context = new RecordsContext();
        
        // GET: Employee
        public ActionResult GetEmployees()
        {
            return View("Index",context.Employees.ToList());
        }

        [HttpGet]
        public ActionResult GetInsertPage()
        {
            return View("InsertEmployee");
        }

        [HttpPost]
        public ActionResult InsertEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("GetEmployees");
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            Employee emp = context.Employees.Find(id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("GetEmployees");
        }
    }
}