using System.Web.Mvc;

namespace DLCMS.Areas.WebsitePages
{
    public class WebsitePagesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WebsitePages";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WebsitePages_default",
                "WebsitePages/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}