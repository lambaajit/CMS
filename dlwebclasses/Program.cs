using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Reflection;

namespace dlwebclasses
{
    class Program
    {
        static void Main(string[] args)
        {

            allStatic.htaccessstaff();
            Console.ReadLine();


            //List<string> depts = db.Database.SqlQuery<string>("Select Distinct Department from Website_Pages").ToList();
            //List<string> depts = new List<string> { "Misleneous", "Main", "InThePress", "Legal News", "Reported Case","Professional Regulation", "Consultancy", "Management Board","Wills and Probate", "EU", "Campaign" };
            //foreach (string dept in depts)
            //{
            //    IKernel kernel = new StandardKernel();
            //    kernel.Load(Assembly.GetExecutingAssembly());
            //    IDepartments departmenttype = kernel.Get<IDepartments>(m => m.Name == null || m.Name == dept);
            //    departmenttype.getDepartmentDetails();
            //    int a = db.Database.ExecuteSqlCommand("Insert into Website_Department_Structure ([Name] ,[Title1] ,[Description1] ,[Keywords1] ,[container1] ,[Heading11] ,[Heading21] ,[Overview1] ,[Services1] ,[Our_Team1] ,[News1] ,[left_under_deptmenu1] ,[leftimage_under_deptmenu1] ,[folder1] ,[folderteam1] ,[contactstr1]) VALUES ('" + departmenttype.Name + "' ,'" + departmenttype.Title1 + "' ,'" + departmenttype.Description1 + "' ,'" + departmenttype.Keywords1 + "' ,'" + departmenttype.contactstr1 + "' ,'" + departmenttype.Heading11 + "' ,'" + departmenttype.Heading21 + "' ,'" + departmenttype.Overview1 + "' ,'" + departmenttype.Services1 + "' ,'" + departmenttype.Our_Team1 + "' ,'" + departmenttype.News1 + "' ,'" + departmenttype.left_under_deptmenu1 + "' ,'" + departmenttype.leftimage_under_deptmenu1 + "' ,'" + departmenttype.folder1 + "' ,'" + departmenttype.folderteam1 + "' ,'" + departmenttype.contactstr1 + "')");
            //    Console.WriteLine(dept);
            //}

            //asynctest a1 = new asynctest();
            //a1.MyMethodAsync();
            //Console.ReadLine();
       }
    }
}
