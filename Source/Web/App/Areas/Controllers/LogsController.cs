﻿using Glimpse.Core.Configuration;
using NLog.Layouts;
using Web.Infrastructure;
using MvcMovie.Models;
using Web.Attributes;
using System.Web.Mvc;
using Massive;
using System.Text;
using KendoGridBinder;
using System;

using System.Linq; 




namespace MvcMovie.Areas.Admin.Controllers
{

    public class LogDto
    {
        public string Summary {get; set;} 
        public string Level {get; set;} 
        public string IpAddress {get; set;} 
        public string Server {get; set;} 
        public string Session {get; set;} 
        public string User {get; set;} 
        public string Email {get; set;} 
        public DateTime Date {get; set;}  
    }

    [AuthorizeByRole(Roles = "Administrator,Dev,Log,Audit")]  
    public class LogsController : CruddyController
    {
        public LogsController(ITokenHandler tokenStore)
            : base(tokenStore)
        {
            _table = new Log();
            ViewBag.Table = _table; 
        }



        public ActionResult Index2()
        {
            return View();
        }
         

        [HttpPost]
        public JsonResult Grid(KendoGridRequest request)
        {
            var fromdb = ((Log)_table).All();
            var dto = fromdb.Select(x => new LogDto { User = x.User, Summary = x.Summary });
            var grid = new KendoGrid<LogDto>(request, dto);
            return Json(grid);
        }

        //public override ViewResult Index()
        //{
        //    //return _table.Paged(where: "BaseId = @0", orderby: "DateUpdated DESC", currentPage: currentPage, pageSize: pageSize, args: baseId); 
        //    return base.Index();
        //}


        [HttpPost]
        public virtual ViewResult Index( FormCollection form)
        {
            var s = form["Search"];
            var model = GetModel(null, s);
            return View(model.Items);
        }


        [HttpGet]
        public override ViewResult Index(int? id)
        {
            //return _table.Paged(where: "BaseId = @0", orderby: "DateUpdated DESC", currentPage: currentPage, pageSize: pageSize, args: baseId); 
            //var model = _table.Paged(orderby: "UpdatedAt DESC", currentPage: page, pageSize: 5); 
            var model = GetModel(id);
            return View(model.Items);
        }

        private dynamic GetModel(int? id, string searchExpression = "")
        {
            int page = id ?? 1;
            int ps = 25;
            var sb = new StringBuilder();
            sb.Append("IpAddress like '%'+@0+'%' or Email like '%'+@0+'%' or Summary like '%'+@0+'%' or Session like '%'+@0+'%'");
            var model = _table.Paged(where: sb.ToString(), orderBy: "UpdatedAt DESC", currentPage: page, pageSize: ps, args: searchExpression);

            ViewBag.CurrentPage = page;
            ViewBag.TotalRecords = model.TotalRecords;
            ViewBag.TotalPages = model.TotalPages;
            ViewBag.PageSize = ps;
            return model;
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

