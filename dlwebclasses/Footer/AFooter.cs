using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public abstract class AFooter
    {
        public abstract StringBuilder getfooter(AContents _contents, Website_Pages webPage = null);
    }
}
