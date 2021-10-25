using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_WebsitePages_NewWebsite:AContents
    {
            private int _id;
            public Content_WebsitePages_NewWebsite(int ID)
            {
                _id = ID;
            }
            public override void getcontents()
            {
                WebsitePages_NewWebsite sp = new WebsitePages_NewWebsite(_id,this);
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
            canonicaltag = sp.canonicaltag;
            }
        
    }
}
