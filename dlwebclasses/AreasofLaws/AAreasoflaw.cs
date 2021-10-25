using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public abstract class AAreasOfLaw
    {
        /// <summary>
        ///  This method return a dictionary of type string and StringBuilder with key values Mobile and Desktop.
        /// </summary>
        public abstract Dictionary<String, StringBuilder> getareasoflaw(DepartmentDetails DD);
    }
}
