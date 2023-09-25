using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using System.Reflection;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.Data;
using System.Data.OleDb;

namespace dlwebclasses
{
    public static class allStatic
    {
        public static StringBuilder getMainNavigation()
        {
            IKernel _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
            IMainNavigation _IMainNavigation = _kernel.Get<IMainNavigation>();
            return _IMainNavigation.getmainnavigation();
        }


        public static string filterjobtitle(Emp_Details _Empdetails)
        {
            if (_Empdetails.cilex == true && _Empdetails.jobtitle.Contains("Director") == true)
                return "Partner";
            else if ((_Empdetails.jobtitle.Contains("Partner") == true) || (_Empdetails.jobtitle.Contains("Director") == true) || (_Empdetails.jobtitle.Contains("Manager") == true))
                return "Partner";
            else if (_Empdetails.cilex == true)
                return "Solicitor";
            else if ((_Empdetails.nonadmitted_staff == "1" || _Empdetails.forename + " " + _Empdetails.surname == "Neel Chakrabarti") && _Empdetails.forename != "Sridhar" && _Empdetails.forename + " " + _Empdetails.surname != "Mohan Bharj" && !_Empdetails.jobtitle.Contains("Chartered") && _Empdetails.jobtitle.Contains("Trainee"))
                return "Trainee";
            else if ((_Empdetails.nonadmitted_staff == "1" ||  _Empdetails.forename + " " + _Empdetails.surname == "Neel Chakrabarti") && _Empdetails.forename != "Sridhar" && _Empdetails.forename + " " + _Empdetails.surname != "Mohan Bharj" && !_Empdetails.jobtitle.Contains("Chartered") && !_Empdetails.jobtitle.Contains("Trainee"))
                return "Caseworker";
            else if ((_Empdetails.emp_status.Contains("Freelance Consultant") == true) || (_Empdetails.emp_status.Contains("Limited Company") == true))
                return "Freelance Consultant";
            else if ((_Empdetails.jobtitle.Contains("Paralegal") == true) || (_Empdetails.jobtitle.Contains("Caseworker") == true) || (_Empdetails.jobtitle.Contains("Legal Consultant") == true) || (_Empdetails.jobtitle.Contains("Legal Assistant") == true) || (_Empdetails.jobtitle.Contains("Clerk") == true) || (_Empdetails.jobtitle.Contains("Trainee") == true) || (_Empdetails.jobtitle.Contains("In-House Counsel") == true))
                return "Caseworker";
            else if ((_Empdetails.jobtitle.Contains("Supervisor") == true) || (_Empdetails.jobtitle.Contains("Solicitor") == true) || (_Empdetails.jobtitle.Contains("High Court Advocate") == true) || _Empdetails.jobtitle.Contains("Chartered"))
                return "Solicitor";
            else
                return "Solicitor";
        }



        public static void sendemail(string To_whom, string from_whom, string subject, string msg, List<string> cclist = null, List<string> bcclist = null, bool formatted = true, List<embeddedImagelist> _embeddedimagelist = null, List<string> attachments = null)
        {
            string mMailServer = "10.0.0.27";
            string mFrom = from_whom;
            int mPort = 25;
            MailMessage message = default(MailMessage);
            try
            {
                message = new MailMessage(mFrom, To_whom);
            }
            catch
            {
                message = new MailMessage(mFrom, "ajitl@duncanlewis.com");
            }
            message.IsBodyHtml = true;
            message.Subject = subject;



            message.ReplyTo = new MailAddress(from_whom, "Re:" + subject);
            if (formatted == true)
            {
                message.Body = "<p style=\"font-family:Arial; font-size:14px\">" + msg + "</p>";
            }
            else
            {
                message.Body = msg;
            }

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(msg, null, "text/html");

            if (_embeddedimagelist != null)
            {
                foreach (var el in _embeddedimagelist)
                {
                    LinkedResource LinkedImage = new LinkedResource(el.path);
                    LinkedImage.ContentId = el.contentid;
                    if (el._mimetype == mimetype.JPEG)
                    {
                        LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
                    }
                    else if (el._mimetype == mimetype.GIF)
                    {
                        LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Gif);
                    }
                    else if (el._mimetype == mimetype.PNG)
                    {
                        LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
                    }
                    htmlView.LinkedResources.Add(LinkedImage);
                }
            }

