using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class MainNavigationNewWebsite : IMainNavigation
    {
        public List<string> teamnames = new List<string>();
        public List<string> officelocation = new List<string>();
        public List<string> AboutFeesFunding = new List<string>();
        public List<string> NewsMedia = new List<string>();
        public List<string> Tabs = new List<string>();
        public string[] tabslinks = new string[] { "/Private.html", "/LegalAid.html", "/Corporate.html", "/Our_Team.html", "/findus.html", "/about.html", "/News.html", "/Careers.html" };
        public MainNavigationNewWebsite()
        {
            teamnames.Add("Management Team");
            teamnames.Add("Teams by Department");
            teamnames.Add("Alphabetic Team Listing");

            officelocation.Add("Offices in London");
            officelocation.Add("Offices outside London");

            AboutFeesFunding.Add("About Us");
            AboutFeesFunding.Add("Fees & Funding");

            NewsMedia.Add("News");
            NewsMedia.Add("Reported Cases");
            NewsMedia.Add("In The Press");
            NewsMedia.Add("Legal_News");

            Tabs.Add("Private");
            Tabs.Add("Legal Aid");
            Tabs.Add("Business");
            Tabs.Add("Our Team");
            Tabs.Add("Our Offices");
            Tabs.Add("About Us");
            Tabs.Add("News");
            Tabs.Add("Careers");

            
            //Tabs.Add("Contact");
        }

        public StringBuilder getmainnavigation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"row nopadding\">");
            sb.AppendLine("    <div class=\"col-xs-12 col-sm-12 nopadding\">");
            sb.AppendLine("<div class=\"navbar navbar-inverse navbar-fixed-top nopadding\">");
            sb.AppendLine("<div class=\"container\">");
            sb.AppendLine("<div class=\"navbar-header nopadding\">");
            sb.AppendLine("<button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\".navbar-collapse\">");
                sb.AppendLine("<span class=\"icon-bar\"></span>");
                sb.AppendLine("<span class=\"icon-bar\"></span>");
                sb.AppendLine("<span class=\"icon-bar\"></span>");
            sb.AppendLine("</button>");

            //sb.AppendLine("<a class=\"navbar-brand\" style=\"z-index:999\" href=\"/index.html\"><span class=\"fa fa-home\"></span></a>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div class=\"navbar-collapse collapse mainnav\">");
            sb.AppendLine("<ul class=\"nav nav-pills\">");
            sb.AppendLine("<li><a href=\"/index.html\"><span style=\"font-size:26px !Important; color: #d7f3ff;\" class=\"fa fa-home\"></span></a></li>");
            int linki = 0;
            foreach (var item in Tabs)
            {
                sb.AppendLine("<li><a href=\"" + tabslinks[linki].ToString() + "\" data-target=\"#" + item.Replace(" ", "").Replace("&", "") + "tab\" data-hover=\"tab\">" + item + "<span class=\"fa fa-chevron-down\" aria-hidden=\"true\"></span></a></li>");
                linki++;
            }
            sb.AppendLine("<li><a href=\"/Home/contact\">Contact<span class=\"fa fa-chevron-down\" aria-hidden=\"true\"></span></a></li>");
            sb.AppendLine("<li style=\"display:none\" class=\"hiddennavigationtab\"><a href=\"#\" data-target=\"#tab-9\" data-hover=\"tab\">Text Size<span class=\"fa fa-chevron-down\" aria-hidden=\"true\"></span></a></li>");
            sb.AppendLine("</ul>");
            sb.AppendLine("<div class=\"tab-content nopadding\">");

            foreach (var item1 in Tabs)
            {
                sb.AppendLine("<div class=\"tab-pane megamenu dropdown-menu nopadding\" id=\"" + item1.Replace(" ", "").Replace("&", "") + "tab\">");
                sb.AppendLine("<div class=\"row row-eq-height\">");

                        sb.AppendLine("<div class=\"col-lg-3 megamunulevel1 nopadding\">");
                        sb.AppendLine("<ul>");
                            sb.Append(getlevel1tabs(item1));
                        sb.AppendLine("</ul>");
                        sb.AppendLine("</div>");
                        sb.Append(getlevel2tabs(item1));
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
            }
            sb.AppendLine("<div class=\"tab-pane megamenu dropdown-menu\" style=\"display:none\" id=\"tab-9\"></div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return sb;
        }

        public StringBuilder getlevel1tabs(string tab)
        {
            StringBuilder sb = new StringBuilder();
            if (tab == "Private" || tab == "Legal Aid" || tab == "Business")
            {

                IT_DatabaseEntities dbit = new IT_DatabaseEntities();
                List<Website_Department_Structure> WDS = new List<Website_Department_Structure>();
                if (tab == "Private")
                    WDS = dbit.Website_Department_Structure.Where(x => x.Private > 0 && x.departmenttype == "AreaOfLaw").OrderBy(y => y.Name).ToList();
                else if (tab == "Legal Aid")
                    WDS = dbit.Website_Department_Structure.Where(x => x.LegalAid > 0 && x.departmenttype == "AreaOfLaw").OrderBy(y => y.Name).ToList();
                else if (tab == "Business")
                    WDS = dbit.Website_Department_Structure.Where(x => x.Corporate > 0 && x.departmenttype == "AreaOfLaw").OrderBy(y => y.Name).ToList();

                string overviewlink = "";
                foreach (var item in WDS)
                {
                    overviewlink = "#";
                    overviewlink = dbit.Website_Department_Structure.Where(x => x.ID == item.ID).Select(y => y.Overview1).FirstOrDefault();
                    if (tab == "Legal Aid" && item.Name == "Housing")
                        sb.AppendLine("<li class=\"" + item.cssclass + " over\"><a href=\"/" + overviewlink + "\" data-target=\"#" + tab.Replace(" ", "") + item.Name.Replace(" ", "-").Replace("&", "") + "\" data-hover=\"tab\">Social Housing<span class=\"fa fa-chevron-right\" aria-hidden=\"true\"></span></a></li>");
                    else
                        sb.AppendLine("<li class=\"" + item.cssclass + " over\"><a href=\"/" + overviewlink + "\" data-target=\"#" + tab.Replace(" ", "") + item.Name.Replace(" ", "-").Replace("&", "") + "\" data-hover=\"tab\">" + item.Name + "<span class=\"fa fa-chevron-right\" aria-hidden=\"true\"></span></a></li>");
                }
            }
            else if (tab == "Our Team")
            {
                foreach (var item in teamnames)
                {
                    sb.AppendLine("<li class=\"dept_default over\"><a href=\"#\" data-target=\"#" + item.Replace(" ", "-").Replace("&","") + "\" data-hover=\"tab\">" + item + "<span class=\"fa fa-chevron-right\" aria-hidden=\"true\"></span></a></li>");
                }
            }
            else if (tab == "Our Offices")
            {
                foreach (var item in officelocation)
                {
                    sb.AppendLine("<li class=\"dept_default over\"><a href=\"#\" data-target=\"#" + item.Replace(" ", "-").Replace("&","") + "\" data-hover=\"tab\">" + item + "<span class=\"fa fa-chevron-right\" aria-hidden=\"true\"></span></a></li>");
                }
            }
            else if (tab == "About Us")
            {
                foreach (var item in AboutFeesFunding)
                {
                    sb.AppendLine("<li class=\"dept_default over\"><a href=\"#\" data-target=\"#" + item.Replace(" ", "-").Replace("&","") + "\" data-hover=\"tab\">" + item + "<span class=\"fa fa-chevron-right\" aria-hidden=\"true\"></span></a></li>");
                }
            }
            else if (tab == "News")
            {
                foreach (var item in NewsMedia)
                {
                    sb.AppendLine("<li class=\"dept_default over\"><a href=\"#\" data-target=\"#" + item.Replace(" ", "-").Replace("&","") + "\" data-hover=\"tab\">" + item.Replace("_", " ") + "<span class=\"fa fa-chevron-right\" aria-hidden=\"true\"></span></a></li>");
                }
            }
            else if (tab == "Careers")
            {
                    sb.AppendLine("<li class=\"dept_default over\"><a href=\"#\" data-target=\"#AllJobs\" data-hover=\"tab\">All Jobs<span class=\"fa fa-chevron-right\" aria-hidden=\"true\"></span></a></li>");
            }

            return sb;
        }



        public StringBuilder getlevel2tabs(string tab)
        {
            StringBuilder sb = new StringBuilder();
            int j = 1;
            if (tab == "Private" || tab == "Legal Aid" || tab == "Business")
            {

                IT_DatabaseEntities dbit = new IT_DatabaseEntities();
                List<Website_Department_Structure> WDS = new List<Website_Department_Structure>();

                if (tab == "Private")
                    WDS = dbit.Website_Department_Structure.Where(x => x.Private > 0 && x.departmenttype == "AreaOfLaw").OrderBy(y => y.Name).ToList();
                else if (tab == "Legal Aid")
                    WDS = dbit.Website_Department_Structure.Where(x => x.LegalAid > 0 && x.departmenttype == "AreaOfLaw").OrderBy(y => y.Name).ToList();
                else if (tab == "Business")
                    WDS = dbit.Website_Department_Structure.Where(x => x.Corporate > 0 && x.departmenttype == "AreaOfLaw").OrderBy(y => y.Name).ToList();

                sb.AppendLine("<div class=\"col-lg-9 tab-content nopadding level2\">");
                
                foreach (var item in WDS)
                {
                    //string activeon = "";
                    //if (j == 1)
                    //    activeon = " active ";
                    //j++;
                    Website_Structure WS_dept = new Website_Structure();
                    WS_dept = dbit.Website_Structure.Where(x => x.name == item.Name && x.level == "Root").FirstOrDefault();
                    List<Website_Structure> WS = new List<Website_Structure>();
                    WS = dbit.Website_Structure.Where(x => x.underwhichnode == WS_dept.id).OrderBy(y => y.sequence).ThenBy(z => z.level).ToList();
                    

                    sb.AppendLine("<div class=\"tab-pane megamunulevel2\" id=\"" + tab.Replace(" ","") + item.Name.Replace(" ", "-").Replace("&","") + "\">");
                    sb.AppendLine("<div class=\"row nopadding " + item.cssclass + "\">");
                    if (tab == "Legal Aid" && item.Name == "Housing")
                        sb.AppendLine("<div class=\"col-lg-12 megamunulevel2topband " + item.cssclass + " kolor\">Social Housing");
                    else
                        sb.AppendLine("<div class=\"col-lg-12 megamunulevel2topband " + item.cssclass + " kolor\">" + item.Name);
                    sb.AppendLine("<span class=\"fa fa-caret-down\" aria-hidden=\"true\"></span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2middleband deptbordercolor " + item.cssclass + " lightkolor\">");
                    sb.AppendLine("<div class=\"row\">");
                    string colsval = "col-lg-4";
                    if (WS.Count < 19)
                        colsval = "col-lg-4";
                    else if (WS.Count > 27)
                        colsval = "col-lg-3";

                    sb.AppendLine("<div class=\"" + colsval + " megamunulevel2middlebandcolumns\">");
                    sb.AppendLine("<ul>");
                    int i = 1;
                    foreach (var item1 in WS)
                    {
                        Website_Structure WS_ContentPage = new Website_Structure();
                        WS_ContentPage = dbit.Website_Structure.Where(x => x.name == item1.name && x.level == "ContentNode" && x.underwhichnode == item1.id).FirstOrDefault();

                        if (WS_ContentPage == null)
                        {
                            WS_ContentPage = dbit.Website_Structure.Where(x => x.underwhichnode == item1.id  && x.level == "ContentNode").OrderBy(y => y.sequence).FirstOrDefault();
                        }

                        if (WS_ContentPage == null)
                        {
                            WS_ContentPage = dbit.Website_Structure.Where(x => x.underwhichnode1 == item1.id && x.level == "ContentNode").OrderBy(y => y.sequence).FirstOrDefault();
                        }

                        string link = "#";

                        if (item1.level == "ContentNode")
                        {
                            link = dbit.Website_Pages.Where(x => x.ID == item1.linkedid).Select(y => y.Filename + ".html").FirstOrDefault();
                        }
                        else
                        {
                            if (WS_ContentPage != null)
                                link = dbit.Website_Pages.Where(x => x.ID == WS_ContentPage.linkedid).Select(y => y.Filename + ".html").FirstOrDefault();
                        }

                        string linktext = item1.name;
                        if (item1.name == item.Name && item1.level == "ContentNode")
                            linktext = "Overview";

                        sb.AppendLine("<li><a href=\"/" + link + "\">" + linktext + "</a></li>");
                        i++;
                        if (i % 9 == 0)
                        {
                            sb.AppendLine("</ul>");
                            sb.AppendLine("</div>");
                            sb.AppendLine("<div class=\"" + colsval + " megamunulevel2middlebandcolumns\">");
                            sb.AppendLine("<ul>");
                        }
                        
                    }
                    sb.AppendLine("</ul>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<img class=\"img-responsive\" src=\"/images/" + item.Name.Replace(" ", "-") + "-thumb.jpg\" alt=\"" + item.Name.Replace(" ", " - ") + "\" />");
                    sb.AppendLine("<span class=\"" + item.cssclass + " kolor deptbordercolor\">" + item.Heading21 + "</span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2bottomband " + item.cssclass + " kolor\">");
                    sb.AppendLine("<span>");
                    sb.AppendLine("<img src=\"/Images/logo_small.PNG\" alt=\"Duncan Lewis\" />");
                    if (tab == "Private" || tab == "Legal Aid")
                    {
                        sb.AppendLine("Legal Services for You");
                    }
                    else
                    {
                        sb.AppendLine("Legal Services for Your Business");
                    }
                    sb.AppendLine("</span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                }
                sb.AppendLine("</div>");
            }
            else if (tab == "Our Team")
            {
                sb.AppendLine("<div class=\"col-lg-9 tab-content nopadding level2\">");
                foreach (var item in teamnames)
                {
                    //string activeon = "";
                    //if (j == 1)
                    //    activeon = " active ";
                    //j++;
                    sb.AppendLine("<div class=\"tab-pane megamunulevel2\" id=\"" + item.Replace(" ", "-").Replace("&","") + "\">");
                    sb.AppendLine("<div class=\"row nopadding dept_default\">");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2topband dept_default kolor\">" + item);
                    sb.AppendLine("<span class=\"fa fa-caret-down\" aria-hidden=\"true\"></span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2middleband deptbordercolor dept_default lightkolor\">");
                    sb.AppendLine("<div class=\"row\">");
                    sb.AppendLine("<div class=\"col-lg-4 megamunulevel2middlebandcolumns\">");
                    sb.AppendLine("<ul>");
                    int i = 0;
                    if (item == "Management Team")
                    {
                        sb.AppendLine("<li><a href=\"/about_managementboard.html\">" + item + "</a></li>");
                    }
                    else if (item == "Teams by Department")
                    {
                        IT_DatabaseEntities dbit = new IT_DatabaseEntities();
                        List<Website_Department_Structure> WDS = new List<Website_Department_Structure>();
                        WDS = dbit.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").OrderBy(y => y.Name).ToList();
                        foreach (var item1 in WDS)
                        {
                            sb.AppendLine("<li><a href=\"/" + item1.Our_Team1 + "\">" + item1.Name + "</a></li>");
                            i++;
                            if (i % 12 == 0)
                            {
                                sb.AppendLine("</ul>");
                                sb.AppendLine("</div>");
                                sb.AppendLine("<div class=\"col-lg-4 megamunulevel2middlebandcolumns\">");
                                sb.AppendLine("<ul>");

                            }
                        }
                    }
                    else if (item == "Alphabetic Team Listing")
                    {
                        foreach (var item1 in Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToList())
                        {
                            sb.AppendLine("<li><a href=\"/Our_Team_Alphabetic_" + item1 + ".html\">" + item1 + "</a></li>");
                            i++;
                            if (i % 12 == 0)
                            {
                                sb.AppendLine("</ul>");
                                sb.AppendLine("</div>");
                                sb.AppendLine("<div class=\"col-lg-4 megamunulevel2middlebandcolumns\">");
                                sb.AppendLine("<ul>");

                            }
                            
                        }
                    }
                    sb.AppendLine("</ul>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<img class=\"img-responsive\" src=\"/images/AboutUs-thumb.jpg\" alt=\"Duncan Lewis About Us\" />");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2bottomband dept_default kolor\">");
                    sb.AppendLine("<span>");
                    sb.AppendLine("<img src=\"/Images/logo_small.PNG\" alt=\"Duncan Lewis\" />");
                    sb.AppendLine("Legal Services");
                    sb.AppendLine("</span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                }
                sb.AppendLine("</div>");
            }
            else if (tab == "Our Offices")
            {
                sb.AppendLine("<div class=\"col-lg-9 tab-content nopadding level2\">");
                foreach (var item in officelocation)
                {
                    string activeon = "";
                    if (j == 1)
                        activeon = " active ";
                    j++;
                    string officeinout = "In";
                    if (item == "Offices outside London")
                        officeinout = "Out";
                    
                    sb.AppendLine("<div class=\"tab-pane megamunulevel2 " + activeon + "\" id=\"" + item.Replace(" ", "-").Replace("&","") + "\">");
                    sb.AppendLine("<div class=\"row nopadding dept_default\">");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2topband dept_default kolor\">" + item);
                    sb.AppendLine("<span class=\"fa fa-caret-down\" aria-hidden=\"true\"></span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2middleband deptbordercolor dept_default lightkolor\">");
                    DLWEBEntities dbweb = new DLWEBEntities();
                    List<OfficeDLW> Off = new List<OfficeDLW>();
                    Off = dbweb.OfficesDLW.Where(x => x.In_Out_London == officeinout && x.Active == true).OrderBy(x => x.Sequence).ThenBy(x => x.Name).ToList();
                    string cols = "col-lg-4";
                    if (Off.Count() > 27)
                        cols = "col-lg-3";

                    sb.AppendLine("<div class=\"row\">");
                    sb.AppendLine("<div class=\"" + cols + " megamunulevel2middlebandcolumns\">");
                    sb.AppendLine("<ul>");
                    int i = 0;
                    
                    foreach (var item1 in Off)
                    {
                        sb.AppendLine("<li><a href=\"/offices/" + item1.Name + "_office.html\">" + item1.Name + "</a></li>");
                        i++;
                        if (i % 12 == 0)
                        {
                            sb.AppendLine("</ul>");
                            sb.AppendLine("</div>");
                            sb.AppendLine("<div class=\"" + cols + " megamunulevel2middlebandcolumns\">");
                            sb.AppendLine("<ul>");

                        }
                    }

                    sb.AppendLine("</ul>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2bottomband dept_default kolor\">");
                    sb.AppendLine("<span>");
                    sb.AppendLine("<img src=\"/Images/logo_small.PNG\" alt=\"Duncan Lewis\" />");
                    sb.AppendLine("Legal Services");
                    sb.AppendLine("</span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    
                }
                sb.AppendLine("</div>");
            }
            else if (tab == "About Us")
            {
                sb.AppendLine("<div class=\"col-lg-9 tab-content nopadding level2\">");
                foreach (var item in AboutFeesFunding)
                {
                    string activeon = "";
                    if (j == 1)
                        activeon = " active ";
                    j++;
                    sb.AppendLine("<div class=\"tab-pane megamunulevel2 " + activeon + "\" id=\"" + item.Replace(" ", "-").Replace("&","") + "\">");
                    sb.AppendLine("<div class=\"row nopadding dept_default\">");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2topband dept_default kolor\">" + item);
                    sb.AppendLine("<span class=\"fa fa-caret-down\" aria-hidden=\"true\"></span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2middleband deptbordercolor dept_default lightkolor\">");
                    sb.AppendLine("<div class=\"row\">");
                    sb.AppendLine("<div class=\"col-lg-4 megamunulevel2middlebandcolumns\">");
                    sb.AppendLine("<ul>");
                    int i = 0;
                    IT_DatabaseEntities dbit = new IT_DatabaseEntities();
                    List<Website_Pages> WP = new List<Website_Pages>();
                    WP = dbit.Website_Pages.Where(x => x.Department == item && x.Company== "Duncan Lewis").OrderBy(y => y.Name).ToList(); //.OrderBy(z => z.Sequence)
                    foreach (var item1 in WP)
                    {
                        sb.AppendLine("<li><a href=\"/" + item1.Filename + ".html\">" + item1.Name + "</a></li>");
                        i++;
                        if (i % 12 == 0)
                        {
                            sb.AppendLine("</ul>");
                            sb.AppendLine("</div>");
                            sb.AppendLine("<div class=\"col-lg-4 megamunulevel2middlebandcolumns\">");
                            sb.AppendLine("<ul>");
                        }
                    }

                    sb.AppendLine("</ul>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2bottomband dept_default kolor\">");
                    sb.AppendLine("<span>");
                    sb.AppendLine("<img src=\"/Images/logo_small.PNG\" alt=\"Duncan Lewis\" />");
                    sb.AppendLine("Legal Services");
                    sb.AppendLine("</span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                }
                sb.AppendLine("</div>");
            }
            else if (tab == "News")
            {
                sb.AppendLine("<div class=\"col-lg-9 tab-content nopadding level2\">");
                foreach (var item in NewsMedia)
                {
                    string activeon = "";
                    if (j == 1)
                        activeon = " active ";
                    j++;
                    sb.AppendLine("<div class=\"tab-pane megamunulevel2 " + activeon + "\" id=\"" + item.Replace(" ", "-").Replace("&","") + "\">");
                    sb.AppendLine("<div class=\"row nopadding dept_default\">");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2topband dept_default kolor\">" + item);
                    sb.AppendLine("<span class=\"fa fa-caret-down\" aria-hidden=\"true\"></span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2middleband deptbordercolor dept_default lightkolor\">");
                    sb.AppendLine("<div class=\"row\">");
                    sb.AppendLine("<div class=\"col-lg-4 megamunulevel2middlebandcolumns\">");
                    sb.AppendLine("<ul>");
                    int i = 2;
                    sb.AppendLine("<li><a href=\"/" + item.Replace(" ", "") + ".html\">" + item + "</a></li>");
                    foreach (var item1 in Enumerable.Range(2010, DateTime.Now.Year - 2010).Reverse().ToList())
                    {
                        if (item == "Legal_News")
                        {
                            sb.AppendLine("<li><a href=\"/" + item.Replace(" ", "").ToLower() + "_January" + "-" + item1 + ".html\">" + item + "-" + item1 + "</a></li>");
                        }
                        else
                        {
                            if (item1 < DateTime.Now.Year - 1)
                            sb.AppendLine("<li><a href=\"/" + item.Replace(" ", "") + "-" + item1 + ".html\">" + item + "-" + item1 + "</a></li>");
                        }
                        i++;
                        if (i % 12 == 0)
                        {
                            sb.AppendLine("</ul>");
                            sb.AppendLine("</div>");
                            sb.AppendLine("<div class=\"col-lg-4 megamunulevel2middlebandcolumns\">");
                            sb.AppendLine("<ul>");
                        }
                    }

                    sb.AppendLine("</ul>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2bottomband dept_default kolor\">");
                    sb.AppendLine("<span>");
                    sb.AppendLine("<img src=\"/Images/logo_small.PNG\" alt=\"Duncan Lewis\" />");
                    sb.AppendLine("Legal Services");
                    sb.AppendLine("</span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                }
                sb.AppendLine("</div>");
            }
            else if (tab == "Careers")
            {
                sb.AppendLine("<div class=\"col-lg-9 tab-content nopadding level2\">");

                    sb.AppendLine("<div class=\"tab-pane megamunulevel2 active\" id=\"AllJobs\">");
                    sb.AppendLine("<div class=\"row nopadding dept_default\">");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2topband dept_default kolor\">All Jobs");
                    sb.AppendLine("<span class=\"fa fa-caret-down\" aria-hidden=\"true\"></span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2middleband deptbordercolor dept_default lightkolor\">");
                    sb.AppendLine("<div class=\"row\">");
                    sb.AppendLine("<div class=\"col-lg-4 megamunulevel2middlebandcolumns\">");
                    sb.AppendLine("<ul>");
                    sb.AppendLine("<li><a href=\"/careers.html\">Overview</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Caseworker.html\">Paralegals Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Trainees.html\">Trainees Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Solicitor.html\">Solicitors Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/JobsConsultancy.html\">Consultant Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Admin.html\">Admin/Support Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Apprenticeship.html\">Apprenticeship</a></li>");
                    sb.AppendLine("<li><a href=\"/internship.aspx\">Internship</a></li>");  
                    sb.AppendLine("</ul>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-4 megamunulevel2middlebandcolumns\">");
                    sb.AppendLine("<ul>");
                    sb.AppendLine("<li><a href=\"/Jobs_Child-Care.html\">Child Care Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Community-Care.html\">Community Care Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Crime.html\">Crime Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Employment.html\">Employment Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Family.html\">Family Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Housing.html\">Housing Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Immigration.html\">Immigration Jobs</a></li>");
                    sb.AppendLine("</ul>");
                    sb.AppendLine("</div>");

                    sb.AppendLine("<div class=\"col-lg-4 megamunulevel2middlebandcolumns\">");
                    sb.AppendLine("<ul>");
                    sb.AppendLine("<li><a href=\"/Jobs_Civil-Litigation.html\">Litigation Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Mental-Health.html\">Mental Health</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Prison-Law.html\">Prison Law Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Public-Law.html\">Public Law Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Welfare-Benefits.html\">Welfare Benefits Jobs</a></li>");
                    sb.AppendLine("<li><a href=\"/Jobs_Personal-Injury.html\">Personal Injury Jobs</a></li>");
                
                    sb.AppendLine("</ul>");
                    sb.AppendLine("</div>");

                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"col-lg-12 megamunulevel2bottomband dept_default kolor\">");
                    sb.AppendLine("<span>");
                    sb.AppendLine("<img src=\"/Images/logo_small.PNG\" alt=\"Duncan Lewis\" />");
                    sb.AppendLine("Legal Services");
                    sb.AppendLine("</span>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");

                sb.AppendLine("</div>");
            }

            return sb;

        }
    }
}
