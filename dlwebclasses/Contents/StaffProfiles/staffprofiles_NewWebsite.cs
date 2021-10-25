using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace dlwebclasses
{
    public class staffprofiles_NewWebsite
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

        public string canonicaltag { get; set; }

        public staffprofiles_NewWebsite(string staffcode, DepartmentDetails dd, bool preview = false)
        {

            Emp_Details _emp_Details = new Emp_Details();
            Emp_ITInfo _emp_ITDetails = new Emp_ITInfo();
            Emp_Profile _emp_Profile = new Emp_Profile();
            _emp_Details = db.Emp_Details.Where(x => x.emp_code == staffcode).FirstOrDefault();
            _emp_ITDetails = db.Emp_ITInfo.Where(x => x.Emp_Code == staffcode).FirstOrDefault();
            _emp_Profile = db.Emp_Profile.Where(x => x.emp_code == staffcode).FirstOrDefault();
            FaxNumber = "";
            Name = _emp_Details.forename + ' ' + _emp_Details.surname;
            //extraareascovered = null;
            extraareascovered = getextraareascovered(staffcode);
            staffVideos = getstaffVideos(staffcode);
            if (_emp_Profile == null)
            {
                Keywords = Name;
                Title = Name + "| Duncan Lewis";
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
            Articles_Staff = dbit.Updates_MainWebsites.Where(x => x.Staff1 == _emp_Details.forename + " " + _emp_Details.surname || x.Staff2 == _emp_Details.forename + " " + _emp_Details.surname || x.Staff3 == _emp_Details.forename + " " + _emp_Details.surname || x.Staff4 == _emp_Details.forename + " " + _emp_Details.surname || x.Staff5 == _emp_Details.forename + " " + _emp_Details.surname || x.Staff6 == _emp_Details.forename + " " + _emp_Details.surname || x.Staff7 == _emp_Details.forename + " " + _emp_Details.surname || x.Staff8 == _emp_Details.forename + " " + _emp_Details.surname || x.Staff9 == _emp_Details.forename + " " + _emp_Details.surname || x.Staff10 == _emp_Details.forename + " " + _emp_Details.surname).OrderByDescending(x => x.ID).ToList();
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

            filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\" + dd.folderteam1 + "\\" + Name.ToString().Replace(" ", "_") + ".html";
            canonicaltag = "<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk/" + allStatic.getRewriteUrlLinkForStaff(_emp_Details) + "/\" />";
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

            if (crimeduty == true && JobTitle.Contains("Partner") == false)
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


            if (JobTitle == "Partner")
            {
                JobTitle = "Director &amp; Solicitor";
            }

            if (Name == "Bahar Ata")
                JobTitle = "Director";

            if (Name == "Neil Sargeant")
                JobTitle = "Motoring Law Specialist";


            string mangementstaffjobtitle = "";
            if (Name == "Shany Gupta")
                mangementstaffjobtitle = "Chief Executive Officer";
            else if (Name == "Syed Talha Rafique")
                mangementstaffjobtitle = "Chairman";
            else if (Name == "Mohan Bharj")
                mangementstaffjobtitle = "CFO";
            else if (Name == "Sridhar Ponnada")
                mangementstaffjobtitle = "Director - IT And Operations";
            else if (Name == "Nina Joshi")
                mangementstaffjobtitle = "Managing Director";
            else if (Name == "Judith Lee-Scott")
                mangementstaffjobtitle = "HR Manager";
            else if (Name == "David Daud")
                mangementstaffjobtitle = "Operations Manager";
            else if (Name == "Jason Bruce")
                mangementstaffjobtitle = "Practice Director &amp; Solicitor";



            string deptstaff = Department;
            string jobtitlestaff = JobTitle;
            if (Name == "Shany Gupta" || Name == "Syed Talha Rafique" || Name == "Mohan Bharj" || Name == "Sridhar Ponnada" || Name == "Nina Joshi" || Name == "Judith Lee-Scott" || Name == "David Daud" || Name == "Jason Bruce")
            {
                deptstaff = "Management";
                jobtitlestaff = mangementstaffjobtitle;
            }
            else if (HOD == "Yes")
            {
                jobtitlestaff = "Head of Department";
            }




            //News Website Contents

            StringBuilder _NewContents = new StringBuilder();

            _NewContents.AppendLine("<div class=\"row nopadding\">");
            Random r = new Random();
            if (Name == "Shany Gupta")
                _NewContents.AppendLine("    <div class=\"col-md-12 col-lg-12 col-sm-12 col-xs-12 nopadding managementbanner1 profilebanner profilebanner5\">");
            else if (deptstaff == "Management")
                _NewContents.AppendLine("    <div class=\"col-md-12 col-lg-12 col-sm-12 col-xs-12 nopadding managementbanner profilebanner profilebanner5\">");
            else
                _NewContents.AppendLine("    <div class=\"col-md-12 col-lg-12 col-sm-12 col-xs-12 nopadding profilebanner profilebanner" + r.Next(1, 8).ToString() + "\">");
            
                _NewContents.AppendLine("        <div class=\"profilebannerbandtop " + dd.cssclass + " kolor\"></div>");

            if (File.Exists("C:\\Inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\Photos\\StaffPics\\" + Name + ".png") && picture_required == true)
            {
                _NewContents.AppendLine("        <img alt=\"" + Title.Replace("|", ",").Replace("^", "") + "\" src=\"/Photos/StaffPics/" + Name + ".png\" />");
            }
            else if (_emp_Details.gender == "M")
            {
                _NewContents.AppendLine("        <img alt=\"" + Title.Replace("|", ",").Replace("^", "") + "\" src=\"/Photos/Staffpics/missingM.png\" />");
            }
            else
            {
                _NewContents.AppendLine("        <img alt=\"" + Title.Replace("|", ",").Replace("^", "") + "\" src=\"/Photos/Staffpics/missingF.png\" />");
            }
            _NewContents.AppendLine("        <div class=\"profilenamepanel\"><h1>" + Name + "</h1><h2>" + jobtitlestaff + "</h2></div>");
            _NewContents.AppendLine("        <div class=\"profilebannerbandbottom " + dd.cssclass + " kolor\"></div>");
            _NewContents.AppendLine("    </div>");
            _NewContents.AppendLine("</div>");

            _NewContents.AppendLine("<div class=\"row nopadding\">");
            _NewContents.AppendLine("    <div class=\"col-sm-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            _NewContents.AppendLine("        <div class=\"row nopadding\">");
            _NewContents.AppendLine("            <div class=\"col-sm-3 col-xs-12 nopadding\">");
            _NewContents.AppendLine("                <div class=\"contactpanelcolumn " + dd.cssclass + " deptbordercolor\" data-spy=\"affix\" data-offset-top=\"520\" data-offset-bottom=\"470\">");
            _NewContents.AppendLine("                    <div class=\"contactpanel " + dd.cssclass + " kolor forecolorlight\">");
            _NewContents.AppendLine("                        <p >Contact Information</p>");
            _NewContents.AppendLine("                        <ul>");
            _NewContents.AppendLine("                            <li><span class=\"fa fa-user\"></span>" + jobtitlestaff + "</li>");
            _NewContents.AppendLine("                            <li>");
            _NewContents.AppendLine("                                <span class=\"fa fa-certificate\"></span>");
            _NewContents.AppendLine(deptstaff);
            _NewContents.AppendLine("                            </li>");

            if (mangementstaffjobtitle != "")
            {
                if (Name != "Nina Joshi")
                    _NewContents.AppendLine("                            <li><span class=\"fa fa-building\"></span><a href=\"/offices/Harrow_Office.html\">Harrow</a></li>");
                else
                    _NewContents.AppendLine("                            <li><span class=\"fa fa-building\"></span><a href=\"/offices/Hackney_Office.html\">Hackney</a></li>");
            }
            else
            {
                _NewContents.AppendLine("                            <li><span class=\"fa fa-building\"></span><a href=\"/offices/" + Office.Replace("Dalston","Hackney") + "_Office.html\">" + Office + "</a></li>");
                if ((Emp_Status != "Freelance Consultant" || Name == "Aina Khan") && Name != "Sabeela Malik" && ddi != null)
                {
                    if (ddi.Length > 5)
                        _NewContents.AppendLine("                            <li><span class=\"fa fa-phone\"></span><a href=\"tel:" + ddi + "\">" + ddi + "</a></li>");
                }

                if (Mob_No != "0")
                {
                    if (Name != "Emma Taylor" && Name != "Aina Khan" && Name != "Sabeela Malik" && Name != "Jason Bruce")
                    {
                        _NewContents.AppendLine("                            <li><span class=\"fa fa-mobile-phone\"></span><a href=\"tel:" + Mob_No + "\">" + Mob_No + "</a></li>");
                    }
                }


                if (!string.IsNullOrEmpty(faxno))
                {
                    _NewContents.AppendLine("                            <li><span class=\"fa fa-fax\"></span>" + faxno + "</li>");
                }

                if (Emp_Status != "Freelance Consultant" || Name == "Aina Khan")
                {
                    _NewContents.AppendLine("                            <li><span>@</span><a href=\"mailto:" + Email + "\" class=\"personcontact\">Send Email</a></li>");
                }

                if (File.Exists("C:\\Inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised\\VCFCards\\" + Name + ".vcf"))
                {
                    _NewContents.AppendLine("                            <li><span class=\"fa fa-vcard\"></span><a href=\"/VCFCards/" + Name + ".vcf\" class=\"personcontact\" style=\"text-decoration:none\">Download VCard</a></li>");
                }
            }


            _NewContents.AppendLine("                        </ul>");
            _NewContents.AppendLine("                    </div>");




            if (deptstaff != "Management")
            {
            _NewContents.AppendLine("                    <div class=\"panel panel-primary homepagepanels " + dd.cssclass + "\">");
            _NewContents.AppendLine("                        <div class=\"panel-heading\">");
            _NewContents.AppendLine("                            <a data-toggle=\"collapse\" href=\"#panelExpertisein\">Expertise In<span class=\"fa fa-caret-down\"></span></a>");
            _NewContents.AppendLine("                        </div>");
            _NewContents.AppendLine("                        <div id=\"panelExpertisein\" class=\"panel-body panel-collapse collapse in\">");
            _NewContents.AppendLine("                            <ul>");
            foreach (var itemextra in extraareascovered)
            {
                _NewContents.AppendLine("                                <li>" + itemextra + "</li>");
            }
            _NewContents.AppendLine("                            </ul>");
            _NewContents.AppendLine("                        </div>");
            _NewContents.AppendLine("                    </div>");
            }


            if (staffVideos.Count() > 0)
            {
                _NewContents.AppendLine("                    <div class=\"panel panel-primary homepagepanels " + dd.cssclass + "\">");
                _NewContents.AppendLine("                        <div class=\"panel-heading\">");
                _NewContents.AppendLine("                            <a data-toggle=\"collapse\" href=\"#panelProfileVideos\">Videos<span class=\"fa fa-caret-down\"></span></a>");
                _NewContents.AppendLine("                        </div>");
                _NewContents.AppendLine("                        <div id=\"panelProfileVideos\" class=\"panel-body panel-collapse collapse in\">");
                _NewContents.AppendLine("                            <ul>");
                foreach (var itemv in staffVideos)
                {
                    _NewContents.AppendLine("                                <li>" + itemv + "</li>");
                }
                _NewContents.AppendLine("                            </ul>");
                _NewContents.AppendLine("                        </div>");
                _NewContents.AppendLine("                    </div>");
            }
            _NewContents.AppendLine("                </div>");
            _NewContents.AppendLine("            </div>");

            _NewContents.AppendLine("            <div class=\"col-sm-9 col-xs-12 " + dd.cssclass + " profiletabs\">");

            //Profile contents
            staffprofileitdatabaseNewWebsite spnd = new staffprofileitdatabaseNewWebsite();
            _NewContents.AppendLine(spnd.getstaffProfile(staffcode).ToString());


            _NewContents.AppendLine("            </div>");


            _NewContents.AppendLine("        </div>");
            _NewContents.AppendLine("    </div>");
            _NewContents.AppendLine("</div>");

            Title = Name + "| Duncan Lewis";
            Contents = _NewContents;

        }


        public List<string> getextraareascovered(string emp_code)
        {
            Emp_Details _emp_Details = new Emp_Details();
            _emp_Details = db.Emp_Details.Where(x => x.emp_code == emp_code).FirstOrDefault();
            List<string> avialabledepartments = new List<string>();
            Website_Department_Structure wds = new Website_Department_Structure();
            avialabledepartments =  db1.Website_Department_Structure.Select(x => x.Name).ToList();
            List<string> extraareascovered1 = new List<string>();
            if (_emp_Details.department_it != null && _emp_Details.department_it != "")
            {
                string landingpagelink = getlinkofdepartmentlandingpage(_emp_Details.department_it, avialabledepartments);
                if (landingpagelink != "")
                {
                    extraareascovered1.Add(landingpagelink);
                }
            }
            if (_emp_Details.department_covered_2 != null && _emp_Details.department_covered_2 != "")
            {
                string landingpagelink = getlinkofdepartmentlandingpage(_emp_Details.department_covered_2, avialabledepartments);
                if (landingpagelink != "")
                {
                    extraareascovered1.Add(landingpagelink);
                }
            }
            if (_emp_Details.department_covered_3 != null && _emp_Details.department_covered_3 != "")
            {
                string landingpagelink = getlinkofdepartmentlandingpage(_emp_Details.department_covered_3, avialabledepartments);
                if (landingpagelink != "")
                {
                    extraareascovered1.Add(landingpagelink);
                }
            }
            if (_emp_Details.department_covered_4 != null && _emp_Details.department_covered_4 != "")
            {
                string landingpagelink = getlinkofdepartmentlandingpage(_emp_Details.department_covered_4, avialabledepartments);
                if (landingpagelink != "")
                {
                    extraareascovered1.Add(landingpagelink);
                }
            }
            if (_emp_Details.department_covered_5 != null && _emp_Details.department_covered_5 != "")
            {
                string landingpagelink = getlinkofdepartmentlandingpage(_emp_Details.department_covered_5, avialabledepartments);
                if (landingpagelink != "")
                {
                    extraareascovered1.Add(landingpagelink);
                }
            }
            return extraareascovered1;
        }


        public List<string> getstaffVideos(string emp_code)
        {
            List<string> _staffVideos = new List<string>();
            List<Website_Videos> wv = new List<Website_Videos>();
            wv = db1.Website_Videos.Where(x => x.emp_code == emp_code).ToList();
            if (wv.Count > 0)
            {
                foreach (var item in wv)
                {
                    _staffVideos.Add("<a href=\"/Videos/" + item.id + "_Videos.html\"><img src=\"/Video-Images/" + item.id + ".JPG\" class=\"img-responsive\" alt=\"Duncan Lewis Videos\"  /></a>");
                }
            }
            return _staffVideos;
        }

        public string getlinkofdepartmentlandingpage(string name, List<string> avialabledepartments)
        {
            if (avialabledepartments.Contains(name))
            {
                DepartmentDetails ddextra = new DepartmentDetails(name);
                return "<a href=\"/" + ddextra.Overview1 + "\">" + name + "</a>";
            }
            else
                return "";
        }

    }
}