            message.AlternateViews.Add(htmlView);


            if ((cclist != null) && cclist.Count > 0)
            {
                foreach (string item in cclist)
                {
                    try
                    {
                        message.CC.Add(item.ToString());
                    }
                    catch
                    {
                        message.CC.Add("ajitl@duncanlewis.com");
                    }
                }
            }
            if ((bcclist != null) && bcclist.Count > 0)
            {
                foreach (string item in bcclist)
                {
                    try
                    {
                        message.Bcc.Add(item.ToString());
                    }
                    catch
                    {
                        message.Bcc.Add("ajitl@duncanlewis.com");
                    }
                }
            }

            if (attachments != null)
            {
                foreach (string att in attachments)
                {
                    System.Net.Mail.Attachment attachment1;
                    attachment1 = new System.Net.Mail.Attachment(att);
                    message.Attachments.Add(attachment1);
                }
            }


            message.Priority = MailPriority.High;
            SmtpClient mySmtpClient = new SmtpClient(mMailServer, mPort);
            mySmtpClient.Port = 25;
            NetworkCredential net = new NetworkCredential("portals", "AlphaDelta@321!");
            mySmtpClient.UseDefaultCredentials = false;
            mySmtpClient.Credentials = net;
            mySmtpClient.Send(message);

        }

        public static List<Emp_Details> getcurrentemployedstafflist()
        {
            HRDDLEntities db = new HRDDLEntities();
            List<Emp_Details> ED = new List<Emp_Details>();
            ED = db.Emp_Details.Where(x => ((string)x.employed == "1") && (x.start_date <= DateTime.Now) && (x.end_date > DateTime.Now || x.end_date == null || x.end_date == new DateTime(1900, 1, 1))).OrderBy(x => x.forename).ToList();
            return ED;
        }


