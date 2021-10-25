using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Configuration;

namespace dlwebclasses
{
    public class staffprofile
    {
        private HRDDLEntities db = new HRDDLEntities();

        IT_DatabaseEntities db1 = new IT_DatabaseEntities();
        
        public string FaxNumber { get; set; }
        public string Keywords { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Emp_Status { get; set; }
        public string Mob_No { get; set; }
        public string Office { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string ddi { get; set; }
        public StringBuilder Profile { get; set; }
        public string EmpPro_Dept { get; set; }
        public string HOD { get; set; }
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public string Language3 { get; set; }
        public string emp_code { get; set; }
        public bool? picture_required { get; set; }
        public bool? profile_required { get; set; }
        public bool? crimeduty { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }
       
        public IStaffProfile _IStaffProfile;
        public StringBuilder contentrightcolumn {get; set;}

        public List<string> extraareascovered { get; set; }

        public List<string> staffVideos { get; set; }

        public staffprofile(string staffcode, DepartmentDetails dd, bool preview = false)
        {

            Emp_Details _emp_Details = new Emp_Details();
            Emp_ITInfo _emp_ITDetails = new Emp_ITInfo();
            Emp_Profile _emp_Profile = new Emp_Profile();
            _emp_Details = db.Emp_Details.Where(x => x.emp_code == staffcode).FirstOrDefault();
            _emp_ITDetails = db.Emp_ITInfo.Where(x => x.Emp_Code == staffcode).FirstOrDefault();
            _emp_Profile = db.Emp_Profile.Where(x => x.emp_code == staffcode).FirstOrDefault();
            FaxNumber = "";
            Name = _emp_Details.forename + ' ' + _emp_Details.surname;
            
            if (_emp_Profile == null)
            {
                Keywords = Name;
                Title = Name;
                Description = Name;
                EmpPro_Dept = "";
            }
            else
            {
                Keywords = _emp_Profile.keywords == null ? "" : _emp_Profile.keywords;
                Title = _emp_Profile.title == null ? "" : _emp_Profile.title;
                Description = _emp_Profile.description == null ? "" : _emp_Profile.description;
                EmpPro_Dept = _emp_Profile.department;
            }

            List<Updates_MainWebsites> Articles_Staff = new List<Updates_MainWebsites>();
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            Articles_Staff = dbit.Updates_MainWebsites.Where(x => x.Staff1 == _emp_Details.forename + " " + _emp_Details.surname || x.Staff2 == _emp_Details.forename + " " + _emp_Details.surname || x.Staff3 == _emp_Details.forename + " " + _emp_Details.surname).OrderByDescending(x => x.ID).ToList();
            StringBuilder CRC = new StringBuilder();
            CRC.AppendLine("<!--Contents coming from content section-->");
            if (Articles_Staff.Count > 0)
            {
                CRC.AppendLine("        <ul class=\"bigbuts\">");
                CRC.AppendLine("          <li><a href=\"#\" style=\"background-position:0px 0px; height:50px;\" class=\"bigbuts_accreditation\"><span>" + _emp_Details.forename + " " + _emp_Details.surname + "'s Articles</span></a></li>");
                CRC.AppendLine("        </ul>");

                CRC.AppendLine("<div id=\"reportedtop\"><div id=\"reportedbottom\"><ul class=\"reportedmenu\">");
                foreach (Updates_MainWebsites UM1 in Articles_Staff)
                {
                    GetLinkfromArticleRef _getlink = new GetLinkfromArticleRef();
                    CRC.AppendLine(_getlink.GetLink(UM1, null, "StaffPage"));
                }
                CRC.AppendLine("</ul></div></div><div class=\"bigbuts_seperator\"></div>");
            }
            contentrightcolumn = CRC;

            filepath = ConfigurationManager.AppSettings["Rootpath"].ToString() + "\\" + dd.folderteam1 + "\\" + Name.ToString().Replace(" ", "_") + ".html";
            Department = _emp_Details.department_it;
            Emp_Status = _emp_Details.emp_status;
            Office = _emp_Details.Office.office_name;
            JobTitle = allStatic.filterjobtitle(_emp_Details);
            Email = _emp_Details.email;
            ddi = _emp_Details.direct_dial_tel_number;

            Language1 = _emp_Details.language1;
            Language2 = _emp_Details.language2;
            Language3 = _emp_Details.language3;
            emp_code = _emp_Details.fee_earner_code;
            crimeduty = _emp_Details.crimeduty_solicitor;

            Dictionary<string, StringBuilder> KD = new Dictionary<string, StringBuilder>();
            KD = allStatic.languagestringforprofiles(Language1, Language2, Language3);

            if (Keywords.Length < 6)
                Keywords = "Duncan Lewis, " + Name + ", " + KD["Keywords"].ToString() + ", " + Office + ", " + Department + " " + JobTitle.Replace("Consultant", "Solicitor").Replace("Partner", "Solicitor") + ", " + Department + " lawyer, Legal aid, Legal aid Solicitor, Solicitors";

            if (Description.Length < 6)
                Description = "Duncan Lewis," + Name + ", " + KD["Description"].ToString() + " speaking " + Department + " Solicitor, " + Office;

            if (Title.Length < 6)
                Title = Name + " | Duncan Lewis | " + Department + " " + JobTitle.Replace("Consultant", "Solicitor").Replace("Partner", "Solicitor") + " | " + Office;

            if (crimeduty == true)
            {
                if (Emp_Status == "Freelance Consultant" || Emp_Status == "Limited Company")
                    JobTitle = "Consultant Crime Duty Solicitor";
                else
                    JobTitle = "Crime Duty Solicitor";
            }
            else
            {
                if (Emp_Status == "Freelance Consultant" || Emp_Status == "Limited Company")
                    JobTitle = "Consultant";
            }
            picture_required = _emp_Details.Picture_website;
            profile_required = _emp_Details.Profile_website;
            if (_emp_Details.bb_given == "1")
                Mob_No = _emp_ITDetails.bb_mobile_no;
            else
                Mob_No = "0";

            if (_emp_Details.jobtitle.Contains("Head of Department") == true)
                HOD = "Yes";
            else
                HOD = "No";



            var faxno = db.Database.SqlQuery<string>("select isnull(Users_Fax,'') as FaxNumber from [dlddbsrv4].Indigo.dbo.users where users_FeCode = '" + emp_code + "' and users_FECOde is not null and len(users_FECOde) > 1").FirstOrDefault();
            FaxNumber = "";
            if (faxno == null)
                FaxNumber = "";
            else if (faxno.ToString().Length > 5)
                FaxNumber = faxno.ToString().Substring(0, 3) + " " + faxno.ToString().Substring(3, 4) + " " + faxno.ToString().Substring(7, 4);



            User_Profile_FinalDraft UP = new User_Profile_FinalDraft();
            UP = db1.User_Profile_FinalDraft.Where(x => x.Emp_code == staffcode).FirstOrDefault();
            if (UP == null)
            {
                _IStaffProfile = new staffprofileoldhrd();
            }
            else if (UP.Quality_Status == true || (UP.Status == true && preview == true))
            {
                _IStaffProfile = new staffprofileitdatabase();
            }
            else
            {
                _IStaffProfile = new staffprofileoldhrd();
            }

            Profile = _IStaffProfile.getstaffProfile(staffcode);
            //if (Department == "Immigration" || Department == "Business Immigration")
            //{ 
            //    Profile = allStatic.replacekeywordswithlinks(Profile);
            //}



            //Old Website Contents

            StringBuilder _Contents = new StringBuilder();

            _Contents.AppendLine("    <div id=\"breadcrumb\" class=\"visible-lg visible-md visible-sm\">");
            _Contents.AppendLine("      <p><a href=\"index.html\">Home</a> | <a href=\"" + dd.Overview1 + "\">" + dd.Name + "</a> | " + Name + " </p>");
            _Contents.AppendLine("    </div>");






            if (JobTitle == "Partner")
            {
                JobTitle = "Director &amp; Solicitor";
            }


            string mangementstaffjobtitle = "";
            if (Name == "Shany Gupta")
                mangementstaffjobtitle = "Chief Executive Officer";
            else if (Name == "Syed Talha Rafique")
                mangementstaffjobtitle = "Chairman";
            else if (Name == "Mohan Bharj")
                mangementstaffjobtitle = "Finance Officer";
            else if (Name == "Sridhar Ponnada")
                mangementstaffjobtitle = "Director - IT And Operations";
            else if (Name == "Nina Joshi")
                mangementstaffjobtitle = "Managing Director";
            else if (Name == "Judith Lee-Scott")
                mangementstaffjobtitle = "HR Manager";
            else if (Name == "David Daud")
                mangementstaffjobtitle = "Operations Manager";
            else if (Name == "Jason Bruce")
                mangementstaffjobtitle = "Practice Manager";


            string deptstaff = Department;
            string jobtitlestaff = JobTitle;
            if (Name == "Shany Gupta" || Name == "Syed Talha Rafique" || Name == "Mohan Bharj" || Name == "Sridhar Ponnada" || Name == "Nina Joshi" || Name == "Judith Lee-Scott" || Name == "David Daud" || Name == "Jason Bruce")
            {
                deptstaff = "Management";
                jobtitlestaff = mangementstaffjobtitle;
            }
            else if (Name == "Geoffrey Yeung")
            {
                jobtitlestaff = "Head of Business Development";
            }
            else if (HOD == "Yes")
            {
                jobtitlestaff = "Head of Department";
            }


            _Contents.AppendLine("    <div class=\"container-fluid\">    ");
            _Contents.AppendLine("        <div class=\"row\">");
            _Contents.AppendLine("            <div class=\"col-lg-4 col-sm-4 col-md-4 hidden-xs\">");
            _Contents.AppendLine("            &nbsp;");
            _Contents.AppendLine("            </div>");
            _Contents.AppendLine("            <div id=\"staff_nav\" class=\"col-lg-8 col-sm-8 col-md-8 col-xs-12\">");
            _Contents.AppendLine("                  <h3>" + Name + "</h3>");
            _Contents.AppendLine("            </div>");
            _Contents.AppendLine("        </div>");
            _Contents.AppendLine("        </div>    ");
            _Contents.AppendLine("        <div class=\"container-fluid\">    ");
            _Contents.AppendLine("        <div class=\"row blueback\" style=\"padding-top:10px; border-top:Solid 2px #fff; margin-bottom:20px;\">");



            if (File.Exists("C:\\Inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised\\Photos\\StaffPics\\" + Name + ".jpg") && picture_required == true)
            {
                _Contents.AppendLine("            <div class=\"col-lg-4 col-sm-4 col-md-4 col-xs-6 blueback\" style=\"padding:3px;\">");
                _Contents.AppendLine("      <img src=\"/Photos/StaffPics/" + Name + ".jpg\" alt=\"" + Title.Replace("|", ",").Replace("^", "") + "\" style=\"border:Solid 3px #74d1f6\" width=\"158\" height=\"173\"/></p>");
                _Contents.AppendLine("            </div>");
                _Contents.AppendLine("            <div class=\"col-lg-8 col-sm-8 col-md-8 col-xs-6 blueback\" style=\"padding-bottom:10px;\">");
            }
            else
            {
                _Contents.AppendLine("            <div class=\"col-lg-12 col-sm-12 col-md-12 col-xs-12 blueback\" style=\"padding-bottom:10px;\">");
            }



            _Contents.AppendLine("\t            <div id=\"staff_details_dept\" class=\"staff_details_icons col-lg-6 col-sm-6 col-md-6\">" + deptstaff + "</div>");
            _Contents.AppendLine("              <div id=\"staff_details_degree\" class=\"staff_details_icons col-lg-6 col-sm-6 col-md-6\">" + jobtitlestaff + "</div>");


            if (mangementstaffjobtitle != "")
            {
                if (Name != "Nina Joshi")
                    _Contents.AppendLine("<div id=\"staff_details_office\" class=\"staff_details_icons col-lg-6 col-sm-6 col-md-6\"><a href=\"http://www.duncanlewis.co.uk/offices/Harrow_Office.html\">Harrow</a></div>");
                else
                    _Contents.AppendLine("<div id=\"staff_details_office\" class=\"staff_details_icons col-lg-6 col-sm-6 col-md-6\"><a href=\"http://www.duncanlewis.co.uk/offices/Hackney_Office.html\">Hackney</a></div>");
            }
            else
            {
                _Contents.AppendLine("              <div id=\"staff_details_office\" class=\"staff_details_icons col-lg-6 col-sm-6 col-md-6\">" + Office.Replace(" Office", "") + "</div>");
                if ((Emp_Status != "Freelance Consultant" || Name == "Aina Khan") && Name != "Sabeela Malik" && ddi != null)
                {
                    if (ddi.Length > 5)
                        _Contents.AppendLine("              <div id=\"staff_details_tel\" class=\"staff_details_icons col-lg-6 col-sm-6 col-md-6\">" + ddi + "</div>");
                }

                if (Mob_No != "0")
                {
                    if (Name != "Emma Taylor" && Name != "Aina Khan" && Name != "Sabeela Malik" && Name != "Jason Bruce")
                    {
                        _Contents.AppendLine("              <div id=\"staff_details_mob\" class=\"staff_details_icons col-lg-6 col-sm-6 col-md-6\">" + Mob_No + "</div>");
                    }
                }


                if (!string.IsNullOrEmpty(faxno))
                {
                    _Contents.AppendLine("       <div id=\"staff_details_fax\" class=\"staff_details_icons col-lg-6 col-sm-6 col-md-6\">" + faxno + "</div>");
                }

                if (Emp_Status != "Freelance Consultant" || Name == "Aina Khan")
                {
                    _Contents.AppendLine("      <div id=\"staff_details_email\" class=\"staff_details_icons col-lg-6 col-sm-6 col-md-6\"><a href=\"mailto:" + Email + "\" class=\"personcontact\">Send Email</a></div>");
                }

                if (File.Exists("C:\\Inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised\\VCFCards\\" + Name + ".vcf"))
                {
                    _Contents.AppendLine("      <div id=\"staff_details_vcf\" class=\"staff_details_icons col-lg-6 col-sm-6 col-md-6\"><a href=\"http://www.duncanlewis.co.uk/VCFCards/" + Name + ".vcf\" class=\"personcontact\" style=\"text-decoration:none\">Download VCard</a></div>");
                }

            }

            _Contents.AppendLine("            </div>");
            _Contents.AppendLine("        </div>");
            _Contents.AppendLine("  </div>");
            _Contents.AppendLine("    <div class=\"container-fluid\">    ");
            _Contents.AppendLine("        <div class=\"row\">");
            _Contents.AppendLine("            <div class=\"col-lg-4 col-sm-4 col-md-4 visible-lg visible-sm visible-md\">");
            _Contents.AppendLine("            &nbsp;");
            _Contents.AppendLine("            </div>");
            _Contents.AppendLine("            <div id=\"staff_nav\" class=\"col-lg-8 col-sm-8 col-md-8 col-xs-12\">");
            _Contents.AppendLine("                  <h3>Profile / Experience</h3>");
            _Contents.AppendLine("            </div>");
            _Contents.AppendLine("        </div>");
            _Contents.AppendLine("        </div>");

            string achlogo = allStatic.achievementlogos(Name);
            _Contents.AppendLine("<div class=\"container-fluid\">");
            _Contents.AppendLine("<div class=\"row staff_profile\" style=\"padding:10px; border:Solid 2px #74d1f6;\">");
            if (string.IsNullOrEmpty(achlogo))
                _Contents.AppendLine("<div class=\"col-lg-12 col-sm-12 col-md-12 col-xs-12\" style=\"padding:0px; padding-bottom:10px;\">");
            else
                _Contents.AppendLine("<div class=\"col-lg-9 col-sm-9 col-md-9 col-xs-12\" style=\"padding:0px; padding-bottom:10px;\">");


            _Contents.AppendLine("<p style=\"line-height:20px;\">" + Profile.Replace("<p>", "<p style=\"line-height:20px;\">").Replace("<li>", "<li style=\"line-height:20px\">") + "</p>");
            _Contents.AppendLine("        </div>");

            if (!string.IsNullOrEmpty(achlogo))
            {
                _Contents.AppendLine("<div class=\"col-lg-3 col-md-3 col-sm-3 col-xs-12\" style=\"padding:0px; text-align:right;\">");
                _Contents.AppendLine(achlogo);
                _Contents.AppendLine("</div>");
            }


            _Contents.AppendLine("    </div> ");
            _Contents.AppendLine("    </div> ");

            //Contents = _Contents;


            Contents = _Contents;

        }







    }    
}
