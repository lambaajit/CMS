using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class PageHeader : APageHeader
    {
        public StringBuilder headercontents {get; set;}
        public override StringBuilder getpageheader()
        {
            MainNavigation MN = new MainNavigation();
            StringBuilder SB = new StringBuilder();

            SB.AppendLine("  <nav class=\"navbar navbar-default top-header-style\" data-spy=\"affix\" data-offset-top=\"0\">");
            SB.AppendLine("\t\t<div class=\"container-fluid\">");
            SB.AppendLine("                \t\t<div class=\"navbar-header\">");
            SB.AppendLine("<button class=\"btn btn-default navbar-btn pull-right hidden-sm  hidden-md hidden-lg navheaderbuttons\" data-toggle=\"collapse\" data-target=\"#div_linked_to_button\"><img alt=\"Duncan Lewis\" src=\"/images/home.png\" /></button>");
            SB.AppendLine("<a href=\"tel:033 3772 0409\" class=\"btn btn-default navbar-btn pull-right hidden-sm hidden-md hidden-lg navheaderbuttons\"><img alt=\"Duncan Lewis\" src=\"/images/call.png\" /></a>");
            SB.AppendLine("<a href=\"/contactus.aspx\" class=\"btn btn-default navbar-btn pull-right hidden-sm hidden-md hidden-lg navheaderbuttons\"><img alt=\"Duncan Lewis\" src=\"/images/contact.png\" /></a>");
            SB.AppendLine("<a class=\"navbar-brand\" href=\"../index.html\"><img alt=\"Duncan Lewis\" class=\"img-responsive\" src=\"/images/DuncanLewis_logo.gif\"  alt=\"Duncan Lewis - Giving people a voice\" description=\"Duncan Lewis - Giving people a voice\"/></a>");
            SB.AppendLine("                        </div>");
            SB.AppendLine("                        <div class=\"collapse navbar-collapse navbar-right\" id=\"div_linked_to_button\">");
            SB.AppendLine("                               <ul class=\"nav navbar-nav\">");
            SB.AppendLine(MN.getmainnavigation().ToString());
            SB.AppendLine("                                </ul>");
            SB.AppendLine("\t\t\t</div>");
            SB.AppendLine("\t      </div>");
            SB.AppendLine("      </nav>");


            return SB;
        }
    }
}
