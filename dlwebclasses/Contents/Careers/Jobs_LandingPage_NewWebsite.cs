using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Jobs_LandingPage_NewWebsite
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

        public Jobs_LandingPage_NewWebsite(AContents _Acontent, string dept, string category)
        {

            DepartmentDetails DD = new DepartmentDetails("Careers");
            DLWEBEntities dlweb = new DLWEBEntities();
            List<Recruitment_DlWeb> _Joblist = new List<Recruitment_DlWeb>();
            if (category == "AreaOfLaw")
            {
                _Joblist = dlweb.Recruitment_DlWeb.Where(x => x.Department == dept && x.Live == true).OrderByDescending(y => y.Job_Ref_Code).ToList();
            }
            else if (category == "Category")
            {
                if (dept == "Solicitor")
                {
                    _Joblist = dlweb.Recruitment_DlWeb.Where(x => (x.Job_Title.Contains("Solicitor") || x.Job_Title.Contains("Panel Member") || x.Job_Title.Contains("Director") || (x.Job_Title.Contains("Supervisor") && x.Job_Title.Contains("Billing") == false)) && x.Job_Title.Contains("Trainee") == false && x.Job_Title.Contains("Training Contract") == false && x.Job_Type != "Freeleance" && x.Live == true).OrderByDescending(y => y.Job_Ref_Code).ToList();
                }
                else if (dept == "Caseworker")
                {
                    _Joblist = dlweb.Recruitment_DlWeb.Where(x => (x.Job_Title.Contains("Paralegal") || x.Job_Title.Contains("Caseworker")) && x.Job_Title.Contains("Trainee") == false && x.Job_Title.Contains("Training Contract") == false && x.Live == true).OrderByDescending(y => y.Job_Ref_Code).ToList();
                }
                else if (dept == "Trainee")
                {
                    _Joblist = dlweb.Recruitment_DlWeb.Where(x => (x.Job_Title.Contains("Trainee") == true ||  x.Job_Title.Contains("Training Contract") == true) && x.Live == true).OrderByDescending(y => y.Job_Ref_Code).ToList();
                }
                else if (dept == "Admin")
                {
                    _Joblist = dlweb.Recruitment_DlWeb.Where(x => x.Department != "Cost Draftsman & Billing" && x.Job_Title.Contains("Solicitor") == false && x.Job_Title.Contains("Panel Member") == false && x.Job_Title.Contains("Director") == false && x.Job_Title.Contains("Caseworker") == false && x.Job_Title.Contains("Paralegal") == false && x.Job_Title.Contains("Trainee") == false && x.Job_Title.Contains("Training Contract") == false && x.Live == true).OrderByDescending(y => y.Job_Ref_Code).ToList();
                }
                else if (dept == "Cost Draftsman and Billing")
                {
                    _Joblist = dlweb.Recruitment_DlWeb.Where(x => x.Department == "Cost Draftsman and Billing" && x.Live == true).OrderByDescending(y => y.Job_Ref_Code).ToList();
                }
                else if (dept == "Apprenticeship")
                {
                    _Joblist = dlweb.Recruitment_DlWeb.Where(x => x.Department == "Apprenticeship" && x.Live == true).OrderByDescending(y => y.Job_Ref_Code).ToList();
                }
                else if (dept == "All")
                {
                    _Joblist = dlweb.Recruitment_DlWeb.Where(x => x.Live == true).OrderByDescending(y => y.Job_Ref_Code).ToList();
                }
            }
            else if (category == "Consultancy")
            {
                _Joblist = dlweb.Recruitment_DlWeb.Where(x => x.Job_Type == "Freeleance" && x.Live == true).OrderBy(y => y.Location).ToList();
            }


            HeadingH1 = dept + " Vacancies";
            Department = "Careers";
            if (category == "AreaOfLaw" || category == "Category")
                filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\Jobs_" + dept.Replace(" ", "-") + ".html";
            else if (category == "Consultancy")
                filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\Jobs_Consultancy.html";
            else
                filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\Jobs\\" + dept.Replace(" ", "-") + "-Jobs.html";


            canonicaltag = "<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk" + filepath.Replace(ConfigurationManager.AppSettings["RootpathNewWebsite"], "").Replace("\\", "/") + "\">";

            int depmenuvar = 0;
            //filepath
            if (category == "Category")
            {
                depmenuvar = 1;
                if (dept == "Solicitor")
                {
                    Title = "Solicitor Jobs | Solicitor Vacancies | Duncan Lewis";
                    Description = "Duncan Lewis Solicitor jobs, Solicitor vacancies, Child Care, Immigration, Family, Crime, Litigation jobs";
                    Keywords = "Duncan Lewis, Solicitor job, Solicitor vacancies, Solicitor’s role, Solicitor jobs, Immigration Solicitor jobs, Crime Solicitor jobs, Duty Solicitor Jobs, Child Care Solicitor jobs, Divorce Solicitor jobs, Family Solicitor jobs, Housing Solicitor jobs, Personal Injury Solicitor jobs, Child Abduction Solicitor jobs, Fraud Solicitor jobs, Prison Law Solicitor jobs, Mental Health Solicitor jobs, Panel Member Solicitor jobs, Immigration Lawyer jobs, Child care panel member jobs, Litigation Solicitor Jobs, Immigration Level 2 Solicitor jobs";
                    HeadingH1 = "Solicitor Vacancies";
                }
                else if (dept == "Caseworker")
                {
                    Title = "Caseworker Jobs | Paralegal Vacancies | Duncan Lewis | Trainees";
                    Description = "Duncan Lewis caseworker jobs, paralegal vacancies, Trainees, Child Care, Immigration, Family, Crime";
                    Keywords = "Duncan Lewis, Caseworker job, Caseworker vacancies, Caseworker role, Paralegal jobs, Paralegal vacancies, Paralegal roles, Paralegal job, Immigration caseworker jobs, Crime caseworker jobs, Child Care caseworker jobs, Divorce caseworker jobs, Family caseworker jobs, Family paralegal jobs, Housing caseworker jobs, Housing paralegal jobs, Personal Injury caseworker jobs, Personal injury paralegal jobs, Child Abduction caseworker jobs, Fraud caseworker jobs , Prison Law caseworker jobs, Mental Health caseworker jobs, Mental health paralegal jobs, Immigration paralegal jobs, Child care paralegal jobs, Litigation paralegal Jobs, Litigation caseworker jobs, Immigration Level 2 caseworker jobs, Immigration level 1 caseworker jobs";
                    HeadingH1 = "Caseworkers &amp; Paralegals Vacancies";
                }
                else if (dept == "Trainee")
                {
                    Title = "Trainee Jobs | Trainee Contracts | Duncan Lewis Jobs";
                    Description = "Duncan Lewis Trainee jobs, vacancies, Trainee Contracts";
                    Keywords = "Vacancy for Solicitor, Solicitor Jobs, Paralegal Jobs, Paralegal Vacancy, Legal Jobs, Jobs London, Vacancies, Paralegals, Caseworkers, Legal, Immigration Caseworkers, Immigrations Paralegal, Childcare Paralegals, Childcare Caseworkers, Crime Duty Solicitors, Mental Health Panel Members, children panel member job, child panel member jobs, childcare jobs, jobs Birmingham, jobs Leicester, jobs Cardiff, legal consultancy roles, consultant solicitor roles, legal consultancy, solicitor consultant jobs, part time solicitor jobs, immigration level 2 vacancies, immigration level 2 jobs, immigration level 1 jobs, trainee solicitor jobs, training contract applications, trainee solicitor vacancies, training contracts at law firms, legal internship, solicitor vacancies, lawyer vacancies, family panel member jobs, childcare solicitor jobs, legal costing jobs, cost lawyer jobs, legal cashier jobs, personal injury jobs, immigration solicitor jobs, crime solicitor vacancies, prison law solicitor jobs, dispute resolution solicitor Duncan Lewis";
                }
                else if (dept == "Admin")
                {
                    Title = "Administrative Jobs| Administrative Vacancies| Duncan Lewis";
                    Description = "Duncan Lewis administrative jobs, vacancies, Accounts, Costing, HR, IT, General Admin";
                    Keywords = "Duncan Lewis, Administrative job, Administrative vacancies, Administrative role, Administrative jobs, Legal cashier jobs, Legal cashier vacancies, HR assistant jobs, HR manager jobs, IT support jobs, Bookkeeping jobs, Accounts assistant jobs, Costing jobs, Billing assistants, Cost lawyer jobs, Solicitor jobs, Reception, Vacancy, Switchboard vacancy, Customer care Jobs, Trainee jobs, Apprenticeship jobs, Apprenticeship vacancies, Internship, Volunteering positions";
                }
                else if (dept == "Cost Draftsman and Billing")
                {
                    Title = "Cost Draftsman Jobs| Costs Lawyer Vacancies | Duncan Lewis";
                    Description = "Law Cost Draftsmen, Costs Lawyer Jobs, Vacancies for Legal Aid Billing, Inter partes, Private Client Billing, Duncan Lewis Solicitors";
                    Keywords = "Law Cost Draftsman Jobs & vacancies, Law Costs Draftsman Jobs & Vacancies, Costs Lawyer, Cost Lawyer, Legal Aid, Private Client billing, Inter partes Billing, Clinical negligence Billing, Personal Injury Billing, Jobs, Vacancies, Duncan Lewis";
                    HeadingH1 = "Costs Draftsman, Costs Lawyer & Legal Aid Billing Jobs & Vacancies";
                }
                else if (dept == "All")
                {
                    Title = "Solicitors Jobs| Caseworkers Vacancies | Duncan Lewis";
                    Description = "Duncan Lewis All Jobs and Vacancies";
                    Keywords = "Solicitors Jobs, Paralegal Vacancies, Duncan Lewis";
                    HeadingH1 = "All Jobs";
                }
                else if (dept == "Apprenticeship")
                {
                    Title = "Apprenticeship Jobs| Apprenticeship Vacancies | Duncan Lewis";
                    Description = "Duncan Lewis Apprenticeship Jobs and Vacancies";
                    Keywords = "Apprenticeship Jobs, Apprenticeship Vacancies, Duncan Lewis";
                    HeadingH1 = "Apprenticeship Roles";
                }
                else
                {
                    Title = dept + " Vacancies | Jobs | Duncan Lewis";
                    Description = "Duncan Lewis, " + dept + " Vacancies, " + dept + " Jobs, Solicitor Jobs, Paralegal Jobs, Training Contracts, Internship";
                    Keywords = "Duncan Lewis, " + dept + " Vacancies, " + dept + " Jobs, Solicitor Jobs, Paralegal Jobs, Training Contracts, Internship";
                    HeadingH1 = "Duncan Lewis, " + dept + " Jobs & Vacancies";
                }
            }
            else if (category == "AreaOfLaw")
            {
                depmenuvar = 2;
                Title = dept + " Vacancies | Jobs | Duncan Lewis";
                Description = "Duncan Lewis, " + dept + " Vacancies, " + dept + " Jobs, Solicitor Jobs, Paralegal Jobs, Training Contracts, Internship";
                Keywords = "Duncan Lewis, " + dept + " Vacancies, " + dept + " Jobs, Solicitor Jobs, Paralegal Jobs, Training Contracts, Internship";
            }
            else if (category == "Consultancy")
            {
                depmenuvar = 3;
                Title = dept + " Vacancies | Jobs | Duncan Lewis";
                Description = "Duncan Lewis, " + dept + " Solicitors Jobs";
                Keywords = "Duncan Lewis, " + dept + " Solicitors Jobs";
            }

            
            

            DepartmentNavigationNewWebsite Deptnav = new DepartmentNavigationNewWebsite();
            StringBuilder SB = new StringBuilder();

            SB.AppendLine("<div class=\"row nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            SB.AppendLine("        <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-xs-12 depttabs\">");
            SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Careers.html\">Careers<span class=\"fa fa-home\"></span></a>");
            SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Trainees.html\">Training Contracts<span class=\"fa fa-suitcase\"></span></a>");
            SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/JobsConsultancy.html\">Consultancy<span class=\"fa fa-suitcase\"></span></a>");
            SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/internship.html\">Volunteer<span class=\"fa fa-suitcase\"></span></a>");
            SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Apprenticeship.html\">Apprenticeship<span class=\"fa fa-suitcase\"></span></a>");
            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");
            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");


            SB.AppendLine("<div class=\"row deptreverseband " + DD.cssclass + " lightkolor  nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            SB.AppendLine("        <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-9 col-xs-12 col-lg-offset-3 breadcrumbs\">");

            SB.AppendLine("       <p><a  class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\">Home</a><span class=\"fa fa-angle-double-right\"></span><a class=\"" + DD.cssclass + " forecolor\" href=\"/Careers.html\"><p>Careers</a><span class=\"fa fa-angle-double-right\"></span>" + dept + " Vacancies" + "</p>");

            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");

            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");

            SB.AppendLine("<div class=\"" + DD.cssclass + " row nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            SB.AppendLine("        <div class=\"row\">");
            SB.AppendLine("            <div class=\"col-sm-3 col-xs-12\">");

            
            SB.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, 0, dept,depmenuvar).ToString());
            
            SB.AppendLine("            </div>");

            SB.AppendLine("            <div class=\"col-sm-9 col-xs-12\">");

            if (_Joblist.Count() == 0)
            {
                SB.AppendLine("                <div class=\"row\">");
                SB.AppendLine("                        <div class=\"col-xs-12 officescheduleblurb\">We do not have any Job listing for this department/Area of Law.</div>");
                SB.AppendLine("                </div>");
            }
            else
            {
                foreach (var item in _Joblist)
                {
                    //if (item.Job_Type == "Freeleance")
                    //    SB.AppendLine("<div id=\"headsheadingthumb\"><h4><a href=\"Jobs/" + item.Job_Title.Replace("^", "'").Replace("*", "").Replace("/", "-").Replace(" ", "-").Replace("(", "").Replace(")", "") + ".html\"" + ">" + item.Job_Title.ToString().Replace("/", " / ") + "</a><h4><p>&nbsp;</p>" + "<p>" + item.Job_Brief_Description.Replace(Environment.NewLine, "<br>").Replace("^", "'") + "</br></br>      <p style=\"float:right;\"><a href=\"Jobs/" + item.Job_Title.Replace("^", "'").Replace("*", "").Replace("/", "-").Replace(" ", "-") + ".html\"" + ">Click here for full Job Description</a></p></div>");
                    //else
                    string link = "";
                    if (item.Job_Type == "Freeleance")
                    {
                        link = "/Jobs/" + item.Job_Title.Replace("|", " ").Replace(",", " ").Replace("^", "'").Replace("*", "").Replace("/", "-").Replace(" ", "-").Replace("(", "").Replace(")", "").Replace("&", "-") + ".html";
                    }
                    else
                    {
                        link = "/Jobs/" + item.Job_Title.Replace("|", " ").Replace(",", " ").Replace("^", "'").Replace("*", "").Replace("/", "-").Replace(" ", "-").Replace("(", "").Replace(")", "").Replace("&", "-") + item.Job_Ref_Code + ".html";
                    }

                    string JobBriefDescription = "<b>Location: </b>" + item.Location + "<br />";
                    JobBriefDescription = JobBriefDescription + "<b>Department: </b>" + item.Department + "<br />";
                    JobBriefDescription = JobBriefDescription + "<b>Last Date to Submit Application: </b>" + item.Date_Posted.AddDays(21).ToShortDateString();
                    //SB.AppendLine("<div id=\"headsheadingthumb\"><h4><a href=\"Jobs/" + item.Job_Title.Replace("^", "'").Replace("*", "").Replace("/", "-").Replace(" ", "-").Replace("(", "").Replace(")", "") + item.Job_Ref_Code + ".html\"" + ">" + item.Job_Title.ToString().Replace("/", " / ") + "</a><h4><p>&nbsp;</p>" + "<p>" + (item.Job_Brief_Description.Replace(Environment.NewLine, "<br>")).Replace("^", "'") + "</br></br>      <p style=\"float:right;\"><a href=\"Jobs/" + item.Job_Title.Replace("^", "'").Replace("*", "").Replace("/", "-").Replace(" ", "-") + item.Job_Ref_Code + ".html\"" + ">Click here for full Job Description</a></p></div>");
                    SB.AppendLine("<div class=\"row joblistings " + DD.cssclass + " deptbordercolor\"><div class=\"col-xs-12\"><h4><a class=\"" + DD.cssclass + " forecolor\" href=\"" + link + "\">" + item.Job_Title.ToString().Replace("/", " / ") + "</a></h4><p>" + JobBriefDescription + "</p><span><a href=\"" + link + "\">Click here for full Job Description</a></span></div></div>");
                }
            }

            if (!string.IsNullOrEmpty(DD.contactstr1))
            {
                SB.AppendLine("<br /><div class=\"deptcontactus " + DD.cssclass + " lightkolor\"><span class=\"" + DD.cssclass + " forecolor\">For all legal matter contact us now.</span><a  class=\"deptcontactus " + DD.cssclass + " kolor\" href=\"http://www.duncanlewis.co.uk/contactUs.aspx?dept=" + DD.contactstr1 + "\">Contact Us</a></div><br />");
            }

            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");
            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");

            Contents = SB;




            
       
        }

    }
}
