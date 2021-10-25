using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class PageScripts:APageScripts
    {
        public override StringBuilder getPageScript()
        {
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<script type=\"text/javascript\" src=\"/js/mootools-1.2.1-core.js\"></script>");
            SB.AppendLine("<script type=\"text/javascript\" src=\"/js/mootools-1.2-more.js\"></script>");
            SB.AppendLine("<script type=\"text/javascript\" src=\"/js/mootools-fluid16-autoselect.js\"></script>");
            SB.AppendLine("<script src=\"../js/script.js\"></script>");
            SB.AppendLine("<script src=\"http://www.google-analytics.com/urchin.js\" type=\"text/javascript\">");
            SB.AppendLine("</script>");

            SB.AppendLine("<script type=\"text/javascript\"> ");
            SB.AppendLine("var $j = jQuery.noConflict(); ");
            SB.AppendLine("$j(document).ready(function() { ");
            SB.AppendLine("$j(\"#Mdepart\").click(function() { ");
            SB.AppendLine("$j(\".Mhomemenu\").toggle(\"down\"); ");
            SB.AppendLine("$j(this).toggleClass(\"uparrow\"); ");
            SB.AppendLine("}); ");
            SB.AppendLine("}); ");
            SB.AppendLine("</script> ");
            SB.AppendLine("<script src=\"../js/html5shiv.js\"></script>");
            SB.AppendLine("<script src=\"../js/Respond.js\"></script>");

            return SB;
        }
    }
}
