using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class DepartmentNavigationNewWebsite : ADepartmentNavigation_NewWebsite
    {
        public IT_DatabaseEntities dbit = new IT_DatabaseEntities();
        public override StringBuilder getDepartmentNavigation(AContents _Acontent, int? activenode = 0, string category = null, int? activemonth = 0)
        {
            StringBuilder sb = new StringBuilder();
            List<string> DepartmentstoExclude = new List<string>(new string[] { "Careers", "Main", "InThePress", "Legal News", "Reported Case", "Consultancy", "European Union", "Campaign", "Misleneous", "Find Us" });
            List<string> DepartmentsNewsMedia = new List<string>(new string[] { "Main", "InThePress", "Legal News", "Reported Case", "Campaign" });

            if ((_Acontent.GetType() == typeof(Content_WebsitePages_NewWebsite) || _Acontent.GetType() == typeof(Content_TeamPages_NewWebsite)))
            {
                DepartmentDetails DD = new DepartmentDetails(_Acontent.Department.Replace("High Net Worth Divorce", "Family"));
                if (DD.Name != "Careers" && DD.Name != "Misleneous")
                    sb = getDeptNavigationAreaofLaws(DD, activenode,_Acontent);
                else if (DD.Name == "Misleneous")
                {
                    DD = new DepartmentDetails("About Us");
                    sb = getDeptNavigationAreaofLaws(DD, activenode, _Acontent);
                }
                else if (DD.Name == "Careers")
                {
                    Website_Pages WP = new Website_Pages();
                    Website_Structure WS = new Website_Structure();
                    int? pageid = dbit.Website_Structure.Where(y => y.id == activenode).Select(z => z.linkedid).FirstOrDefault();
                    WP = dbit.Website_Pages.Where(x => x.ID == pageid).FirstOrDefault();
                    if (WP.Filename == "Careers")
                        sb = getDeptNavigationCareers(DD, category, 1);
                    else if (WP.Name == "Trainee Solicitors")
                        sb = getDeptNavigationCareers(DD, "Trainee", 1);
                    else if (WP.Name == "Consultancy Jobs")
                        sb = getDeptNavigationCareers(DD, "Overview", 30);
                    else if (WP.Name == "Fee Sharing Consultancy")
                        sb = getDeptNavigationCareers(DD, "Overview", 30);
                    else if (WP.Filename == "Internship")
                        sb = getDeptNavigationCareers(DD, "Internship", 1);
                    else if (WP.Filename == "Apprenticeship")
                        sb = getDeptNavigationCareers(DD, "Apprenticeship", 1);
                    else if (WP.Filename == "Employee-Reward-and-Benefits")
                        sb = getDeptNavigationCareers(DD, "Employee Reward and Benefits", 1);
                }

            }
            else if (_Acontent.GetType() == typeof(Content_NewsArticlesLandingPages_NewWebsite) || _Acontent.GetType() == typeof(Content_NewsArticles_NewWebsite))
            {
                DepartmentDetails DD = new DepartmentDetails(_Acontent.Department);
                sb = getDeptNavigationNewsMedia(DD, activenode, category, activemonth);
            }
            else if (_Acontent.GetType() == typeof(Content_AlphabeticPages_NewWebsite))
            {
                DepartmentDetails DD = new DepartmentDetails(_Acontent.Department);
                sb = getDeptNavigationAlphabet(DD, category);
            }
            else if ((_Acontent.GetType() == typeof(Content_Offices_NewWebsite)) || (_Acontent.GetType() == typeof(Content_OfficesLanding_NewWebsite)))
            {
                DepartmentDetails DD = new DepartmentDetails(_Acontent.Department);
                sb = getDeptNavigationOffices(DD, activenode);
            }
            else if ((_Acontent.GetType() == typeof(Content_JobsLanding_NewWebsite)) || (_Acontent.GetType() == typeof(Content_JobsPage_NewWebsite)))
            {
                DepartmentDetails DD = new DepartmentDetails(_Acontent.Department);
                sb = getDeptNavigationCareers(DD, category, activemonth);
            }
            else if ((_Acontent.GetType() == typeof(Content_VideoslandingPage_NewWebsite)) || (_Acontent.GetType() == typeof(Content_Video_NewWebsite)))
            {
                DepartmentDetails DD = new DepartmentDetails(_Acontent.Department);
                sb = getDeptNavigationVideos(DD, category);
            }
            else if ((_Acontent.GetType() == typeof(Content_Brochures)))
            {
                DepartmentDetails DD = new DepartmentDetails(_Acontent.Department);
                sb = getDeptNavigationBrochure(DD, category);
            }
            return sb;
        }


        public StringBuilder getDeptNavigationNewsMedia(DepartmentDetails DD, int? activenode = 0, string category = null, int? activemonth = 0)
        {


            StringBuilder SB = new StringBuilder();
            List<int?> activeNodes = new List<int?>();
            activeNodes.Add(activenode);
                string cat = "";
                string linktext = DD.Name;
                if (DD.Name == "Main" || DD.Name == "InThePress")
                {
                    if (DD.Name == "InThePress")
                        linktext = "In The Press";
                    else
                        linktext = "News";
                }
                





                


                SB.AppendLine("<div id=\"deptmenu\" class=\"" + DD.cssclass + "\">");
                SB.AppendLine("<div class=\"panel panel-default deptbordercolor\">");
                SB.AppendLine("                        <div class=\"" + DD.cssclass + " deptbordercolor forecolor deptmenumainheading\">");
                SB.AppendLine("<a data-toggle=\"collapse\" href=\"#deptnavigationmenu\">" + DD.Name + "<span class=\"fa fa-caret-down\"></span></a>");
                SB.AppendLine("                        </div>");

                SB.AppendLine("                        <div id=\"deptnavigationmenu\" class=\"panel-collapse collapse in\">");
                SB.AppendLine("                            <div class=\"panel-body\">");
                SB.AppendLine("                                <ul>");
                if (DD.Name != "Legal News" && DD.Name != "InThePress" && DD.Name != "Reported Case" && DD.Name != "Main")
                {
                    int totalloop = 1;
                    if (DD.departmenttype == "AreaOfLaw")
                    {
                        totalloop = 2;
                    }
                    for (int j = 1; j <= totalloop; j++)
                    {
                        string collapsein = " class=\"collapsed\" ";
                        string active = "";
                        string addin = "";
                        if (category == "DL" && j == 1)
                        {
                            collapsein = "";
                            addin = " in ";
                        }
                        if (category == "NonDL" && j == 2)
                        {
                            collapsein = "";
                            addin = " in ";
                        }

                        if (totalloop > 1)
                        {
                            if (j == 1)
                            {
                                cat = "News";
                                SB.AppendLine("<li><a data-toggle=\"collapse\"" + collapsein + "\" href=\"#" + DD.Name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","") + "NewsLevel1\"><p>" + DD.Name + " News</p><span></span></a>");
                                SB.AppendLine("<ul class=\"collapse" + addin + "\" id=\"" + DD.Name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","") + "NewsLevel1\">");
                            }
                            else
                            {
                                cat = "Articles";
                                SB.AppendLine("</ul>");
                                SB.AppendLine("<li class=\"lastmenuitem\"><a data-toggle=\"collapse\"" + collapsein + "\" href=\"#" + DD.Name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","") + "ArticlesLevel1\"><p>" + DD.Name + " Articles</p><span></span></a>");
                                SB.AppendLine("<ul class=\"collapse" + addin + "\" id=\"" + DD.Name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","") + "ArticlesLevel1\">");
                            }
                        }
                        List<int> yrs = new List<int>();
                        if (j == 1)
                            yrs = dbit.Database.SqlQuery<int>("Select distinct Year(date_Update) from Updates_MainWebsites where Department ='" + DD.Name + "' and category = 'DL' order by Year(date_Update) desc").ToList();
                        else
                            yrs = dbit.Database.SqlQuery<int>("Select distinct Year(date_Update) from Updates_MainWebsites where Department ='" + DD.Name + "' and category = 'NonDL' order by Year(date_Update) desc").ToList();

                        foreach (int item in yrs)
                        {
                            string level1lastnode = "";
                            string level1lastnode1 = "";
                            string collapsein1 = " class=\"collapsed\" ";
                            string active1 = "";
                            string addin1 = "";
                            if (item.Equals(yrs.Last()))
                            {
                                level1lastnode = "lastmenuitem ";
                                level1lastnode1 = " class=\"lastmenuitem\" ";
                            }
                            if (activeNodes != null && activeNodes.Contains(item) && ((category == "NonDL" && j == 2) || (category == "DL" && j == 1)))
                            {
                                collapsein1 = "";
                                active1 = " class=\"active\" ";
                                addin1 = " in ";
                            }

                            if (j == 1)
                            {
                                if (item == DateTime.Now.Year || item == (DateTime.Now.Year - 1))
                                    SB.AppendLine("<li class=\"" + level1lastnode + "lastnode\"><a " + active1 + " href=\"/" + DD.News1.ToString() + "\"><p>" + linktext + " " + cat + " " + item.ToString() + "</p><span></span></a></li>");
                                else
                                    SB.AppendLine("<li class=\"" + level1lastnode + "lastnode\"><a " + active1 + " href=\"/" + DD.News1.Replace(".html", "-" + item.ToString() + ".html") + "\"><p>" + linktext + " " + cat + " " + item.ToString() + "</p><span></span></a></li>");
                            }
                            else
                            {
                                if (item == DateTime.Now.Year || item == (DateTime.Now.Year - 1))
                                    SB.AppendLine("<li class=\"" + level1lastnode + "lastnode\"><a " + active1 + " href=\"/" + DD.News1.Replace("news", "articles").ToString() + "\"><p>" + linktext + " " + cat + " " + item.ToString() + "</p><span></span></a></li>");
                                else
                                    SB.AppendLine("<li class=\"" + level1lastnode + "lastnode\"><a " + active1 + " href=\"/" + DD.News1.Replace("news", "articles").Replace(".html", "-" + item.ToString() + ".html") + "\"><p>" + linktext + " " + cat + " " + item.ToString() + "</p><span></span></a></li>");
                            }
                        }
                    }
                    if (totalloop > 1)
                        SB.AppendLine("</ul>");
                }
                else if(DD.Name == "InThePress" || DD.Name == "Reported Case" || DD.Name == "Main")
                {
                    List<string> depts = new List<string>(new string[]{"Main", "Reported Case", "InThePress"});
                    foreach (var item in depts)
                    {
                        string collapsein = " class=\"collapsed\" ";
                        string active = "";
                        string addin = "";
                        string level1lastnode12 = "";
                        if (item == DD.Name)
                        {
                            collapsein = "";
                            addin = " in ";
                        }
                        if (item.Equals(depts.Last()))
                        {
                            level1lastnode12 = " class=\"lastmenuitem\" ";
                        }
                        SB.AppendLine("<li " + level1lastnode12 + "><a data-toggle=\"collapse\"" + collapsein + "\" href=\"#" + item.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","") + "Level1\"><p>" + item.Replace("Main", "News").Replace("InThePress", "In The Press") + "</p><span></span></a>");
                        SB.AppendLine("<ul class=\"collapse" + addin + "\" id=\"" + item.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","") + "Level1\">");
                        List<int> yrs = new List<int>();
                        yrs = dbit.Database.SqlQuery<int>("Select distinct Year(date_Update) from Updates_MainWebsites where Department ='" + DD.Name + "' order by Year(date_Update) desc").ToList();

                        foreach (int item1 in yrs)
                        {
                            string level1lastnode = "";
                            string level1lastnode1 = "";
                            string collapsein1 = " class=\"collapsed\" ";
                            string active1 = "";
                            string addin1 = "";
                            if (item1.Equals(yrs.Last()))
                            {
                                level1lastnode = "lastmenuitem ";
                                level1lastnode1 = " class=\"lastmenuitem\" ";
                            }
                            if (item == DD.Name && activeNodes.Contains(item1))
                            {
                                collapsein1 = "";
                                active1 = " class=\"active\" ";
                                addin1 = " in ";
                            }
                            if (item1 == DateTime.Now.Year || item1 == (DateTime.Now.Year - 1))
                                SB.AppendLine("<li class=\"" + level1lastnode + "lastnode\"><a " + active1 + " href=\"/" + item.Replace("Main", "News.html").Replace("InThePress", "InThePress.html").Replace("Reported Case", "ReportedCases.html") + "\"><p>" + item.Replace("Main", "News").Replace("InThePress", "In The Press") + " " + item1.ToString() + "</p><span></span></a></li>");
                            else
                                SB.AppendLine("<li class=\"" + level1lastnode + "lastnode\"><a " + active1 + " href=\"/" + item.Replace("Main", "News.html").Replace("InThePress", "InThePress.html").Replace("Reported Case", "ReportedCases.html").Replace(".html", "-" + item1.ToString() + ".html") + "\"><p>" + item.Replace("Main", "News").Replace("InThePress", "In The Press") + " " + item1.ToString() + "</p><span></span></a></li>");
                        }
                        SB.AppendLine("</ul>");
                    }
                }
                else if (DD.Name == "Legal News")
                {
                    List<int> yrs = new List<int>();
                    yrs = dbit.Database.SqlQuery<int>("Select distinct Year(date_Update) from Updates_MainWebsites where Department ='" + DD.Name + "' order by Year(date_Update) desc").ToList();

                    foreach (var item in yrs)
                    {
                        string collapsein = " class=\"collapsed\" ";
                        string active = "";
                        string addin = "";
                        string level1lastnode12 = "";
                        if (activeNodes.Contains(item))
                        {
                            collapsein = "";
                            addin = " in ";
                        }
                        if (item.Equals(yrs.Last()))
                        {
                            level1lastnode12 = " class=\"lastmenuitem\" ";
                        }

                        SB.AppendLine("<li " + level1lastnode12 + "><a data-toggle=\"collapse\"" + collapsein + "\" href=\"#" + DD.Name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","") + item.ToString() + "Level1\"><p>" + DD.Name + " News " + item.ToString() + "</p><span></span></a>");

                        List<int> mths1 = new List<int>();
                        mths1 = dbit.Database.SqlQuery<int>("Select distinct Month(date_Update) from Updates_MainWebsites where Department ='" + DD.Name + "' and Year(Date_Update) = " + item + " order by Month(date_Update) desc").ToList();

                        if (mths1.Count() > 0)
                        {
                            SB.AppendLine("<ul class=\"collapse" + addin + "\" id=\"" + DD.Name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","") + item.ToString() + "Level1\">");

                            foreach (var item1 in mths1)
                            {
                                string level1lastnode = "";
                                string collapsein1 = " class=\"collapsed\" ";
                                string active1 = "";
                                string addin1 = "";
                                if (item1.Equals(mths1.Last()))
                                {
                                    level1lastnode = "lastmenuitem ";
                                }
                                if (activeNodes != null && activeNodes.Contains(item) && activemonth == item1)
                                {
                                    collapsein1 = "";
                                    active1 = " class=\"active\" ";
                                    addin1 = " in ";
                                }

                                SB.AppendLine("<li class=\"" + level1lastnode + "lastnode\"><a " + active1 + " href=\"/" + "legal_news_" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item1) + "-" + item + ".html" + "\"><p>" + DD.Name + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item1) + " " + item.ToString() + "</p><span></span></a></li>");
                            }
                             SB.AppendLine("</ul>");
                        }
                    }
                }
                SB.AppendLine("                                </ul>");
                SB.AppendLine("                            </div>");
                SB.AppendLine("                        </div>");


                SB.AppendLine("                    </div>");
                SB.AppendLine("                </div>");

            return SB;
        }

        public StringBuilder getDeptNavigationAreaofLaws(DepartmentDetails DD, int? activenode = 0, AContents _Acontent = null)
        {
            int? actualnode = activenode;

            int[] collapsednodes = new int[] { 3596, 3604 };
            int[] collapsedids = new int[] { 4300, 4297, 4298, 4299, 3596 };
            List<int> landingpagesids = new List<int>();
            List<int> landingpagesids1 = new List<int>();
            List<string> landingpages = new List<string>();
            landingpages = dbit.Website_Department_Structure.Select(x => x.Overview1.Replace(".html","")).ToList();
            landingpagesids = dbit.Website_Pages.Where(x => landingpages.Contains(x.Filename)).Select(y => y.ID).ToList();
            landingpagesids1 = dbit.Website_Structure.Where(x => landingpagesids.Contains((int)x.linkedid)).Select(y => y.id).ToList();
            List<int?> activeNodes = new List<int?>();
            bool areaoflaw = false;
            if (activenode != 0)
            {
                activeNodes.Add(activenode);
                Website_Structure wsactivenode = new Website_Structure();
                while (wsactivenode.level != "Root")
                {
                    wsactivenode = dbit.Website_Structure.Where(x => x.id == activenode).FirstOrDefault();
                    if (wsactivenode.underwhichnode != null)
                    {
                        activeNodes.Add(wsactivenode.underwhichnode);
                        activenode = wsactivenode.underwhichnode;    
                    }
                    if (wsactivenode.level == "Root")
                    {
                        if (dbit.Website_Department_Structure.Where(x => x.Name == wsactivenode.name).Select(y => y.departmenttype).FirstOrDefault() == "AreaOfLaw")
                            areaoflaw = true;
                    }
                    
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div id=\"deptmenu\" class=\"" + DD.cssclass + "\">");
            sb.AppendLine("<div class=\"panel panel-default deptbordercolor\">");
            sb.AppendLine("                        <div class=\"" + DD.cssclass + " deptbordercolor forecolor deptmenumainheading nopadding\">");
            sb.AppendLine("<a data-toggle=\"collapse\" href=\"#deptnavigationmenu\">" + DD.Name + (areaoflaw == true ? " Services" : "") + "<span class=\"fa fa-caret-down\"></span></a>");
            sb.AppendLine("                        </div>");

            
            Website_Structure root = new Website_Structure();
            root = dbit.Website_Structure.Where(x => (x.name == DD.Name || x.name == DD.NameForNavigation) && x.level == "Root").FirstOrDefault();
            List<Website_Structure> Level1 = new List<Website_Structure>();
            Level1 = dbit.Website_Structure.Where(x => x.underwhichnode == root.id || x.underwhichnode1 == root.id || x.underwhichnode2 == root.id || x.underwhichnode3 == root.id).OrderBy(y => y.sequence).ThenBy(s => s.level).ThenBy(x => x.name).ToList();
            sb.AppendLine("                        <div id=\"deptnavigationmenu\" class=\"panel-collapse collapse in\">");
            sb.AppendLine("                            <div class=\"panel-body\">");
            sb.AppendLine("                                <ul>");
            foreach(var item in Level1)
            {
                string level1lastnode = "";
                string level1lastnode1 = "";
                string collapsein1 = " class=\"collapsed\" ";
                string active1 = "";
                string addin1 = "";
                if (item.Equals(Level1.Last()))
                {
                    level1lastnode = "lastmenuitem ";
                    level1lastnode1 = " class=\"lastmenuitem\" ";
                }
                if (activeNodes != null && activeNodes.Contains(item.id))
                {
                    collapsein1 = "";
                    active1 = " class=\"active\" ";
                    addin1 = " in ";
                }
                if ((_Acontent.GetType() == typeof(Content_TeamPages_NewWebsite) || landingpagesids1.Contains((int)actualnode)) && collapsedids.Contains(item.id) == false)
                {
                    collapsein1 = "";
                    addin1 = " in ";
                }

                if (collapsednodes.Contains(actualnode ?? 0))
                {
                    addin1 = "";
                    collapsein1 = " class=\"collapsed\" ";
                }

                if (activenode == 16 && item.id == 4657)
                {
                    addin1 = "";
                    collapsein1 = " class=\"collapsed\" ";
                }

                if (item.level == "ContentNode")
                {
                    sb.AppendLine("<li class=\"" + level1lastnode + "lastnode\"><a " + active1 + " href=\"/" + getlinkfromwebsitepages(item.linkedid) + ".html\"><p>" + (item.name == DD.Name ? "Overview" : string.IsNullOrEmpty(item.NewNameForNavigationLink) ? item.name : item.NewNameForNavigationLink) + "</p><span></span></a></li>");
                }
                else
                {
                    sb.AppendLine("<li" + level1lastnode1 + "><a data-toggle=\"collapse\"" + collapsein1 + "\" href=\"#" + item.name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";", "").Replace("&", "").Replace("(", "").Replace(")", "").Trim() + "Level1\"><p>" + item.name + "</p><span></span></a>");
                    List<Website_Structure> Level2 = new List<Website_Structure>();
                    Level2 = dbit.Website_Structure.Where(x => x.underwhichnode == item.id || x.underwhichnode1 == item.id || x.underwhichnode2 == item.id || x.underwhichnode3 == item.id).OrderBy(y => y.sequence).ThenBy(s => s.level).ThenBy(x => x.name).ToList();
                    if (Level2.Count>0)
                        sb.AppendLine("<ul class=\"collapse" + addin1 + "\" id=\"" + item.name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","").Replace("(", "").Replace(")", "").Trim() + "Level1\">");

                        foreach (var item1 in Level2)
                        {
                            string level2lastnode = "";
                            string level2lastnode1 = "";
                            string collapsein2 = " class=\"collapsed\" ";
                            string active2 = "";
                            string addin2 = "";
                            if (item1.Equals(Level2.Last()))
                            {
                                level2lastnode = "lastmenuitem ";
                                level2lastnode1 = " class=\"lastmenuitem\" ";
                            }
                            if (activeNodes != null && activeNodes.Contains(item1.id))
                            {
                                collapsein2 = "";
                                active2 = " class=\"active\" ";
                                addin2 = " in ";
                            }
                            if (landingpagesids1.Contains((int)actualnode) && collapsedids.Contains(item1.id) == false)
                            {
                                collapsein2 = "";
                                addin2 = " in ";
                            }
                            

                        if (item1.level == "ContentNode")
                            {
                                sb.AppendLine("<li class=\"" + level2lastnode + "lastnode\"><a " + active2 + " href=\"/" + getlinkfromwebsitepages(item1.linkedid) + ".html\"><p>" + (item1.name == item.name ? "Overview" : string.IsNullOrEmpty(item1.NewNameForNavigationLink) ? item1.name : item1.NewNameForNavigationLink) + "</p><span></span></a></li>");
                            }
                            else
                            {
                                sb.AppendLine("<li" + level2lastnode1 + "><a data-toggle=\"collapse\"" + collapsein2 + "\" href=\"#" + item1.name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","").Replace("(", "").Replace(")", "") + "Level2\"><p>" + item1.name + "</p><span></span></a>");
                                List<Website_Structure> Level3 = new List<Website_Structure>();
                                Level3 = dbit.Website_Structure.Where(x => x.underwhichnode == item1.id || x.underwhichnode1 == item1.id || x.underwhichnode2 == item1.id || x.underwhichnode3 == item1.id).OrderBy(y => y.sequence).ThenBy(s => s.level).ThenBy(x => x.name).ToList();
                                if (Level3.Count > 0)
                                    sb.AppendLine("<ul class=\"collapse" + addin2 + "\" id=\"" + item1.name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","").Replace("(", "").Replace(")", "") + "Level2\">");
                                        foreach (var item2 in Level3)
                                        {
                                            string level3lastnode = "";
                                            string level3lastnode1 = "";
                                            string collapsein3 = " class=\"collapsed\" ";
                                            string active3 = "";
                                            string addin3 = "";
                                            if (item2.Equals(Level3.Last()))
                                            {
                                                level3lastnode = "lastmenuitem ";
                                                level3lastnode1 = " class=\"lastmenuitem\" ";
                                            }
                                            if (activeNodes != null && activeNodes.Contains(item2.id))
                                            {
                                                collapsein3 = "";
                                                active3 = " class=\"active\" ";
                                                addin3 = " in ";
                                            }
                                            if (landingpagesids1.Contains((int)actualnode) && collapsedids.Contains(item1.id) == false)
                                            {
                                                collapsein3 = "";
                                                addin3 = " in ";
                                            }

                                            if (item2.level == "ContentNode")
                                            {
                                                sb.AppendLine("<li class=\"" + level3lastnode + "lastnode\"><a " + active3 + " href=\"/" + getlinkfromwebsitepages(item2.linkedid) + ".html\"><p>" + (item2.name == item1.name ? "Overview" : string.IsNullOrEmpty(item2.NewNameForNavigationLink) ? item2.name : item2.NewNameForNavigationLink) + "</p><span></span></a></li>");
                                            }
                                            else
                                            {
                                                sb.AppendLine("<li" + level3lastnode1 + "><a data-toggle=\"collapse\"" + collapsein3 + "\" href=\"#" + item2.name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","").Replace("(", "").Replace(")", "") + "Level3\"><p>" + item2.name + "</p><span></span></a>");
                                                List<Website_Structure> Level4 = new List<Website_Structure>();
                                                Level4 = dbit.Website_Structure.Where(x => x.underwhichnode == item2.id || x.underwhichnode1 == item2.id || x.underwhichnode2 == item2.id || x.underwhichnode3 == item2.id).OrderBy(y => y.sequence).ThenBy(s => s.level).ThenBy(x => x.name).ToList();
                                                if (Level4.Count > 0)
                                                    sb.AppendLine("<ul class=\"collapse" + addin3 + "\" id=\"" + item2.name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";","").Replace("&","").Replace("(", "").Replace(")", "") + "Level3\">");
                                                foreach (var item3 in Level4)
                                                {
                                                    string level4lastnode = "";
                                                    string level4lastnode1 = "";
                                                    string collapsein4 = " class=\"collapsed\" ";
                                                    string active4 = "";
                                                    string addin4 = "";
                                                    if (item3.Equals(Level4.Last()))
                                                    {
                                                        level4lastnode = "lastmenuitem ";
                                                        level4lastnode1 = " class=\"lastmenuitem\" ";
                                                    }
                                                    if (activeNodes != null && activeNodes.Contains(item3.id))
                                                    {
                                                        collapsein4 = "";
                                                        active4 = " class=\"active\" ";
                                                        addin4 = " in ";
                                                    }
                                                    if (landingpagesids1.Contains((int)actualnode) && collapsedids.Contains(item1.id) == false)
                                                    {
                                                        collapsein4 = "";
                                                        addin4 = " in ";
                                                    }
                                                    if (item3.level == "ContentNode")
                                                    {
                                                        sb.AppendLine("<li class=\"" + level4lastnode + "lastnode\"><a " + active4 + " href=\"/" + getlinkfromwebsitepages(item3.linkedid) + ".html\"><p>" + (item3.name == item2.name ? "Overview" : string.IsNullOrEmpty(item3.NewNameForNavigationLink) ? item3.name : item3.NewNameForNavigationLink) + "</p><span></span></a></li>");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine("<li" + level4lastnode1 + "><a data-toggle=\"collapse\"" + collapsein4 + "\" href=\"#" + item3.name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";", "").Replace("&", "").Replace("(", "").Replace(")", "") + "Level4\"><p>" + item3.name + "</p><span></span></a>");
                                                        List<Website_Structure> Level5 = new List<Website_Structure>();
                                                        Level5 = dbit.Website_Structure.Where(x => x.underwhichnode == item3.id || x.underwhichnode1 == item3.id || x.underwhichnode2 == item3.id || x.underwhichnode3 == item3.id).OrderBy(y => y.sequence).ThenBy(s => s.level).ThenBy(x => x.name).ToList();
                                                        if (Level5.Count > 0)
                                                            sb.AppendLine("<ul class=\"collapse" + addin4 + "\" id=\"" + item3.name.Replace(" ", "").Replace("_", "").Replace("-", "").Replace("/", "").Replace(":", "").Replace(";", "").Replace("&", "").Replace("(", "").Replace(")", "") + "Level4\">");
                                                        foreach (var item4 in Level5)
                                                        {
                                                            string level5lastnode = "";
                                                            string active5 = "";
                                                            if (item4.Equals(Level5.Last()))
                                                            {
                                                                level4lastnode = "lastmenuitem ";
                                                            }
                                                            if (item4.level == "ContentNode")
                                                            {
                                                                sb.AppendLine("<li class=\"" + level5lastnode + "lastnode\"><a " + active5 + " href=\"/" + getlinkfromwebsitepages(item4.linkedid) + ".html\"><p>" + (item4.name == item3.name ? "Overview" : string.IsNullOrEmpty(item4.NewNameForNavigationLink) ? item4.name : item4.NewNameForNavigationLink) + "</p><span></span></a></li>");
                                                            }
                                                        }
                                                        if (Level5.Count > 0)
                                                            sb.AppendLine("</ul>");

                                                        sb.AppendLine("</li>");
                                                    }
                                                }
                                                if (Level4.Count > 0)
                                                    sb.AppendLine("</ul>");

                                                sb.AppendLine("</li>");
                                            }
                                        }
                                if (Level3.Count > 0)
                                    sb.AppendLine("</ul>");

                                sb.AppendLine("</li>");
                            }
                        }
                        if (Level2.Count > 0)
                            sb.AppendLine("</ul>");

                    sb.AppendLine("</li>");
                }
            }
            sb.AppendLine("                                </ul>");
            sb.AppendLine("                            </div>");
            sb.AppendLine("                        </div>");


            sb.AppendLine("                    </div>");
            sb.AppendLine("                </div>");
            return sb;
        }

        public StringBuilder getDeptNavigationAlphabet(DepartmentDetails DD, string category = null)
        {
            

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div id=\"deptmenu\" class=\"" + DD.cssclass + "\">");
            sb.AppendLine("<div class=\"panel panel-default deptbordercolor\">");
            sb.AppendLine("                        <div class=\"" + DD.cssclass + " deptbordercolor forecolor deptmenumainheading\">");
            sb.AppendLine("<a data-toggle=\"collapse\" href=\"#deptnavigationmenu\">Alphabetical Listing<span class=\"fa fa-caret-down\"></span></a>");
            
            sb.AppendLine("                        </div>");


            sb.AppendLine("                        <div id=\"deptnavigationmenu\" class=\"panel-collapse collapse in\">");
            sb.AppendLine("                            <div class=\"panel-body\">");
            sb.AppendLine("                                <ul>");


            for (int vf = 65; vf <= 90; vf++)
            {
                string active3 = "";

                if (((char)vf).ToString() == category)
                    active3 = " class=\"active\" ";

                sb.AppendLine("<li class=\"lastnode\"><a " + active3 + " href=\"Our_Team_Alphabetic_" + (char)vf + ".html\"><p>Staff Listing - Alphabet - " + (char)vf + "</p><span></span></a></li>");
            }

            sb.AppendLine("                                </ul>");
            sb.AppendLine("                            </div>");
            sb.AppendLine("                        </div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            return sb;
        }

        public StringBuilder getDeptNavigationBrochure(DepartmentDetails DD, string category = null)
        {


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div id=\"deptmenu\" class=\"" + DD.cssclass + "\">");
            sb.AppendLine("<div class=\"panel panel-default deptbordercolor\">");
            sb.AppendLine("                        <div class=\"" + DD.cssclass + " deptbordercolor forecolor deptmenumainheading\">");
            sb.AppendLine("<a data-toggle=\"collapse\" href=\"#deptnavigationmenu\">Brochures<span class=\"fa fa-caret-down\"></span></a>");

            sb.AppendLine("                        </div>");


            sb.AppendLine("                        <div id=\"deptnavigationmenu\" class=\"panel-collapse collapse in\">");
            sb.AppendLine("                            <div class=\"panel-body\">");
            sb.AppendLine("                                <ul>");


            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures/DL002_210 MAIN BROCHURE_Final.pdf\" target=\"_blank\"><p>Corporate Brochure</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures/DL006 General leaflet_A4_Final.pdf\" target=\"_blank\"><p>Our Services Leaflet</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures/DL_ImmigrationBrochure_Final.pdf\" target=\"_blank\"><p>Immigration Brochure</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures/DL010_ Child Care Brochure_Final.pdf\" target=\"_blank\"><p>Family &amp; Child Care Brochure</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures/I_Brochure._web.pdf\" target=\"_blank\"><p>Islamic Brochure</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures/P_Brochure_web.pdf\" target=\"_blank\"><p>Punjabi Brochure</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures/DL021 Social Welfare 4pp_Final.pdf\" target=\"_blank\"><p>Social Welfare Brochure</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures/DL014 Employment Leaflet A5_Final.pdf\" target=\"_blank\"><p>Employment Leaflet</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures/DL015 Managed Migration A5_Final.pdf\" target=\"_blank\"><p>Managed Migration Leaflet</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures/DL018 Mental Health 2pp_Final.pdf\" target=\"_blank\"><p>Mental Health Leaflet</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures/DL019 Public Law 2pp_final.pdf\" target=\"_blank\"><p>Public Law Leaflet</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures/Recruitment.pdf\" target=\"_blank\"><p>Recruitment Brochure</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"https://www.duncanlewis.co.uk/brochures/Duncan Lewis Employment Insurance package.pdf\" target=\"_blank\"><p>Employment Insurance Package</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"Main_Brochure_French.pdf\" target=\"_blank\"><p>Main Brochure - French Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"Main_Brochure_Farsi.pdf\" target=\"_blank\"><p>Main Brochure - Farsi Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"Main_Brochure_Spanish.pdf\" target=\"_blank\"><p>Main Brochure - Spanish Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"Main_Brochure_Punjabi.pdf\" target=\"_blank\"><p>Main Brochure - Punjabi Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"Main_Brochure_Russian.pdf\" target=\"_blank\"><p>Main Brochure - Russian Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"Main_Brochure_Turkish.pdf\" target=\"_blank\"><p>Main Brochure - Turkish Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Arabic.html\" ><p>Service Leaflet - Arabic Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Chinese.html\" ><p>Service Leaflet - Chinese Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Farsi.html\" ><p>Service Leaflet - Farsi Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_French.html\" ><p>Service Leaflet - French Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Hindi.html\" ><p>Service Leaflet - Hindi Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Punjabi.html\" ><p>Service Leaflet - Punjabi Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Shona.html\" ><p>Service Leaflet - Shona Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Somali.html\" ><p>Service Leaflet - Somali Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Sorani.html\" ><p>Service Leaflet - Sorani Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Spanish.html\" ><p>Service Leaflet - Spanish Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Tamil.html\" ><p>Service Leaflet - Tamil Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Tigrinya.html\" ><p>Service Leaflet -Tigrinya Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Turkish.html\" ><p>Service Leaflet - Turkish Language</p><span></span></a></li>");
            sb.AppendLine("         <li class=\"lastnode\"><a href=\"brochures_Urdu.html\" ><p>Service Leaflet - Urdu Language</p><span></span></a></li>");



            sb.AppendLine("                                </ul>");
            sb.AppendLine("                            </div>");
            sb.AppendLine("                        </div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            return sb;
        }

        public StringBuilder getDeptNavigationOffices(DepartmentDetails DD, int? activenode = null)
        {

            DLWEBEntities dlweb = new DLWEBEntities();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div id=\"deptmenu\" class=\"" + DD.cssclass + "\">");
            sb.AppendLine("<div class=\"panel panel-default deptbordercolor\">");
            sb.AppendLine("                        <div class=\"" + DD.cssclass + " deptbordercolor forecolor deptmenumainheading\">");
            sb.AppendLine("<a data-toggle=\"collapse\" href=\"#deptnavigationmenu\">Our Offices<span class=\"fa fa-caret-down\"></span></a><br /><p><sup class=\"redsuperscript\">*</sup>For scheduled appointments only</p>");
            sb.AppendLine("                        </div>");


            sb.AppendLine("                        <div id=\"deptnavigationmenu\" class=\"panel-collapse collapse in\">");
            sb.AppendLine("                            <div class=\"panel-body\">");
            sb.AppendLine("                                <ul>");

            string inout = dlweb.OfficesDLW.Where(x => x.ID == activenode).Select(y => y.In_Out_London).FirstOrDefault();
            for (int i = 1; i <= 2; i++)
            {
                string inout1 = "";
                if (i == 1)
                    inout1 = "In";
                else
                    inout1="Out";

                List<OfficeDLW> officeslist = new List<OfficeDLW>();
                officeslist = dlweb.OfficesDLW.Where(x => x.Active == true && (x.Company == "Duncan Lewis" || x.Company == "Both") && x.In_Out_London ==inout1).OrderBy(y => y.Sequence).ThenBy(z => z.Name).ToList();
            

                string level3lastnode = "";
                string level3lastnode1 = "";
                string collapsein3 = " class=\"collapsed\" ";
                string active3 = "";
                string addin3 = "";
                if ((inout == "In" && i == 1) || (activenode == 2000 && i == 1) || (activenode == 1000 && i == 1))
                {
                    collapsein3 = "";
                    active3 = " class=\"active\" ";
                    addin3 = " in ";
                }
                else if ((inout == "Out" && i == 2) || (activenode == 3000 && i == 2) || (activenode == 1000 && i == 2))
                {
                    collapsein3 = "";
                    active3 = " class=\"active\" ";
                    addin3 = " in ";
                }
                if (i == 2)
                    level3lastnode1 = " class=\"lastmenuitem\" ";



                sb.AppendLine("<li" + level3lastnode1 + "><a data-toggle=\"collapse\"" + collapsein3 + "\" href=\"#InOutLondon" + i.ToString() + "\"><p>Offices " + inout1.Replace("Out","Outside") + " London</p><span></span></a>");
                sb.AppendLine("<ul class=\"collapse" + addin3 + "\" id=\"InOutLondon" + i.ToString() + "\">");

                    foreach (var item in officeslist)
                    {
                        string level3lastnode2 = "";
                        string active = "";

                        if (item.ID == activenode)
                        {
                            active = " class=\"active\" ";
                            addin3 = " in ";
                        }
                        if (officeslist.Last() == item)
                            level3lastnode2 = " lastmenuitem ";
                        string addstar = "";
                        if (item.Appointment == "Yes")
                            addstar = " <sup class=\"redsuperscript\">*</sup>";

                        sb.AppendLine("<li class=\"" + level3lastnode2 + "lastnode\"><a " + active + " href=\"/offices/" + item.Name.ToString() + "-Solicitors.html\"><p>" + item.Name + " Office" + addstar + "</p><span></span></a></li>");
                    }
                    sb.AppendLine("                                </ul>");
                    sb.AppendLine("                                </li>");
                }


            sb.AppendLine("                                </ul>");
            sb.AppendLine("                            </div>");
            sb.AppendLine("                        </div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            return sb;
        }

        public StringBuilder getDeptNavigationCareers(DepartmentDetails DD, string activenode = null, int? category = 0)
        {

            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            DLWEBEntities dlweb = new DLWEBEntities();
            

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div id=\"deptmenu\" class=\"" + DD.cssclass + "\">");
            sb.AppendLine("<div class=\"panel panel-default deptbordercolor\">");
            sb.AppendLine("                        <div class=\"" + DD.cssclass + " deptbordercolor forecolor deptmenumainheading\">");
            sb.AppendLine("<a data-toggle=\"collapse\" href=\"#deptnavigationmenu\">Careers / Vacancies<span class=\"fa fa-caret-down\"></span></a>");
            sb.AppendLine("                        </div>");

            sb.AppendLine("                        <div id=\"deptnavigationmenu\" class=\"panel-collapse collapse in\">");
            sb.AppendLine("                            <div class=\"panel-body\">");
            sb.AppendLine("                                <ul>");

            sb.AppendLine("<li class=\"lastnode\"><a href=\"/Jobs_All.html\"><p>All Jobs</p><span></span></a></li>");

            for (int i = 1; i <= 3; i++)
            {
                string Heading = "";
                if (i == 1)
                    Heading = "Jobs by Category";
                else if (i == 2)
                    Heading = "Jobs by Department";
                else
                    Heading = "Consultancy Jobs";

                string level3lastnode1 = "";
                string collapsein3 = " class=\"collapsed\" ";
                string addin3 = "";
                if ((dbit.Website_Department_Structure.Where(x => x.Name == activenode).Count() == 0 && i == 1) && category == 1)
                {
                    collapsein3 = "";
                    addin3 = " in ";
                }
                else if ((dbit.Website_Department_Structure.Where(x => x.Name == activenode).Count()>0 && i == 2) && category == 2)
                {
                    collapsein3 = "";
                    addin3 = " in ";
                }
                else if (((dlweb.Areas.Where(x => x.Department == activenode).Count() > 0 && i == 3) &&  category == 3) || ((category == 30) && (i == 3)))
                {
                    collapsein3 = "";
                    addin3 = " in ";
                }
                if (i == 3)
                    level3lastnode1 = " class=\"lastmenuitem\" ";



                sb.AppendLine("<li" + level3lastnode1 + "><a data-toggle=\"collapse\"" + collapsein3 + "\" href=\"#" + Heading.Replace(" ","") + "\"><p>" + Heading + "</p><span></span></a>");
                sb.AppendLine("<ul class=\"collapse" + addin3 + "\" id=\"" + Heading.Replace(" ", "") + "\">");
                
                
                
                if (i == 2)
                {
                    List<string> depts = new List<string>();
                    depts = dbit.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").Select(y => y.Name).ToList();
                    foreach (var item in depts)
                    {
                        string level3lastnode2 = "";
                        string active = "";

                        if (item == activenode && category == 2)
                        {
                            active = " class=\"active\" ";
                            addin3 = " in ";
                        }
                        if (depts.Last() == item)
                            level3lastnode2 = " lastmenuitem ";


                        sb.AppendLine("<li class=\"" + level3lastnode2 + "lastnode\"><a " + active + " href=\"/Jobs_" + item.Replace(" ", "-").Replace("&","and") + ".html\"><p>" + item + " Jobs</p><span></span></a></li>");
                    }
                }
                else if (i == 1)
                {
                    List<string> categories = new List<string>(new string[] { "Caseworker", "Trainee", "Solicitor", "Admin", "Internship", "Cost Draftsman and Billing", "Apprenticeship"});
                    foreach (var item in categories)
                    {
                        string level3lastnode2 = "";
                        string active = "";

                        if (item == activenode)
                        {
                            active = " class=\"active\" ";
                            addin3 = " in ";
                        }
                        if (categories.Last() == item)
                            level3lastnode2 = " lastmenuitem ";

                        sb.AppendLine("<li class=\"" + level3lastnode2 + "lastnode\"><a " + active + " href=\"/Jobs_" + item.Replace(" ", "-") + ".html\"><p>" + item + " Jobs</p><span></span></a></li>");
                    }
                }
                else if (i == 3)
                {
                    //List<string> deptsconsultancy = new List<string>();
                    //List<Recruitment_DlWeb> consultantsdepts1 = new List<Recruitment_DlWeb>();
                    //consultantsdepts1 = dlweb.Recruitment_DlWeb.Where(z => z.Live == true && z.Job_Type == "Freeleance").ToList().GroupBy(x => x.Department).Select(y => y.First()).ToList();
                    //deptsconsultancy = consultantsdepts1.Select(x => x.Department.Trim()).ToList();


                    //foreach (var item in deptsconsultancy)
                    //{
                    //    string level3lastnode2 = "";
                    //    string active = "";

                    //    if (item == activenode && category == 3)
                    //    {
                    //        active = " class=\"active\" ";
                    //        addin3 = " in ";
                    //    }
                    //    if (deptsconsultancy.Last() == item)
                    //        level3lastnode2 = " lastmenuitem ";

                        sb.AppendLine("<li class=\"lastnode\"><a href=\"/JobsConsultancy.html\"><p>Overview</p><span></span></a></li>");
                        sb.AppendLine("<li class=\"lastnode\"><a href=\"/Jobs_Consultancy.html\"><p>Consultants Jobs</p><span></span></a></li>");
                    //}
                }
                sb.AppendLine("                                </ul>");
                sb.AppendLine("                                </li>");
            }


            sb.AppendLine("                                </ul>");
            sb.AppendLine("                            </div>");
            sb.AppendLine("                        </div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            return sb;
        }

        public StringBuilder getDeptNavigationVideos(DepartmentDetails DD, string category = null)
        {
            List<string> DD1 = new List<string>();
            DD1.Add("All");
            DD1.AddRange(dbit.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").OrderBy(z => z.Name).Select(y => y.Name).ToList());
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div id=\"deptmenu\" class=\"" + DD.cssclass + "\">");
            sb.AppendLine("<div class=\"panel panel-default deptbordercolor\">");
            sb.AppendLine("                        <div class=\"" + DD.cssclass + " deptbordercolor forecolor deptmenumainheading\">");
            sb.AppendLine("<a data-toggle=\"collapse\" href=\"#deptnavigationmenu\">Videos<span class=\"fa fa-caret-down\"></span></a>");
            sb.AppendLine("                        </div>");



            sb.AppendLine("                        <div id=\"deptnavigationmenu\" class=\"panel-collapse collapse in\">");
            sb.AppendLine("                            <div class=\"panel-body\">");
            sb.AppendLine("                                <ul>");

            foreach(var item in DD1)
            {
                string active3 = "";

                if (item == category)
                    active3 = " class=\"active\" ";

                if (item == "All")
                    sb.AppendLine("<li class=\"lastnode\"><a " + active3 + " href=\"/Video.html\"><p>" + item + " Videos</p><span></span></a></li>");
                else
                    sb.AppendLine("<li class=\"lastnode\"><a " + active3 + " href=\"/" + item.Replace(" ","-") + "-Solicitor-Video.html\"><p>" + item + " Solicitor Videos</p><span></span></a></li>");
            }

            sb.AppendLine("                                </ul>");
            sb.AppendLine("                            </div>");
            sb.AppendLine("                        </div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            return sb;
        }



        public string getlinkfromwebsitepages(int? id){
            //return dbit.Website_Pages.Where(x => x.ID == id).Select(y => (y.RewriteURL==null || y.RewriteURL=="") ? y.Filename : y.RewriteURL).FirstOrDefault();
            return dbit.Website_Pages.Where(x => x.ID == id).Select(y => y.Filename).FirstOrDefault();
        }

    }
}
