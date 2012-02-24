using System.Web.Mvc;

namespace MvcMovie.Areas.Ranch
{
    public class RanchAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Ranch";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Ranch_default",
                "Ranch/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
