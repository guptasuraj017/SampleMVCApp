using SampleMVCApp.ApplicationDbContext;
using SampleMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SampleMVCApp.ViewModel;

namespace SampleMVCApp.Controllers
{
 
    public class EmployeeController : Controller
    { 
        private readonly AppDbContext appDbContext = new AppDbContext();
        public ActionResult Index()
        {
            
            return View(appDbContext.Employees.ToList());
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
                    appDbContext.Employees.Add(employee);
                    appDbContext.SaveChanges();
                   
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(int? id)
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

        public ActionResult Edit(int? id)
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

        [HttpGet]
        public ActionResult DirectoryInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DirectoryInfo(FormCollection formCollection)
        {
            var directoryInfo = GetDirectoryDetails(formCollection[0]);
            return View(directoryInfo);
        }
        public DirectoryInfoViewModel GetDirectoryDetails(string path)
        {
            var pathConfigure = @path;
            var directory = new DirectoryInfo(pathConfigure);
            var directoryInfo = new DirectoryInfoViewModel()
            {
                DierecotoryList = directory.GetDirectories().ToList(),
                FileList = directory.GetFiles().ToList()

            };
            
            return directoryInfo;
        }
    }
}
