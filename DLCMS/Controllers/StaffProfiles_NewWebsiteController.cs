using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;
using System.IO;
using dlwebclasses.Contents.StaffProfiles;

namespace DLCMS.Controllers
{
    public class StaffProfiles_NewWebsiteController : BaseController
    {
        //
        // GET: /StaffProfiles/
        public ActionResult Index()
        {
            //List<string> ls = new List<string>();
            //foreach (Emp_Details staffmember in stafflist)
            //{
            //    DepartmentDetails dd = new DepartmentDetails(staffmember.department_it);
            //    if (System.IO.File.Exists("C:\\Inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\" + dd.folderteam1 + "\\" + staffmember.forename.Replace(" ", "_") + "_" + staffmember.surname.Replace(" ", "_") + ".html") == true)
            //    {
            //        ls.Add("<a href=\"http://10.0.5.214:8080/" + dd.folderteam1 + "/" + staffmember.forename.Replace(" ", "_") + "_" + staffmember.surname.Replace(" ", "_") + ".html\" target=\"_blank\">" + staffmember.forename.Replace(" ", "_") + "_" + staffmember.surname.Replace(" ", "_") + "</a>");
            //    }
            //}
            //ViewBag.listlinks = ls;
            return View();
        }

        [HttpPost]
        public ActionResult CreateStaffProfiles(string cbo_StaffList, string cbo_Staffdept, string cbo_Type, bool htaccessfile = false)
        {
            if (cbo_Type == "AlphabeticTeamPages")
            {
                AContents NAL1;
                for (int i = 65; i <= 90; i++)
                {
                    NAL1 = new Content_AlphabeticPages_NewWebsite((char)i);
                    CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL1);
                }
            }
            else if (cbo_Staffdept == "All" && cbo_StaffList == "All")
            {
                if ((cbo_Type == "Both Pages") || (cbo_Type == "Staff Pages"))
                {
                    AContents NAL;
                    foreach (Emp_Details staffmember in stafflist)
                    {
                        //DepartmentDetails dd = new DepartmentDetails(staffmember.department_it);
                        //if (System.IO.File.Exists("C:\\Inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\" + dd.folderteam1 + "\\" + staffmember.forename.Replace(" ", "_") + "_" + staffmember.surname.Replace(" ", "_") + ".html") == false)
                        //{
                        NAL = new Content_StaffProfileNewWebsite(staffmember.emp_code);
                        CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
                        //}
                    }
                }

                if ((cbo_Type == "Team Pages") || (cbo_Type == "Both Pages"))
                {
                    AContents NAL1;
                    foreach (string dept in staffdeptlist)
                    {
                        NAL1 = new Content_TeamPages_NewWebsite(dept);
                        CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL1);
                    }
                }
            }
            else if (cbo_Staffdept != "All" && cbo_StaffList == "All")
            {
                if ((cbo_Type == "Both Pages") || (cbo_Type == "Staff Pages"))
                {
                    AContents NAL;
                    foreach (Emp_Details staffmember in stafflist)
                    {
                        if (staffmember.department_it == cbo_Staffdept)
                        {
                            NAL = new Content_StaffProfileNewWebsite(staffmember.emp_code);
                            CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
                        }
                    }
                    if (cbo_Staffdept == "Management Board")
                    {
                        string[] mgtb = new string[] { "ponnadas", "guptas", "joshin", "BharjM", "Lee-ScotJ20150611", "BruceJ20071122", "DaudD20120209", "RafiqueS20100430" };
                        foreach (string str in mgtb)
                        {
                            NAL = new Content_StaffProfileNewWebsite(str, false, "Management Board");
                            CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
                        }
                    }
                }

                if ((cbo_Type == "Team Pages") || (cbo_Type == "Both Pages"))
                {
                    AContents NAL1;
                    NAL1 = new Content_TeamPages_NewWebsite(cbo_Staffdept);
                    CreateHTMLFIles_NEwWebsite F2 = new CreateHTMLFIles_NEwWebsite(NAL1);
                }
            }
            else if (cbo_StaffList != "All")
            {
                AContents NAL;
                Emp_Details ED = new Emp_Details();
                ED = stafflist.Where(x => x.emp_code == cbo_StaffList).FirstOrDefault();
                NAL = new Content_StaffProfileNewWebsite(ED.emp_code);
                CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
            }

            if ((cbo_Type == "Team Pages" || cbo_Type == "Both Pages") && htaccessfile == true)
                allStatic.htaccessstaff();

            return View("Index");
        }

        public ActionResult CreateOldHTAccess()
        {
            allStatic.htaccessstaffold();
            return View("Index");
        }

        public ActionResult CreateVCFCards()
        {
            VCFCards.generateVCFCards();
            return View("Index");
        }

        public ActionResult CostLawTeamPages()
        {
            AContents NAL1;
            NAL1 = new Content_CostLawTeamPages();
            CreateHTMLFiles_CostLaw F2 = new CreateHTMLFiles_CostLaw(NAL1);
            return View("Index");
        }

        public ActionResult CostLawProfilePages()
        {
            List<string> excludednames = new List<string>() { "Ajit Lamba", "Lubna Chauhan", "Ritu Sharma", "Robert Poulter", "Sangita Shah", "Sonal Ruparelia" };
            HRDDLEntities dbhr = new HRDDLEntities();
            var emplist = dbhr.Emp_Details.Where(x => x.employed == "1" && x.start_date < DateTime.Now && excludednames.Contains(x.forename + " " + x.surname) == false && x.start_date < DateTime.Now && (x.end_date == null || x.end_date > DateTime.Now || x.end_date.Value.ToString().Contains("1900")) && (x.company_name == "Cost Law Services Limited" || x.company_name == "Cost Law Limited")).OrderBy(y => y.forename).ToList();
            foreach (var item in emplist)
            {
                AContents NAL1 = new Content_CostLawStaffProfile(item.emp_code);
                CreateHTMLFiles_CostLaw F2 = new CreateHTMLFiles_CostLaw(NAL1);
            }
            return View("Index");
        }
    }
}