        public static void htaccessstaff(string path = "C:\\Inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\htaccess_Staff1.txt")
        {
            //List<Website_Department_Structure> WDS = new List<Website_Department_Structure>();
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            HRDDLEntities dbhr = new HRDDLEntities();
            List<string> departments_aol = db.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").Select(x => x.Name).ToList();

            IEnumerable<Emp_Details> ed;
            ed = getcurrentemployedstafflist();
            List<Emp_Details> ed1;
            ed1 = ed.Where(x => (departments_aol.Contains(x.department_it))).OrderBy(x => x.forename).ToList();
            StreamWriter fp;
            fp = File.CreateText(path);

            int i = 1;
            foreach (Emp_Details ed2 in ed1)
            {
                string Name = ed2.forename + " " + ed2.surname;
                DepartmentDetails DD = new DepartmentDetails(ed2.department_it);
                string rewriteurllink = allStatic.getRewriteUrlLinkForStaff(ed2);
                fp.WriteLine("<rule name=\"Imported Rule " + i.ToString() + "\" stopProcessing=\"true\">");
                fp.WriteLine("<match url=\"" + rewriteurllink + ".*\" />");
                fp.WriteLine("<action type=\"Rewrite\" url=\"" + DD.folderteam1 + "/" + Name.Replace(" ", "_") + ".html" + "\" />");
                fp.WriteLine("</rule>");
                i++;


                Emp_Details edupdate = dbhr.Emp_Details.Find(ed2.emp_code);
                edupdate.website_link = rewriteurllink;
                dbhr.Entry(edupdate).State = System.Data.Entity.EntityState.Modified;
                dbhr.SaveChanges();
                //fp.WriteLine("RewriteRule " + rewriteurllink + "/ " + DD.folderteam1 + "/" + Name.Replace(" ", "_") + ".html [NC,L]");
            }
            fp.WriteLine("<rule name=\"Imported Rule " + i++.ToString() + "\" stopProcessing=\"true\">");
            fp.WriteLine("<match url=\"mentalhealth.html.*\" />");
            fp.WriteLine("<action type=\"Rewrite\" url=\"Index.html\" />");
            fp.WriteLine("</rule>");

            fp.WriteLine("<rule name=\"Imported Rule " + i++.ToString() + "\" stopProcessing=\"true\">");
            fp.WriteLine("<match url=\"mentalhealth_services.html.*\" />");
            fp.WriteLine("<action type=\"Rewrite\" url=\"Index.html\" />");
            fp.WriteLine("</rule>");

            fp.WriteLine("<rule name=\"Imported Rule " + i++.ToString() + "\" stopProcessing=\"true\">");
            fp.WriteLine("<match url=\"mentalhealth_ourteam.html.*\" />");
            fp.WriteLine("<action type=\"Rewrite\" url=\"courtofprotection_ourteam.html\" />");
            fp.WriteLine("</rule>");

            fp.WriteLine("<rule name=\"Imported Rule " + i++.ToString() + "\" stopProcessing=\"true\">");
            fp.WriteLine("<match url=\"High-net-worth-individuals.html.*\" />");
            fp.WriteLine("<action type=\"Rewrite\" url=\"/High-net-worth-divorce.html\" />");
            fp.WriteLine("</rule>");

            fp.WriteLine("<rule name=\"Imported Rule " + i++.ToString() + "\" stopProcessing=\"true\" patternSyntax=\"ExactMatch\">");
            fp.WriteLine("<match url=\"careers\" />");
            fp.WriteLine("<action type=\"Rewrite\" url=\"careers.html\" />");
            fp.WriteLine("</rule>");


            fp.WriteLine("<rule name=\"Imported Rule " + i++.ToString() + "\" stopProcessing=\"true\" patternSyntax=\"ExactMatch\">");
            fp.WriteLine("<match url=\"childcare_CourtPowers.html.*\" />");
            fp.WriteLine("<action type=\"Rewrite\" url=\"childcare_CareOrder.html\" />");
            fp.WriteLine("</rule>");


            fp.WriteLine("<rule name=\"Imported Rule " + i++.ToString() + "\" stopProcessing=\"true\" patternSyntax=\"ExactMatch\">");
            fp.WriteLine("<match url=\"childcare_kinship.html.*\" />");
            fp.WriteLine("<action type=\"Rewrite\" url=\"Kinship-Care.html\" />");
            fp.WriteLine("</rule>");

            fp.WriteLine("<rule name=\"Imported Rule " + i++.ToString() + "\" stopProcessing=\"true\" patternSyntax=\"ExactMatch\">");
            fp.WriteLine("<match url=\"Children-Court-Orders.html.*\" />");
            fp.WriteLine("<action type=\"Rewrite\" url=\"Specific-Issue-Orders.html\" />");
            fp.WriteLine("</rule>");

            fp.WriteLine("<rule name=\"Imported Rule " + i++.ToString() + "\" stopProcessing=\"true\" patternSyntax=\"ExactMatch\">");
            fp.WriteLine("<match url=\"Residence-Orders.html.*\" />");
            fp.WriteLine("<action type=\"Rewrite\" url=\"Child-Arrangement-Orders.html\" />");
            fp.WriteLine("</rule>");


            fp.WriteLine("<rule name=\"Imported Rule " + i++.ToString() + "\" stopProcessing=\"true\" patternSyntax=\"ExactMatch\">");
            fp.WriteLine("<match url=\"branchLocator_DL_WithMap.aspx.*\" />");
            fp.WriteLine("<action type=\"Rewrite\" url=\"findus.html\" />");
            fp.WriteLine("</rule>");
            

            //fp.WriteLine("<rule name=\"Imported Rule " + i++.ToString() + "\" stopProcessing=\"true\" patternSyntax=\"ExactMatch\">");
            //fp.WriteLine("<match url=\"https://duncanlewis.co.uk/\" />");
            //fp.WriteLine("<action type=\"Rewrite\" url=\"https://www.duncanlewis.co.uk/\" />");
            //fp.WriteLine("</rule>");

            fp.Close();
        }


