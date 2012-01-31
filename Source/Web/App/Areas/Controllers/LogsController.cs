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

         


        //public override ViewResult Index()
        //{
        //    //return _table.Paged(where: "BaseId = @0", orderby: "DateUpdated DESC", currentPage: currentPage, pageSize: pageSize, args: baseId); 
        //    return base.Index();
        //}

        public override ViewResult Index(int? id)
        {
            //return _table.Paged(where: "BaseId = @0", orderby: "DateUpdated DESC", currentPage: currentPage, pageSize: pageSize, args: baseId); 
            //var model = _table.Paged(orderby: "UpdatedAt DESC", currentPage: page, pageSize: 5); 
            int page = id ?? 1; 
            int ps = 20;
            var model = _table.Paged(where: "1=1", orderBy: "UpdatedAt DESC", currentPage: page, pageSize: ps);

            ViewBag.CurrentPage = page;
            ViewBag.TotalRecords = model.TotalRecords;
            ViewBag.TotalPages = model.TotalPages;
            ViewBag.PageSize = ps; 
            return View(model.Items);
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


    }
}

