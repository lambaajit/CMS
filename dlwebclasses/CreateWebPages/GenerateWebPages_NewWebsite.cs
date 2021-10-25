using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class GenerateWebPages_NewWebsite
    {
        public StringBuilder PageContent { get; set; }
        public GenerateWebPages_NewWebsite(AContents _content)
        {
            AWebPage WP = new WebPage_NewWebsite();
            client_WebPage cwp = new client_WebPage(WP, _content);
            StringBuilder SB = new StringBuilder();


            //Start of document

            SB.AppendLine("<!DOCTYPE html>");
            SB.AppendLine("<html xmlns=\"https://www.w3.org/1999/xhtml\" lang=\"en\">");
            SB.AppendLine(cwp.getheadsection().ToString());

            if (_content.GetType() == typeof(Content_StaffProfileNewWebsite))
            {
                SB.Append("<body data-spy=\"scroll\" data-target=\".profilenav\" data-offset=\"100\">");
            }
            else
            {
                SB.Append("<body>");
            }
            

            SB.AppendLine("<div class=\"row nopadding\">");
            SB.AppendLine("<div class=\"col-sm-12 col-md-12 col-sm-12 col-xs-12 nopadding\">");

            if (_content.GetType() == typeof(Content_HomePage)){
                MainNavigationNewWebsite MN = new MainNavigationNewWebsite();
                SB.AppendLine(MN.getmainnavigation().ToString());
            }
            else
            {
                SB.AppendLine("<div class=\"row nopadding\">");
                SB.AppendLine("<div w3-include-html=\"/MainNav.html\"></div>");
                SB.AppendLine("</div>");
            }

            SB.AppendLine(cwp.getpageheader().ToString());

            if (_content.GetType() != typeof(Content_StaffProfileNewWebsite) && _content.GetType() != typeof(Content_TeamPages_NewWebsite) && _content.GetType() != typeof(Content_AlphabeticPages_NewWebsite))
            {
                SB.AppendLine(cwp.getheadercontainer().ToString());
            }

            SB.AppendLine(cwp.getcontents().ToString());

            SB.AppendLine(cwp.getfooter().ToString());
            SB.AppendLine("</div>");
            SB.AppendLine("</div>");
             SB.AppendLine("</body>");

             if (_content.GetType() != typeof(Content_HomePage))
             {
                 SB.AppendLine("<script>");
                 SB.AppendLine("includeHTML();");
                 SB.AppendLine("</script>");
             }

            SB.AppendLine("</html>");
            PageContent = SB;
        }
    }
}
