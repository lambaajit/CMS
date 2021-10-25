using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DLCMS.Controllers
{
    public class AllAPIsController : BaseApiController
    {
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<string> Get(string ID)
        {
            List<string> ls = new List<string>();
            if (ID == "DL")
            {
                ls = newsarticlesdeptlist;
                ls.Remove("Legal News");
                ls.Remove("InThePress");
                ls.Remove("Reported Case");
            }
            else if (ID == "NonDL")
            {
                ls = newsarticlesdeptlist;
                ls.Remove("Reported Case");
                ls.Remove("Campaign");
                ls.Remove("InThePress");
                ls.Remove("Main");
            }
            else if (ID == "Reported Case")
            {
                ls.Add("Reported Case");
            }
            else if (ID == "InThePress")
            {
                ls.Add("InThePress");
            }
                return ls;
        }

        
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}