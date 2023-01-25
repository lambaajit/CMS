using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class AlphabeticalTeamPage_NewWebsite
    {
                public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }

        public AlphabeticalTeamPage_NewWebsite(char Alphabet, AContents _Acontent)
        {
            Title = Alphabet + " Duncan Lewis Team starting with Letter " + Alphabet;
            Description = "Duncan Lewis Team starting with Letter " + Alphabet;
            Keywords = "Solicitor, Solicitor in London, legal aid solicitor, lawyers, specialist solicitor, solicitors speaking a language, solicitor profiles, solicitor in London, solicitor in Birmingham, solicitor in Cardiff, solicitor in Leicester, Legal Help, Solicitors in Middlesex, UK Solicitors, solicitors at Duncan Lewis, directors at Duncan Lewis, staff at Duncan Lewis, Legal 500 solicitors, Chambers listed solicitors, solicitor panel members, law society accredited solicitors";
            Department = "About Us";
            HeadingH1 = "Our Team";
            filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Our_Team_Alphabetic_" + Alphabet + ".html";
            string Name = "";
            string Jobtitle = "";
            string Office = "";


            HRDDLEntities db = new HRDDLEntities();

            List<Emp_Details> ED = new List<Emp_Details>();
            IEnumerable<Emp_Details> ED1;
            ED1 = allStatic.getcurrentemployedstafflist();
            List<string> WDS= new List<String>();
            IT_DatabaseEntities db1 = new IT_DatabaseEntities();
            WDS = db1.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").Select(x => x.Name).ToList();
            ED = ED1.Where(x => (x.forename.StartsWith(Alphabet.ToString())) && x.Profile_website == true && x.surname != "Mouse" && x.surname != "Duck" && WDS.Contains(x.department_it) && x.admin_staff == "0" && (x.reporting_consultant == false || x.reporting_consultant == null)).OrderBy(x => x.forename).ToList();
            StringBuilder SB = new StringBuilder();
            StringBuilder Staff = new StringBuilder();
            StringBuilder StaffMissing = new StringBuilder();

            int backimgloop = 1;
            foreach (Emp_Details _ed in ED)
            {
                Name = _ed.forename + ' ' + _ed.surname;
                Jobtitle = allStatic.filterjobtitle(_ed);
                Office = _ed.Office.office_name.Replace("Dalston", "Hackney");

                string name1 = "";
                if (Name == "Raja Rajeswaran Uruthiravinayagan")
                    name1 = "Raja Uruthiravinayagan";
                else
                    name1 = Name;

                bool picmiss = false;
                string rewriteurllink = "";
                if (_ed.forename + ' ' + _ed.surname == "Syed Talha Rafique" || _ed.forename + ' ' + _ed.surname == "Shany Gupta" || _ed.forename + ' ' + _ed.surname == "Nina Joshi" || _ed.forename + ' ' + _ed.surname == "Sridhar Ponnada" || _ed.forename + ' ' + _ed.surname == "Jason Bruce" || _ed.forename + ' ' + _ed.surname == "Mohan Bharj" || _ed.forename + ' ' + _ed.surname == "David Daud" || _ed.forename + ' ' + _ed.surname == "Judith Lee-Scott")
                    rewriteurllink = "http://www.duncanlewis.co.uk/about_managementboard/" + (_ed.forename + ' ' + _ed.surname).ToString().Replace(" ", "_") + ".html";
                else
                    rewriteurllink = allStatic.getRewriteUrlLinkForStaff(_ed) + "/";

                string photostr;
                if (File.Exists("C:\\Inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\Photos\\StaffPics\\" + Name + ".png") && _ed.Picture_website == true)
                {
                    if (_ed.email == "SimranKa@duncanlewis.com")
                        photostr = "/Photos/Staffpics/KaurS20220713110928.png";
                    else
                        photostr = "/Photos/Staffpics/" + Name + ".png";
                }
                else if (_ed.gender == "M")
                {
                    picmiss = true;
                    photostr = "/Photos/Staffpics/missingM.png";
                }
                else
                {
                    picmiss = true;
                    photostr = "/Photos/Staffpics/missingF.png";
                }

                //photostr = "<p><a href=\"" + rewriteurllink + "\"><img src=\"" + photostr + "\" alt=\"" + Name + "\" width=\"125\" height=\"137\" class=\"thumb_img\"  /></a></p>";


                string hodstring = "";
                if (_ed.jobtitle.Contains("Head of Department") == true)
                    hodstring = " - HOD";
                else if (_ed.jobtitle.Contains("Chartered"))
                    Jobtitle = "Chartered Legal Executive";


                if (picmiss == true)
                        StaffMissing.AppendLine("<div class=\"col-sm-4 col-xs-6 nopadding\"><div class=\"teampagepanel teampagepanelM" + backimgloop.ToString() + " dept_default lightkolor deptbordercolor forecolor\"><a href=\"" + rewriteurllink + "\"><img src=\"" + photostr + "\" class=\"img-responsive\" alt=\"" + name1 +  "\" /></a><p  class=\" dept_default lightkolor\">" + name1 + "<span>" + Jobtitle + "<br />Office: " + Office + "<br /><br /><a class=\"btm btn-primary dept_default kolor overlight deptbordercolor\" href=\"mailto:" + _ed.email + "\"><span>@</span>Send Email</a><a class=\"btm btn-primary dept_default kolor overlight deptbordercolor\" href=\"tel:" + _ed.direct_dial_tel_number + "\"><span class=\"fa fa-phone\"></span>Call</a><a class=\"btm btn-primary dept_default kolor overlight deptbordercolor\" href=\"" + rewriteurllink + "\"><span class=\"fa fa-user\"></span>View Details</a></span></p></div></div>");
                    else
                        Staff.AppendLine("<div class=\"col-sm-4 col-xs-6 nopadding\"><div class=\"teampagepanel teampagepanelM" + backimgloop.ToString() + "  dept_default lightkolor deptbordercolor forecolor\"><a href=\"" + rewriteurllink + "\"><img src=\"" + photostr + "\" class=\"img-responsive\" alt=\"" + name1 + "\" /></a><p class=\" dept_default lightkolor\">" + name1 + "<span>" + Jobtitle + "<br />Office: " + Office + "<br /><br /><a class=\"btm btn-primary dept_default kolor overlight deptbordercolor\" href=\"mailto:" + _ed.email + "\"><span>@</span>Send Email</a><a class=\"btm btn-primary dept_default kolor overlight deptbordercolor\" href=\"tel:" + _ed.direct_dial_tel_number + "\"><span class=\"fa fa-phone\"></span>Call</a><a class=\"btm btn-primary dept_default kolor overlight deptbordercolor\" href=\"" + rewriteurllink + "\"><span class=\"fa fa-user\"></span>View Details</a></span></p></div></div>");

                    backimgloop++;
                    if (backimgloop > 16)
                        backimgloop = 1;
                
            }


            DepartmentNavigationNewWebsite Deptnav = new DepartmentNavigationNewWebsite();

            StringBuilder _NewContent = new StringBuilder();

            _NewContent.AppendLine("<div class=\"row nopadding dept_default parentrowoffixedrow\">");
            _NewContent.AppendLine("    <div class=\"row nopadding dept_default kolor deptheading\" data-spy=\"affix\" data-offset-top=\"100\">");
            _NewContent.AppendLine("        <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            _NewContent.AppendLine("            <h1>Alphabetic Team Listing</h1>");
            _NewContent.AppendLine("        </div>");
            _NewContent.AppendLine("    </div>");
            _NewContent.AppendLine("</div>");

            _NewContent.AppendLine("<div class=\"row nopadding\">");
            _NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-sm-offset-2 nopadding applyblock centerdiv\">");
            _NewContent.AppendLine("        <div class=\"row nopadding\">");
            _NewContent.AppendLine("            <div class=\"col-sm-8 col-xs-12 col-lg-offset-4 depttabs\" style=\"z-index:999\">");
            _NewContent.AppendLine("                <a class=\"dept_default forecolor lightkolor over\" href=\"/about_managementboard.html\">Management Team<span class=\"fa fa-users\"></span></a>");
            _NewContent.AppendLine("                <a class=\"dept_default forecolor lightkolor over\" href=\"/Our_Team_Alphabetic_A.html\">Alphabetic Team Listing<span class=\"fa fa fa-users\"></span></a>");
            _NewContent.AppendLine("                <a class=\"dept_default forecolor lightkolor over\" href=\"/Our_Team.html\">Teams by Department<span class=\"fa fa fa-users\"></span></a>");
            _NewContent.AppendLine("            </div>");
            _NewContent.AppendLine("        </div>");
            _NewContent.AppendLine("    </div>");
            _NewContent.AppendLine("</div>");

            _NewContent.AppendLine("<div class=\"row deptreverseband nopadding dept_default lightkolor\">");
            _NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            _NewContent.AppendLine("        <div class=\"row nopadding\">");
            _NewContent.AppendLine("            <div class=\"col-sm-9 col-xs-12 col-lg-offset-3 breadcrumbs\">");
            _NewContent.AppendLine("<p><a  class=\"dept_default forecolor\" href=\"/index.html\"><p>Home</a><span class=\"fa fa-angle-double-right\"></span><a  class=\"dept_default forecolor\" href=\"/Our_Team.html\"><p>Our Team</a><span class=\"fa fa-angle-double-right\"></span>Staff Listing (Alphabet - " + Alphabet + ")</p>");
            _NewContent.AppendLine("            </div>");
            _NewContent.AppendLine("        </div>");

            _NewContent.AppendLine("    </div>");
            _NewContent.AppendLine("</div>");

            _NewContent.AppendLine("<div class=\"row nopadding\">");
            _NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            _NewContent.AppendLine("        <div class=\"row\">");
            _NewContent.AppendLine("            <div class=\"col-sm-3 col-xs-12\">");

            _NewContent.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, 0, Alphabet.ToString()).ToString());

            _NewContent.AppendLine("            </div>");



            _NewContent.AppendLine("<div id=\"maincontent\" class=\"col-sm-9 col-xs-12\">");

            _NewContent.AppendLine("                <div class=\"row extramargin100\" id=\"StaffPanel\"><div class=\"col-sm-12 dept_default kolor forecolorlight teampageseparator\"><a class=\"dept_default forecolorlight\" href=\"#DirectorsPanel\" data-toggle=\"collapse\">Staff Listing (Alphabet - " + Alphabet + ")</a><span class=\"fa fa-caret-down\"></span></div></div>");

            _NewContent.AppendLine("                <div class=\"row collapse in\">");

            _NewContent.AppendLine("<div class=\"container\">");

            _NewContent.AppendLine(Staff.ToString());
            _NewContent.AppendLine(StaffMissing.ToString());

            _NewContent.AppendLine("                </div>");

            _NewContent.AppendLine("                </div>");

            _NewContent.AppendLine("                </div>");

            _NewContent.AppendLine("                </div>");
            _NewContent.AppendLine("                </div>");
            _NewContent.AppendLine("                </div>");

            Contents = _NewContent;




            filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\Our_Team_Alphabetic_" + Alphabet + ".html";
        }
    }
}
