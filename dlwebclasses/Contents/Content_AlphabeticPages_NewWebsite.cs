using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_AlphabeticPages_NewWebsite : AContents
    {
        private char _id;
        public Content_AlphabeticPages_NewWebsite(char ID)
        {
            Department = "About Us";
            _id = ID;
        }
        public override void getcontents()
        {
            AlphabeticalTeamPage_NewWebsite sp = new AlphabeticalTeamPage_NewWebsite(_id, this);
            title = sp.Title;
            description = sp.Description;
            keywords = sp.Keywords;
            HeadingH1 = sp.HeadingH1;
            Department = "About Us";
            contents = sp.Contents;
            filepath = sp.filepath;
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<!--Contents coming from content section-->");
            rightcolcontents = SB;
        }
    }
}
