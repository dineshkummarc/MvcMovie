using Web.Infrastructure;
using MvcMovie.Models;
namespace MvcMovie.Areas.Admin.Controllers{
    public class RoleMembershipsController : CruddyController {
        public RoleMembershipsController(ITokenHandler tokenStore):base(tokenStore) {
            _table = new RoleMemberships();
            ViewBag.Table = _table;
        }






         


    }




}

