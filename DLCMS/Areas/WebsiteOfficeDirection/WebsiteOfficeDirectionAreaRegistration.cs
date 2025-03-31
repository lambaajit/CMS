using System.Web.Mvc;

namespace DLCMS.Areas.WebsiteOfficeDirection
{
    public class WebsiteOfficeDirectionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WebsiteOfficeDirection";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WebsiteOfficeDirection_default",
                "WebsiteOfficeDirection/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}