//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DLCMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class website_awards
    {
        public int id { get; set; }
        public string IndividualCompany { get; set; }
        public string StaffName { get; set; }
        public Nullable<int> Year { get; set; }
        public string LegalDirectory { get; set; }
        public string LegalDirectoryArea { get; set; }
        public string LegalDirectoryDepartment { get; set; }
        public string DLOffice { get; set; }
        public string DLDepartment { get; set; }
        public string Blurb { get; set; }
        public string LogosToUse { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
