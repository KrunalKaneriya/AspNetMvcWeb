using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    
    public class EmployeeController : ApiController
    {

        public List<Employee>Get()
        {
            using (EmployeeEntities context = new EmployeeEntities())
            {
                return context.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (EmployeeEntities context = new EmployeeEntities())
            {
                Employee existingEmployee = context.Employees.Find(id);
                Console.Write(existingEmployee.ToString());
                return existingEmployee;
            }
        }


        public string Post([FromBody] Employee emp)
        {
            using (EmployeeEntities context = new EmployeeEntities())
            {
                context.Employees.Add(emp);
                context.SaveChanges();
                return "data inserted post api";
            }
        }

        public HttpResponseMessage Put([FromBody] Employee emp)
        {
            using (EmployeeEntities context = new EmployeeEntities())
            {
                try
                {
                    Employee existingEmployee = context.Employees.Find(emp.Id);
                    existingEmployee.firstname = emp.firstname;
                    existingEmployee.lastname = emp.lastname;
                    existingEmployee.gender = emp.gender;
                    existingEmployee.salary = emp.salary;
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                } catch(Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                        
                }
               
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            using (EmployeeEntities context = new EmployeeEntities())
            {
                try
                {
                    Employee emp = context.Employees.Find(id);
                    context.Employees.Remove(emp);
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                } catch (Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                }
            }
        }


    }
}