        public static void htaccessstaffold(string path = "C:\\Inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\htaccessOldLinksRedirections.txt")
        {
            //List<Website_Department_Structure> WDS = new List<Website_Department_Structure>();
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            HRDDLEntities dbhr = new HRDDLEntities();
            List<string> departments_aol = db.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").Select(x => x.Name).ToList();

            List<nameanddate> NameAndDate = dbhr.Database.SqlQuery<nameanddate>("select  forename + ' ' + surname as name, Max(end_date) as date_time  from hrd.Emp_Details  where end_Date < getdate() and admin_staff <> '1' and forename + ' ' + surname not in (select forename + ' ' + surname from hrd.Emp_Details  where end_Date > getdate() or end_date is null and admin_staff <> '1') and forename + ' ' + surname not like '%1%' and forename + ' ' + surname not like '%2%' and forename + ' ' + surname not like '%3%' and forename + ' ' + surname not like '% old%' and forename + ' ' + surname not like '%Consultant%' and end_date > '01/01/2010' group by forename + ' ' + surname").ToList();


            List<Emp_Details> ed3 = new List<Emp_Details>();
            foreach (var item in NameAndDate)
                ed3.Add(dbhr.Emp_Details.Where(x => x.end_date == item.date_time && x.forename + " " + x.surname == item.name).FirstOrDefault());

            List<Emp_Details> ed1;
            ed1 = ed3.Where(x => (departments_aol.Contains(x.department_it))).OrderBy(x => x.forename).ToList();

            StreamWriter fp;
            fp = File.CreateText(path);
            int i = 1;
            List<string> parseded1 = new List<string>();
            foreach (Emp_Details ed2 in ed1)
            {

                string Name = ed2.forename + " " + ed2.surname;
                parseded1.Add(Name);
                DepartmentDetails DD = new DepartmentDetails(ed2.department_it);
                string rewriteurllink = allStatic.getOldRewriteUrlLinkForStaff(ed2);

                fp.WriteLine("Redirect 301 /" + rewriteurllink + " https://www.duncanlewis.co.uk/" + ed2.department_it.Replace(" ", "") + "_ourteam.html");

                string rewriteurllinknew = allStatic.getRewriteUrlLinkForStaff(ed2);
                fp.WriteLine("Redirect 301 /" + rewriteurllinknew + " https://www.duncanlewis.co.uk/" + ed2.department_it.Replace(" ", "") + "_ourteam.html");

                i++;
                //fp.WriteLine("RewriteRule " + rewriteurllink + "/ " + DD.folderteam1 + "/" + Name.Replace(" ", "_") + ".html [NC,L]");
            }
            fp.Close();
        }


        public class nameanddate
        {
            public string name { get; set; }
            public DateTime date_time { get; set; }
        }

        public static string getRewriteUrlLinkForStaff(Emp_Details _Empdetails)
        {
            string Name = _Empdetails.forename + ' ' + _Empdetails.surname;
            string Jobtitle = filterjobtitle(_Empdetails);
            string jobtitle1 = "";

            if (Jobtitle == "High Court Advocate" || Jobtitle == "Freelance Consultant" || Jobtitle == "Partner" || Jobtitle == "Supervisor" || Jobtitle == "Solicitor")
                jobtitle1 = "Solicitor";
            else if (Jobtitle == "Caseworker" || Jobtitle == "Trainee Solicitor")
                jobtitle1 = "Lawyer";
            else
                jobtitle1 = Jobtitle;
            string url = "";

            //url = Name.ToString().Replace(" ", "-") + "-" + _Empdetails.department_it.ToString().Replace(" ", "-") + "-" + jobtitle1 + "-" + _Empdetails.Office.office_name.Replace(" ", "-") + "-" + (_Empdetails.Office.county == null ? "" : _Empdetails.Office.county.ToString().Replace(" ", "-"));
            url = Name.ToString().Replace(" ", "-") + "-" + _Empdetails.department_it.ToString().Replace(" ", "-") + "-" + jobtitle1 + "-" + _Empdetails.Office.office_name.Replace(" ", "-") + "-";
            url = url.Replace("(", "").Replace(")", "");
            return url;
        }


        public static string getOldRewriteUrlLinkForStaff(Emp_Details _Empdetails)
        {
            string Name = _Empdetails.forename + ' ' + _Empdetails.surname;
            string Jobtitle = filterjobtitle(_Empdetails);
            string jobtitle1 = "";

            if (Jobtitle == "High Court Advocate" || Jobtitle == "Freelance Consultant" || Jobtitle == "Partner" || Jobtitle == "Supervisor" || Jobtitle == "Solicitor")
                jobtitle1 = "Solicitor";
            else if (Jobtitle == "Caseworker" || Jobtitle == "Trainee Solicitor")
                jobtitle1 = "Lawyer";
            else
                jobtitle1 = Jobtitle;
            string url = "";

            url = _Empdetails.department_it.ToString().Replace(" ", "") + "_ourteam/" + Name.ToString().Replace(" ", "_") + ".html";
            return url;
        }

