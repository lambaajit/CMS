using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using dlwebclasses;

namespace DLCMS.Controllers
{
    public class BaseApiController : ApiController
    {
        //
        // GET: /BaseApi/
        
        public List<string> newsarticlesdeptlist = new List<string>();
        public List<string> staffdeptlist = new List<string>();
        public List<Emp_Details> stafflist = new List<Emp_Details>();
        public List<string> categories = new List<string>();
        public List<string> _months = new List<string>();
        public List<string> webpagesdeptlist = new List<string>();

        public BaseApiController()
        {
            Dropdownlistvalues dv = new Dropdownlistvalues();
            dv.getvalues();
            webpagesdeptlist = dv.webpagesdeptlist;
            newsarticlesdeptlist = dv.newsarticlesdeptlist;
            staffdeptlist = dv.staffdeptlist;
            stafflist = dv.stafflist;
            categories = dv.categories;
            _months = dv._months;
            //return dv.getvalues();
        }
	}
}