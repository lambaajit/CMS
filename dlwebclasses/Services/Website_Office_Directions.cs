using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    [CanBeEdited(true), NameToBeDisplayedOnUI("Website Office Directions")]
    public partial class website_Office_Direction : ITrackedEntity, IEntity
    {
        public int? DepartmentInt { get; set; }
        public int? Sub_DepartmentInt { get; set; }
        public int? Sub_Sub_DepartmentInt { get; set; }
    }
}
