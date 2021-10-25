using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_JobsPage_NewWebsite:AContents
    {
        private int id;
       public Content_JobsPage_NewWebsite(int _id)
            {
                id = _id;
                Department = "Careers";
            }
            public override void getcontents()
            {
                Jobs_Pages_NewWebsite sp = new Jobs_Pages_NewWebsite(this, id);
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
