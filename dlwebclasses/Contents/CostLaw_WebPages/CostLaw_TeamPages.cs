using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class CostLaw_TeamPages
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }
        public string canonicaltag { get; set; }

        public CostLaw_TeamPages(AContents _Acontent)
        {
            Title = "Cost Draftsperson | Cost Lawyer | Team";
            Description = "Meet our team dealing with billing, cost drafting";
            Keywords = "Cost Draftsperson, Cost Lawyer, Team";
            HeadingH1 =  "Cost Lawyres";
            filepath = ConfigurationManager.AppSettings["RootpathCostLawWebsite"].ToString() + "\\our-people.html";
            canonicaltag = "https://www.costlaw.com/our-people.html";
            HRDDLEntities dbhr = new HRDDLEntities();
            

            StringBuilder SB = new StringBuilder();

            SB.AppendLine(getwebbanner.getwebbanners().ToString());


            SB.AppendLine("<div class=\"row nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-12\">");
            SB.AppendLine("        <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-8 col-sm-offset-2 applyblock centerdiv teampage\">");
            SB.AppendLine("                <h1>Our Team</h1>");

            string jtitle = "";
            string jtitle1 = "";
            string jtitle2 = "";
            string heading = "";

            List<string> excludednames = new List<string>() {"Ajit Lamba", "Lubna Chauhan", "Ritu Sharma", "Robert Poulter", "Sangita Shah","Sonal Ruparelia", "Nina Joshi"  };
            for (int j = 1; j <= 7; j++)
            {
                if (j == 1)
                {
                    jtitle = "Manager";
                    jtitle1 = "Director";
                    heading = "Management";
                }
                else if (j == 2)
                {
                    jtitle = "Development Manager";
                    jtitle1 = "Assistant Manager";
                    jtitle2 = "Legal Aid Manager";
                    heading = "Assistant Managers &amp; HR";
                }
                else if (j == 3)
                {
                    jtitle = "Lawyer";
                    jtitle1 = "Manager";
                    jtitle2 = "Solicitor";
                    heading = "Costs Lawyers";
                }
                else if (j == 4)
                {
                    jtitle = "Senior";
                    jtitle1 = "Executive";
                    heading = "Senior Law Costs Draftspersonss";
                }
                else if (j == 5)
                {
                    jtitle = "Junior";
                    jtitle1 = "Trainee";
                    heading = "Law Costs Draftsman";
                }
                else if (j == 6)
                {
                    jtitle = "Draftsman";
                    jtitle1 = "Draftsman";
                    heading = "Trainee Costs Lawyers & Junior Law Costs Draftspersons";
                }
                else if (j == 7)
                {
                    jtitle = "Controlled Work";
                    jtitle1 = "exceptional";
                    heading = "Controlled Work Team";
                }
                List<Emp_Details> employeelist = new List<Emp_Details>();

                DateTime emptydate = Convert.ToDateTime("01/01/1900");

                if (j == 1)
                    employeelist = dbhr.Emp_Details.Where(x => x.forename +  " " + x.surname == "Yllka Olly Sufi" || x.forename + " " + x.surname == "Arvin Bharj" && excludednames.Contains(x.forename + " " + x.surname) == false && x.Profile_website == true).ToList();
                else if (j == 2)
                    employeelist = dbhr.Emp_Details.Where(x => x.employed == "1" && x.Profile_website == true && x.start_date < DateTime.Now && excludednames.Contains(x.forename + " " + x.surname) == false && (x.end_date == null || x.end_date > DateTime.Now || x.end_date.Value.ToString().Contains("1900")) && (x.jobtitle.Contains(jtitle) || x.jobtitle.Contains(jtitle1) || x.jobtitle.Contains(jtitle2)) && (x.company_name == "Cost Law Services Limited" || x.company_name == "Cost Law Limited" || x.cls_intranet_access == true)).OrderBy(y => y.forename).ToList();
                else if (j == 3)
                    employeelist = dbhr.Emp_Details.Where(x => x.employed == "1" && x.Profile_website == true && x.start_date < DateTime.Now && excludednames.Contains(x.forename + " " + x.surname) == false && (x.end_date == null || x.end_date > DateTime.Now || x.end_date.Value.ToString().Contains("1900")) && (x.jobtitle.Contains(jtitle) || x.jobtitle.Contains(jtitle1) || x.jobtitle.Contains(jtitle2)) && (x.company_name == "Cost Law Services Limited" || x.company_name == "Cost Law Limited" || x.cls_intranet_access == true) && !x.jobtitle.Contains("Junior") == true && !x.jobtitle.Contains("Trainee") == true && !x.jobtitle.Contains("Controlled Work") && !x.jobtitle.Contains("exceptional") && !x.jobtitle.Contains("Manager")).OrderBy(y => y.forename).ToList();
                else if (j == 4)
                    employeelist = dbhr.Emp_Details.Where(x => x.employed == "1" && x.Profile_website == true && x.start_date < DateTime.Now && excludednames.Contains(x.forename + " " + x.surname) == false && (x.end_date == null || x.end_date > DateTime.Now || x.end_date.Value.ToString().Contains("1900")) && (x.jobtitle.Contains(jtitle) || x.jobtitle.Contains(jtitle1)) && (x.company_name == "Cost Law Services Limited" || x.company_name == "Cost Law Limited" || x.cls_intranet_access == true) && !x.jobtitle.Contains("Controlled Work") && !x.jobtitle.Contains("exceptional") && !x.jobtitle.Contains("Manager")).OrderBy(y => y.forename).ToList();
                else if (j == 5)
                    employeelist = dbhr.Emp_Details.Where(x => x.employed == "1" && x.Profile_website == true && x.start_date < DateTime.Now && excludednames.Contains(x.forename + " " + x.surname) == false && (x.end_date == null || x.end_date > DateTime.Now || x.end_date.Value.ToString().Contains("1900")) && (x.jobtitle.Contains("Junior") == false && x.jobtitle.Contains("Trainee") == false && x.jobtitle.Contains("Director") == false && x.jobtitle.Contains("Manager") == false && x.jobtitle.Contains("Senior") == false && x.jobtitle.Contains("Executive") == false && x.jobtitle.Contains("Lawyer") == false && x.jobtitle.Contains("Solicitor") == false && x.jobtitle.Contains("HR Generalist") == false) && (x.company_name == "Cost Law Services Limited" || x.company_name == "Cost Law Limited" || x.cls_intranet_access == true) && !x.jobtitle.Contains("Controlled Work") && !x.jobtitle.Contains("exceptional")).OrderBy(y => y.forename).ToList();
                else if (j == 6)
                    employeelist = dbhr.Emp_Details.Where(x => x.employed == "1" && x.Profile_website == true && x.start_date < DateTime.Now && excludednames.Contains(x.forename + " " + x.surname) == false && (x.end_date == null || x.end_date > DateTime.Now || x.end_date.Value.ToString().Contains("1900")) && (x.jobtitle.Contains("Junior") == true || x.jobtitle.Contains("Trainee") == true) && (x.company_name == "Cost Law Services Limited" || x.company_name == "Cost Law Limited") && !x.jobtitle.Contains("Controlled Work") && !x.jobtitle.Contains("exceptional")).OrderBy(y => y.forename).ToList();
                else if (j == 7)
                    employeelist = dbhr.Emp_Details.Where(x => x.employed == "1" && x.Profile_website == true && x.start_date < DateTime.Now && excludednames.Contains(x.forename + " " + x.surname) == false && (x.end_date == null || x.end_date > DateTime.Now || x.end_date.Value.ToString().Contains("1900")) && (x.jobtitle.Contains(jtitle) || x.jobtitle.Contains(jtitle1)) && (x.company_name == "Cost Law Services Limited" || x.company_name == "Cost Law Limited" || x.cls_intranet_access == true)).OrderByDescending(y => y.forename).ToList();

                SB.AppendLine("                <h2><i class=\"fa fa-user\">&nbsp;</i>" + heading + ":</h2>");
                SB.AppendLine("                <div class=\"row nopadding\">");

                int i = 1;
                foreach (var emp in employeelist.Where(x => x.Profile_website == true))
                {
                    if (emp.emp_code == "GirdziusR")
                    {
                        string der = "";
                    }
                    

                    SB.AppendLine("                    <div class=\"col-sm-6\">");
                    SB.AppendLine("                        <div class=\"profilebox\">");
                    //SB.AppendLine("                            <img src=\"/staffpics/" + emp.forename + " " + emp.surname + ".png\" />");
                    if (System.IO.File.Exists("C:\\inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\Photos\\StaffPics\\" + emp.forename + " " + emp.surname + ".png"))
                        SB.AppendLine("                            <img src=\"/StaffPics/" + emp.forename + " " + emp.surname + ".png\" alt=\"" + emp.forename + " " + emp.surname + "is a Cost Lawyers/Cost Draftsperson at Cost Law Services working in " + emp.Office.office_name + " office\" />");
                    else
                        SB.AppendLine("                            <img src=\"/StaffPics/missing.png\" alt=\"" + emp.forename + " " + emp.surname + "is a Cost Lawyers/Cost Draftsperson at Cost Law Services working in " + emp.Office.office_name + " office\" />");

                    SB.AppendLine("                            <div class=\"profileboxbuttons\">");
                    SB.AppendLine("                                <a href=\"/Profiles/" + emp.forename.Replace(" ","-") + "-" + emp.surname.Replace(" ", "-") + ".html\" class=\"btn btn-primary\"><i class=\"fa fa-user\"></i><span>Profile</span></a>");
                    SB.AppendLine("                                <a href=\"mailto:" + (emp.email ?? emp.forename + "." + emp.surname + "@costlaw.com") + "\" class=\"btn btn-primary\"><i class=\"fa fa-at\"></i><span>Email</span></a>");
                    SB.AppendLine("                                <a href=\"tel:" + emp.direct_dial_tel_number + "\" class=\"btn btn-primary\"><i class=\"fa fa-phone\"></i><span>Call</span></a>");
                    SB.AppendLine("                            </div>");
                    SB.AppendLine("                            <div class=\"profileboxsub\">");
                    SB.AppendLine("                                <span class=\"staffname\">" + emp.forename + " " + emp.surname.Replace("Graham","") + " </span><span class=\"jobtitle\">" + (emp.forename == "Yllka Olly" ? "Solicitor/Costs Manager" : emp.jobtitle.Replace("Manager and Supervisor","Manager/Supervisor")) + "</span>");
                    SB.AppendLine("                            </div>");
                    SB.AppendLine("                        </div>");
                    SB.AppendLine("                    </div>");

                    if (i % 2 == 0)
                    {
                        SB.AppendLine("                </div>");
                        SB.AppendLine("                <div class=\"row nopadding\">");
                    }
                    i++;
                }

                SB.AppendLine("                </div>");
            }


            SB.AppendLine("                </div>");
            SB.AppendLine("                </div>");
            SB.AppendLine("                </div>");
            SB.AppendLine("                </div>");

            Contents = SB;
        }
        
    }
}
