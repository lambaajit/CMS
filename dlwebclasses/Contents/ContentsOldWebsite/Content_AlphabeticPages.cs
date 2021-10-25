using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_AlphabeticPages : AContents
    {
         private char _id;
         public Content_AlphabeticPages(char ID)
        {
            _id = ID;
        }
        public override void getcontents()
        {
            AlphabeticalTeamPage sp = new AlphabeticalTeamPage(_id);
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
