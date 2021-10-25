using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLCMS.Models
{
    public class PhotoMissingVM
    {
        public int Sno { get; set; }

        public string Forename { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Office { get; set; }
        public string Department { get; set; }
        public string Director { get; set; }

        public string Directormail { get; set; }
        public bool Picture_Website { get; set; }
        public bool Request_Submitted { get; set; }
        public DateTime? JoiningDate { get; set; }

    }
}