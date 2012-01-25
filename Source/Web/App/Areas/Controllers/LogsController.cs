using Web.Infrastructure;
using MvcMovie.Models;
using Web.Attributes;
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


         

        protected override dynamic Get()
        { 
             var   ret = _table.All(  orderby:"UpdatedAt DESC"); 
            return ret;
        } 
         



    }
}

