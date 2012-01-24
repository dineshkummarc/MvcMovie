using System.Web;
using System.Web.Mvc;
using Web.Infrastructure;
using Web.Infrastructure.Logging;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : ApplicationController
    {


        
        public HelloWorldController(ITokenHandler tokenStore, ILogger logger)
        {
            TokenStore = tokenStore;
            Logger = logger; 
        }

        public HelloWorldController(ITokenHandler tokenStore):this( tokenStore, new NLogger()) { }

        public HelloWorldController() : this(new FormsAuthTokenStore()) { }





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