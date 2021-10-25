using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class RightColoumn:ARightColoumn
    {
        public override StringBuilder getRightColoumn(DepartmentDetails DD, AContents _Content)
        {
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("    <div class=\"col-lg-3 col-md-3 col-sm-3 visible-lg visible-md visible-sm rightcoloumn\">");
            SB.AppendLine("        <div id=\"Quote\">\"" + DD.Heading21 + "\"</div>");
            SB.AppendLine("          <ul class=\"bigbuts\">");
            SB.AppendLine("            <li style=\"padding-top:8px;\"><a href=\"#\" class=\"bigbuts_tel\"><span>Telephone</span><br/><span><strong>033 3772 0409</strong></span></a></li>");
            SB.AppendLine("\t        <li><a class=\"bigbuts_online\" href=\"/onlineenquiry.html\"><span>Contact Us</span></a></li>");
            SB.AppendLine("         \t<li><a class=\"bigbuts_find\" href=\"/findus.html\"><span>Find Us</span></a></li>");
            SB.AppendLine("          </ul>");
            SB.AppendLine("       <div class=\"bigbuts_seperator\"></div>");
            SB.AppendLine("        <ul class=\"bigbuts\">");
            SB.AppendLine("          <li><a class=\"bigbuts_payments\" href=\"/payments.aspx\"><span>Make a Payment</span></a></li>");
            SB.AppendLine("          <li><a class=\"bigbuts_brochure\" href=\"/brochures.html\"><span>Brochures</span></a></li>");
            SB.AppendLine("          <li><a class=\"bigbuts_ourpeople\" href=\"/Our_Team.html\"><span>Meet our people</span></a></li>      ");
            SB.AppendLine("          <li><a class=\"bigbuts_eu\" href=\"/European-Union-Solicitors.html\"><span>European Union</span></a></li> ");
            SB.AppendLine("        </ul>");
            SB.AppendLine("        <div class=\"bigbuts_seperator\"></div>");
            SB.AppendLine("<!--custom contents-->");
            SB.AppendLine(_Content.rightcolcontents.ToString());
            SB.AppendLine("        <ul class=\"bigbuts\">");
            SB.AppendLine("          <li><a href=\"#\" style=\"background-position:0px 0px; height:50px;\" class=\"bigbuts_accreditation\"><span>Our Quality Marks</span></a></li>");
            SB.AppendLine("        </ul>");
            SB.AppendLine("        <div id=\"reportedtop\" style=\"padding:10px; text-align:center;margin-bottom:10px\">");
            SB.AppendLine("          <img alt=\"Duncan Lewis Solicitors, Lawyers, Legal Aid, Free legal Advice\" style=\"border:Solid 0px #888888;max-width:200px; margin:10px;\" src=\"" + DD.lawlogoimg + "\" width=\"95%\" /></p>");
            SB.AppendLine("        </div>");
            SB.AppendLine("    </div>");

            return SB;

        }
    }
}
