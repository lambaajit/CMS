using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLCMS.Models;

namespace DLCMS.Controllers
{
    public class MissingProfilesController : Controller
    {
        public ActionResult Index(string id, string company = null)
        {
            List<MissingStaffList> ed = new List<MissingStaffList>();
            dlwebclasses.CheckMissingProfiles _mp = new dlwebclasses.CheckMissingProfiles();
            List<dlwebclasses.Emp_Details> mp = new List<dlwebclasses.Emp_Details>();
            if (id == "Photos")
            {
                mp = _mp.getmissingphotographs(company).OrderBy(x => x.forename).ToList();
                ViewBag.category = "Photos";
                //foreach (var item in mp.Skip(100).Take(10))
                //{
                //        sendemailforphoto(item);
                //}
            }
            else
            {
                mp = _mp.getmissingprofiles(company);
                ViewBag.category = "Profiles";
            }
            foreach (dlwebclasses.Emp_Details _ed in mp.OrderBy(x => x.bb_given).ThenBy(y => y.start_date))
            {
                MissingStaffList msl = new MissingStaffList();
                msl.staffname = _ed.forename.ToString() + " " + _ed.surname.ToString();
                msl.JobTitle = _ed.jobtitle;
                msl.Department = _ed.department_it;
                msl.StartDate = _ed.start_date.Value.ToShortDateString();
                msl.Supervisor = _ed.recruitmanager;
                msl.Status = _ed.bb_given;
                msl.employment_Status = _ed.emp_status;
                msl.office_name = _ed.Office.office_name;
                ed.Add(msl);
            }
            return View(ed.OrderBy(x => x.staffname));
        }


        public void sendemailforphoto(dlwebclasses.Emp_Details emp_Details)
        {
            if (emp_Details.email != null && emp_Details.email.Contains("@") && emp_Details.Picture_website == true)
            {
                string msg = "Dear " + emp_Details.forename + ", <br /><br />" +
"Our records indicate that we do not have your photograph to use on your profile page on DL website and Intranet. We normally take everyone’s photograph in-house on the first day of you starting your employment. However, for the past few months, induction is being carried out remotely which prevented us from taking photographs in-house.<br /><br />" +
"If you have a professionally taken photograph or a decent quality photograph that we can use, please do send it over to me by email urgently and we will try and use it on DL website and intranet.<br /><br />" +
"Any photograph that you send must be in high resolution, preferably taken using a SLR camera or in a studio. <br /><br />" +
"Unfortunately, we will not be able to use any photographs that were taken using a mobile phone.<br /><br />" +
"We understand not everyone will have a high resolution photograph readily available. If this is the case, please can you confirm if it is possible to visit Harrow office on 5th October between 10.00AM and 12.00 Noon so that I can set up a studio and take pictures?<br /><br />" +
"I might be able to take pictures in Birmingham office too.If this is more convenient for you, please do let me know and I will fix a day in October.<br /><br />" +
"If you live outside London, please let me know which office is closer to you and I will see what we can do. <br /><br />Regards<br /><br />Ajit Lamba";


                dlwebclasses.allStatic.sendemail(emp_Details.email, "ajitl@duncanlewis.com", "Your Photo for the Website and Intranet", msg,null,new List<string> { "ajitl@duncanlewis.com"});
                //dlwebclasses.allStatic.sendemail("ajitl@duncanlewis.com", "ajitl@duncanlewis.com", "Your Photo for the Website and Intranet", msg);
            }
        }
    }
}
