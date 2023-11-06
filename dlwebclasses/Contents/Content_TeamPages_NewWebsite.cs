using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_TeamPages_NewWebsite:AContents
    {
        private string dept;
        private bool subDepartmentProfile;
        public Content_TeamPages_NewWebsite(string Dept, bool subDepartmentProfile = false, string SubDepartment = null)
        {
            dept = SubDepartment??Dept;
            Department = Dept;
            this.subDepartmentProfile = subDepartmentProfile;
        }
        public override void getcontents()
        {
            TeamPages_NewWebsite sp = new TeamPages_NewWebsite(dept, this, subDepartmentProfile);
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
            canonicaltag = sp.canonicaltag;
        }
    }
}
