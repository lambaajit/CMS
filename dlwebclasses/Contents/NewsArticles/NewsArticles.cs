using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Configuration;

namespace dlwebclasses
{
    public class NewsArticles
    {
        private int id;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public string filepath { get; set; }
        public StringBuilder Contents { get; set; }

        public NewsArticles(int ID)
        {
            id = ID;
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            Updates_MainWebsites WP = new Updates_MainWebsites();
            WP = db.Updates_MainWebsites.Where(x => x.ID == ID).FirstOrDefault();

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

            if (DD.departmenttype== "AreaOfLaw")
            HeadingH1 = DD.Name + " Solicitors";
            else
            HeadingH1 = DD.Name.Replace("Main","News");
            

            Department = WP.Department;

            string imgstr = "";
            string contentstext = "";
            string Update_Title = "";
            string contents = "";
            string breadcrumb = "";
            string baililink = "";

            if (WP.Department == "Reported Case")
                baililink = "<p>&nbsp;</p><h5><a href=\"" + WP.Brief + "\" target=\"_blank\">Find full details of this case on Bailii’s website here.</a></h5>";


            Update_Title = WP.filename + " (" + ((DateTime)WP.Date_Update).Day.ToString() + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((((DateTime)WP.Date_Update).Month)) + " " + ((DateTime)WP.Date_Update).Year.ToString() + ")";
            string Linktext = WP.Title + " (" + ((DateTime)WP.Date_Update).Day.ToString() + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((((DateTime)WP.Date_Update).Month)) + " " + ((DateTime)WP.Date_Update).Year.ToString() + ")";
            contentstext = "<p>" + WP.Contents.ToString().Replace("^", "'").Replace("***", "</p><h6>").Replace("**", "</h6><p>").Replace("*is*", "<i>").Replace("*ie*", "</i>").Replace("*bis*", "<b><i>").Replace("*bie*", "</b></i>").Replace(". " + (char)13, ".<br />").Replace("." + (char)13, ".<br />").Replace("</br>", "<br />").Replace("" + (char)13,"<br />") + "</p>";
            if (WP.Department == "Legal News")
                imgstr = "<img style=\"padding-right:15px; padding-bottom:15px; float:left;\" src=\"../images_newarticles/" + WP.Blog_Department + ".jpg\" alt=\"Duncan Lewis, " + DD.Name + " Solicitors, " + WP.Title + "\" width=\"200px\" />";
            else if (WP.Image == true && WP.video != true)
                imgstr = "<img style=\"padding-right:15px; padding-bottom:15px; float:left;\" src=\"../ArticlesImages/" + ID + ".jpg\" alt=\"Duncan Lewis, " + WP.Department.ToString().Replace("'", "^") + " Solicitors, " + WP.Title + "\" width=\"200px\" />";
            else if (WP.video == true)
                imgstr = "";
            else if (WP.Image != true)
                imgstr = "<img style=\"padding-right:15px; padding-bottom:15px; float:left;\" src=\"http://www.duncanlewis.co.uk/ArticlesImages/DLStandardNewsImage.JPG\" alt=\"Duncan Lewis, " + WP.Department.ToString().Replace("'", "^") + " Solicitors, " + WP.Title + "\" width=\"200px\" />";

            contents = "<h4>" + Linktext.Replace("^", "'") + "</h4>" +
                    "<div id=\"segregator\"><p><div id=\"thumbsdate\">Date: <strong>" + ((DateTime)WP.Date_Update).ToString().Substring(0,10) + "</strong></div></p></div>" +
                    "<div id=\"maincontent\"><br />" + imgstr + "<p>" + contentstext + "</p></h5>" + baililink + "</div>";

            if (WP.category == "DL" && DD.departmenttype == "AreaOfLaw")
                breadcrumb = DD.Name + " News";
            else if (WP.category == "NonDL" && DD.departmenttype == "AreaOfLaw")
                breadcrumb = DD.Name + " Articles";
            else if (DD.departmenttype != "AreaOfLaw")
                breadcrumb = DD.Name;



            StringBuilder SB = new StringBuilder();
            SB.AppendLine("    <div id=\"breadcrumb\" class=\"visible-lg visible-md visible-sm\">");

            if (DD.Name == "Main")
                SB.AppendLine("      <p><a href=\"/index.html\">Home</a> &#9654; <a href=\"../news.html\">News</a> &#9654; " + WP.Title + "</p>");
            else
                SB.AppendLine("      <p><a href=\"/index.html\">Home</a> &#9654; <a href=\"../" + DD.Overview1 + "\">" + DD.Name + "</a> &#9654; " + breadcrumb + "</p>");

            SB.AppendLine("    </div>");

            SB.AppendLine(contents);
            Contents = SB;
            filepath = ConfigurationManager.AppSettings["Rootpath"].ToString() + "\\" + DD.folder1 + "\\" + Update_Title.ToString().Replace("?", "").Replace(":", "").Replace("-", "").Replace("^", "").Replace(" ", "_").Replace("/", "").Replace("'", "").Replace("%", "") + ".html";

        }

    }
}
