using Glimpse.Core.Configuration;
using NLog.Layouts;
using Web.Infrastructure;
using MvcMovie.Models;
using Web.Attributes;
using System.Web.Mvc;
using Massive;
namespace MvcMovie.Areas.Admin.Controllers
{ 
    [AuthorizeByRole(Roles = "Administrator,Dev,Log,Audit")]  
    public class LogsController : CruddyController
    {
        public LogsController(ITokenHandler tokenStore)
            : base(tokenStore)
        {
            _table = new Log();
            ViewBag.Table = _table;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TestLogger()
        {
            var desc = "test";
            //var level = ""; 
            //var Logger = "";
            //var Status= ""; 
            //var IpAddress= "";  
            //var Browser= "";
            //var Server= "";  
            //var Session= "";  
            //var UserName= "";
            //var Application= "";  
            //var Type= "";   
            //var Email= ""; 
            //var Layout = ""; 
            var v = DynamicModel.Open("ApplicationConnectionString").Query("exec InsertLog2 @0 ", desc  );
            var x = v.GetEnumerator() ;
            return RedirectToAction("Index");
        }


        /*0
        var sales = DynamicModel.Open("VidPub").Query("exec Reports_AnnualSales @0", year);
          
            InsertLog  ( 
                @Description, 
                SUBSTRING(@Description, 1, 100),  
                @Level,  
                @Logger , 
                @Status,  
                @IpAddress,  
                SUBSTRING(@Browser, 1, 100),  
                @Server,  
                @Session,  
                @UserName,  
                @Application,  
                SUBSTRING(@Type, 1, 100),  
                @Email,  
                @Layout  )   return View(sales);

    */

        protected override dynamic Get()
        { 
             var   ret = _table.All(  orderby:"UpdatedAt DESC"); 
            return ret;
        } 
         



    }
}

