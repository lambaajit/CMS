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
    
    public partial class Website_Videos
    {
        public int id { get; set; }
        public string Department { get; set; }
        public string VideoString { get; set; }
        public string emp_code { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string name { get; set; }
        public string website_filename { get; set; }
        public string content { get; set; }
        public string thumbnailpic { get; set; }
        public string DoneBy { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Reason_removal { get; set; }
        public Nullable<System.DateTime> DateOfVideo { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public bool Staff_Profile_Video { get; set; }
    }
}
