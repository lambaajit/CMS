using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;

namespace DLCMS.Controllers
{
    public class VideosController : Controller
    {
        //
        // GET: /Offices/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createVideos()
        {
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            List<int> ids = dbit.Website_Videos.Select(z => z.id).ToList();
            Content_Video_NewWebsite NAL;
            foreach (var item in ids)
            {
                NAL = new Content_Video_NewWebsite(item);
                CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult createVideoslandingpage()
        {
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            List<string> depts = dbit.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw" || x.Name == "Careers").OrderBy(y => y.Name).Select(z => z.Name).ToList();
            depts.Add("All");
            Content_VideoslandingPage_NewWebsite NAL;
            foreach (var item in depts)
            {
                NAL = new Content_VideoslandingPage_NewWebsite(item);
                CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
            }
            return View("Index");
        }
	}
}