        public static StringBuilder replacelinespacewithbr(StringBuilder SB)
        {
            SB.Replace("^", "'").Replace(". " + (char)13, ".<br /><br />");
            SB.Replace("." + (char)13, ".<br /><br />");
            return SB;
        }


        public static StringBuilder replacekeywordswithlinks(StringBuilder SB)
        {
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            List<Website_Pages> WP = new List<Website_Pages>();
            WP = db.Website_Pages.Where(x => x.Department == "Immigration" || x.Department == "Business Immigration").ToList();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (Website_Pages _Wp in WP)
            {
                if (_Wp.Name.Contains("Tier") == true && _Wp.Name.Contains("Visa"))
                {
                    _Wp.Name = _Wp.Name.Replace(" Visa", "");
                }
                dict.Add(_Wp.Filename, _Wp.Name);
            }

            //dict.Add("Immigration.html", " Immigration ");

            dict.Add("fees_publicfunding.html", "Legal Aid");

            dict.Add("Immigration_asylum.html", "Human Rights");


            dict.Add("immigration_advocacy.html", "Advocacy");

            dict.Add("Immigration_Indefinite_Leave.html", "ILR");

            dict.Add("immigration_settling.html", " Settling ");

            dict.Add("Immigration_Naturalisation.html", " Naturalisation ");

            dict.Add("immigration_Businesses.html", " Businesses ");

            foreach (var d1 in dict)
            {
                SB.Replace(d1.Value, "<a href=\"" + d1.Key.ToString() + "\" target=\"_blank\">" + d1.Value.ToString() + "</a>");
            }
            return SB;
        }

        public static Dictionary<string, StringBuilder> languagestringforprofiles(string language1, string language2, string language3)
        {
            StringBuilder Description = new StringBuilder();
            StringBuilder Keywords = new StringBuilder();
            for (int i = 1; i <= 3; i++)
            {
                string language = "";
                if (i == 1 && language1 != null)
                    language = language1;
                else if (i == 2 && language2 != null)
                    language = language2;
                else if (i == 3 && language3 != null)
                    language = language3;

                if ((language.ToString().Length > 2) && (language.ToLower() != "none") && (language.ToLower() != "None") && (language != "English") && (language != "Select language"))
                {
                    Description.Append(", " + language);
                    Keywords.Append(language + " speaking Solicitor, " + language + " speaking lawyer, ");
                }
            }
            Dictionary<string, StringBuilder> KD = new Dictionary<string, StringBuilder>();
            KD.Add("Description", Description);
            KD.Add("Keywords", Keywords);
            return KD;
        }

        public static string refinenewarticlelink(string link)
        {
            return link.Replace("?", "").Replace(":", "").Replace("-", "").Replace("^", "").Replace(" ", "_").Replace("/", "").Replace("'", "").Replace("%", "").Replace("&", "");
        }
        public static string achievementlogos(string Name)
        {
            string achievementlogos = "";
            if (Name == "Vinita Templeton" || Name == "Heather Iqbal Rayner" || Name == "Adam Tear" || Name == "James Packer" || Name == "Seher Toguz" || Name == "Toufique Hossain" || Name == "Angela Smith" || Name == "Aina Khan" || Name == "Bernadette P E Sylvester" || Name == "Dianne Cowie" || Name == "James de Vere Moss" || Name == "S K Sivapunniyam" || Name == "Vanessa Delgado" || Name == "Vicash Ramkissoon" || Name == "Kaajal Chandrasingh")
            {
                achievementlogos = achievementlogos + "<img src=\"http://www.legal500.com/assets/images/recommended/UK_recommended_lawyer_2015.jpg\" alt=\"The Legal 500 - The Clients Guide to Law Firms\" width=\"100px\">";
            }

            if (Name == "Vinita Templeton" || Name == "James Packer" || Name == "Toufique Hossain" || Name == "Adam Tear" || Name == "S K Sivapunniyam" || Name == "Aina Khan" || Name == "Hardeep Dhaliwal" || Name == "Vicash Ramkissoon")
            {
                achievementlogos = achievementlogos + "<img src=\"../images/L500 UK_recommended_lawyer_2014.jpg\" alt=\"Duncan Lewis\" width=\"100px\"/></p>";
            }


            if (Name == "Rubin Italia")
            {
                achievementlogos = achievementlogos + "<img src=\"../images/Chambers-Rubin.jpg\" alt=\"Duncan Lewis\" width=\"100px\"/>";
            }
            if (Name == "James Packer")
            {
                achievementlogos = achievementlogos + "<img src=\"../images/Chambers-James.jpg\" alt=\"Duncan Lewis\" width=\"100px\"/><br /><br />";
                achievementlogos = achievementlogos + "<img src=\"http://www.legal500.com/assets/images/recommended/UK_recommended_lawyer_2012.jpg\" alt=\"The Legal 500 - The Clients Guide to Law Firms\" width=\"100px\">";
            }

            if (Name == "Jason Bruce")
            {
                achievementlogos = achievementlogos + "<img src=\"http://www.legal500.com/assets/images/recommended/UK_recommended_lawyer_2012.jpg\" alt=\"The Legal 500 - The Clients Guide to Law Firms\" width=\"100px\">";
            }
            return achievementlogos;
        }

