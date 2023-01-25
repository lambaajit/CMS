using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Jobs_Pages_NewWebsite
    {
         private int id;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public string filepath { get; set; }
        public StringBuilder Contents { get; set; }

        public Jobs_Pages_NewWebsite(AContents _Acontent, int ID)
        {
            id = ID;

            DepartmentDetails DD = new DepartmentDetails("Careers");
            DLWEBEntities dlweb = new DLWEBEntities();
            Recruitment_DlWeb recruitment = new Recruitment_DlWeb();
            recruitment = dlweb.Recruitment_DlWeb.Where(x => x.Job_Ref_Code == id).FirstOrDefault();

            string title = "";
            if (recruitment.Job_Type == "Freeleance")
            {
                if (recruitment.Job_Title.ToString().Contains("Criminal Duty") == true || recruitment.Job_Title.ToString().Contains("Prison Law"))
                {
                    title = "Job Reference:" + recruitment.Job_Ref_Code;
                }
                else
                {
                    title = "Job Reference:" + recruitment.Job_Ref_Code;
                }
            }
            else
            {
                title = "Job Reference:" + recruitment.Job_Ref_Code;
            }

            string description = "";
            if (recruitment.Job_Type == "Freeleance")
            {
                if (recruitment.Job_Title.ToString().Contains("Criminal Duty") == true || recruitment.Job_Title.ToString().Contains("Prison Law"))
                {
                    description = "Job Ref:" + recruitment.Job_Ref_Code + " " + recruitment.Job_Title.ToString()+ ", jobs, vacancies, crime jobs " + recruitment.Location.ToString() + "";
                }
                else
                {
                    description = "Job Ref:" + recruitment.Job_Ref_Code + " " + recruitment.Department.ToString()+ " solicitor jobs, " + recruitment.Location.ToString()+ ", fee share consultants, consultancy";
                }
            }
            else
            {
                description = "Job Ref:" + recruitment.Job_Ref_Code + " " + recruitment.Job_Title.ToString()+ " | Job Vacancy | Duncan Lewis Solicitors | " + recruitment.Location.ToString();
            }

            string keywords = "";
            if (!string.IsNullOrEmpty(recruitment.Keywords))
            {
                keywords = recruitment.Keywords.ToString();
            }
            else
            {
                if (recruitment.Job_Type == "Freeleance")
                {
                    if (recruitment.Job_Title.ToString().Contains("Criminal Duty") == true)
                    {
                        keywords = "crime duty solicitors, CLAS, criminal duty solicitor consultants, criminal solicitor jobs, crime lawyer jobs, " + recruitment.Location.ToString();
                    }
                    else if (recruitment.Job_Title.ToString().Contains("Prison Law"))
                    {
                        keywords = "prison lawyer jobs, prison solicitor jobs, vacancies, prison law solicitor consultants, prison law vacancies, " + recruitment.Location.ToString();
                    }
                    else
                    {
                        keywords = recruitment.Department.ToString()+ " solicitor jobs, vacancies, " + recruitment.Location.ToString()+ ", Fee share consultants, Consultancy, Consultant solicitors, Vacancies, Duncan Lewis";
                    }
                }
                else
                {
                    keywords = recruitment.Department + " solicitor job, " + recruitment.Department + " solicitor jobs , vacancies, " + recruitment.Department + " solicitor vacancies, Jobs in  " + recruitment.Location + ", Jobs Duncan Lewis, Vacancies at Duncan Lewis, Consultancy vacancies at Duncan Lewis, Training contract, Trainee solicitor jobs, Apprenticeship vacancies, Internship work experience,  " + recruitment.Department + " jobs  " + recruitment.Location + "";
                }
            }
            keywords = keywords + ", London, West Midlands, East Midlands, Kent, Hertfordshire, Bedfordshire, Surrey, Buckinghamshire, Wales, Northamptonshire, Nottinghamshire, Avon";

            
                

            string heading= "";
            if (recruitment.Job_Type != "Freeleance") {
	            heading = recruitment.Department.ToString() + " Jobs, Vacancies";
            } else {
	            if (recruitment.Job_Title.ToString().Contains("Criminal Duty") == true || recruitment.Job_Title.ToString().Contains("Prison Law")) {
		            heading = recruitment.Department.ToString().Replace("Consultants", "") + " " + recruitment.Location.ToString();
	            } else {
		            heading = recruitment.Department.ToString() + " Solicitors Jobs " + recruitment.Location.ToString();
	            }
            }

            string fpath = "";
            if (recruitment.Job_Type == "Freeleance") {
                fpath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Jobs\\" + recruitment.Job_Title.Replace("|", " ").Replace(",", " ").Replace("^", "'").Replace("*", "").Replace("/", "-").Replace(" ", "-").Replace("(", "").Replace(")", "").Replace("&", "-") + ".html";
            } else {
                fpath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Jobs\\" + recruitment.Job_Title.Replace("|", " ").Replace(",", " ").Replace("^", "'").Replace("*", "").Replace("/", "-").Replace(" ", "-").Replace("(", "").Replace(")", "").Replace("&", "-") + recruitment.Job_Ref_Code + ".html";
            }

            Title =title;
            Description =description;
            Keywords =keywords;
            HeadingH1 = heading;
            filepath = fpath;
            Department = "Careers";

            if (recruitment.MetaDescription != null && recruitment.MetaDescription.Length > 5)
                Description = "Job Ref:" + recruitment.Job_Ref_Code + " " + recruitment.MetaDescription;

            if (recruitment.MetaKeywords != null && recruitment.MetaKeywords.Length > 5)
                Keywords = recruitment.MetaKeywords;

            //if (recruitment.MetaTitle != null && recruitment.MetaTitle.Length > 5)
            //    Title = recruitment.MetaTitle;




            IT_DatabaseEntities dbit = new IT_DatabaseEntities();

            int depmenuvar = 0;
            if (recruitment.Job_Type == "Freelance")
                depmenuvar = 3;
            else if (dbit.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").Select(y => y.Name).ToList().Contains(recruitment.Department) == true)
                depmenuvar = 2;
            else
                depmenuvar = 1;


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
            SB.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Employee-Reward-and-Benefits.html\">Rewards<span class=\"fa fa-suitcase\"></span></a>");
            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");
            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");


            SB.AppendLine("<div class=\"row deptreverseband " + DD.cssclass + " lightkolor  nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            SB.AppendLine("        <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-9 col-xs-12 col-lg-offset-3 breadcrumbs\">");

            SB.AppendLine("       <p><a  class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\">Home</a><span class=\"fa fa-angle-double-right\"></span><a class=\"" + DD.cssclass + " forecolor\" href=\"/Careers.html\"><p>Careers</a><span class=\"fa fa-angle-double-right\"></span>" + recruitment.Job_Title + " Vacancies" + "</p>");

            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");

            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");

            SB.AppendLine("<div class=\"" + DD.cssclass + " row nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            SB.AppendLine("        <div class=\"row\">");
            SB.AppendLine("            <div class=\"col-sm-3 col-xs-12\">");


            SB.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, 0, recruitment.Department ,depmenuvar).ToString());

            SB.AppendLine("            </div>");



            SB.AppendLine("<div class=\"col-sm-9 col-xs-12 jobdetails\">");
