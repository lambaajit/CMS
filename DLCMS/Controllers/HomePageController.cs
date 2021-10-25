using dlwebclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLCMS.Controllers
{
    public class HomePageController : Controller
    {
        //
        // GET: /HomePage/
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult createHomePage()
        {
            for (int i = 1; i <= 4; i++)
            {
                HomePagetype htype;
                if (i == 1)
                {
                    htype = HomePagetype.Main;
                }
                else if (i == 2)
                {
                    htype = HomePagetype.Private;
                }
                else if (i == 3)
                {
                    htype = HomePagetype.LegalAid;
                }
                else
                {
                    htype = HomePagetype.Corporate;
                }
                Content_HomePage NAL = NAL = new Content_HomePage(htype);
                CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
                Fl.Create_MainNavigation();
            }

            
            
            return View("Index");
        }
	}
}