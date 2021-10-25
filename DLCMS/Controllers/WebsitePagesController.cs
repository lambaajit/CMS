using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;


namespace DLCMS.Controllers
{
    public class WebsitePagesController : BaseController
    {
        //
        // GET: /WebsitePages/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createwebsitepages(string cbo_WebPagedept)
        {
            if (cbo_WebPagedept == "All")
            {
                
                foreach (string str in webpagesdeptlist)
                {
                    cwp(int.Parse(str));
                }
            }
            else
            {
                cwp(int.Parse(cbo_WebPagedept));
            }
            return View("Index");
        }

        public void cwp(int dept)
        {
            Content_WebsitePages NAL;
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            string deptname = db.Website_Structure.Where(x => x.id == dept).Select(y => y.name).FirstOrDefault();
            List<Website_Pages> WP = new List<Website_Pages>();
            WP = db.Website_Pages.Where(x => x.Department == deptname).ToList();
            foreach (Website_Pages _WP in WP)
            {
                NAL = new Content_WebsitePages(_WP.ID);
                CreateHTMLFiles Fl = new CreateHTMLFiles(NAL);
            }
        }
	}
}