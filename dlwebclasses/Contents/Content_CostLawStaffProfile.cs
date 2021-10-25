using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_CostLawStaffProfile : AContents
    {
        private string _empcode;
        private bool _preview;
        private string _dept1;
        HRDDLEntities db = new HRDDLEntities();
        public Content_CostLawStaffProfile(string empcode, bool preview = false, string dept1 = "")
        {
            _empcode = empcode;
            _preview = preview;
            _dept1 = dept1;
        }
        public override void getcontents()
        {
            CostLaw_staffprofiles sp = new CostLaw_staffprofiles(_empcode);
            canonicaltag = sp.canonicaltag;
            title = sp.Title;
            description = sp.Description;
            keywords = sp.Keywords;
            HeadingH1 = "Cost Law Drafting services";
            Department = "";
            contents = sp.Contents;
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<!--Contents coming from content section-->");
            filepath = sp.filepath;
            canonicaltag = sp.canonicaltag;
        }
    }
}
