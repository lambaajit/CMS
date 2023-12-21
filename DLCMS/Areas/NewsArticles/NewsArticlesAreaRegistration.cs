using System.Web.Mvc;

namespace DLCMS.Areas.NewsArticles
{
    public class NewsArticlesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NewsArticles";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NewsArticles_default",
                "NewsArticles/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}