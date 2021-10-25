using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_TeamPages:AContents
    {
        private string dept;
        public Content_TeamPages(string Dept)
        {
            dept = Dept;
        }
        public override void getcontents()
        {
            TeamPages sp = new TeamPages(dept);
            title = sp.Title;
            description = sp.Description;
            keywords = sp.Keywords;
            HeadingH1 = sp.HeadingH1;
            Department = sp.Department;
            contents = sp.Contents;
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<!--Contents coming from content section-->");
            rightcolcontents = SB;
            filepath = sp.filepath;
        }
    }
}
