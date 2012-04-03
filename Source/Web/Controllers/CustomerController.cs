using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;  
using KendoGridBinder;
using System.Text;
using System.Web.Mvc;
using Web.Attributes;
using Web.Models;
using Web.Infrastructure;
using MvcMovie.App.Models;
namespace MvcMovie.Controllers{
    public class CustomerController : CruddyController 
	{
        public CustomerController(ITokenHandler tokenStore):base(tokenStore) 
		{
            _table = new Customer();
            ViewBag.Table = _table;
        }


        public override ViewResult Index()
        {
            return View();
        } 
        [AuthorizeByRole(Roles = "Dev")]
        public override ActionResult Edit(int id)
        {
            return base.Edit(id);
        }
        [AuthorizeByRole(Roles = "Dev")] 
        public override ActionResult Create()
        {
            return base.Create();
        }
        [AuthorizeByRole(Roles = "Dev")]
        public override ActionResult Details(int id)
        {
            return base.Details(id);
        }






        [HttpPost]
        public virtual ViewResult Index(FormCollection form)
        {
            TempData["query"] = form["Search"];
            var model = GetModel(null, (string)TempData["query"]);
            return View(model.Items);
        } 


        [HttpPost]
        public JsonResult Grid(KendoGridRequest request)
        {
            var fromdb = ((Customer)_table).All();
            var dto = fromdb.Select(x => new CustomerDto 
            { 
                Id = x.Id,
				UpdatedAt = x.UpdatedAt,
                IpAddress = x.IpAddress,
                Session = x.Session,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
				/*, Level = x.Level, Server = x.Server, UserName= x.UserName, 
                Summary = x.Summary,  
                Email = x.Email*/ 
            }).OrderByDescending(x => x.UpdatedAt);
            var grid = new KendoGrid< CustomerDto>(request, dto);
            return Json(grid);
        } 

        private dynamic GetModel(int? id, string searchExpression = "")
        {
            int page = id ?? 1;
            const int ps = 25;
            var whereClause = BuildWhereClause(searchExpression);
            var model = _table.Paged(where: whereClause, orderBy: "UpdatedAt DESC", currentPage: page, pageSize: ps, args: searchExpression);

            ViewBag.CurrentPage = page;
            ViewBag.TotalRecords = model.TotalRecords;
            ViewBag.TotalPages = model.TotalPages;
            ViewBag.PageSize = ps;
            return model;
        }

        private static string BuildWhereClause(string searchExpression)
        {
            var sb = new StringBuilder();
            if (string.IsNullOrEmpty(searchExpression))
            {
                sb.Append(" 1=1 ");
            }
            else
            {
                sb.Append(@"IpAddress LIKE ('%'+@0+'%') 
                        or Session LIKE('%'+@0+'%')
                        or XXXXXXX LIKE('%'+@0+'%')
                        or ZZZZZZZ LIKE('%'+@0+'%')");
            }
            var where = sb.ToString();
            return @where;
        } 
    }
}

