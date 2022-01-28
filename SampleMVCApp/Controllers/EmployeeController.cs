using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCApp.Controllers
{
 
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbEntities employeeDbEntities = new EmployeeDbEntities();
        public ActionResult Index()
        {
            
            return View(employeeDbEntities.Employees.ToList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Create( Employee employee)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    employeeDbEntities.Employees.Add(employee);
                    employeeDbEntities.SaveChanges();
                   
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeDbEntities.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeDbEntities.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);

        }
        
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeDbEntities.Entry(employee).State = EntityState.Modified;
                    employeeDbEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

      
        public ActionResult Delete(int ?id)
        {
            try
            {
                if (id==null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = employeeDbEntities.Employees.Find(id);
                employeeDbEntities.Employees.Remove(employee);
                employeeDbEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
