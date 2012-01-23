using System.Collections.Generic;
using System.Web.Mvc;
using Web.Infrastructure;
using MvcMovie.Models;
namespace MvcMovie.Areas.Admin.Controllers{
    public class UsersController : CruddyController {
        public UsersController(ITokenHandler tokenStore)
            : base(tokenStore)
        {
            _table = new Users();
            ViewBag.Table = _table;
        }


        public override ViewResult Index()
        {
            IEnumerable<dynamic> items = Get();
            return View(items);
        }


         

         
        public ActionResult About()
        {
            return View();
        }


    }
}

