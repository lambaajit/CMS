//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dlwebclasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubDepartmentProfile
    {
        public int Id { get; set; }
        public string emp_code { get; set; }
        public string Profile { get; set; }
        public string SubDepartment { get; set; }
        public string StaffName { get; set; }
        public Nullable<int> SubDepartmentProfileStructureId { get; set; }
        public Nullable<bool> Selected { get; set; }
        public bool Approve { get; set; }
        public string ApprovedProfile { get; set; }
    
        public virtual SubDepartmentProfileStructure SubDepartmentProfileStructure { get; set; }
    }
}
