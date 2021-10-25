using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DLCMS.Models;

namespace DLCMS.Controllers
{
    public class SubDepartmentApiController : BaseApiController
    {
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<string> Get(string ID)
        {
            List<string> ls = new List<string>();
            DLCMS_ITDatabase db = new DLCMS_ITDatabase();
            ls = db.Database.SqlQuery<string>("SELECT DISTINCT Sub_department FROM  Website_Pages_SubDepartments where department = '" + ID + "' ORDER BY Sub_department").ToList();
            //ls = db.Database.SqlQuery<string>("SELECT        name from Website_Structure where underwhichnode = " + ID + " and [level] <> 'ContentNode' ORDER BY id DESC").ToList();
            return ls;
        }
    }
}
