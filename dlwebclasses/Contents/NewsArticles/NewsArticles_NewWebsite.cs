using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class NewsArticles_NewWebsite
    {
        private int id;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public string filepath { get; set; }
        public StringBuilder Contents { get; set; }
        public string duplicateid { get; set; }

        public NewsArticles_NewWebsite(AContents _Acontent, int ID)
        {
            id = ID;
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            Updates_MainWebsites WP = new Updates_MainWebsites();
            WP = db.Updates_MainWebsites.Where(x => x.ID == ID).FirstOrDefault();

            DepartmentDetails DD = new DepartmentDetails(WP.Department);

            if (!string.IsNullOrEmpty(WP.Page_Title))
                Title = WP.Page_Title.Length > 75 ? "Article | News | Reference:" + WP.ID : WP.Page_Title;
            else
                Title = WP.filename.Replace(" _", " ");

            if (!string.IsNullOrEmpty(WP.Keywords))
                Keywords = WP.Keywords;
            else
                Keywords = WP.Title;

            if (!string.IsNullOrEmpty(WP.Description))
                Description = WP.Description + DD.Name;
            else
                Description = WP.Title;

            if (WP.Duplicate_ID != null && WP.Duplicate_ID != 0 && WP.Duplicate_ID != WP.ID)
            {
                duplicatefieldsforcanonicaltag _DFCT  = db.Updates_MainWebsites.Where(x => x.ID == WP.Duplicate_ID).Select(y => new duplicatefieldsforcanonicaltag { dept = y.Department, filename = y.filename, dateupdate = y.Date_Update }).FirstOrDefault();
                string canonicallink = _DFCT.filename + " (" + ((DateTime)_DFCT.dateupdate).Day.ToString() + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((((DateTime)_DFCT.dateupdate).Month)) + " " + ((DateTime)_DFCT.dateupdate).Year.ToString() + ")";
                DepartmentDetails canonicaldept = new DepartmentDetails(_DFCT.dept);
                string duplicatelink = "https://www.duncanlewis.co.uk" + "/" + canonicaldept.folder1 + "/" + canonicallink.ToString().Replace("?", "").Replace(":", "").Replace("-", "").Replace("^", "").Replace(" ", "_").Replace("/", "").Replace("'", "").Replace("%", "") + ".html";
                duplicateid = "<link rel=\"canonical\" href=\"" + duplicatelink + "\" />";
            }
            else
                duplicateid = "No";

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
                imgstr = "<img class=\"newsarticlesmainimage\" src=\"/images_newarticles/" + WP.Blog_Department + ".jpg\" alt=\"Duncan Lewis, " + DD.Name + " Solicitors, " + WP.Title + "\" />";
            else if (WP.Department == "Reported Case" || WP.Department == "InThePress")
                imgstr = "<img class=\"newsarticlesmainimage\" src=\"/ArticlesImages/DLStandardNewsImage.JPG\" alt=\"Duncan Lewis, " + DD.Name + " Solicitors, " + WP.Title + "\" />";
            else if (WP.Image == true && WP.video != true)
                imgstr = "<img class=\"newsarticlesmainimage\" src=\"/ArticlesImages/" + ID + ".jpg\" alt=\"Duncan Lewis, " + WP.Department.ToString().Replace("'", "^") + " Solicitors, " + WP.Title + "\" />";
            else if (WP.video == true)
                imgstr = "";
            else if (WP.Image != true)
                imgstr = "<img class=\"newsarticlesmainimage\" src=\"/ArticlesImages/DLStandardNewsImage.JPG\" alt=\"Duncan Lewis, " + WP.Department.ToString().Replace("'", "^") + " Solicitors, " + WP.Title + "\" />";

            contents = "<div class=\"newarticleheading dept_Family deptbordercolor\"><h4 class=\"dept_Family forecolor\">" + Linktext + "</h4><span>Date: <strong>" + ((DateTime)WP.Date_Update).ToString().Substring(0, 10) + "</strong></span></div>" +
            "<div id=\"newsarticlescontents\">" + imgstr + "<p>" + contentstext + "</p></h5>" + baililink + "</div>";


            if (WP.category == "DL" && DD.departmenttype == "AreaOfLaw")
                breadcrumb = DD.Name + " News";
            else if (WP.category == "NonDL" && DD.departmenttype == "AreaOfLaw")
                breadcrumb = DD.Name + " Articles";
            else if (DD.departmenttype != "AreaOfLaw")
                breadcrumb = DD.Name;

            DepartmentNavigationNewWebsite Deptnav = new DepartmentNavigationNewWebsite();


            StringBuilder SB = new StringBuilder();


            if (DD.departmenttype == "AreaOfLaw")
            {
                SB.AppendLine("<div class=\"row nopadding\">");
                SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
                SB.AppendLine("        <div class=\"row nopadding\">");
                SB.AppendLine("            <div class=\"col-sm-12 col-md-7 col-xs-12 col-md-offset-5 depttabs\">");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.Our_Team1 + "\">Our Team<span class=\"fa fa-users\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.News1 + "\">News<span class=\"fa fa-newspaper-o\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.News1.Replace("news", "articles") + "\">Articles<span class=\"fa fa-book\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.Video + "\">Videos<span class=\"fa fa-video-camera\"></span></a>");
                SB.AppendLine("            </div>");
                SB.AppendLine("        </div>");
                SB.AppendLine("    </div>");
                SB.AppendLine("</div>");
            }
            else
            {
                SB.AppendLine("<div class=\"row nopadding\">");
                SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
                SB.AppendLine("        <div class=\"row nopadding\">");
                SB.AppendLine("            <div class=\"col-sm-12 col-md-8 col-xs-12 col-md-offset-4 depttabs\">");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/News.html\">News<span class=\"fa fa-newspaper-o\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/InThePress.html\">In The Press<span class=\"fa fa-newspaper-o\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Reportedcases.html\">Reported Cases<span class=\"fa fa-newspaper-o\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Legal_News.html\">Legal News<span class=\"fa fa-newspaper-o\"></span></a>");
                SB.AppendLine("            </div>");
                SB.AppendLine("        </div>");
                SB.AppendLine("    </div>");
                SB.AppendLine("</div>");
            }

            SB.AppendLine("<div class=\"row deptreverseband " + DD.cssclass + " lightkolor  nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            SB.AppendLine("        <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-9 col-xs-12 col-sm-offset-3 breadcrumbs\">");

            if (DD.Name == "Main")
                SB.AppendLine("      <p><a class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\">Home</a><span class=\"fa fa-angle-double-right\"></span><a class=\"" + DD.cssclass + " forecolor\" href=\"/news.html\">" + WP.Title + "</a></p>");
            else
                SB.AppendLine("       <p><a  class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\">Home</a><span class=\"fa fa-angle-double-right\"></span><a class=\"" + DD.cssclass + " forecolor\" href=\"/" + DD.Overview1 + "\"><p>" + DD.Name + "</a><span class=\"fa fa-angle-double-right\"></span>" + breadcrumb.ToString().Replace("<br />", " ") + "</p>");


            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");

            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");

            SB.AppendLine("<div class=\"" + DD.cssclass + " row nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            SB.AppendLine("        <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-3 col-xs-12 nopadding\">");


            SB.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, WP.Date_Update.Value.Year, WP.category, WP.Date_Update.Value.Month).ToString());

            SB.AppendLine("            </div>");

            SB.AppendLine("            <div class=\"col-sm-9 col-xs-12\">");

            SB.AppendLine("                <div id=\"container\">");

            SB.AppendLine(contents);

            if (!string.IsNullOrEmpty(DD.contactstr1))
            {
                SB.AppendLine("<br /><div class=\"deptcontactus " + DD.cssclass + " lightkolor\"><span class=\"" + DD.cssclass + " forecolor\">For all " + DD.Name + " related matter contact us now.</span><a  class=\"deptcontactus " + DD.cssclass + " kolor\" href=\"/Home/Contact/" + DD.contactstr1 + "\">Contact Us</a></div><br />");
            }

            SB.AppendLine("                </div>");
            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");
            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");

            Contents = SB;

            filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\" + DD.folder1 + "\\" + allStatic.refinenewarticlelink(Update_Title.ToString()) + ".html";

        }
    }

    public class duplicatefieldsforcanonicaltag
    {
        public string filename { get; set; }
        public string dept { get; set; }
        public DateTime? dateupdate { get; set; }
    }
}
