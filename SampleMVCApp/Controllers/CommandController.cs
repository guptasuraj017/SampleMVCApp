using System.Web.Http;
using System.Web.Mvc;
using System;
using MongoDB.Bson;
using System.Collections.Generic;
using BusinessLayer;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;

namespace SampleMVCApp.Controllers
{
    
    public class CommandController : Controller
    {
        private readonly BusinessLayer.CommandRepo commandRepo =new BusinessLayer.CommandRepo();

        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult RunCommand(Command command)
        {

            try
            {
                var result = commandRepo.RunCmdlets(command);
                var baseObject = result[0].BaseObject;
                var jsonBaseObject= JsonConvert.SerializeObject(baseObject);
                return Json(jsonBaseObject, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }

        }
        
       
       
        
    }

}