SB.AppendLine("                <div class=\"row\">");
SB.AppendLine("                    <div class=\"col-xs-12\">");
SB.AppendLine("                        <h4><a class=\"dept_default forecolor\" href=\"#\">" + recruitment.Job_Title.Replace("^", "'") + "</a></h4>");
SB.AppendLine("                    </div>");
SB.AppendLine("                    </div>");
SB.AppendLine("                    <div class=\"row\">");
SB.AppendLine("                        <div class=\"col-sm-8\">");
SB.AppendLine("                            <h5>Job Description:</h5>");
            if (recruitment.Job_Type != "Freeleance")
                SB.AppendLine(recruitment.Job_Description.Replace("***", "</p><h6>").Replace("**", "</h6><p>").Replace("*is*", "<i>").Replace("*ie*", "</i>").Replace("*bis*", "<b><i>").Replace("*bie*", "</b></i>").Replace(Environment.NewLine, "<br />").Replace("*bs*", "<strong>").Replace("*be*", "</strong>").Replace("*bullets*", "<ul>").Replace("*bullete*", "</ul>").Replace("*-s*", "<li>").Replace("*-e*", "</li>"));
            else
                SB.AppendLine(recruitment.Job_Description.ToString().Replace("<h4>","<h5>").Replace("</h4>","</h5>") + "<p>&nbsp;</p><h4><p>For more information on our Consultancy Model, please call Mr David Daud (Director of Operations) in confidence on:-</p><p>&nbsp;</p><p>Direct Telephone Number: 0203 114 1242 </p><p>Mobile Number:	07725 823 000 or</p><p>E-Mail: davidd@duncanlewis.com</p></h4>");

            if (!string.IsNullOrEmpty(recruitment.Key_Skills_Required) && recruitment.Key_Skills_Required != "NA" && recruitment.Job_Type != "Freeleance")
            {
                SB.AppendLine("                            <h5>Key Skills Required:</h5>");
                SB.AppendLine(recruitment.Key_Skills_Required.Replace("***", "</p><h6>").Replace("**", "</h6><p>").Replace("*is*", "<i>").Replace("*ie*", "</i>").Replace("*bis*", "<b><i>").Replace("*bie*", "</b></i>").Replace(Environment.NewLine, "<br />").Replace("*bs*", "<strong>").Replace("*be*", "</strong>").Replace("*bullets*", "<ul>").Replace("*bullete*", "</ul>").Replace("*-s*", "<li>").Replace("*-e*", "</li>"));
            }


