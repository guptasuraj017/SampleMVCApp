using SampleMVCApp.ViewModel;
using System.Linq;
using System.Web.Mvc;
using System;

namespace SampleMVCApp.Controllers
{
    public class DirectoryController : Controller
    {
        private readonly BusinessLayer.Directory directory=new BusinessLayer.Directory();
        [HttpGet]
        public ActionResult DirectoryInfo()
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
        public ActionResult DirectoryInfo([System.Web.Http.FromBody]string path)
        {
            try
            {
                var directorydetails = directory.GetDirectoryDetails(path);
                var directoryInfo = new DirectoryInfoViewModel()
                {
                    DierecotoryList = directorydetails.GetDirectories().ToList(),
                    FileList = directorydetails.GetFiles().ToList()

                };
                return View(directoryInfo);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }
    }
}