using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_Video_NewWebsite:AContents
    {
    private int id;
    IT_DatabaseEntities dbit = new IT_DatabaseEntities();
    public Content_Video_NewWebsite(int _id)
        {
            id = _id;
            Website_Videos WV = new Website_Videos();
            WV = dbit.Website_Videos.Where(x => x.id == _id).FirstOrDefault();
            Department = WV.Department;

        }
        public override void getcontents()
        {
            Videos_NewWebsite sp = new Videos_NewWebsite(id, this);
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
