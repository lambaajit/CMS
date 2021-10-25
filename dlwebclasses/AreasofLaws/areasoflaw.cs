using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{

    class areasoflaw : AAreasOfLaw
    {

        public override Dictionary<String, StringBuilder> getareasoflaw(DepartmentDetails DD = null)
        {
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            List<Website_Department_Structure> WDS = new List<Website_Department_Structure>();
            WDS = db.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").OrderBy(x => x.NameForNavigation).ToList();
            StringBuilder SB = new StringBuilder();
            foreach (Website_Department_Structure WDS1 in WDS)
            {
                if (DD != null)
                {
                    if (DD.Name == WDS1.Name)
                    {
                        SB.AppendLine("<li><a href=\"/" + WDS1.Overview1 + "\" style=\"color:0b1a55\">" + WDS1.NameForNavigation + "</a></li>");
                    }
                    else
                    {
                        SB.AppendLine("<li><a href=\"/" + WDS1.Overview1 + "\">" + WDS1.NameForNavigation + "</a></li>");
                    }
                }
                else
                {
                    SB.AppendLine("<li><a href=\"/" + WDS1.Overview1 + "\">" + WDS1.NameForNavigation + "</a></li>");
                }
            }

            Dictionary<String, StringBuilder> dict = new Dictionary<String, StringBuilder>();

            StringBuilder SB1 = new StringBuilder();


            SB1.AppendLine("<div class=\"col-md-3 col-xs-12 visible-xs\" style=\"padding:0px 0px 0px 5px;\">");
            SB1.AppendLine("   <nav class=\"navbar navbar-default\" style=\"background-color:#FFF; border-bottom:Solid 0px #fff; margin-bottom:0px;\">");
            SB1.AppendLine("\t\t<div class=\"container-fluid\">");
            SB1.AppendLine("                \t\t<div class=\"navbar-header\">");
            SB1.AppendLine("                            <button type=\"button\" class=\"navbar-toggle collapsed\" data-toggle=\"collapse\" data-target=\"#div_departments\">");
            SB1.AppendLine("                            <span class=\"icon-bar\"></span>");
            SB1.AppendLine("                            <span class=\"icon-bar\"></span>");
            SB1.AppendLine("                            <span class=\"icon-bar\"></span>        ");
            SB1.AppendLine("                            </button>");
            SB1.AppendLine("                            <span class=\"navbar-brand navbarbrandaol\" data-toggle=\"collapse\" data-target=\"#div_departments\"><a>Areas of Law<span style=\"margin-top:0px;\" class=\"caret\"></span></a></span>");
            SB1.AppendLine("                        </div>");
            SB1.AppendLine("                         <div class=\"collapse navbar-collapse navbar-right\" id=\"div_departments\">");
            SB1.AppendLine("                                <ul class=\"nav navbar-nav\">");
            SB1.AppendLine(SB.ToString());
            SB1.AppendLine("                                </ul>");
            SB1.AppendLine("\t\t\t\t\t\t</div>");
            SB1.AppendLine("\t      </div>");
            SB1.AppendLine("      </nav>");
            SB1.AppendLine("</div>");

            dict.Add("Mobile", SB1);


            StringBuilder SB2 = new StringBuilder();



            SB2.AppendLine("<div class=\"col-md-3 col-xs-3 col-sm-3 visible-lg visible-md visible-sm\" style=\"padding:0px 0px 0px 0px;\">");
            SB2.AppendLine("  <nav class=\"navbar navbar-default\" style=\"background-color:#FFF; border:Solid 0px #fff;\">");
            SB2.AppendLine("\t\t<div class=\"container-fluid\" style=\"padding:0px;\">");
            SB2.AppendLine("                \t\t<div class=\"navbar-header\" style=\"width:100%;\">");
            SB2.AppendLine("                            <button type=\"button\" class=\"navbar-toggle collapsed\" data-toggle=\"collapse\" data-target=\"#div_departments\">");
            SB2.AppendLine("                            <span class=\"icon-bar\"></span>");
            SB2.AppendLine("                            <span class=\"icon-bar\"></span>");
            SB2.AppendLine("                            <span class=\"icon-bar\"></span>        ");
            SB2.AppendLine("                            </button>");
            SB2.AppendLine("                            <span  class=\"navbar-brand1\"><a>Areas of Law</a></span>");
            SB2.AppendLine("                        </div>");
            SB2.AppendLine("                        <div class=\"collapse navbar-collapse navbar-right\" style=\"padding:0px; width:100%\" id=\"div_departments\">");
            SB2.AppendLine("                                <ul class=\"nav navbar-nav\">");
            SB2.AppendLine(SB.ToString());
            SB2.AppendLine("                                </ul>");
            SB2.AppendLine("\t\t\t\t\t\t</div>");
            SB2.AppendLine("\t      </div>");
            SB2.AppendLine("      </nav>");
            SB2.AppendLine("                                  <div class=\"bigbuts_seperator\"></div>");
            SB2.AppendLine("                                  <div id=\"leftimg\"><img src=\"/images/" + DD.leftimage_under_deptmenu1 + "\" alt=\"Duncan Lewis\" /></div>");
            SB2.AppendLine("</div>");

            dict.Add("Desktop", SB2);

            return dict;

        }
    }
}
