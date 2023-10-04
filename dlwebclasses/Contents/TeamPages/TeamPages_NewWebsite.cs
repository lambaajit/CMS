using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class TeamPages_NewWebsite
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }
        public string canonicaltag { get; set; }
        public TeamPages_NewWebsite(string Dept, AContents _Acontent)
        {

            string Name = "";
            string Jobtitle = "";
            string Office = "";
            StringBuilder Solicitor =  new StringBuilder();
            StringBuilder Caseworker = new StringBuilder();
            StringBuilder partner = new StringBuilder();
            StringBuilder Trainee = new StringBuilder();
            StringBuilder Solicitormisspic = new StringBuilder();
            StringBuilder Caseworkermisspic = new StringBuilder();
            StringBuilder partnermisspic = new StringBuilder();
            StringBuilder Traineemisspic = new StringBuilder();
            string[] deptstr;

            DepartmentDetails DD = new DepartmentDetails(Dept);
            
            Title = DD.Name + " Solicitors | Team | Lawyers";
            Description = DD.Name + " Team, " + DD.Name + " Solicitors, " + DD.Name + " Lawyers, Duncan Lewis " + DD.Name + " Team";
            Keywords = DD.Name + " Team, " + DD.Name + " Solicitors, " + DD.Name + " Lawyers, Duncan Lewis " + DD.Name + " Team";
            Department = DD.Name;
            HeadingH1 = DD.Name + " Solicitors";
            filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\" + DD.Our_Team1;
            canonicaltag = "<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk" + filepath.Replace(ConfigurationManager.AppSettings["RootpathNewWebsite"], "").Replace("\\", "/") + "\">";

            if (DD.Name == "Child Care" || DD.Name == "Family")
                deptstr = new string[] {"Family","Child Care"};
            else
                deptstr = new string[] { DD.Name };

            HRDDLEntities db = new HRDDLEntities();
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();

            List<Emp_Details> ED = new List<Emp_Details>();
            IEnumerable<Emp_Details> ED1;
            ED1 = allStatic.getcurrentemployedstafflist();
            
            if (DD.Name != "Management Board")
                ED = ED1.Where(x => ((deptstr.Contains(x.department_it)) || (deptstr.Contains(x.department_covered_2)) || (deptstr.Contains(x.department_covered_3)) || (deptstr.Contains(x.department_covered_4)) || (deptstr.Contains(x.department_covered_5))) && x.surname != "Mouse" && x.surname != "Duck" &&  x.Profile_website == true && x.admin_staff == "0" && (x.reporting_consultant == false || x.reporting_consultant == null)).OrderByDescending(x => x.Picture_website).ThenBy(x => x.forename).ToList(); /*&& x.jobtitle != "Legal Casework Assistant"*/
            else
                ED = ED1.Where(x => x.Profile_website == true && ((x.jobtitle.Contains("Director") && (x.forename + ' ' + x.surname) != "Ibrahim Daud Ali" && (x.Profile_website == true) && (x.admin_staff == "0")) || ((deptstr.Contains(x.department_it)) || (deptstr.Contains(x.department_covered_2)) || (deptstr.Contains(x.department_covered_3)) || (deptstr.Contains(x.department_covered_4)) || (deptstr.Contains(x.department_covered_5))))).OrderByDescending(x => x.forename == "Syed Talha").ThenByDescending(x => x.forename == "Shany").ThenByDescending(x => x.forename == "Nina").ThenByDescending(x => x.forename == "Sridhar").ThenByDescending(x => x.forename == "Jason").ThenByDescending(x => x.forename == "Mohan").ThenByDescending(x => x.forename + ' ' + x.surname == "David Daud").ThenByDescending(x => x.forename == "Judith").ThenBy(x => x.forename).ToList();

            
                        //CommandText = "select P.[Emp_Code], forename+' '+surname as Name, [Emp_Status] as Emp_Status, Department_IT,Isnull(department_covered_2,'') as areacovered11,Isnull(department_covered_3,'') as areacovered21, Department_IT as Department , O.Office_name as Office, Case when forename + ' ' + Surname = 'Geoffrey Yeung' then 'Partner' when p.jobtitle like '%High Court Advocate%' then 'High Court Advocate' when p.[Emp_Status] in ('Freelance Consultant','Limited Company') then 'Freelance Consultant'   when p.jobtitle like '%Partner%' then 'Partner' when p.jobtitle like '%Director%' then 'Partner' when p.forename + ' ' + Surname like 'BusinessDevelopmentManager' then 'Partner' when p.jobtitle like '%Director%' then 'Partner' when p.jobtitle like '%Paralegal%' then 'Caseworker' when p.jobtitle like '%Caseworker%' then 'Caseworker' when p.jobtitle like '%Legal Consultant%' then 'Caseworker' when p.jobtitle like '%Clerk%' then 'Caseworker' when p.jobtitle like '%Trainee%' then 'Trainee Solicitor' when p.jobtitle = 'In-House Counsel' then 'Solicitor' when p.jobtitle like '%Supervisor%' then 'Solicitor' when p.jobtitle like '%Solicitor%' then 'Solicitor' when p.jobtitle like '%Head of Department%' then 'Solicitor' when p.jobtitle like '%Manager%' then 'Senior Manager' else ' ' End as JobTitle, isnull(P.Email,'  ' ) as Email, direct_dial_tel_number as ddi,case when p.jobtitle like '%Head of Department%' then 'Yes' else 'No' End HOD, isnull(O.County,'') as County,Forename,Surname from hrd.[emp_Details] P , Emp_ITInfo E, Offices O where P.Office_Code = O.Office_Code and P.[Emp_Code] = E.emp_Code and  [employed] ='1' and ([start_date] <= GETDATE()) AND ([end_date] > GETDATE() OR [end_date] IS NULL OR [end_date] = '01/01/1900') AND ([Employed] = '1') and ([Admin_Staff] <> '1' or forename + ' ' + Surname = 'Geoffrey Yeung') and Department_IT Not In ('Office Administration','Cost Drafting', 'Information Technology','Finance','Marketing','Human Resources')  and (Department_IT = '" + Arraydept(i, 0) + "' or department_covered_2 = '" + Arraydept(i, 0) + "' or department_covered_3 = '" + Arraydept(i, 0) + "'  or department_covered_4 = '" + Arraydept(i, 0) + "'  or department_covered_5 = '" + Arraydept(i, 0) + "' " + famCC + ") and forename+' '+surname not in ('Fozia Iqbal','Andrew Egby','Rumana Kausar','Paresh Joshi','Charlotte Ecroyd','Reena Matharu','Ian Hawkings','Munsoor Ahmed Chaudhry','Isma Moghal','Sulaiha Ali','Sumitra Rao') ORDER BY Forename + ' ' + Surname";
            int backimgloop = 1;
            foreach (Emp_Details _ed in ED)
            {

                Name = _ed.forename + ' ' + _ed.surname;
                Jobtitle = allStatic.filterjobtitle(_ed);
                Office = _ed.Office.office_name.Replace("Dalston","Hackney");

                string name1 = "";
                //if (Name.Length > 16)
                //{
                //    name1 = _ed.forename.ToString().Substring(0, 1) + " " + _ed.surname.ToString();
                //    if (name1.Length > 16)
                //        name1 = name1.Substring(0, 16).ToString();
                //}
                //else

                if (Name == "Raja Rajeswaran Uruthiravinayagan")
                    name1 = "Raja Uruthiravinayagan";
                else if (Name == "Rajminder Mehat")
                    name1 = "Mindy Chall Mehat";
                else
                    name1 = Name;

                bool picmiss = false;
                string rewriteurllink = "";
                string managementpic = "";
                List<string> _subDepartments = dbit.SubDepartmentProfiles.GroupBy(x => x.SubDepartment).Select(x => x.Key).ToList();
                if (_ed.forename + ' ' + _ed.surname == "Syed Talha Rafique" || _ed.forename + ' ' + _ed.surname == "Shany Gupta" || _ed.forename + ' ' + _ed.surname == "Nina Joshi" || _ed.forename + ' ' + _ed.surname == "Sridhar Ponnada" || _ed.forename + ' ' + _ed.surname == "Jason Bruce" || _ed.forename + ' ' + _ed.surname == "Mohan Bharj" || _ed.forename + ' ' + _ed.surname == "David Daud" || _ed.forename + ' ' + _ed.surname == "Judith Lee-Scott")
                {
                    rewriteurllink = "/about_managementboard/" + (_ed.forename + ' ' + _ed.surname).ToString().Replace(" ", "_") + ".html";
                    managementpic = "1";
                }
                else if (_subDepartments.Contains(DD.Name))
                    rewriteurllink = "/" + DD.Name.Replace(" ", "-") + "_ourteam/" + _ed.forename + "_" + _ed.surname + ".html";
                else
                    rewriteurllink = "/" + allStatic.getRewriteUrlLinkForStaff(_ed) + "/#" + Department.Replace(" ", "");

                string photostr;
                if (File.Exists("C:\\Inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\Photos\\StaffPics\\" + Name + ".png") && _ed.Picture_website == true)
                {
                    if (_ed.email == "SimranKa@duncanlewis.com")
                        photostr = "/Photos/Staffpics/KaurS20220713110928.png";
                    else
                        photostr = "/Photos/Staffpics/" + Name + managementpic + ".png";
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
                    hodstring = "Head Of Department";
                else if (name1 == "Neil Sargeant")
                    hodstring = "Motoring Law Specialist";
                else if (_ed.jobtitle.Contains("Chartered"))
                    hodstring = "Chartered Legal Executive";
                else 
                    hodstring = "Solicitor";

                if ((Jobtitle == "Solicitor" || Jobtitle == "Freelance Consultant") && (DD.Name != "Management Board"))
                {
                    if (picmiss == true)
                        Solicitormisspic.AppendLine("<div class=\"col-sm-4 col-xs-6 nopadding\"><div class=\"teampagepanel teampagepanelM" + backimgloop.ToString() + " " + DD.cssclass + " lightkolor deptbordercolor forecolor\"><a href=\"" + rewriteurllink + "\"><img src=\"" + photostr + "\" class=\"img-responsive\" alt=\"" + _ed.forename + " " + _ed.surname + "\" /></a><p  class=\"" + DD.cssclass + " lightkolor\">" + name1 + "<span>" + hodstring + "<br />Office: " + Office + "<br /><br /><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"mailto:" + _ed.email + "\"><span>@</span>Send Email</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"tel:" + _ed.direct_dial_tel_number + "\"><span class=\"fa fa-phone\"></span>Call</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"" + rewriteurllink + "\"><span class=\"fa fa-user\"></span>View Details</a></span></p></div></div>");
                    else
                        Solicitor.AppendLine("<div class=\"col-sm-4 col-xs-6 nopadding\"><div class=\"teampagepanel teampagepanelM" + backimgloop.ToString() + "  " + DD.cssclass + " lightkolor deptbordercolor forecolor\"><a href=\"" + rewriteurllink + "\"><img src=\"" + photostr + "\" class=\"img-responsive\" alt=\"" + _ed.forename + " " + _ed.surname + "\" /></a><p class=\"" + DD.cssclass + " lightkolor\">" + name1 + "<span>" + hodstring + "<br />Office: " + Office + "<br /><br /><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"mailto:" + _ed.email + "\"><span>@</span>Send Email</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"tel:" + _ed.direct_dial_tel_number + "\"><span class=\"fa fa-phone\"></span>Call</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"" + rewriteurllink + "\"><span class=\"fa fa-user\"></span>View Details</a></span></p></div></div>");
                }
                else if (Jobtitle.Contains("Trainee"))
                {
                    if (picmiss == true)
                        Traineemisspic.AppendLine("<div class=\"col-sm-4 col-xs-6 nopadding\"><div class=\"teampagepanel teampagepanelM" + backimgloop.ToString() + " " + DD.cssclass + " lightkolor deptbordercolor forecolor\"><a href=\"" + rewriteurllink + "\"><img src=\"" + photostr + "\" class=\"img-responsive\" alt=\"" + _ed.forename + " " + _ed.surname + "\" /></a><p class=\"" + DD.cssclass + " lightkolor\">" + name1 + "<span>" + Jobtitle + "<br />Office: " + Office + "<br /><br /><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"mailto:" + _ed.email + "\"><span>@</span>Send Email</a><a class=\"btm btn-primary " + DD.cssclass + "y kolor overlight deptbordercolor\" href=\"tel:" + _ed.direct_dial_tel_number + "\"><span class=\"fa fa-phone\"></span>Call</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"" + rewriteurllink + "\"><span class=\"fa fa-user\"></span>View Details</a></span></p></div></div>");
                    else
                        Trainee.AppendLine("<div class=\"col-sm-4 col-xs-6 nopadding\"><div class=\"teampagepanel teampagepanelM" + backimgloop.ToString() + " " + DD.cssclass + " lightkolor deptbordercolor forecolor\"><a href=\"" + rewriteurllink + "\"><img src=\"" + photostr + "\" class=\"img-responsive\" alt=\"" + _ed.forename + " " + _ed.surname + "\" /></a><p class=\"" + DD.cssclass + " lightkolor\">" + name1 + "<span>" + Jobtitle + "<br />Office: " + Office + "<br /><br /><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"mailto:" + _ed.email + "\"><span>@</span>Send Email</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"tel:" + _ed.direct_dial_tel_number + "\"><span class=\"fa fa-phone\"></span>Call</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"" + rewriteurllink + "\"><span class=\"fa fa-user\"></span>View Details</a></span></p></div></div>");
                }
                else if (Jobtitle == "Caseworker")
                {
                    if (picmiss == true)
                        Caseworkermisspic.AppendLine("<div class=\"col-sm-4 col-xs-6 nopadding\"><div class=\"teampagepanel teampagepanelM" + backimgloop.ToString() + " " + DD.cssclass + " lightkolor deptbordercolor forecolor\"><a href=\"" + rewriteurllink + "\"><img src=\"" + photostr + "\" class=\"img-responsive\" alt=\"" + _ed.forename + " " + _ed.surname + "\" /></a><p class=\"" + DD.cssclass + " lightkolor\">" + name1 + "<span>" + Jobtitle + "<br />Office: " + Office + "<br /><br /><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"mailto:" + _ed.email + "\"><span>@</span>Send Email</a><a class=\"btm btn-primary " + DD.cssclass + "y kolor overlight deptbordercolor\" href=\"tel:" + _ed.direct_dial_tel_number + "\"><span class=\"fa fa-phone\"></span>Call</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"" + rewriteurllink + "\"><span class=\"fa fa-user\"></span>View Details</a></span></p></div></div>");
                    else
                        Caseworker.AppendLine("<div class=\"col-sm-4 col-xs-6 nopadding\"><div class=\"teampagepanel teampagepanelM" + backimgloop.ToString() + " " + DD.cssclass + " lightkolor deptbordercolor forecolor\"><a href=\"" + rewriteurllink + "\"><img src=\"" + photostr + "\" class=\"img-responsive\" alt=\"" + _ed.forename + " " + _ed.surname + "\" /></a><p class=\"" + DD.cssclass + " lightkolor\">" + name1 + "<span>" + Jobtitle + "<br />Office: " + Office + "<br /><br /><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"mailto:" + _ed.email + "\"><span>@</span>Send Email</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"tel:" + _ed.direct_dial_tel_number + "\"><span class=\"fa fa-phone\"></span>Call</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"" + rewriteurllink + "\"><span class=\"fa fa-user\"></span>View Details</a></span></p></div></div>");
                }
                else if (Jobtitle == "Partner" || (DD.Name == "Management Board"))
                {
                    string jtitle = "Director";
                    if (name1 == "Mohan Bharj")
                        jtitle = "CFO";
                    else if (name1 == "David Daud")
                        jtitle = "Operations Manager";

                        if (DD.Name == "Management Board")
                            partner.AppendLine("<div class=\"col-sm-3 col-xs-6 nopadding\"><div class=\"teampagepanel teampagepanelM" + backimgloop.ToString() + " " + DD.cssclass + " lightkolor deptbordercolor forecolor\"><a href=\"" + rewriteurllink + "\"><img src=\"" + photostr + "\" class=\"img-responsive\" alt=\"" + _ed.forename + " " + _ed.surname + "\" /></a><p class=\"" + DD.cssclass + " lightkolor\">" + name1 + "<span>" + jtitle + "<br />Office: " + Office + "<br /><br /><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"mailto:" + _ed.email + "\"><span>@</span>Send Email</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"tel:" + _ed.direct_dial_tel_number + "\"><span class=\"fa fa-phone\"></span>Call</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"" + rewriteurllink + "\"><span class=\"fa fa-user\"></span>View Details</a></span></p></div></div>");
                        else
                            partner.AppendLine("<div class=\"col-sm-4 col-xs-6 nopadding\"><div class=\"teampagepanel teampagepanelM" + backimgloop.ToString() + " " + DD.cssclass + " lightkolor deptbordercolor forecolor\"><a href=\"" + rewriteurllink + "\"><img src=\"" + photostr + "\" class=\"img-responsive\" alt=\"" + _ed.forename + " " + _ed.surname + "\" /></a><p class=\"" + DD.cssclass + " lightkolor\">" + name1 + "<span>" + jtitle + "<br />Office: " + Office + "<br /><br /><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"mailto:" + _ed.email + "\"><span>@</span>Send Email</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"tel:" + _ed.direct_dial_tel_number + "\"><span class=\"fa fa-phone\"></span>Call</a><a class=\"btm btn-primary " + DD.cssclass + " kolor overlight deptbordercolor\" href=\"" + rewriteurllink + "\"><span class=\"fa fa-user\"></span>View Details</a></span></p></div></div>");
                }
                backimgloop++;
                if (backimgloop > 16)
                    backimgloop = 1;
            }

            DepartmentNavigationNewWebsite Deptnav = new DepartmentNavigationNewWebsite();

            StringBuilder _NewContent = new StringBuilder();

            _NewContent.AppendLine("<div class=\"row nopadding " + DD.cssclass + " parentrowoffixedrow\">");
            _NewContent.AppendLine("    <div class=\"row nopadding " + DD.cssclass + " kolor deptheading\" data-spy=\"affix\" data-offset-top=\"100\">");
_NewContent.AppendLine("        <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
_NewContent.AppendLine("            <h1>" + (DD.Name != "Management Board" ? DD.Name + " Solicitors" : DD.Name) + "</h1>");
_NewContent.AppendLine("        </div>");
_NewContent.AppendLine("    </div>");
_NewContent.AppendLine("</div>");

_NewContent.AppendLine("<div class=\"row nopadding\">");
_NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-sm-offset-2 nopadding applyblock centerdiv\">");
_NewContent.AppendLine("        <div class=\"row nopadding\">");
_NewContent.AppendLine("            <div class=\"col-sm-12 col-md-7 col-xs-12 col-md-offset-5 depttabs\" style=\"z-index:999\">");
_NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.Our_Team1 + "\">Our Team<span class=\"fa fa-users\"></span></a>");
_NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.News1 + "\">News<span class=\"fa fa-newspaper-o\"></span></a>");
_NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.News1.Replace("news", "articles") + "\">Articles<span class=\"fa fa-book\"></span></a>");
_NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.Video + "\">Videos<span class=\"fa fa-video-camera\"></span></a>");
_NewContent.AppendLine("            </div>");
_NewContent.AppendLine("        </div>");
_NewContent.AppendLine("    </div>");
_NewContent.AppendLine("</div>");