        public static List<SubDepartmentListModel> CreateSubDepartmentList()
        {
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            DLWEBEntities dbweb = new DLWEBEntities();
            List<SubDepartmentListModel> subDepartmentListModel = new List<SubDepartmentListModel>();
            //Adding SubDepartments from Website Pages
            List<Website_Pages> WP = dbit.Website_Pages.Where(x => x.CustomSubDepartment != null && x.CustomSubDepartment != "").ToList();
            List<SubDepartmentListModel> WPList = new List<SubDepartmentListModel>();
            foreach (var item in WP)
                WPList.Add(new SubDepartmentListModel() { Department = (item.CustomDepartment == "" || item.CustomDepartment == null) ? item.Department : item.CustomDepartment.Replace("&","and").Replace("\\","-") , SubDepartment = item.CustomSubDepartment.Replace("&", "and").Replace("\\", "-") });

            subDepartmentListModel = WPList.GroupBy(y => new { y.Department, y.SubDepartment }).Select(x => new SubDepartmentListModel { SubDepartment = x.Key.SubDepartment.Replace("&", "and").Replace("\\", "-"), Department = x.Key.Department.Replace("&","and").Replace("\\","-") }).ToList();

            List<Website_Structure> WS = dbit.Website_Structure.Where(x => x.level != "ContentNode" && x.SubDepartment == true).ToList();
            List<SubDepartmentListModel> WSList = new List<SubDepartmentListModel>();

            foreach (var item in WS)
               WSList.Add(new SubDepartmentListModel() { Department = (item.NewNameForDepartment == "" || item.NewNameForDepartment == null) ? item.dept : item.NewNameForDepartment, SubDepartment = (item.NewNameForSubDepartment == "" || item.NewNameForSubDepartment == null) ?  item.name : item.NewNameForSubDepartment });

            //Adding SubDepartments from Website Structure
            subDepartmentListModel.AddRange(WSList.GroupBy(x => new { x.Department, x.SubDepartment }).Select(y => new SubDepartmentListModel { SubDepartment = y.Key.SubDepartment.Replace("&", "and").Replace("\\", "-"), Department = y.Key.Department.Replace("&", "and").Replace("\\", "-") }).ToList());


            //Adding SubDepartments not on website
            subDepartmentListModel.AddRange(dbit.Website_Custom_SubDepartments.Select(x => new SubDepartmentListModel { Department = x.Department.Replace("&", "and").Replace("\\", "-"), SubDepartment = x.SubDepartment.Replace("&", "and").Replace("\\", "-") }).ToList());



            foreach (var item in dbweb.SubDepartments)
                dbweb.SubDepartments.Remove(item);

            foreach (var item in subDepartmentListModel)
            {
                dbweb.SubDepartments.Add(new SubDepartment { Department = item.Department.Replace("&", "and").Replace("/", "and"), SubDepartment1 = item.SubDepartment.Replace("&", "and").Replace("/", "and") });
                dbweb.SaveChanges();
            }
            
            return subDepartmentListModel;
        }



