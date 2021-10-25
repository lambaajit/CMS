using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_JobsLanding_NewWebsite:AContents
    {
       private string dept;
       private string category;
       public Content_JobsLanding_NewWebsite(string _dept, string _category)
            {
                dept = _dept;
                category = _category;
                Department = "Careers";
            }
            public override void getcontents()
            {
                Jobs_LandingPage_NewWebsite sp = new Jobs_LandingPage_NewWebsite(this,dept,category);
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
