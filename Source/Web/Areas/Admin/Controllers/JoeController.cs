using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Infrastructure;
namespace MvcMovie.Areas.Admin.Controllers{
    public class JoeController : CruddyController {



        public JoeController(ITokenHandler tokenStore)
            : base(tokenStore)
        {
        }


        //           /Test/Joe/About 
        public ActionResult About()
        {
            return View();
        }



    }
}


