using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class WebsitePages_NewWebsite
    {
         private int id;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }
        public string canonicaltag { get; set; }

        public WebsitePages_NewWebsite(int ID, AContents _Acontent)
        {
            string _ourTeamLink =null;
            id = ID;
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            Website_Pages WP = new Website_Pages();
            WP = db.Website_Pages.Where(x => x.ID == ID).FirstOrDefault();

            Website_Structure ws = new Website_Structure();
            ws = db.Website_Structure.Where(x => x.level != "Root" && x.linkedid == ID).FirstOrDefault();

            DepartmentDetails DD = new DepartmentDetails(WP.Department);

            if (DD.Name == "Child Care" || DD.Name == "Family" || DD.Name == "Domestic Abuse and Violence")
                _ourTeamLink = allStatic.GetOurTeamLinkForSubDepartment(WP.ID);


            if (!string.IsNullOrEmpty(WP.Title))
                Title = WP.Title + (WP.Title.Length < 55 ? WP.Title.Contains("Duncan Lewis") ? "" : " | Duncan Lewis" : "");
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
            _Acontent.Department = WP.Department;

            DepartmentNavigationNewWebsite Deptnav = new DepartmentNavigationNewWebsite();
            StringBuilder SB = new StringBuilder();

            List<website_awards> logos = new List<website_awards>();



            foreach (var item in db.website_awards.Where(x => x.IndividualCompany == "Department" && x.DLDepartment == DD.Name && x.LogosToUse !=null && x.LogosToUse.Contains(".")).GroupBy(y => y.LegalDirectory).Select(z => z.Key).ToList())
            {

                var wa = db.website_awards.Where(x => x.IndividualCompany == "Department" && x.DLDepartment == DD.Name && x.LegalDirectory == item).OrderByDescending(y =>y.Year).FirstOrDefault();
                if (wa != null)
                    logos.Add(wa);
            }
            
            



            SB.AppendLine("<div class=\"row nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-sm-offset-2 nopadding applyblock centerdiv\">");
            SB.AppendLine("        <div class=\"row nopadding\">");

            if (DD.Name == "Careers")
            {
                SB.AppendLine("            <div class=\"col-sm-12 col-md-9 col-xs-12 col-md-offset-3 depttabs\">");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Careers.html\">Careers</a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Trainees.html\">Trainees<span class=\"fa fa-suitcase\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/JobsConsultancy.html\">Consultancy<span class=\"fa fa-suitcase\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/internship.html\">Volunteer<span class=\"fa fa-suitcase\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Employee-Reward-and-Benefits.html\">Rewards<span class=\"fa fa-suitcase\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Careers-Video.html\">Videos<span class=\"fa fa-suitcase\"></span></a>");
                

                SB.AppendLine("        </div>");
            }
            else if (DD.Name == "About Us" || DD.Name == "Fees & Funding" || DD.Name == "Misleneous")
            {
                SB.AppendLine("            <div class=\"col-sm-12 col-md-7 col-xs-12 col-md-offset-5 depttabs\">");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/our_team.html\">Our Team<span class=\"fa fa-users\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/News.html\">News<span class=\"fa fa-newspaper-o\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Video.html\">Videos<span class=\"fa fa-video-camera\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/brochures.html\">Brochures<span class=\"fa fa-book\"></span></a>");
                SB.AppendLine("            </div>");
            }
            else if (DD.Name == "Commercial & Company" || DD.Name == "Commercial Litigation & Disputes" || DD.Name == "Commercial Property Services" || DD.Name == "International Disputes" || DD.Name == "Charities" || DD.Name == "European Union" || DD.Name == "Business Crime & Investigation")
            {
                SB.AppendLine("            <div class=\"col-sm-12 col-md-7 col-xs-12 col-md-offset-5 depttabs\">");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.Our_Team1 + "\">Our Team<span class=\"fa fa-users\"></span></a>");
                SB.AppendLine("            </div>");
            }
            else
            {
                SB.AppendLine("            <div class=\"col-sm-12 col-md-7 col-xs-12 col-md-offset-5 depttabs\">");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + ((_ourTeamLink != null && _ourTeamLink.Contains("_ourTeam")) ? _ourTeamLink : DD.Our_Team1) + "\">Our Team<span class=\"fa fa-users\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.News1 + "\">News<span class=\"fa fa-newspaper-o\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.News1.Replace("news", "articles") + "\">Articles<span class=\"fa fa-book\"></span></a>");
                SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.Video + "\">Videos<span class=\"fa fa-video-camera\"></span></a>");
                SB.AppendLine("            </div>");
            }

            
            
            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");
            SB.AppendLine("</div>");

            SB.AppendLine("<div class=\"row deptreverseband " + DD.cssclass + " lightkolor  nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            SB.AppendLine("        <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-9 col-xs-12 col-sm-offset-3 breadcrumbs\">");

            if (DD.Name == "Misleneous")
                SB.AppendLine("      <p><a class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\">Home</a></p>");
            else
                SB.AppendLine("       <p><a  class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\"><p>Home</a><span class=\"fa fa-angle-double-right\"></span><a  class=\"" + DD.cssclass + " forecolor\" href=\"/" + DD.Overview1 + "\"><p>" + DD.Name + "</a><span class=\"fa fa-angle-double-right\"></span>" + WP.Name.ToString().Replace("<br />", " ") + "</p>");

            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");

            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");

            SB.AppendLine("<div class=\"" + DD.cssclass + " row nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            SB.AppendLine("        <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-3 col-xs-12 nopadding\">");

            if (ws != null)
                SB.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, ws.id).ToString());
            else
                SB.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, 0).ToString());

            SB.AppendLine("            </div>");

            SB.AppendLine("            <div class=\"col-sm-9 col-xs-12\">");

            SB.AppendLine("                <div id=\"container\">");

            if (WP.Filename.ToLower() + ".html" == DD.Overview1.ToLower())
            {
                if (logos != null && logos.Count() > 0)
                {

                    SB.AppendLine("                            <div class=\"legaldirectorypanel " + DD.cssclass + " lightkolor deptbordercolor\" style=\"margin-top:20px\">");
                    SB.AppendLine("                                <div class=\"row nopadding\">");
                    SB.AppendLine("                                    <div class=\"col-sm-4 nopadding\">");
                    SB.AppendLine("                                        <div class=\"awardtext\">Awards and Recommendations for the " + DD.Name + " Department</div>");
                    SB.AppendLine("                                        <div class=\"legaldirectoryimgdiv\">");

                    foreach (var item in logos)
                    SB.AppendLine("                                             <img src=\"/Images/" + item.LogosToUse + "\" alt=\"Duncan Lewis - " + item.LegalDirectory +"\" />");

                    
                    
                    SB.AppendLine("                                        </div>");
                    SB.AppendLine("                                    </div>");
                    SB.AppendLine("                                    <div class=\"col-sm-8 nopadding\">");
                    SB.AppendLine("                                        <div class=\"row legaldirectory " + DD.cssclass + " deptbordercolor\">");
                    int i = 0;
                    foreach (var item in db.website_awards.Where(x => x.IndividualCompany == "Department" && x.DLDepartment == DD.Name).OrderByDescending(y => y.Year).ToList())
                    {
                        i++;
                        if (i == 3)
                        {
                            SB.AppendLine("                                            <div class=\"col-sm-12 nopadding\">");
                            SB.AppendLine("                                                <div class=\"row collapse nopadding\" id=\"moredirectorylisting\">");
                        }
                        SB.AppendLine("                                            <div class=\"col-sm-12 nopadding\">");
                        SB.AppendLine("                                                <div class=\"legaldirectoryblurb " + DD.cssclass + " lightkolor\">");
                        SB.AppendLine("                                                    <p class=\"" + DD.cssclass + " lightkolor\">" + item.Blurb + "</p>");
                        SB.AppendLine("                                                    <span class=\"" + DD.cssclass + " forecolor deptbordercolor\">" + item.LegalDirectory + " " + item.Year + " Edition.<br />" + item.LegalDirectoryDepartment + " / " + item.LegalDirectoryArea + "</span>");
                        SB.AppendLine("                                                </div>");
                        SB.AppendLine("                                            </div>");
                    }
                    if (i > 2)
                    {
                        SB.AppendLine("                                                </div>");
                        SB.AppendLine("                                                <a class=\"legaldirectoryviewmore " + DD.cssclass + " forecolor\" href=\"#moredirectorylisting\" data-toggle=\"collapse\"></a>");
                        SB.AppendLine("                                            </div>");
                    }



                    SB.AppendLine("                                        </div>");
                    SB.AppendLine("                                    </div>");
                    SB.AppendLine("                                </div>");
                    SB.AppendLine("                            </div>");
                }
            }

            if (WP.Text.IndexOf("<div class=\"wistia") > -1 && WP.Text.IndexOf("async></script>") > -1)
            {
                //WP.Text = WP.Text.ToString().Replace(WP.Text.Substring(WP.Text.IndexOf("<div class=\"wistia"), ((WP.Text.IndexOf("async></script>") + 15)) - WP.Text.IndexOf("<div class=\"wistia")), "");
                SB.AppendLine(WP.Text.ToString().Replace("^", "'").Replace(WP.Text.Substring(WP.Text.IndexOf("<div class=\"wistia"), ((WP.Text.IndexOf("async></script>") + 15)) - WP.Text.IndexOf("<div class=\"wistia")), ""));
            }
            else
            {
                SB.AppendLine(WP.Text.ToString().Replace("^", "'"));
            }

            if (WP.VideoId != null && WP.VideoId > 0)
            {
                var _video = db.Website_Videos.Where(x => x.id == WP.VideoId).FirstOrDefault();
                if (_video != null)
                {
                    SB.AppendLine(_video.VideoString);
                }
            }


            
            string strsubdept_newreferral = getsubdepartmentforclientreferral.getsubdept(WP);

            if (!string.IsNullOrEmpty(DD.contactstr1) && DD.Name != "Mental Health")
            {
                SB.AppendLine("<br /><div class=\"deptcontactus " + DD.cssclass + " lightkolor\"><span class=\"" + DD.cssclass + " forecolor\">For all " + DD.Name + " related matters contact us online now.</span><a  class=\"deptcontactus " + DD.cssclass + " kolor\" href=\"/Home/Contact/" + strsubdept_newreferral + "\">Contact Us</a></div><br />");
            }

            SB.AppendLine("                </div>");
            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");
            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");

            Contents = SB;
            filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\" + WP.Filename.ToString() + ".html";
            canonicaltag = "<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk" + filepath.Replace(ConfigurationManager.AppSettings["RootpathNewWebsite"], "").Replace("\\", "/") + "\">";

        }
    }

    public static class getsubdepartmentforclientreferral
    {
        public static string getsubdept(Website_Pages WP)
        {

            DLWEBEntities dbweb = new DLWEBEntities();
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            string dept = "";
            string subdept = "";
            if (!string.IsNullOrEmpty(WP.CustomSubDepartment))
            {
                if (!string.IsNullOrEmpty(WP.CustomDepartment))
                    dept = WP.CustomDepartment.Trim();
                else
                    dept = WP.Department;

                subdept = WP.CustomSubDepartment.Trim();
            }
            else
            {
                Website_Structure WS = new Website_Structure();
                if (dbit.Website_Structure.Where(x => x.linkedid == WP.ID && x.level != "Root").FirstOrDefault() != null)
                {
                    int LevelID = dbit.Website_Structure.Where(x => x.linkedid == WP.ID && x.level != "Root").Select(y => y.underwhichnode).FirstOrDefault() ?? 0;
                    WS = dbit.Website_Structure.Where(x => x.SubDepartment == true && x.id == LevelID).FirstOrDefault();
                }
                
                if (WS != null)
                {
                        dept = string.IsNullOrEmpty(WS.NewNameForDepartment) ? WS.dept.Trim() : WS.NewNameForDepartment.Trim();
                        subdept = string.IsNullOrEmpty(WS.NewNameForSubDepartment) ? WS.name.Trim() : WS.NewNameForSubDepartment.Trim();
                }
            }

            dept = dept.Replace("&", "and").Replace("\\", "-").Replace("/", "and");
            subdept = subdept.Replace("&", "and").Replace("\\", "-").Replace("/", "and");


            //dbweb.WebsitePagesSubDepartments.Add(new WebsitePagesSubDepartment { Dept = dept, SubDept = subdept, WebPageName = WP.Name });
            //dbweb.SaveChanges();

            string returnstr = "";
            if (!string.IsNullOrEmpty(dept))
            {

                returnstr = "?dept=" + dept;
                if (!string.IsNullOrEmpty(subdept))
                    returnstr = returnstr + "&subDepartment=" + subdept;

                return returnstr;
            }
            else
                return "";

        }
    }
}
