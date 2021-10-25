using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_CostLawWebpages : AContents
    {
        private int _id;
        public Content_CostLawWebpages(int ID)
        {
            _id = ID;
        }
        public override void getcontents()
        {
            CostLawWebPages sp = new CostLawWebPages(_id, this);
            canonicaltag = sp.canonicaltag;
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
