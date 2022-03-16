using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLCMS.Models
{
    public class MissingStaffList
    {
        public string staffname { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public string Supervisor { get; set; }
        public string Status { get; set; }
        public string employment_Status { get; set; }
        public string office_name { get; set; }

    }
}