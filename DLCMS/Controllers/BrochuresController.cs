using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;

namespace DLCMS.Controllers
{
    public class BrochuresController : Controller
    {
        // GET: Brochures
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult createBrochures()
        {
            DLWEBEntities dbit = new DLWEBEntities();
            List<int> ids = dbit.Brochures.Select(z => z.ID).ToList();
            Content_Brochures NAL;
            foreach (var item in ids)
            {
                NAL = new Content_Brochures(item);
                CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
            }
            return View("Index");
        }
    }
}