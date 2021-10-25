using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;

namespace DLCMS.Controllers
{
    public class SiteMapController : Controller
    {
        //
        // GET: /SiteMap/
        public ActionResult Index()
        {
            SitemapDL SM = new SitemapDL();
            return View();
        }
	}
}