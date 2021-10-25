using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Configuration;

namespace dlwebclasses
{
    public class NewsArticlesLandingPages
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public string filepath { get; set; }
        public StringBuilder Contents { get; set; }
        public StringBuilder rightcolcontent { get; set; }
        public NewsArticlesLandingPages(string dept, string category, int Year1 = 0, int month1 = 0)
        {
            if (Year1 == 0)
                Year1 = DateTime.Now.Year;

            if (month1 == 0)
                month1 = DateTime.Now.Month;

            IT_DatabaseEntities db = new IT_DatabaseEntities();
            List<Updates_MainWebsites> UM = new List<Updates_MainWebsites>();

            int year2 = Year1;
            if (Year1 == DateTime.Now.Year)
                year2 = Year1 - 1;

            if (dept == "Campaign")
                UM = db.Updates_MainWebsites.Where(x => x.Department == dept && (x.Date_Update.Value.Year == Year1 || x.Date_Update.Value.Year == year2)).OrderByDescending(x => x.Date_Update).ToList();
            else if (dept != "Legal News" && dept != "Reported Case" && dept != "InThePress")
                UM = db.Updates_MainWebsites.Where(x => x.Department == dept && (x.Date_Update.Value.Year == Year1 || x.Date_Update.Value.Year == year2) && x.category == category).OrderByDescending(x => x.Date_Update).ToList();
            else if (dept == "Reported Case" || dept == "InThePress")
                UM = db.Updates_MainWebsites.Where(x => x.Department == dept && (x.Date_Update.Value.Year == Year1 || x.Date_Update.Value.Year == year2)).OrderByDescending(x => x.Date_Update).ToList();
            else
                UM = db.Updates_MainWebsites.Where(x => (x.Department == dept) && (x.Date_Update.Value.Year == Year1) && (x.Date_Update.Value.Month == month1)).OrderByDescending(x => x.Date_Update).ToList();

            DepartmentDetails DD1 = new DepartmentDetails(dept);
            string prefix = "";
            if (category == "DL")
                prefix = "News";
            else
                prefix = "Articles";


            Title = "Duncan Lewis " + prefix + " | " + DD1.Title1;
            Description = prefix + "- " + DD1.Description1;
            Keywords = prefix + ", " + DD1.Keywords1;
            
            HeadingH1 = dept.Replace("Main","") + " " + prefix;
            Department = dept;


            StringBuilder contents = new StringBuilder();

             contents.AppendLine("<div id=\"breadcrumb\" class=\"visible-lg visible-md visible-sm\">");
            contents.AppendLine("<p><a href=\"index.html\">Home</a> | <a href=\"" + DD1.Overview1 + "\">" + DD1.Name + "</a> | " + DD1.Name + " " + prefix + " </p>");
            contents.AppendLine("</div>");
            contents.AppendLine("<div class=\"container-fluid\">");
            contents.AppendLine("<div class=\"row\">");
            contents.AppendLine("<div class=\"col-lg-12 thumbs1\">");
            contents.AppendLine("<p>&nbsp;</p>");

            if ((category == "NonDL" && dept != "Reported Case" && dept != "InThePress") || dept == "Legal News")
                contents.AppendLine("<p>&nbsp;</p><h5>Duncan Lewis Solicitors does not have direct involvement in the cases and events covered in these articles. These are articles that exist in the public domain and are used by Duncan Lewis purely for informative purpose.</h5><p>&nbsp;</p>");
            
            foreach (Updates_MainWebsites UM1 in UM)
            {
                GetLinkfromArticleRef _getlink = new GetLinkfromArticleRef();
                contents.AppendLine(_getlink.GetLink(UM1));
            }
            contents.AppendLine("</div>");
            contents.AppendLine("</div>");
            contents.AppendLine("</div>");

            Contents = contents;

            string _cat = "";
            string linktext = "";
            if (category == "DL" || category == "Reported Case" || category == "InThePress")
            {
                _cat = DD1.News1;
                if (category == "Reported Case")
                    linktext = category;
                else if (category == "InThePress")
                    linktext = "In The Press";
                else
                    linktext = "News";
            }
            else if (category == "NonDL")
            {
                _cat = DD1.News1.Replace("news", "articles").Replace("News", "articles");
                linktext = "Articles";
            }


                if (dept == "Legal News")
                {
                    if (month1 == DateTime.Now.Month && Year1 == DateTime.Now.Year)
                        filepath = ConfigurationManager.AppSettings["Rootpath"] + "\\legal_news.html";
                    else
                        filepath = ConfigurationManager.AppSettings["Rootpath"] + "\\legal_news_" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month1) + "-" + Year1 + ".html";
                }
                else
                {
                    if (Year1 == DateTime.Now.Year || Year1 == DateTime.Now.Year - 1)
                        filepath = ConfigurationManager.AppSettings["Rootpath"] + "\\" + _cat;
                    else
                        filepath = ConfigurationManager.AppSettings["Rootpath"] + "\\" + _cat.Replace(".html", "-" + Year1 + ".html");
                }


