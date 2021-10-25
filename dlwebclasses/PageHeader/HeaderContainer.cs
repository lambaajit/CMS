using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class HeaderContainer:AHeaderContainer
    {
        public override StringBuilder getheadercontainer(DepartmentDetails DD, AContents _content)
        {
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("        <div class=\"container-fluid\">");
            SB.AppendLine("        <div class=\"row\">      ");
            SB.AppendLine("              <div class=\"col-lg-12 col-md-12\">");
            SB.AppendLine("                    <div id=\"" + DD.container1 + "\" class=\"col-lg-12 col-md-12\">");
            SB.AppendLine("    <h1>" + _content.HeadingH1 + "</h1>");
            SB.AppendLine("                    </div>");
            SB.AppendLine("                </div>      ");
            SB.AppendLine("        </div>");
            SB.AppendLine("</div>");
            return SB;
        }
    }
}
