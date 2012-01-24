using System.Web;
using System.Web.Mvc;
using Web.Infrastructure;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : ApplicationController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        { 
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
    }
}