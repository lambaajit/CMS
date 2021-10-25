using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_StaffProfile:AContents
    {
        private string _empcode;
        private bool _preview;
        private string _dept1;
        public Content_StaffProfile(string empcode, bool preview = false, string dept1 = "")
        {
            _empcode = empcode;
            _preview = preview;
            _dept1 = dept1;
        }
        public override void getcontents()
        {
            HRDDLEntities db = new HRDDLEntities();
            string dept;
            if (_dept1 == "")
                dept = db.Emp_Details.Where(x => x.emp_code == _empcode).Select(x => x.department_it).FirstOrDefault();
            else
                dept = _dept1;

            DepartmentDetails dd = new DepartmentDetails(dept);
            staffprofile sp = new staffprofile(_empcode, dd, _preview);
            title = sp.Title;
            description = sp.Description;
            keywords = sp.Keywords;
            HeadingH1 = dept + " Solicitor";
            Department = dd.Name;
            contents = sp.Contents;
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<!--Contents coming from content section-->");
            rightcolcontents = sp.contentrightcolumn;
            filepath = sp.filepath;
        }
    }
}
