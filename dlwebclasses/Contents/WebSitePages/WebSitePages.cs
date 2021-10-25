using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace dlwebclasses
{
    public class WebSitePages
    {
        private int id;
            public string Title { get; set; }
            public string Description { get; set; }
            public string Keywords { get; set; }
            public string HeadingH1 { get; set; }
            public string Department { get; set; }
            public StringBuilder Contents { get; set; }
            public string filepath { get; set; }

        public WebSitePages(int ID)
        {
            id = ID;
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            Website_Pages WP = new Website_Pages();
            WP = db.Website_Pages.Where(x => x.ID == ID).FirstOrDefault();

            DepartmentDetails DD = new DepartmentDetails(WP.Department);

            if (!string.IsNullOrEmpty(WP.Title))
                Title = WP.Title;
            else
                Title = DD.Title1;

            if (!string.IsNullOrEmpty(WP.Keywords))
                Keywords = WP.Keywords;
            else
                Keywords = DD.Keywords1;

            if (!string.IsNullOrEmpty(WP.Description))
                Description = WP.Description;
            else
                Description = DD.Description1;

            HeadingH1 = WP.Name;
            Department = WP.Department;

            StringBuilder SB = new StringBuilder();
            SB.AppendLine("    <div id=\"breadcrumb\" class=\"visible-lg visible-md visible-sm\">");
            if (DD.Name == "Misleneous")
                SB.AppendLine("      <p><a href=\"index.html\">Home</a></p>");
            else
                SB.AppendLine("      <p><a href=\"index.html\">Home</a> | <a href=\"" + DD.Overview1 + "\">" + DD.Name + "</a> | " + WP.Name.ToString().Replace("<br />", " ") + " </p>");

            SB.AppendLine("    </div>");

            SB.AppendLine("<div id=\"maincontent\">");

            SB.AppendLine(WP.Text.ToString().Replace("^", "'"));
            //if (Datareader("filename").ToString != "about_managementboard" & Datareader("filename").ToString != "our_team")
            //{
            //    SB.AppendLine(listring);
            //}

            if (!string.IsNullOrEmpty(DD.contactstr1))
            {
                SB.AppendLine("<br /><a href=\"http://www.duncanlewis.co.uk/contactUs.aspx?dept=" + DD.contactstr1 + "\"><img src=\"images/ContactUs.png\" alt=\"Contact Us\" style=\"border-width:0px\" /></a><br />");
            }

            SB.AppendLine("    </div> ");

            Contents = SB;
            filepath = ConfigurationManager.AppSettings["Rootpath"].ToString() + "\\" + WP.Filename.ToString() + ".html";
            
        }

    }
}
