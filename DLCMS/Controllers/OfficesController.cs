using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;

namespace DLCMS.Controllers
{
    public class OfficesController : Controller
    {
        //
        // GET: /Offices/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createoffices()
        {
            DLWEBEntities dbo = new DLWEBEntities();
            List<OfficeDLW> offices = new List<OfficeDLW>();
            offices = dbo.OfficesDLW.Where(x => x.Company == "Duncan Lewis" || x.Company == "Both").ToList();
            Content_Offices_NewWebsite NAL;
            foreach (var item in offices)
            {
                NAL = new Content_Offices_NewWebsite(item.ID);
                CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult createofficelandingpage()
        {
            DLWEBEntities dbo = new DLWEBEntities();
            //List<OfficeDLW> offices = new List<OfficeDLW>();
            //offices = dbo.OfficesDLW.Where(x => x.Active == true).ToList();
            Content_OfficesLanding_NewWebsite NAL;
            for (int i = 1; i <= 3; i++)
            {
                NAL = new Content_OfficesLanding_NewWebsite(i);
                CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
            }
            return View("Index");
        }
        public ActionResult createcostlawofficepage()
        {
            Content_CostLawOfficespages NAL;
            DLWEBEntities db = new DLWEBEntities();
            
            var Off = db.OfficesDLW.Where(x => x.Active == true && (x.Company == "Cost Law" || x.Company == "Both")).ToList();
            foreach (var Office in Off)
            {
                NAL = new Content_CostLawOfficespages(Office.ID);
                CreateHTMLFiles_CostLaw Fl = new CreateHTMLFiles_CostLaw(NAL);
            }
            return View("Index");
        }
}
}