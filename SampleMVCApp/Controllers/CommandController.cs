using System.Web.Http;
using System.Web.Mvc;
using System;

namespace SampleMVCApp.Controllers
{
    
    public class CommandController : Controller
    {
        private readonly BusinessLayer.Command commandClass =new BusinessLayer.Command();
        [System.Web.Mvc.HttpGet]
        public ActionResult RunCommand()
        {
            try
            {
                ViewBag.BaseObject = null;
                return View();
            }
            catch (Exception)
            {

                return View("Error");
            }
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult RunCommand([FromBody]string commandName)
        {
            try
            {
                var result = commandClass.RunCmdlets(commandName);
                var baseObject = result.BaseObject;
                ViewBag.BaseObject = baseObject;
                return View();
            }
            catch (Exception)
            {

                return View ("Error");
            }
            
        }
    }
}