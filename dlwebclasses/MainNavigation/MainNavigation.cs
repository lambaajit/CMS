using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    class MainNavigation:IMainNavigation
    {
        public StringBuilder getmainnavigation()
        {
            StringBuilder homenavtab1 = new StringBuilder();
            homenavtab1.AppendLine("<li class=\"top_nav_bar\"><a href=\"/index.html\"><span>Home</span></a></li>   ");
            homenavtab1.AppendLine("<li class=\"top_nav_bar\"><a href=\"/about.html\"><span>About Us</span></a></li>");
            homenavtab1.AppendLine("<li class=\"top_nav_bar\"><a href=\"/fees.html\"><span>Fees and Funding</span></a></li>");
            homenavtab1.AppendLine("<li class=\"top_nav_bar\"><a href=\"/careers.html\"><span>Careers</span></a></li>");
            homenavtab1.AppendLine("<li class=\"top_nav_bar\"><a href=\"/news.html\"><span>News</span></a></li>");
            homenavtab1.AppendLine("<li class=\"visible-xs top_nav_bar\"><a href=\"/onlineenquiry.html\"><span>Contact Us</span></a></li>");
            homenavtab1.AppendLine("<li class=\"visible-xs top_nav_bar\"><a href=\"/findus.html\"><span>Find Us</span></a></li>");
            homenavtab1.AppendLine("<li class=\"visible-xs top_nav_bar\"><a href=\"/payments.aspx\"><span>Make a Payment</span></a></li>");
            homenavtab1.AppendLine("<li class=\"visible-xs top_nav_bar\"><a href=\"/brochures.html\"><span>Brochures</span></a></li>");
            homenavtab1.AppendLine("<li class=\"visible-xs top_nav_bar\"><a href=\"/Our_Team.html\"><span>Meet our people</span></a></li>");
            homenavtab1.AppendLine("<li class=\"dropdown visible-lg top_nav_bar\">");
            homenavtab1.AppendLine("<a href=\"#\" data-toggle=\"dropdown\" class=\"navbar-collapse\">Text Size<span class=\"caret\"></span></a>");
            homenavtab1.AppendLine("<ul class=\"dropdown-menu\">");
            homenavtab1.AppendLine("<li><a href=\"#\" onclick=\"javascript:setActiveStyleSheet('A');\">A</a></li>");
            homenavtab1.AppendLine("<li><a href=\"#\" onclick=\"javascript:setActiveStyleSheet('A+');\">A+</a></li>");
            homenavtab1.AppendLine("<li><a href=\"#\" onclick=\"javascript:setActiveStyleSheet('A++');\">A++</a></li>");
            homenavtab1.AppendLine("</ul>");
            homenavtab1.AppendLine("</li>");
            return homenavtab1;

        }
    }
}
