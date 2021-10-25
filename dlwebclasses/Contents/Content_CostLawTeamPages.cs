using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_CostLawTeamPages : AContents
    {
        public override void getcontents()
        {
            CostLaw_TeamPages sp = new CostLaw_TeamPages(this);
            canonicaltag = sp.canonicaltag;
            title = sp.Title;
            description = sp.Description;
            keywords = sp.Keywords;
            HeadingH1 = sp.HeadingH1;
            Department = "";
            contents = sp.Contents;
            filepath = sp.filepath;
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<!--Contents coming from content section-->");
            rightcolcontents = SB;
        }
    }
}
