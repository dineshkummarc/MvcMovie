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
namespace MvcMovie.Areas.Admin.Controllers{
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
            }).OrderByDescending(x => x.UpdatedAt);
            var grid = new KendoGrid< CustomerDto>(request, dto);
            return Json(grid);
        }
         
 
    }
}

