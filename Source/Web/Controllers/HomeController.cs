using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }




        [HttpGet]
        public virtual ActionResult PersonalInfo()
        {
            this.FlashInfo("Hi");
            return View( );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult PersonalInfo(int id, FormCollection collection)
        {
            return View( );
            //var model = _table.CreateFrom(collection);
            //try
            //{
            //    // TODO: Add update logic here
            //    _table.Update(model, id);
            //    return RedirectToAction("Index");
            //}
            //catch (Exception x)
            //{
            //    TempData["Error"] = "There was a problem editing this record";
            //    ModelState.AddModelError(string.Empty, x.Message);
            //    return View(model);
            //}
        }



        [HttpGet]
        public ActionResult PaymentInfo()
        {
            this.FlashInfo("hello");
            throw new Exception("asdfasdfasdf");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaymentInfo(FormCollection collection)
        {
            return View();
        }
    }
}
