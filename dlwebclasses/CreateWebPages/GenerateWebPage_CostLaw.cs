using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class GenerateWebPage_CostLaw
    {
        public StringBuilder PageContent { get; set; }
        public GenerateWebPage_CostLaw(AContents _content)
        {
            AWebPage WP = new WebPage_CostLaw();
            CostLaw_WebPage cwp = new CostLaw_WebPage(WP, _content);
            StringBuilder SB = new StringBuilder();


            //Start of document

            SB.AppendLine("<!DOCTYPE html>");
            SB.AppendLine("<html xmlns=\"https://www.w3.org/1999/xhtml\" lang=\"en\">");
            SB.AppendLine(cwp.getheadsection().ToString());
            SB.Append("<body>");
            SB.AppendLine("<div class=\"row nopadding\">");
            SB.AppendLine("<div class=\"col-sm-12 col-md-12 col-sm-12 col-xs-12 nopadding\">");
            SB.AppendLine(cwp.getpageheader().ToString());
            SB.AppendLine(cwp.getcontents().ToString());
            SB.AppendLine(cwp.getfooter().ToString());
            SB.AppendLine("</div>");
            SB.AppendLine("</div>");
            SB.AppendLine("</body>");
            SB.AppendLine("</html>");
            PageContent = SB;
        }
    }
}
