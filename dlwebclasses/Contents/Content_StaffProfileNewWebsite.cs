using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_StaffProfileNewWebsite:AContents
    {
        private string _empcode;
        private bool _preview;
        private string _dept1;
        private string _subDepartment;
        HRDDLEntities db = new HRDDLEntities();
        public Content_StaffProfileNewWebsite(string empcode, bool preview = false, string dept1 = "", string subdepartment = null)
        {
            _empcode = empcode;
            _preview = preview;
            _dept1 = dept1;
            _subDepartment = subdepartment;
            Department = db.Emp_Details.Where(x => x.emp_code == _empcode).Select(x => x.department_it).FirstOrDefault();
        }
        public override void getcontents()
        {
            
            string dept;
            if (_dept1 == "")
                dept = db.Emp_Details.Where(x => x.emp_code == _empcode).Select(x => x.department_it).FirstOrDefault();
            else
                dept = _dept1;

            DepartmentDetails dd = new DepartmentDetails(dept);
            if (_subDepartment == null)
            {
                staffprofiles_NewWebsite sp = new staffprofiles_NewWebsite(_empcode, dd, _preview);
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
                canonicaltag = sp.canonicaltag;
            }
            else
            {
                staffprofiles_NewWebsite_SubDepartment sp = new staffprofiles_NewWebsite_SubDepartment(_empcode, dd, _subDepartment , _preview);
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
                canonicaltag = sp.canonicaltag;
            }
        }
    }
}
