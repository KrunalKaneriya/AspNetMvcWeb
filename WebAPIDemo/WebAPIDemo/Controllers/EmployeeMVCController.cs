using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class EmployeeMVCController : Controller
    {
        EmployeeEntities context = new EmployeeEntities();
        // GET: EmployeeMVC
        public ActionResult Index()
        {
            return View("Index",context.Employees.ToList());
        }

        public ActionResult Find()
        {
            return View("Find");
        }
    }
}