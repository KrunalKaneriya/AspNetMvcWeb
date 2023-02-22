using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace EmployeeService.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBEntities context = new EmployeeDBEntities())
            {
                return context.Employees.ToList();
            }
        }
    }
}