        public static DataTable readexcelasdatatable(string filepath, string worksheet, string querystring = null)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + "; Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;MAXSCANROWS=0'";
            OleDbConnection con = new OleDbConnection(connectionString);
            con.Open();
            string qstring;
            if (querystring != null)
                qstring = querystring;
            else
                qstring = "SELECT * FROM [" + worksheet + "$]";

            OleDbCommand cmd = new OleDbCommand(qstring, con);
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            cmd = null;
            con.Close();
            return dt;
        }


        public static string SubDepartmentSwitchboard()
        {
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            DLWEBEntities dbweb = new DLWEBEntities();
            List<SubDepartmentListModel> subDepartmentListModel = new List<SubDepartmentListModel>();
            //Adding SubDepartments from Website Pages
            List<Website_Pages> WP = dbit.Website_Pages.Where(x => x.CustomSubDepartment != null && x.CustomSubDepartment != "").ToList();
            List<SubDepartmentListModel> WPList = new List<SubDepartmentListModel>();
            foreach (var item in WP)
                WPList.Add(new SubDepartmentListModel() { Department = (item.CustomDepartment == "" || item.CustomDepartment == null) ? item.Department : item.CustomDepartment.Replace("&", "and").Replace("\\", "-"), SubDepartment = item.CustomSubDepartment.Replace("&", "and").Replace("\\", "-") });

            subDepartmentListModel = WPList.GroupBy(y => new { y.Department, y.SubDepartment }).Select(x => new SubDepartmentListModel { SubDepartment = x.Key.SubDepartment.Replace("&", "and").Replace("\\", "-"), Department = x.Key.Department.Replace("&", "and").Replace("\\", "-") }).ToList();

            List<Website_Structure> WS = dbit.Website_Structure.Where(x => x.level != "ContentNode" && x.SubDepartment == true).ToList();
            List<SubDepartmentListModel> WSList = new List<SubDepartmentListModel>();

            foreach (var item in WS)
                WSList.Add(new SubDepartmentListModel() { Department = (item.NewNameForDepartment == "" || item.NewNameForDepartment == null) ? item.dept : item.NewNameForDepartment, SubDepartment = (item.NewNameForSubDepartment == "" || item.NewNameForSubDepartment == null) ? item.name : item.NewNameForSubDepartment });

            //Adding SubDepartments from Website Structure
            subDepartmentListModel.AddRange(WSList.GroupBy(x => new { x.Department, x.SubDepartment }).Select(y => new SubDepartmentListModel { SubDepartment = y.Key.SubDepartment.Replace("&", "and").Replace("\\", "-"), Department = y.Key.Department.Replace("&", "and").Replace("\\", "-") }).ToList());


            //Adding SubDepartments not on website
            subDepartmentListModel.AddRange(dbit.Website_Custom_SubDepartments.Select(x => new SubDepartmentListModel { Department = x.Department.Replace("&", "and").Replace("\\", "-"), SubDepartment = x.SubDepartment.Replace("&", "and").Replace("\\", "-") }).ToList());



            foreach (var item in dbit.SubDepartmentSwitchboards)
                dbit.SubDepartmentSwitchboards.Remove(item);

            foreach (var item in subDepartmentListModel)
            {
                dbit.SubDepartmentSwitchboards.Add(new SubDepartmentSwitchboard { Department = item.Department.Replace("&", "and").Replace("/", "and"), SubDepartment = item.SubDepartment.Replace("&", "and").Replace("/", "and"), SubDepartmentDisplay = item.Subdepartment_Switchboard != null ? item.Subdepartment_Switchboard.Replace("&", "and").Replace("/", "and") : "" });
                dbit.SaveChanges();
            }
            return "";
        }

    }

    public class SubDepartmentListModel{
        public string SubDepartment { get; set; }
        public string Department { get; set; }
        public string Subdepartment_Switchboard { get; set; }
    }

    public class embeddedImagelist
    {
        public string path { get; set; }
        public string contentid { get; set; }
        public mimetype _mimetype { get; set; }
    }

    public enum HomePagetype
    {
        Main,
        Private,
        LegalAid,
        Corporate
    }


    public enum mimetype
    {
        GIF,
        JPEG,
        PNG
    }
}
