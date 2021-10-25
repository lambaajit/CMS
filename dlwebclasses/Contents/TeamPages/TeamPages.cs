using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace dlwebclasses
{
    public class TeamPages
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }
        public TeamPages(string Dept)
        {

            string Name = "";
            string Jobtitle = "";
            string Office = "";
            string Solicitor = "";
            string Caseworker = "";
            string partner = "";
            string Solicitormisspic = "";
            string Caseworkermisspic = "";
            string partnermisspic = "";
            string[] deptstr;

            DepartmentDetails DD = new DepartmentDetails(Dept);
            Title = DD.Name + " Team | " + DD.Name + " Solicitors | " + DD.Name + " Lawyers | Duncan Lewis " + DD.Name + " Team";
            Description = DD.Name + " Team, " + DD.Name + " Solicitors, " + DD.Name + " Lawyers, Duncan Lewis " + DD.Name + " Team";
            Keywords = DD.Name + " Team, " + DD.Name + " Solicitors, " + DD.Name + " Lawyers, Duncan Lewis " + DD.Name + " Team";
            Department = DD.Name;
            HeadingH1 = DD.Name + " Solicitors";
            filepath = ConfigurationManager.AppSettings["Rootpath"].ToString() + "\\" + DD.Our_Team1;
            if (DD.Name == "Child Care" || DD.Name == "Family")
                deptstr = new string[] {"Family","Child Care"};
            else
                deptstr = new string[] { DD.Name };

            HRDDLEntities db = new HRDDLEntities();

            List<Emp_Details> ED = new List<Emp_Details>();
            IEnumerable<Emp_Details> ED1;
            ED1 = allStatic.getcurrentemployedstafflist();
            
            if (DD.Name != "Management Board")
                ED = ED1.Where(x => ((deptstr.Contains(x.department_it)) || (deptstr.Contains(x.department_covered_2)) || (deptstr.Contains(x.department_covered_3)) || (deptstr.Contains(x.department_covered_4)) || (deptstr.Contains(x.department_covered_5))) && x.Profile_website == true && x.admin_staff == "0").OrderByDescending(x => x.Picture_website).ThenBy(x => x.forename).ToList();
            else
                ED = ED1.Where(x => ((x.jobtitle.Contains("Director") && (x.forename + ' ' + x.surname) != "Ibrahim Daud Ali" && (x.Profile_website == true) && (x.admin_staff == "0")) || ((deptstr.Contains(x.department_it)) || (deptstr.Contains(x.department_covered_2)) || (deptstr.Contains(x.department_covered_3)) || (deptstr.Contains(x.department_covered_4)) || (deptstr.Contains(x.department_covered_5))))).OrderByDescending(x => x.forename == "Syed Talha").ThenByDescending(x => x.forename == "Shany").ThenByDescending(x => x.forename == "Nina").ThenByDescending(x => x.forename == "Sridhar").ThenByDescending(x => x.forename == "Jason").ThenByDescending(x => x.forename == "Mohan").ThenByDescending(x => x.forename + ' ' + x.surname == "David Daud").ThenByDescending(x => x.forename == "Judith").ThenBy(x => x.forename).ToList();

            
                        //CommandText = "select P.[Emp_Code], forename+' '+surname as Name, [Emp_Status] as Emp_Status, Department_IT,Isnull(department_covered_2,'') as areacovered11,Isnull(department_covered_3,'') as areacovered21, Department_IT as Department , O.Office_name as Office, Case when forename + ' ' + Surname = 'Geoffrey Yeung' then 'Partner' when p.jobtitle like '%High Court Advocate%' then 'High Court Advocate' when p.[Emp_Status] in ('Freelance Consultant','Limited Company') then 'Freelance Consultant'   when p.jobtitle like '%Partner%' then 'Partner' when p.jobtitle like '%Director%' then 'Partner' when p.forename + ' ' + Surname like 'BusinessDevelopmentManager' then 'Partner' when p.jobtitle like '%Director%' then 'Partner' when p.jobtitle like '%Paralegal%' then 'Caseworker' when p.jobtitle like '%Caseworker%' then 'Caseworker' when p.jobtitle like '%Legal Consultant%' then 'Caseworker' when p.jobtitle like '%Clerk%' then 'Caseworker' when p.jobtitle like '%Trainee%' then 'Trainee Solicitor' when p.jobtitle = 'In-House Counsel' then 'Solicitor' when p.jobtitle like '%Supervisor%' then 'Solicitor' when p.jobtitle like '%Solicitor%' then 'Solicitor' when p.jobtitle like '%Head of Department%' then 'Solicitor' when p.jobtitle like '%Manager%' then 'Senior Manager' else ' ' End as JobTitle, isnull(P.Email,'  ' ) as Email, direct_dial_tel_number as ddi,case when p.jobtitle like '%Head of Department%' then 'Yes' else 'No' End HOD, isnull(O.County,'') as County,Forename,Surname from hrd.[emp_Details] P , Emp_ITInfo E, Offices O where P.Office_Code = O.Office_Code and P.[Emp_Code] = E.emp_Code and  [employed] ='1' and ([start_date] <= GETDATE()) AND ([end_date] > GETDATE() OR [end_date] IS NULL OR [end_date] = '01/01/1900') AND ([Employed] = '1') and ([Admin_Staff] <> '1' or forename + ' ' + Surname = 'Geoffrey Yeung') and Department_IT Not In ('Office Administration','Cost Drafting', 'Information Technology','Finance','Marketing','Human Resources')  and (Department_IT = '" + Arraydept(i, 0) + "' or department_covered_2 = '" + Arraydept(i, 0) + "' or department_covered_3 = '" + Arraydept(i, 0) + "'  or department_covered_4 = '" + Arraydept(i, 0) + "'  or department_covered_5 = '" + Arraydept(i, 0) + "' " + famCC + ") and forename+' '+surname not in ('Fozia Iqbal','Andrew Egby','Rumana Kausar','Paresh Joshi','Charlotte Ecroyd','Reena Matharu','Ian Hawkings','Munsoor Ahmed Chaudhry','Isma Moghal','Sulaiha Ali','Sumitra Rao') ORDER BY Forename + ' ' + Surname";
            foreach (Emp_Details _ed in ED)
            {
                Name = _ed.forename + ' ' + _ed.surname;
                Jobtitle = allStatic.filterjobtitle(_ed);
                Office = _ed.Office.office_name.Replace("Dalston","Hackney");

                string name1 = "";
                if (Name.Length > 16)
                {
                    name1 = _ed.forename.ToString().Substring(0, 1) + " " + _ed.surname.ToString();
                    if (name1.Length > 16)
                        name1 = name1.Substring(0, 16).ToString();
                }
                else
                    name1 = Name;

                bool picmiss = false;
                string rewriteurllink = "";
                if (_ed.forename + ' ' + _ed.surname == "Syed Talha Rafique" || _ed.forename + ' ' + _ed.surname == "Shany Gupta" || _ed.forename + ' ' + _ed.surname == "Nina Joshi" || _ed.forename + ' ' + _ed.surname == "Sridhar Ponnada" || _ed.forename + ' ' + _ed.surname == "Jason Bruce" || _ed.forename + ' ' + _ed.surname == "Mohan Bharj" || _ed.forename + ' ' + _ed.surname == "David Daud" || _ed.forename + ' ' + _ed.surname == "Judith Lee-Scott")
                    rewriteurllink = "http://www.duncanlewis.co.uk/about_managementboard/" + (_ed.forename + ' ' + _ed.surname).ToString().Replace(" ", "_") + ".html";
                else
                     rewriteurllink = allStatic.getRewriteUrlLinkForStaff(_ed) + "/";

                string photostr;
                if (File.Exists("C:\\Inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised\\Photos\\StaffPics\\" + Name + ".jpg") && _ed.Picture_website == true)
                {
                    photostr = "http://www.duncanlewis.co.uk/Photos/Staffpics/" + Name + ".jpg";
                }
                else
                {
                    picmiss = true;
                    photostr = "http://www.duncanlewis.co.uk/Photos/Staffpics/missing.jpg";
                }

                photostr = "<p><a href=\"" + rewriteurllink + "\"><img src=\"" + photostr + "\" alt=\"" + Name + "\" width=\"125\" height=\"137\" class=\"thumb_img\"  /></a></p>";


                string hodstring = "";
                if (_ed.jobtitle.Contains("Head of Department") == true)
                    hodstring = " - HOD";

                if ((Jobtitle == "Solicitor" || Jobtitle == "Freelance Consultant") && (DD.Name != "Management Board"))
                {
                    if (picmiss == true)
                        Solicitormisspic = Solicitormisspic + "<div class=\"col-sm-4 col-xs-6 nopadding\"><h4><a href=\"" + rewriteurllink + "\">" + name1 + "</a></h4><p>" + Office + hodstring + "</p>" + photostr + "<p>&nbsp;</p></div>";
                    else
                        Solicitor = Solicitor + "<div class=\"col-sm-4 col-xs-6 nopadding\"><h4><a href=\"" + rewriteurllink + "\">" + name1 + "</a></h4><p>" + Office + hodstring + "</p>" + photostr + "<p>&nbsp;</p></div>";
                }
                else if (Jobtitle == "Caseworker" || Jobtitle == "Trainee Solicitor")
                {
                    if (picmiss == true)
                        Caseworkermisspic = Caseworkermisspic + "<div class=\"col-sm-4 col-xs-6 nopadding\"><h4><a href=\"" + rewriteurllink + "\">" + name1 + "</a></h4><p>" + Office + "</p>" + photostr + "<p>&nbsp;</p></div>";
                    else
                        Caseworker = Caseworker + "<div class=\"col-sm-4 col-xs-6 nopadding\"><h4><a href=\"" + rewriteurllink + "\">" + name1 + "</a></h4><p>" + Office + "</p>" + photostr + "<p>&nbsp;</p></div>";
                }
                else if (Jobtitle == "Partner" || (DD.Name == "Management Board"))
                {
                    if (Name == "Judith Lee-Scott" && DD.Name == "Management Board")
                    {
                        partner = partner + "<div class=\"col-sm-8 col-xs-6 nopadding\"><h4><a href=\"" + rewriteurllink + "\">" + name1 + "</a></h4><p>" + Office + "</p>" + photostr + "<p>&nbsp;</p></div>";
                    }
                    else
                    {
                        partner = partner + "<div class=\"col-sm-4 col-xs-6 nopadding\"><h4><a href=\"" + rewriteurllink + "\">" + name1 + "</a></h4><p>" + Office + "</p>" + photostr + "<p>&nbsp;</p></div>";
                    }
                }
            }



            StringBuilder SB = new StringBuilder();
            SB.AppendLine("    <div id=\"breadcrumb\" class=\"visible-lg visible-md visible-sm\">");
            SB.AppendLine("      <p><a href=\"index.html\">Home</a> | <a href=\"" + DD.Overview1 + "\">" + DD.Name + "</a> | Our Team </p>");
            SB.AppendLine("    </div>");



            SB.AppendLine("    <div class=\"container-fluid\">    ");
            SB.AppendLine("        <div class=\"row\">");
            SB.AppendLine("<div class=\"col-lg-12 nopadding\">");

            if (!string.IsNullOrEmpty(partner))
            {
                SB.AppendLine("    <div class=\"container-fluid\">    ");
                SB.AppendLine("        <div class=\"row\">");
                SB.AppendLine("    <div class=\"container-fluid\">    ");
                SB.AppendLine("        <div class=\"row\" style=\"border-bottom:Solid 10px #74d1f6;\">");
                SB.AppendLine("            <div class=\"col-lg-4 col-sm-4 col-md-4 hidden-xs\">");
                SB.AppendLine("            &nbsp;");
                SB.AppendLine("            </div>");
                SB.AppendLine("            <div id=\"staff_nav\" class=\"col-lg-8 col-sm-8 col-md-8 col-xs-12\">");
                if (DD.Name == "Management Board")
                    SB.AppendLine("                  <h3>Board of Directors</h3>");
                else
                    SB.AppendLine("                  <h3>Directors</h3>");
                SB.AppendLine("            </div>");
                SB.AppendLine("        </div>");
                SB.AppendLine("        </div>    ");


                SB.AppendLine("    <div id=\"maincontent_team\" class=\"col-xs-12 nopadding\">");
                SB.AppendLine(partner);
                SB.AppendLine("    </div>");
                SB.AppendLine("    </div> ");
                SB.AppendLine("    </div> ");
            }


            if (!string.IsNullOrEmpty(Solicitor))
            {
                SB.AppendLine("    <div class=\"container-fluid\">    ");
                SB.AppendLine("        <div class=\"row\">");
                SB.AppendLine("    <div class=\"container-fluid\">    ");
                SB.AppendLine("        <div class=\"row\" style=\"border-bottom:Solid 10px #74d1f6;\">");
                SB.AppendLine("            <div class=\"col-lg-4 col-sm-4 col-md-4 hidden-xs\">");
                SB.AppendLine("            &nbsp;");
                SB.AppendLine("            </div>");
                SB.AppendLine("            <div id=\"staff_nav\" class=\"col-lg-8 col-sm-8 col-md-8 col-xs-12\">");
                SB.AppendLine("      <h3>Solicitors &amp; Lawyers</h3>");
                SB.AppendLine("            </div>");
                SB.AppendLine("        </div>");
                SB.AppendLine("        </div>    ");


                SB.AppendLine("    <div id=\"maincontent_team\" class=\"col-xs-12 nopadding\">");
                SB.AppendLine(Solicitor);
                SB.AppendLine(Solicitormisspic);
                SB.AppendLine("    </div>");

                SB.AppendLine("    </div> ");
                SB.AppendLine("    </div> ");
            }



            if (!string.IsNullOrEmpty(Caseworker))
            {
                SB.AppendLine("    <div class=\"container-fluid\">    ");
                SB.AppendLine("        <div class=\"row\">");
                SB.AppendLine("    <div class=\"container-fluid\">    ");
                SB.AppendLine("        <div class=\"row\" style=\"border-bottom:Solid 10px #74d1f6;\">");
                SB.AppendLine("            <div class=\"col-lg-4 col-sm-4 col-md-4 hidden-xs\">");
                SB.AppendLine("            &nbsp;");
                SB.AppendLine("            </div>");
                SB.AppendLine("            <div id=\"staff_nav\" class=\"col-lg-8 col-sm-8 col-md-8 col-xs-12\">");
                SB.AppendLine("                  <h3>Caseworkers</h3>");
                SB.AppendLine("            </div>");
                SB.AppendLine("        </div>");
                SB.AppendLine("        </div>    ");

                SB.AppendLine("    <div id=\"maincontent_team\" class=\"col-xs-12 nopadding\">");
                SB.AppendLine(Caseworker);
                SB.AppendLine(Caseworkermisspic);
                SB.AppendLine("    </div>");
                SB.AppendLine("    </div> ");
                SB.AppendLine("    </div> ");
            }

            SB.AppendLine("    </div> ");
            SB.AppendLine("    </div> ");
            SB.AppendLine("    </div> ");

            Contents = SB;
        }
    }
}
