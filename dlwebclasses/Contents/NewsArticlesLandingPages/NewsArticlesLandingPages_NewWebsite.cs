using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class NewsArticlesLandingPages_NewWebsite
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public string filepath { get; set; }
        public StringBuilder Contents { get; set; }
        public StringBuilder rightcolcontent { get; set; }
        public string canonicaltag { get; set; }
        public NewsArticlesLandingPages_NewWebsite(AContents _Acontent,  string dept, string category, int Year1 = 0, int month1 = 0)
        {
            if (Year1 == 0)
                Year1 = DateTime.Now.Year;

            if (month1 == 0)
                month1 = DateTime.Now.Month;


             
                DepartmentDetails DD = new DepartmentDetails(dept);
            

            IT_DatabaseEntities db = new IT_DatabaseEntities();
            List<Updates_MainWebsites> UM = new List<Updates_MainWebsites>();

            int year2 = Year1;
            if (Year1 == DateTime.Now.Year)
                year2 = Year1 - 1;

            if (dept != "Legal News" && dept != "Reported Case" && dept != "InThePress")
                    UM = db.Updates_MainWebsites.Where(x => x.Department == dept && (x.Date_Update.Value.Year == Year1 || x.Date_Update.Value.Year == year2) && x.category == category).OrderByDescending(x => x.Date_Update).ToList();
            else if (dept == "Reported Case" || dept == "InThePress" || dept == "Campaign")
                UM = db.Updates_MainWebsites.Where(x => x.Department == dept && (x.Date_Update.Value.Year == Year1 || x.Date_Update.Value.Year == year2)).OrderByDescending(x => x.Date_Update).ToList();
            else
                UM = db.Updates_MainWebsites.Where(x => (x.Department == dept) && (x.Date_Update.Value.Year == Year1) && (x.Date_Update.Value.Month == month1)).OrderByDescending(x => x.Date_Update).ToList();

            DepartmentDetails DD1 = new DepartmentDetails(dept);
            string prefix = "";
            if (category == "DL")
                prefix = "News";
            else
                prefix = "Articles";



            
            HeadingH1 = dept.Replace("Main","") + " " + prefix;
            Department = dept;

             DepartmentNavigationNewWebsite Deptnav = new DepartmentNavigationNewWebsite();

            StringBuilder contents = new StringBuilder();

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
            SB.AppendLine("            <div class=\"col-sm-12 col-lg-9 col-xs-12 col-lg-offset-3 depttabs\">");
            SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/News.html\">News<span class=\"fa fa-newspaper-o\"></span></a>");
            SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over hidden-xs\" href=\"/InThePress.html\">Press<span class=\"fa fa-newspaper-o\"></span></a>");
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

            if (DD.Name == "InThePress" || DD.Name == "Main" || DD.Name == "Reported Case" || DD.Name == "Legal News" || DD.Name == "Campaign")
                SB.AppendLine("      <p><a class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\">Home</a><span class=\"fa fa-angle-double-right\"></span>" + DD.Name.ToString().Replace("Main", "News") + "</p>");
            else
                SB.AppendLine("       <p><a  class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\">Home</a><span class=\"fa fa-angle-double-right\"></span><a class=\"" + DD.cssclass + " forecolor\" href=\"/" + DD.Overview1 + "\"><p>" + DD.Name + "</a><span class=\"fa fa-angle-double-right\"></span>" + DD.Name.ToString().Replace("<br />", " ") + "</p>");

            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");

            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");

            SB.AppendLine("<div class=\"" + DD.cssclass + " row nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            SB.AppendLine("        <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-3 col-xs-12 nopadding\">");

            
                SB.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, Year1, category, month1).ToString());
            
            SB.AppendLine("            </div>");

            SB.AppendLine("            <div class=\"col-sm-9 col-xs-12 nopadding\">");

            SB.AppendLine("                <div id=\"container\">");

            if ((category == "NonDL" && dept != "Reported Case" && dept != "InThePress") || dept == "Legal News")
                SB.AppendLine("<div class=\"articlesdiscliamer " + DD.cssclass + " kolor\">Duncan Lewis Solicitors does not have direct involvement in the cases and events covered in these articles. These are articles that exist in the public domain and are used by Duncan Lewis purely for informative purpose.</div>");

            foreach (Updates_MainWebsites UM1 in UM)
            {
                GetLinkfromArticleRef _getlink = new GetLinkfromArticleRef();
                SB.AppendLine(_getlink.GetLink(UM1, null, "NewWebsite"));
            }

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



            //filepath
            if (dept == "Legal News")
            {
                if (month1 == DateTime.Now.Month && Year1 == DateTime.Now.Year)
                    filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\legal_news.html";
                else
                    filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\legal_news_" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month1) + "-" + Year1 + ".html";
            }
            else if (category == "DL")
            {
                if (Year1 == DateTime.Now.Year || Year1 == DateTime.Now.Year - 1)
                    filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\" + DD.News1;
                else
                    filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\" + DD.News1.Replace(".html", "-" + Year1 + ".html");
            }
            else if (category == "NonDL")
            {
                if (Year1 == DateTime.Now.Year || Year1 == DateTime.Now.Year - 1)
                    filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\" + DD.News1.Replace("news", "articles").Replace("News", "articles");
                else
                    filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\" + DD.News1.Replace("news", "articles").Replace("News", "articles").Replace(".html", "-" + Year1 + ".html");
            }
            else
            {
                if (Year1 == DateTime.Now.Year || Year1 == DateTime.Now.Year - 1)
                    filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\" + DD.News1;
                else
                    filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\" + DD.News1.Replace(".html", "-" + Year1 + ".html");
            }
            
            canonicaltag = "<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk" + filepath.Replace(ConfigurationManager.AppSettings["RootpathNewWebsite"], "").Replace("\\", "/") + "\">";

            string pagetitle = ConfigurationManager.AppSettings["RootpathNewWebsite"];
            Title = filepath.Replace(ConfigurationManager.AppSettings["RootpathNewWebsite"],"").Replace(".html","").Replace("-"," ").Replace("_", " ").Replace("\\", "") + " | Duncan Lewis" ;
            Description = "Duncan Lewis - " + filepath.Replace(ConfigurationManager.AppSettings["RootpathNewWebsite"], "").Replace(".html", "").Replace("-", " ").Replace("_"," ").Replace("\\","");
            Keywords = prefix + ", " + DD1.Keywords1;

        }
    }
}