                StringBuilder SB = new StringBuilder();
                if (dept != "Legal News")
                {
                    List<string> yrs = new List<string>();
                    yrs = db.Database.SqlQuery<string>("Select distinct convert(varchar(10),Year(date_Update)) from Updates_MainWebsites where Department ='" + dept + "' and Year(Date_Update) <> Year(Getdate()) and Year(Date_Update) <> (Year(Getdate()) - 1)  order by convert(varchar(10),Year(date_Update)) desc").ToList();
                    SB.AppendLine("<!--Contents coming from content section-->");

                    SB.AppendLine("        <ul class=\"bigbuts\">");
                    SB.AppendLine("          <li><a href=\"#\" style=\"background-position:0px 0px; height:50px;\" class=\"bigbuts_accreditation\"><span>" + linktext + " Archive</span></a></li>");
                    SB.AppendLine("        </ul>");

                    SB.AppendLine("<div id=\"reportedtop\"><div id=\"reportedbottom\"><ul class=\"reportedmenu\">");
                    foreach (string str in yrs)
                    {
                        SB.AppendLine("<li><a href=\"http://www.duncanlewis.co.uk/" + _cat.Replace(".html", "-" + str + ".html") + "\" style=\"padding-bottom:0px; margin-bottom:3px;\">" + DD1.Name.Replace("Main","") + " " + linktext + " " + str + "</a> </li>");
                    }
                    SB.AppendLine("</ul></div></div><div class=\"bigbuts_seperator\"></div>");
                }
                else if (dept == "Legal News")
                {
                    List<int> yrs1 = new List<int>();
                    yrs1 = db.Database.SqlQuery<int>("Select distinct Month(date_Update) from Updates_MainWebsites where Department ='" + dept + "' and Year(Date_Update) = " + Year1 + " order by Month(date_Update) desc").ToList();
                    SB.AppendLine("<!--Contents coming from content section-->");

                    SB.AppendLine("        <ul class=\"bigbuts\">");
                    SB.AppendLine("          <li><a href=\"#\" style=\"background-position:0px 0px; height:50px;\" class=\"bigbuts_accreditation\"><span>Legal News (" + Year1 + ")</span></a></li>");
                    SB.AppendLine("        </ul>");

                    SB.AppendLine("<div id=\"reportedtop\"><div id=\"reportedbottom\"><ul class=\"reportedmenu\">");
                    foreach (int str in yrs1)
                    {
                        SB.AppendLine("<li><a href=\"http://www.duncanlewis.co.uk/" + "legal_news_" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(str) + "-" + Year1 + ".html" + "\" style=\"padding-bottom:0px; margin-bottom:3px;\">Legal News " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(str) + " " + Year1 + "</a> </li>");
                    }
                    SB.AppendLine("</ul></div></div><div class=\"bigbuts_seperator\"></div>");


                    
                    List<string> yrs = new List<string>();
                    yrs = db.Database.SqlQuery<string>("Select distinct convert(varchar(10),Year(date_Update)) from Updates_MainWebsites where Department ='" + dept + "'  order by convert(varchar(10),Year(date_Update)) desc").ToList();

                    SB.AppendLine("        <ul class=\"bigbuts\">");
                    SB.AppendLine("          <li><a href=\"#\" style=\"background-position:0px 0px; height:50px;\" class=\"bigbuts_accreditation\"><span>Legal News Archive</span></a></li>");
                    SB.AppendLine("        </ul>");

                    SB.AppendLine("<div id=\"reportedtop\"><div id=\"reportedbottom\"><ul class=\"reportedmenu\">");
                    foreach (string str in yrs)
                    {
                        SB.AppendLine("<li><a href=\"http://www.duncanlewis.co.uk/" + "legal_news_" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(1) + "-" + str + ".html" + "\" style=\"padding-bottom:0px; margin-bottom:3px;\">" + DD1.Name + " " + str + "</a> </li>");
                    }
                    SB.AppendLine("</ul></div></div><div class=\"bigbuts_seperator\"></div>");


                }
                rightcolcontent = SB;
        
        }



        
    }
}