_NewContent.AppendLine("<div class=\"row deptreverseband " + DD.cssclass + " lightkolor nopadding\">");
_NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
_NewContent.AppendLine("        <div class=\"row nopadding\">");
_NewContent.AppendLine("            <div class=\"col-sm-9 col-xs-12 col-sm-offset-3 breadcrumbs\">");
_NewContent.AppendLine("<p><a  class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\"><p>Home</a><span class=\"fa fa-angle-double-right\"></span><a  class=\"" + DD.cssclass + " forecolor\" href=\"/" + DD.Overview1 + "\"><p>Our Team</a><span class=\"fa fa-angle-double-right\"></span>" + DD.Name + " Team</p>");
_NewContent.AppendLine("            </div>");
_NewContent.AppendLine("        </div>");

_NewContent.AppendLine("    </div>");
_NewContent.AppendLine("</div>");

_NewContent.AppendLine("<div class=\"row nopadding\">");
_NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
_NewContent.AppendLine("        <div class=\"row nopadding\">");

if (DD.Name != "Management Board")
{
    _NewContent.AppendLine("            <div class=\"col-sm-3 col-xs-12 nopadding\">");

    _NewContent.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, 0).ToString());

    _NewContent.AppendLine("            </div>");
    _NewContent.AppendLine("<div class=\"col-sm-9 col-xs-12 nopadding\">");
}
else
{
    _NewContent.AppendLine("<div class=\"col-sm-12 col-xs-12 nopadding\">");
}



            if (ED.Count() > 20 && DD.Name != "Management Board")
            {
                _NewContent.AppendLine("                <nav class=\"affixh3teampage hidden-sm hidden-md hidden-xs " + DD.cssclass + " lightcolor\" data-spy=\"affix\" data-offset-top=\"210\">");
                _NewContent.AppendLine("                    <div class=\"collapse navbar-collapse\">");
                _NewContent.AppendLine("                        <h3 class=\"navbar-brand\">" + DD.Name + " Team</h3>");
                _NewContent.AppendLine("                        <ul class=\"nav navbar-nav\">");
                _NewContent.AppendLine("                            <li class=\"dept_Family deptbordercolor\"><a href=\"#DirectorsPanel\" class=\"" + DD.cssclass + " forecolor lightkolor over\">Directors<span class=\"fa fa-user-circle\"></span></a></li>");
                _NewContent.AppendLine("                            <li class=\"dept_Family deptbordercolor\"><a href=\"#SolicitorsPanel\" class=\"" + DD.cssclass + " forecolor lightkolor over\">Solicitors<span class=\"fa fa-graduation-cap\"></span></a></li>");
                _NewContent.AppendLine("                            <li style=\"border-right: solid 0px #000 !important;\"><a href=\"#CaseworkerPanel\" class=\"" + DD.cssclass + " forecolor lightkolor over\">Caseworker<span class=\"fa fa-suitcase\"></span></a></li>");
                _NewContent.AppendLine("                        </ul>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                </nav>");
            }


            if (partner.Length > 20)
            {
                _NewContent.AppendLine("                <div class=\"row extramargin100 nopadding\" id=\"DirectorsPanel\"><div class=\"col-sm-12 " + DD.cssclass + " kolor forecolorlight teampageseparator\"><a class=\"" + DD.cssclass + " forecolorlight\" href=\"#DirectorsPanel\" data-toggle=\"collapse\">Directors</a><span class=\"fa fa-caret-down\"></span></div></div>");
                _NewContent.AppendLine("                <div class=\"row nopadding collapse in\">");
                _NewContent.AppendLine("<div class=\"container\">");
                _NewContent.AppendLine(partner.ToString());
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                </div>");
            }

            if (Solicitor.Length > 20 || Solicitormisspic.Length > 20)
            {
                _NewContent.AppendLine("                <div class=\"row extramargin100 nopadding\" id=\"SolicitorsPanel\">");
                _NewContent.AppendLine("                    <div class=\"col-sm-12 teampageseparator " + DD.cssclass + " kolor forecolorlight\"><a class=\"" + DD.cssclass + " forecolorlight\" href=\"#SolicitorsPanel\" data-toggle=\"collapse\">Solicitors &amp; Lawyers</a><span class=\"fa fa-caret-down\"></span></div>");
                _NewContent.AppendLine("                </div>");

                _NewContent.AppendLine("                <div  class=\"row nopadding collapse in\">");
                _NewContent.AppendLine("<div class=\"container\">");
                _NewContent.AppendLine(Solicitor.ToString());
                _NewContent.AppendLine(Solicitormisspic.ToString());
                _NewContent.AppendLine("                    </div>");

                _NewContent.AppendLine("                </div>");
            }

            if (Trainee.Length > 20 || Traineemisspic.Length > 20)
            {
                _NewContent.AppendLine("                <div class=\"row extramargin100 nopadding\" id=\"CaseworkerPanel\">");
                _NewContent.AppendLine("                    <div class=\"col-sm-12 teampageseparator " + DD.cssclass + " kolor forecolorlight \"><a class=\"" + DD.cssclass + " forecolorlight\" href=\"#CaseworkerPanel\" data-toggle=\"collapse\">Trainee Solicitors &amp; Apprentice Solicitors</a><span class=\"fa fa-caret-down\"></span></div>");
                _NewContent.AppendLine("                </div>");

                _NewContent.AppendLine("                    <div class=\"row nopadding collapse in\">");
                _NewContent.AppendLine("<div class=\"container\">");
                _NewContent.AppendLine(Trainee.ToString());
                _NewContent.AppendLine(Traineemisspic.ToString());
                _NewContent.AppendLine("                    </div>");

                _NewContent.AppendLine("                    </div>");
            }

            if (Caseworker.Length > 20 || Caseworkermisspic.Length > 20)
            {
                _NewContent.AppendLine("                <div class=\"row extramargin100 nopadding\" id=\"CaseworkerPanel\">");
                _NewContent.AppendLine("                    <div class=\"col-sm-12 teampageseparator " + DD.cssclass + " kolor forecolorlight \"><a class=\"" + DD.cssclass + " forecolorlight\" href=\"#CaseworkerPanel\" data-toggle=\"collapse\">Caseworkers</a><span class=\"fa fa-caret-down\"></span></div>");
                _NewContent.AppendLine("                </div>");

                _NewContent.AppendLine("                    <div class=\"row nopadding collapse in\">");
                _NewContent.AppendLine("<div class=\"container\">");
                _NewContent.AppendLine(Caseworker.ToString());
                _NewContent.AppendLine(Caseworkermisspic.ToString());
                _NewContent.AppendLine("                    </div>");

                _NewContent.AppendLine("                    </div>");
            }
            _NewContent.AppendLine("                </div>");

            _NewContent.AppendLine("                </div>");
            _NewContent.AppendLine("                </div>");
            _NewContent.AppendLine("                </div>");

            Contents = _NewContent;
        }
    }
}
