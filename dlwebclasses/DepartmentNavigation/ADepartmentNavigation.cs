using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public abstract class ADepartmentNavigation
    {
        public abstract StringBuilder getDepartmentNavigation(DepartmentDetails DD, int? activenode=0);
    }
}
