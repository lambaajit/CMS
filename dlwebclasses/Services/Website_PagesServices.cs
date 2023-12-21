using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    [CanBeEdited(true), NameToBeDisplayedOnUI("Website Pages")]
    public partial class Website_Pages : ITrackedEntity,IEntity
    {
        public int? DepartmentInt { get; set; }
        public int? Sub_DepartmentInt { get; set; }
        public int? Sub_Sub_DepartmentInt { get; set; }
    }

    public class Website_PagesServices : TrackedEntityWithLogging<Website_Pages>, IDisposable
    {
        public void Dispose()
        {

        }
    }
}
