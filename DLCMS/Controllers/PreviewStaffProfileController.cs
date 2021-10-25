using dlwebclasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLCMS.Controllers
{
    public class PreviewStaffProfileController : Controller
    {
        //
        // GET: /PreviewStaffProfile/
        [HttpGet]
        public ActionResult Edit(string ID)
        {
            ViewBag.staffid = ID;
            return View();
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Editpost(string ID)
        {
            ViewBag.filepath = ConfigurationManager.AppSettings["Rootpath"].ToString() + "\\Preview\\StaffProfile_Preview.html";
            ViewBag.filepathnewwebsite = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Preview\\StaffProfile_Preview.html";
            ViewBag.staffid = ID;
            createpreviewpage(ID);
            createpreviewnewwebsite(ID);
            return View();
        }

        public void createpreviewpage(string ID)
        {
            dlwebclasses.Content_StaffProfile NAL = new dlwebclasses.Content_StaffProfile(ID, true);
            string filepath = ConfigurationManager.AppSettings["Rootpath"].ToString() + "\\Preview\\StaffProfile_Preview.html";
            dlwebclasses.CreateHTMLFiles Fl = new dlwebclasses.CreateHTMLFiles(NAL, filepath);
        }

        public void createpreviewnewwebsite(string ID)
        {
            AContents NAL;
            NAL = new Content_StaffProfileNewWebsite(ID, true);
            string filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Preview\\StaffProfile_Preview.html";
            CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL, filepath);
        }
	}
}