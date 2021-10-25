using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class DepartmentDetails
        {
            public string Name { get; set; }
            public string Title1 { get; set; }
            public string Description1 { get; set; }
            public string Keywords1 { get; set; }
            public string container1 { get; set; }
            public string Heading11 { get; set; }
            public string Heading21 { get; set; }
            public string Overview1 { get; set; }
            public string Services1 { get; set; }
            public string Our_Team1 { get; set; }
            public string News1 { get; set; }
            public string left_under_deptmenu1 { get; set; }
            public string leftimage_under_deptmenu1 { get; set; }
            public string folder1 { get; set; }
            public string folderteam1 { get; set; }
            public string contactstr1 { get; set; }
            public string telstr1 { get; set; }
            public string tel { get; set; }
            public string departmenttype { get; set; }
            public string lawlogoimg { get; set; }
            public StringBuilder departmentnav1 { get; set; }

            public string cssclass { get; set; }
            public string Video { get; set; }

            public DepartmentDetails(string dept)
            {
                IT_DatabaseEntities db1 = new IT_DatabaseEntities();
                Website_Department_Structure db = new Website_Department_Structure();

                bool digit = true;
                foreach (char value in dept)
                {
                    if (char.IsDigit(value) == false)
                    {
                        digit = false;
                        break;
                    }
                }

                int deptid = 0;
                if (digit == true)
                    deptid = int.Parse(dept);

                if (digit == true)
                    db = db1.Website_Department_Structure.Where(x => x.ID == deptid).FirstOrDefault();
                else
                    db = db1.Website_Department_Structure.Where(x => x.Name == dept).FirstOrDefault();

                Name = db.Name;
                Title1 = db.Title1;
                Description1 = db.Description1;
                Keywords1 = db.Keywords1;
                container1 = db.container1;
                Heading11 = db.Heading11;
                Heading21 = db.Heading21;
                Overview1 = db.Overview1;
                Services1 = db.Services1;
                Our_Team1 = db.Our_Team1;
                News1 = db.News1;
                left_under_deptmenu1 = db.left_under_deptmenu1;
                leftimage_under_deptmenu1 = db.leftimage_under_deptmenu1;
                folder1 = db.folder1;
                folderteam1 = db.folderteam1;
                contactstr1 = db.contactstr1;
                departmenttype = db.departmenttype;
                lawlogoimg = db.lawlogoimg;
                cssclass = db.cssclass;
                Video = db.Video;
            }

        }
}
