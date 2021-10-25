using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_HomePage:AContents
    {
        public HomePagetype htype { get; set; }
    public Content_HomePage(HomePagetype _htype = HomePagetype.Main)
        {
            htype = _htype;
        }
        public override void getcontents()
        {
            HomePage sp = new HomePage(htype);
            title = sp.Title;
            description = sp.Description;
            keywords = sp.Keywords;
            HeadingH1 = sp.HeadingH1;
            Department = "HomePage";
            contents = sp.Contents;
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<!--Contents coming from content section-->");
            rightcolcontents = SB;
            filepath = sp.filepath;
        }
    }
}
