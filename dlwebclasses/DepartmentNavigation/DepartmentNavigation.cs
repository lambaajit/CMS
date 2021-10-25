using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class DepartmentNavigation : ADepartmentNavigation
    {



        public override StringBuilder getDepartmentNavigation(DepartmentDetails DD,int? activenode = 0)
        {
          IT_DatabaseEntities db = new IT_DatabaseEntities();
          string filterstring = "";
          string filterstring1 = "";
          if (DD.Name == "Management Board")
              DD.Name = "About Us";

              filterstring = " where department = '" + DD.Name + "' ";
              filterstring1 = " and department = '" + DD.Name + "' ";
          
          
            var sub_departments = db.Database.SqlQuery<subdepartments>("select department, sub_department, sequence1 from Website_Pages_SubDepartments" + filterstring + " order by sequence1").ToList();
            StringBuilder SB = new StringBuilder();
            
            foreach (subdepartments sub_d in sub_departments)
            {

                var links = db.Database.SqlQuery<navigationlinks>("select case when RewriteURL is null then filename + '.html' when RewriteURL ='' then filename + '.html' else RewriteURL End as filename, case when sub_department = 'Overview' then 'Overview' when (anchortextnavigation is null or len(anchortextnavigation) < 4) then name else anchortextnavigation End as name from Website_Pages where sub_department = '" + sub_d.sub_department + "' " + filterstring1 + " order by name").ToList();
                if (links.Count > 1 && sub_d.sub_department != "Main")
                {
                    SB.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">" + sub_d.sub_department.ToString() + "<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
                    SB.AppendLine("<ul class=\"dropdown-menu\">");
                }
                foreach (navigationlinks nl in links)
                {
                    if (links.Count < 2 && sub_d.sub_department != "Main")
                    {
                        SB.AppendLine("<li role=\"presentation\"><a href=\"/" + nl.filename.ToString() + "\">" + nl.name.ToString() + "</a></li>");
                    }
                    else
                    {
                        SB.AppendLine("<li role=\"presentation\"><a href=\"/" + nl.filename.ToString() + "\"  style=\"text-decoration:none\">" + nl.name.ToString() + "</a></li>");
                    }
                }
                if (links.Count > 1 && sub_d.sub_department != "Main")
                {
                    SB.AppendLine("</ul>");
                    SB.AppendLine("</li>");
                }
            }

            if (DD.Name == "Immigration")
            {
                SB.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-uk-immigration.html\"  style=\"text-decoration:none\">Business Immigration</a></li>");
            }

            Website_Department_Structure wds = new Website_Department_Structure();
            wds = db.Website_Department_Structure.Where(x => x.Name == DD.Name).FirstOrDefault();
            if (wds.departmenttype.ToString() == "AreaOfLaw")
            {
                if (wds.Our_Team1.ToString().Length > 5)
                { 
                SB.AppendLine("<li role=\"presentation\"><a href=\"/" + wds.Our_Team1.ToString() + "\">Team</a></li>");
                }
                if (wds.News1.ToString().Length > 5)
                {
                    SB.AppendLine("<li role=\"presentation\"><a href=\"/" + wds.News1.ToString() + "\">DL News</a></li>");
                    SB.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + wds.News1.ToString().Replace("news", "articles") + "\">Articles</a></li>");
                }
            }
            else if (DD.Name == "Misleneous")
            {
                SB.Clear();
                SB.AppendLine("  \t    <li role=\"presentation\"><a href=\"/Index.html\">Home</a></li>");
            }
            else if (DD.Name.ToString() == "Find Us")
            {
                SB.Clear();
                SB.AppendLine("<li role=\"presentation\"><a href=\"/findus.html\">Our Offices</a></li>");
                SB.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/branchLocator_DL_WithMap.aspx\">Branch Locator</a></li>");
            }


            else if (wds.departmenttype.ToString() == "News")
            {
                System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                string strMonthName = mfi.GetMonthName(DateTime.Now.Month).ToString();
                SB.AppendLine("  \t    <li role=\"presentation\"><a href=\"/news.html\">News</a></li>");
                SB.AppendLine("        <li role=\"presentation\"><a href=\"/InThePress.html\">In the Press</a></li>");
                SB.AppendLine("        <li role=\"presentation\"><a href=\"/Reportedcases.html\">Reported Cases</a></li>");
                SB.AppendLine("        <li role=\"presentation\" ><a href=\"/Legal_News.html\">Legal News</a></li>");
            }
            else if (wds.departmenttype.ToString() == "Jobs")
            {
                SB.Clear();
                SB.AppendLine("  \t    <li role=\"presentation\"><a href=\"/careers.html\">Careers</a></li>");
                SB.AppendLine("        <li role=\"presentation\"><a href=\"/Jobs_Caseworker.html\">Paralegal Jobs</a></li>");
                SB.AppendLine("        <li role=\"presentation\"><a href=\"/trainees.html\">Trainees</a></li>");
                SB.AppendLine("        <li role=\"presentation\"><a href=\"/Jobs_Solicitors.html\">Solicitor Jobs</a></li>");
                SB.AppendLine("        <li role=\"presentation\"><a href=\"/JobsConsultancy.html\">Consultant Solicitors Jobs</a></li>");
                SB.AppendLine("        <li role=\"presentation\"><a href=\"/Jobs_Admin.html\">Admin Jobs</a></li>");
                SB.AppendLine("        <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"http://www.dalstonsolicitors.co.uk/internship.aspx\">Internship</a></li>");
            }


            StringBuilder SB1 = new StringBuilder();

            SB1.AppendLine("<div class=\"col-md-12 col-xs-12\" style=\"padding:0px;\">");
            SB1.AppendLine("<div class=\"panel panel-default custompanel\">");
            SB1.AppendLine("<div class=\"panel-heading visible-xs\"><a data-toggle=\"collapse\" data-target=\"#collapse1\">" + DD.Name + "&nbsp;&nbsp;<span style=\"margin-top:0px;\" class=\"caret\"></span></a></div>");
            SB1.AppendLine("<div id=\"collapse1\" class=\"panel-collapse collapse panelbodydiv\">");
            SB1.AppendLine("<ul class=\"nav nav-pills\">");

            SB1.AppendLine(SB.ToString());

            SB1.AppendLine("</ul>");
            SB1.AppendLine("</div>");
            SB1.AppendLine("</div>");
            SB1.AppendLine("</div>");



            return SB1;
        }        
    }
    public class subdepartments
    {
        public string department { get; set; }
        public string sub_department { get; set; }
        public int sequence1 { get; set; }

    }
    public class navigationlinks
    {
        public string name { get; set; }
        public string filename { get; set; }
        public string RewriteURL { get; set; }
    }
}
