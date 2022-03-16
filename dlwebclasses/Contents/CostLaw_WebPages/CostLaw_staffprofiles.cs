using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class CostLaw_staffprofiles
    {
        private HRDDLEntities db = new HRDDLEntities();
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }
        public string canonicaltag { get; set; }

        public CostLaw_staffprofiles(string staffcode)
        {
            Emp_Details _emp_Details = new Emp_Details();
            Emp_ITInfo _emp_ITDetails = new Emp_ITInfo();
            Emp_Profile _emp_Profile = new Emp_Profile();
            _emp_Details = db.Emp_Details.Where(x => x.emp_code == staffcode).FirstOrDefault();

            Title = _emp_Details.forename + " " + _emp_Details.surname + " | Law Costs Draftsperson | Cost Law Services";
            Description = _emp_Details.forename + " " + _emp_Details.surname + ", Specialist Cost Draftsperson at Cost Law Services";
            Keywords = _emp_Details.forename + " " + _emp_Details.surname + ", Cost Draftsperson , " + "Cost Law Services";

            HeadingH1 = _emp_Details.forename + " " + _emp_Details.surname;
            filepath = ConfigurationManager.AppSettings["RootpathCostLawWebsite"].ToString() + "\\Profiles\\" + _emp_Details.forename.Replace(" ","-") + "-" + _emp_Details.surname.Replace(" ", "-") + ".html";
            canonicaltag = "https://www.costlaw.com/" + "Profiles/" + _emp_Details.forename.Replace(" ", "-") + "-" + _emp_Details.surname.Replace(" ", "-") + ".html";
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();

            StringBuilder SB = new StringBuilder();

            SB.AppendLine("<div class=\"row nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-12\">");
            SB.AppendLine("        <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-8 col-sm-offset-2 applyblock centerdiv\">");

            SB.AppendLine("                <div class=\"staffpage\">");
            SB.AppendLine("                    <div class=\"staffpagename\">");
            SB.AppendLine("                        <h1>" + _emp_Details.forename + " " + _emp_Details.surname + "</h1>");
            SB.AppendLine("                        <h2>" + (_emp_Details.forename == "Yllka Olly" ? "Solicitor<br />Costs Manager" : _emp_Details.jobtitle) + "</h2>");
            SB.AppendLine("                    </div>");

            if (System.IO.File.Exists("C:\\inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\Photos\\StaffPics\\" + _emp_Details.forename + " " + _emp_Details.surname + ".png"))
                SB.AppendLine("                    <img src=\"/StaffPics/" + _emp_Details.forename + " " + _emp_Details.surname + ".png\" alt=\"" + _emp_Details.forename + " " + _emp_Details.surname + "is a Cost Lawyers/Cost Draftsmen at Cost Law Services working in " + _emp_Details.Office.office_name + " office\" />");
            else
                SB.AppendLine("                            <img src=\"/StaffPics/missing.png\" alt=\"" + _emp_Details.forename + " " + _emp_Details.surname + "is a Cost Lawyers/Cost Draftsmen at Cost Law Services working in " + _emp_Details.Office.office_name + " office\" />");

            SB.AppendLine("                </div>");
            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");
            string jobtitle1 = _emp_Details.jobtitle;
            if (jobtitle1.Contains("Manager") || jobtitle1.Contains("Director"))
                jobtitle1 = "Manager";
            else if (jobtitle1.Contains("Lawyer"))
                jobtitle1 = "Costs Lawyers";
            else if (jobtitle1.Contains("Senior") || jobtitle1.Contains("Executive"))
                jobtitle1 = "Senior Costs Draftsperson";
            else if (jobtitle1.Contains("Junior") || jobtitle1.Contains("Trainee"))
                jobtitle1 = "Junior Costs Draftsperson";
            else
                jobtitle1 = "Law Costs Draftsperson";

            SB.AppendLine("        <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-8 col-sm-offset-2 applyblock centerdiv\">");
            SB.AppendLine("                <div class=\"row nopadding\">");
            SB.AppendLine("                    <div class=\"col-sm-3 staffpagedetails\">");
            SB.AppendLine("                        <table class=\"table table-responsive\">");
            SB.AppendLine("                            <tr><th>Contact Details<i class=\"fa fa-angle-down\"></i></th></tr>");
            SB.AppendLine("                            <tr>");
            SB.AppendLine("                                <td><i class=\"fa fa-certificate\"></i><a href=\"#\">" + (_emp_Details.forename == "Yllka Olly" ? "Solicitor / Costs Manager" : jobtitle1 ) + "</a></td>");
            SB.AppendLine("                            </tr>");
            SB.AppendLine("                            <tr>");
            SB.AppendLine("                                <td><i class=\"fa fa-phone\"></i><a href=\"tel:"+ _emp_Details.direct_dial_tel_number + "\">" + _emp_Details.direct_dial_tel_number + "</a></td>");
            SB.AppendLine("                            </tr>");
            SB.AppendLine("                            <tr>");
            SB.AppendLine("                                <td><i class=\"fa fa-at\"></i><a href=\"mailto:" + (_emp_Details.email ?? _emp_Details.forename + "." + _emp_Details.surname + "@costlaw.com") + "\">Email</a></td>");
            SB.AppendLine("                            </tr>");
            SB.AppendLine("                            <tr>");
            SB.AppendLine("                                <td><i class=\"fa fa-building\"></i><a href=\"#\">" +db.Offices.Where(x => x.office_code == _emp_Details.office_code).Select(y => y.office_name).FirstOrDefault() + "</a></td>");
            SB.AppendLine("                            </tr>");
            SB.AppendLine("                        </table>");
            SB.AppendLine("                    </div>");

            User_Profile_FinalDraft UP = new User_Profile_FinalDraft();

            if (_emp_Details.emp_code == "SufiY")
                UP = dbit.User_Profile_FinalDraft.Where(x => x.Emp_code == "OllySufi").FirstOrDefault();
            else
                UP = dbit.User_Profile_FinalDraft.Where(x => x.Emp_code == _emp_Details.emp_code).FirstOrDefault();


            SB.AppendLine("                    <div class=\"col-sm-9\">");
            SB.AppendLine("                        <div class=\"profile\">");
            
            SB.AppendLine("                            <h2>");
            SB.AppendLine("                                Profile");
            SB.AppendLine("                            </h2>");
            if (UP != null)
            {
                SB.AppendLine(UP.Profile.Replace(Environment.NewLine, "<br />"));
                if (UP.Profile2 != null && UP.Profile2.Length > 10)
                    SB.AppendLine("<br />" + UP.Profile.Replace(Environment.NewLine, "<br />"));

                if (UP.Education_Status == "Yes")
                {
                    SB.AppendLine("                        <h3>Education</h3>");
                    SB.AppendLine(UP.Education.Replace(Environment.NewLine, "<br />"));
                }
                if (UP.Career_Status == "Yes")
                {
                    SB.AppendLine("                        <h3>Career</h3>");
                    SB.AppendLine(UP.Career.Replace(Environment.NewLine, "<br />"));
                }
                if (UP.Client_Comments_Status == "Yes")
                {
                    SB.AppendLine("                        <h3>Testimonials</h3>");
                    SB.AppendLine(UP.Client_Comments.Replace(Environment.NewLine, "<br />"));
                }
                if (UP.Supreme_Court_Status == "Yes" || UP.Court_of_Appeal_Status == "Yes" || UP.High_Court_Status == "Yes" || UP.Criminal_Court_Status == "Yes" || UP.Civil_Court_Status == "Yes" || UP.Other_Supreme_Court_Status == "Yes" || UP.Other_Court_of_Appeal_Status == "Yes" || UP.Other_High_Court_Status == "Yes" || UP.Other_Criminal_Court_Status == "Yes" || UP.Other_Civil_Court_Status == "Yes")
                {
                    SB.AppendLine("                        <h3>Notable Cases</h3>");

                    if (UP.Supreme_Court_Status == "Yes" || UP.Other_Supreme_Court_Status == "Yes")
                    {
                        SB.AppendLine("                            <h6>Supreme Court</h6>");
                    }

                    if (UP.Supreme_Court_Status == "Yes")
                    {
                        SB.AppendLine(UP.Supreme_Court.Replace(Environment.NewLine, "<br />"));
                        SB.AppendLine("                            <br>");

                    }
                    if (UP.Other_Supreme_Court_Status == "Yes")
                    {
                        SB.AppendLine(UP.Other_Supreme_Court.Replace(Environment.NewLine, "<br />"));
                        SB.AppendLine("                            <br>");
                    }

                    if (UP.Court_of_Appeal_Status == "Yes" || UP.Other_Court_of_Appeal_Status == "Yes")
                    {
                        SB.AppendLine("                            <h6>Court of Appeal</h6>");
                    }

                    if (UP.Court_of_Appeal_Status == "Yes")
                    {
                        SB.AppendLine(UP.Court_of_Appeal.Replace(Environment.NewLine, "<br />"));
                        SB.AppendLine("                            <br>");

                    }
                    if (UP.Other_Court_of_Appeal_Status == "Yes")
                    {
                        SB.AppendLine("                            <br>");
                        SB.AppendLine(UP.Other_Court_of_Appeal.Replace(Environment.NewLine, "<br />"));
                    }

                    if (UP.High_Court_Status == "Yes" || UP.Other_High_Court_Status == "Yes")
                    {
                        SB.AppendLine("                            <h6>High Court</h6>");
                    }

                    if (UP.High_Court_Status == "Yes")
                    {
                        SB.AppendLine(UP.High_Court.Replace(Environment.NewLine, "<br />"));
                        SB.AppendLine("                            <br>");
                    }
                    if (UP.Other_High_Court_Status == "Yes")
                    {
                        SB.AppendLine(UP.Other_High_Court.Replace(Environment.NewLine, "<br />"));
                        SB.AppendLine("                            <br>");
                    }

                    if (UP.Criminal_Court_Status == "Yes" || UP.Other_Criminal_Court_Status == "Yes")
                    {
                        SB.AppendLine("                            <h6>High Court</h6>");
                    }
                    if (UP.Criminal_Court_Status == "Yes")
                    {
                        SB.AppendLine(UP.Criminal_Court.Replace(Environment.NewLine, "<br />"));
                        SB.AppendLine("                            <br>");

                    }
                    if (UP.Other_Criminal_Court_Status == "Yes")
                    {
                        SB.AppendLine(UP.Other_Criminal_Court);
                        SB.AppendLine("                            <br>");
                    }

                    if (UP.Civil_Court_Status == "Yes" || UP.Other_Civil_Court_Status == "Yes")
                    {
                        SB.AppendLine("                            <h6>Civil Court</h6>");
                    }

                    if (UP.Civil_Court_Status == "Yes")
                    {
                        SB.AppendLine(UP.Civil_Court.Replace(Environment.NewLine, "<br />"));
                        SB.AppendLine("                            <br>");
                    }
                    if (UP.Other_Civil_Court_Status == "Yes")
                    {
                        SB.AppendLine(UP.Other_Civil_Court.Replace(Environment.NewLine, "<br />"));
                        SB.AppendLine("                            <br>");
                    }
                }
                if (UP.MembershipAndAccreditations_Status == "Yes")
                {

                    SB.AppendLine("                        <h3>Membership & Accreditations</h3>");
                    SB.AppendLine(UP.MembershipAndAccreditations.Replace(Environment.NewLine, "<br />"));
                }
                if (UP.Personal_Interests_Status == "Yes")
                {
                    SB.AppendLine("                        <h3>Interests</h3>");
                    SB.AppendLine(UP.Personal_Interests.Replace(Environment.NewLine, "<br />"));
                }
            

            if (UP.Page_Title == null || String.IsNullOrEmpty(UP.Page_Title))
                Title = _emp_Details.forename + " " + _emp_Details.surname +" | Law Costs Draftsperson | Cost Law Services";
            else
                Title = UP.Page_Title;

            if (UP.Page_Description == null || String.IsNullOrEmpty(UP.Page_Description))
                Description = _emp_Details.forename + " " + _emp_Details.surname + ", Specialist " + jobtitle1 + " at Cost Law Services";
            else
                Description = UP.Page_Description;

            if (UP.Page_Keywords == null || String.IsNullOrEmpty(UP.Page_Keywords))
                Keywords = _emp_Details.forename + " " + _emp_Details.surname + ", " + jobtitle1 +", " + "Cost Law Services";
            else
                Keywords = UP.Page_Keywords;
            }

            SB.AppendLine("                        </div>");
            SB.AppendLine("                    </div>");

            SB.AppendLine("                </div>");

            SB.AppendLine("            </div>");
            SB.AppendLine("        </div>");
            SB.AppendLine("    </div>");
            SB.AppendLine("    </div>");


            Contents = SB;
        }
        
    }
}
