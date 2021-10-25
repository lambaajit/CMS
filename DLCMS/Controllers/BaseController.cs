using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;
using System.Globalization;

namespace DLCMS.Controllers
{
    public class BaseController : Controller
    {
        public List<string> newsarticlesdeptlist = new List<string>();
        public List<string> staffdeptlist = new List<string>();
        public List<Emp_Details> stafflist = new List<Emp_Details>();
        public List<string> categories = new List<string>();
        public List<string> _months = new List<string>();
        public List<string> webpagesdeptlist = new List<string>();

        public BaseController()
        {

            Dropdownlistvalues dv = new Dropdownlistvalues();
            ViewBag.Dict = dv.getvalues();
            newsarticlesdeptlist = dv.newsarticlesdeptlist;
            staffdeptlist = dv.staffdeptlist;
            stafflist = dv.stafflist;
            categories = dv.categories;
            _months = dv._months;
            webpagesdeptlist = dv.webpagesdeptlist;

        }
    }
}