SB.AppendLine("                            <a style=\"font-size:20px\" class=\"btn btn-primary\" href=\"/Home/Apply/" + recruitment.Job_Ref_Code + "\">Apply Online<span style=\"float:right; margin-right:10px\" class=\"fa fa-hand-o-up\"></span></a>");
SB.AppendLine("                        </div>");
SB.AppendLine("                        <div class=\"col-sm-4\">");
SB.AppendLine("                            <table class=\"table table-responsive table-hover table-bordered\">");
SB.AppendLine("                                <tr><th colspan=\"2\">Job Details<span class=\"fa fa-caret-down\"></span></th></tr>");
SB.AppendLine("                 <tr><td><span class=\"fa fa-building\"></span>Location:</td><td><b>" + recruitment.Location + "</b></td></tr>");
SB.AppendLine("                                <tr><td><span class=\"fa fa-certificate\"></span>Department: </td><td><b>" + recruitment.Department + "</b></td></tr>");
SB.AppendLine("                                <tr><td><span class=\"fa fa-money\"></span>Salary:</td><td> <b>" + recruitment.Salary + "</b></td></tr>");
SB.AppendLine("                                <tr><td><span class=\"fa fa-user-circle\"></span>Job Type:</td><td> <b>" + (recruitment.Job_Type == "Freeleance" ? "Consultancy" : "Permanent") + "</b></td></tr>");
SB.AppendLine("                                <tr><td><span class=\"fa fa-calendar\"></span>Date Posted:</td><td> <b>" + recruitment.Date_Posted.Date.ToShortDateString() + "</b></td></tr>");
SB.AppendLine("                                <tr><td><span class=\"fa fa-calendar\"></span>Last Date for Application:</td><td> <b>" + recruitment.Date_Posted.AddDays(21).Date.ToShortDateString() + "</b></td></tr>");
            if (!string.IsNullOrEmpty(recruitment.FIlename) && recruitment.FIlename.Contains("."))
            {
                SB.AppendLine("                                <tr><td colspan=\"2\"><a style=\"margin:0px !important\" class=\"btn btn-primary\" href=\"/JobDescriptionDocuments/" + recruitment.Job_Ref_Code + ".pdf\" target=\"_blank\"><i class=\"fa fa-file\" style=\"margin-right:10px\"></i>View Job Description</td></tr>");
            }
            SB.AppendLine("                                <tr><td colspan=\"2\">");
SB.AppendLine("                                    <b>Disclaimer</b><br /><br />");
SB.AppendLine("                                    <p>We are the fastest growing firm of Solicitors, with offices across London and the UK. We deal in a wide range of legal services that caters for clients on a public funding or private fee basis. Duncan Lewis is privileged to have several franchises from the Legal Aid Agency.");
SB.AppendLine("                                    <br /><br />");
SB.AppendLine("                                    We look to recruit dedicated and talented employees in both legal and non-legal capacities, and we are always interested to receive applications from quality candidates, whether experienced or novice. If you can demonstrate a strong commitment to the areas of law provided by the firm, and you are keen to build a career with us, please click here to apply online with your details and CV.");
SB.AppendLine("                                    <br /><br />");
SB.AppendLine("                                    Duncan Lewis is committed to Equal Opportunities and embraces diversity of its staff. The Company strives to ensure that our staff reflects the diversity of the communities we serve, which is reflective at all levels within our workforce.");
SB.AppendLine("                                    We guarantee an interview for candidates that disclose a disability and meet the essential requirements for the post. Please provide additional details in your covering letter, if this applies.</p></td></tr>");
SB.AppendLine("                            </table>");
SB.AppendLine("                        </div>");


            SB.AppendLine("                </div>");
            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");
            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");

            Contents = SB;


        }
    }
}
