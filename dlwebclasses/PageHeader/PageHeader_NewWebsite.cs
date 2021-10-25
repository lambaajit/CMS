using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class PageHeader_NewWebsite:APageHeader
    {
        
        public override StringBuilder getpageheader()
        {

            StringBuilder SB = new StringBuilder();
            SB.AppendLine("            <div class=\"row nopadding\">");
            SB.AppendLine("                <div class=\"col-lg-8 col-sm-12 col-xs-12 col-lg-offset-2 applyblock centerdiv header nopadding\">");

            SB.AppendLine("                    <div class=\"row nopadding\">");
            SB.AppendLine("                        <div class=\"col-sm-4 col-xs-5 nopadding\">");
            SB.AppendLine("                            <a href=\"/index.html\"><img src=\"/Images/DL_Logo.PNG\" alt=\"Duncan Lewis Solicitors\" class=\"img-responsive dllogo\" /></a>");
            SB.AppendLine("                        </div>");
            SB.AppendLine("                        <div class=\"col-sm-8 col-xs-7 nopadding\">");
            SB.AppendLine("                            <div class=\"headerright\">");
            SB.AppendLine("<form method=\"get\" action=\"https://www.google.co.uk/search\">");
            SB.AppendLine("                                <p><font class=\"lightcyantext\">Have a question?</font><br /><span class=\"fa fa-phone\"></span>033 3772 0409</p>");
            SB.AppendLine("                                <input type=\"text\" name=\"q\" id=\"q\" class=\"form-control hidden-xs\" />");
            SB.AppendLine("                                <button name=\"searchgoogle\" id=\"searchgoogle\" class=\"btn btn-primary hidden-xs\" value=\"search\"><span class=\"fa fa-search\"></span></button>");
            SB.AppendLine("</form>");
            SB.AppendLine("                            </div>");
            SB.AppendLine("                        </div>");
            SB.AppendLine("                    </div>");
            SB.AppendLine("                </div>");
            SB.AppendLine("            </div>");
            return SB;
        }
}
}
