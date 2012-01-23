using Web.Infrastructure;
using MvcMovie.Models;
namespace MvcMovie.Areas.Admin.Controllers{
    public class RolesController : CruddyController {
        public RolesController(ITokenHandler tokenStore):base(tokenStore) {
            _table = new Roles();
            ViewBag.Table = _table;
        }

         

    }
}

