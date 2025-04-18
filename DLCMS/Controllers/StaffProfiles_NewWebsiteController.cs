﻿using System;
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

        public override void PolulateList()
        {
            using (var _subDepartmentProfileStructureService = new SubDepartmentProfileStructureService())
            {
                var _subDepartmentProfileStructureList = _subDepartmentProfileStructureService.GetAll().Where(x => x.Enabled == true).Select(x => new SelectListItem() { Text = x.SubDepartment, Value = x.Id.ToString() }).ToList();
                _subDepartmentProfileStructureList.Add(new SelectListItem() { Text = "All", Value = "0" });
                ViewBag.SubDepartments = new SelectList(_subDepartmentProfileStructureList, "Value", "Text");
            }
        }

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

        public ActionResult CreateStaffProfilesSubDepartments(string Category, int SubDepartmentProfileStructureId)
        {
            if (Category == "Team Pages" || Category == "Both")
            {
                AContents NAL;
                IT_DatabaseEntities dbit = new IT_DatabaseEntities();
                var _approveSubDepartmentProfiles = dbit.SubDepartmentProfiles.Where(x => x.Approve == true && ((x.ApprovedProfile != null && x.ApprovedProfile != "" && x.ApprovedProfile.Length > 20) || x.SubDepartmentProfileStructure.UseMainProfile == true)).AsQueryable();
                var _approvedProfilesSubDepartmentsNamesList = new List<string>();
                if (SubDepartmentProfileStructureId == 0)
                    _approvedProfilesSubDepartmentsNamesList = _approveSubDepartmentProfiles.GroupBy(x => x.SubDepartmentProfileStructure.SubDepartment).Select(x => x.Key).ToList();
                else
                    _approvedProfilesSubDepartmentsNamesList = _approveSubDepartmentProfiles.Where(x => x.SubDepartmentProfileStructureId == SubDepartmentProfileStructureId).GroupBy(x => x.SubDepartmentProfileStructure.SubDepartment).Select(x => x.Key).ToList();

                foreach (var _approvedProfilesSubDepartment in _approvedProfilesSubDepartmentsNamesList)
                {
                    var _dept = dbit.SubDepartmentProfileStructures.Where(x => x.SubDepartment == _approvedProfilesSubDepartment).Select(x => x.Department1).FirstOrDefault();
                    NAL = new Content_TeamPages_NewWebsite(_dept, true, _approvedProfilesSubDepartment);
                    CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
                }
            }

            if (Category == "Profile Pages" || Category == "Both")
            {
                AContents NAL;
                IT_DatabaseEntities dbit = new IT_DatabaseEntities();
                HRDDLEntities dbhr = new HRDDLEntities();
                List<int> _excludedWebsiteStructureIds = dbit.SubDepartmentProfileStructures.Where(x => x.UseMainProfile == true).Select(x => x.Id).ToList();
                var _subDepartmentProfiles = new List<SubDepartmentProfile>();
                if (SubDepartmentProfileStructureId == 0)
                    _subDepartmentProfiles = dbit.SubDepartmentProfiles.Where(x => x.ApprovedProfile != null && !_excludedWebsiteStructureIds.Contains(x.SubDepartmentProfileStructureId ?? 0) && x.ApprovedProfile.Length > 20).ToList();
                else
                    _subDepartmentProfiles = dbit.SubDepartmentProfiles.Where(x => x.ApprovedProfile != null && !_excludedWebsiteStructureIds.Contains(x.SubDepartmentProfileStructureId ?? 0) && x.ApprovedProfile.Length > 20 && x.SubDepartmentProfileStructureId == SubDepartmentProfileStructureId).ToList();

                var _employedStaffEmpCodes = dbhr.Emp_Details.Where(x => x.employed == "1").Select(x => x.emp_code).ToList();
                foreach (var staff in _subDepartmentProfiles.Where(x => _employedStaffEmpCodes.Contains(x.emp_code)))
                {
                    NAL = new Content_StaffProfileNewWebsite(staff.emp_code, false, staff.SubDepartmentProfileStructure.Department1, staff.SubDepartmentProfileStructure.SubDepartment);
                    CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
                }
            }
            return View("Index");
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
                    IT_DatabaseEntities db = new IT_DatabaseEntities();
                    var _date = DateTime.Now.Date;
                    var _staffProfilescreatedtoday = db.StaffProfilesCreatedLogs.Where(x => x.date_created == _date).Select(x => x.emp_code).ToList();
                    AContents NAL;
                    foreach (Emp_Details staffmember in stafflist.Where(x => !_staffProfilescreatedtoday.Contains(x.emp_code)))
                    {
                        //DepartmentDetails dd = new DepartmentDetails(staffmember.department_it);
                        //if (System.IO.File.Exists("C:\\Inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\" + dd.folderteam1 + "\\" + staffmember.forename.Replace(" ", "_") + "_" + staffmember.surname.Replace(" ", "_") + ".html") == false)
                        //{
                        NAL = new Content_StaffProfileNewWebsite(staffmember.emp_code);
                        CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
                        StaffProfilesCreatedLog staffProfilesCreatedLog = new StaffProfilesCreatedLog() { emp_code = staffmember.emp_code, date_created = _date };
                        db.StaffProfilesCreatedLogs.Add(staffProfilesCreatedLog);
                        db.SaveChanges();
                        //}
                    }
                }

                if ((cbo_Type == "Team Pages") || (cbo_Type == "Both Pages"))
                {
                    AContents NAL1;
                    foreach (string dept in staffdeptlist.Where(x => x != "Data Claims"))
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

        public ActionResult CreateHTAccess()
        {
            allStatic.htaccessstaff();
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
            List<string> excludednames = new List<string>() { "Ajit Lamba", "Lubna Chauhan", "Ritu Sharma", "Robert Poulter", "Sangita Shah", "Sonal Ruparelia", "Nina Joshi" };
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