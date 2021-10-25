using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;

namespace DLCMS.Controllers
{
    public class ValidationController : BaseController
    {
        //
        // GET: /Validation/
        public ActionResult CheckStaffName(string Staff1)
        {
            string fieldName = Request.QueryString.Keys[0];
            string staff = Request.QueryString[fieldName];

            List<Emp_Details> ls = new List<Emp_Details>();
            ls = stafflist.Where(x => x.forename + ' ' + x.surname == staff).ToList();
            if (ls.Count > 0)
                return Json(true, JsonRequestBehavior.AllowGet);
            else
                return Json(false, JsonRequestBehavior.AllowGet);
        }
	}
}