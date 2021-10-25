using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;

namespace DLCMS.Controllers
{
    public class StaffProfilesController : BaseController
    {
        //
        // GET: /StaffProfiles/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStaffProfiles(string cbo_StaffList, string cbo_Staffdept, string cbo_Type)
        {
            if (cbo_Type == "AlphabeticTeamPages")
            {
                AContents NAL1;
                for (int i = 65; i <= 90; i++)
                {
                    NAL1 = new Content_AlphabeticPages((char)i);
                    CreateHTMLFiles Fl = new CreateHTMLFiles(NAL1);
                }
            }
            else if (cbo_Staffdept == "All" && cbo_StaffList == "All")
            {
                if ((cbo_Type == "Both Pages") || (cbo_Type == "Staff Pages"))
                {
                    AContents NAL;
                    foreach (Emp_Details staffmember in stafflist)
                    {
                        NAL = new Content_StaffProfile(staffmember.emp_code);
                        CreateHTMLFiles Fl = new CreateHTMLFiles(NAL);
                    }
                }

                if ((cbo_Type == "Team Pages") || (cbo_Type == "Both Pages"))
                {
                    AContents NAL1;
                    foreach (string dept in staffdeptlist)
                    {
                        NAL1 = new Content_TeamPages(dept);
                        CreateHTMLFiles Fl = new CreateHTMLFiles(NAL1);
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
                            NAL = new Content_StaffProfile(staffmember.emp_code);
                            CreateHTMLFiles Fl = new CreateHTMLFiles(NAL);
                        }
                    }
                    if (cbo_Staffdept == "Management Board")
                    {
                        string[] mgtb = new string[] { "ponnadas", "guptas", "joshin", "BharjM", "Lee-ScotJ20150611", "BruceJ20071122", "DaudD20120209", "RafiqueS20100430" };
                        foreach (string str in mgtb)
                        {
                            NAL = new Content_StaffProfile(str,false,"Management Board");
                            CreateHTMLFiles Fl = new CreateHTMLFiles(NAL);
                        }
                    }
                }

                if ((cbo_Type == "Team Pages") || (cbo_Type == "Both Pages"))
                {
                    AContents NAL1;
                    NAL1 = new Content_TeamPages(cbo_Staffdept);
                    CreateHTMLFiles F2 = new CreateHTMLFiles(NAL1);
                }
            }
            else if (cbo_StaffList != "All")
            {
                AContents NAL;
                Emp_Details ED = new Emp_Details();
                ED = stafflist.Where(x => x.emp_code == cbo_StaffList).FirstOrDefault();
                NAL = new Content_StaffProfile(ED.emp_code);
                CreateHTMLFiles Fl = new CreateHTMLFiles(NAL);
            }

            if ((cbo_Type == "Team Pages") || (cbo_Type == "Both Pages"))
            allStatic.htaccessstaff();

            return View("Index");
        }
	}
}