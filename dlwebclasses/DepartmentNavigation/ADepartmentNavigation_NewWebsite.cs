using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public abstract class ADepartmentNavigation_NewWebsite
    {
        public abstract StringBuilder getDepartmentNavigation(AContents _Acontent, int? activenode = 0, string category = null, int? activemonth = 0);
    }
}
