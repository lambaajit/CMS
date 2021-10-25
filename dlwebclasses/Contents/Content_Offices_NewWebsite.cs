using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_Offices_NewWebsite:AContents
    {
        private int id;
        public Content_Offices_NewWebsite(int _id)
        {
            id = _id;
            Department = "Find Us";
        }

        public override void getcontents()
        {
            OfficePages_NewWebsite sp = new OfficePages_NewWebsite(id, this);
            title = sp.Title;
            description = sp.Description;
            keywords = sp.Keywords;
            HeadingH1 = sp.HeadingH1;
            Department = sp.Department;
            contents = sp.Contents;
            filepath = sp.filepath;
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<!--Contents coming from content section-->");
            rightcolcontents = SB;
        }
    }
}


