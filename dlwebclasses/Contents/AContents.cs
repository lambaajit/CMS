using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public abstract class AContents
    {
        public string keywords { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public string filepath { get; set; }
        public StringBuilder contents { get; set; }
        public StringBuilder rightcolcontents { get; set; }
        public abstract void getcontents();
        public string canonicaltag { get; set; }
    }
}
