using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DLCMS.Controllers
{
    public class StaffListController : BaseApiController
    {
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<string> Get(string ID)
        {
            List<string> ls = new List<string>();
            ls = stafflist.Where(x => x.forename.StartsWith(ID)).ToList().Select(x => x.forename + ' ' + x.surname).ToList();
            return ls;
        }
    }
}
