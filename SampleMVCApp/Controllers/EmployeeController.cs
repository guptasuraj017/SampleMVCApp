using SampleMVCApp.ApplicationDbContext;
using SampleMVCApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
namespace SampleMVCApp.Controllers
{
 
    public class EmployeeController : Controller
    { 
        private readonly AppDbContext appDbContext = new AppDbContext();
        public ActionResult Index()
        {

            try
            {
                return View(appDbContext.Employees.ToList());
            }
            catch (Exception)
            {

                return View("Error");
            }
        }


        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

       
        [HttpPost]
        public ActionResult Create( Employee employee)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    appDbContext.Employees.Add(employee);
                    appDbContext.SaveChanges();
                   
                }


                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = appDbContext.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = appDbContext.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            catch (Exception)
            {

                return View("Error");
            }

        }
        
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    appDbContext.Entry(employee).State = EntityState.Modified;
                    appDbContext.SaveChanges();
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
                Employee employee = appDbContext.Employees.Find(id);
                appDbContext.Employees.Remove(employee);
                appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

      
       
    }
}
