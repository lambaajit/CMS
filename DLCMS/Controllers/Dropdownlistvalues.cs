using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;
using System.Globalization;

namespace DLCMS.Controllers
{
    public class Dropdownlistvalues
    {
        
        public List<string> newsarticlesdeptlist = new List<string>();
        public List<string> staffdeptlist = new List<string>();
        public List<Emp_Details> stafflist = new List<Emp_Details>();
        public List<string> categories = new List<string>();
        public List<string> _months = new List<string>();
        public List<string> webpagesdeptlist = new List<string>();

         
        
        public Dictionary<string, SelectList> getvalues()
        {
            Dictionary<string, SelectList> dict = new Dictionary<string, SelectList>();
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            newsarticlesdeptlist = db.Database.SqlQuery<string>("select A.name from " +
                                                "(select name from Website_Department_Structure) A " +
                                                "left join " +
                                                "(select distinct department from Updates_MainWebsites) B " +
                                                "on B.department = A.name where B.Department is not null order by name").ToList();

            List<SelectListItem> sli = new List<SelectListItem>();
            sli.Add(new SelectListItem { Text = "All except Legal News", Value = "All", Selected = true });
            foreach (string str in newsarticlesdeptlist)
            {
                sli.Add(new SelectListItem() { Text = str, Value = str, Selected = false });
            }
            SelectList sl = new SelectList(sli, "Value", "Text");
            dict.Add("NewsArticleList", sl);

            int y = 0;
            List<SelectListItem> sli_y = new List<SelectListItem>();
            sli_y.Add(new SelectListItem { Text = "All", Value = "All" });
            for (int i = 2008; i <= DateTime.Now.Year; i++)
            {
                if (i == DateTime.Now.Year)
                    y = i;
                sli_y.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }
            
            SelectList sly = new SelectList(sli_y, "Value", "Text", y);
            dict.Add("Years", sly);

            int m = 0;
            List<SelectListItem> sli_m = new List<SelectListItem>();
            sli_m.Add(new SelectListItem { Text = "All", Value = "All", Selected = false });
            for (int i = 1; i <= 12; i++)
            {
                if (i == DateTime.Now.Month)
                    m = i;
                sli_m.Add(new SelectListItem() { Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i), Value = i.ToString() });
            }
            SelectList slm = new SelectList(sli_m, "Value", "Text",m);
            dict.Add("Months", slm);


            categories = db.Database.SqlQuery<string>("select Distinct Category from Updates_MainWebsites where category in ('DL','NonDL')").ToList();

            
            List<SelectListItem> sli_c = new List<SelectListItem>();
            sli_c.Add(new SelectListItem { Text = "All", Value = "All", Selected = true });
            foreach (string str in categories)
            {
                sli_c.Add(new SelectListItem() { Text = str, Value = str });
            }
            SelectList slc = new SelectList(sli_c, "Value", "Text");
            dict.Add("Categories", slc);

            // or name = 'Management Board'
            HRDDLEntities dbhr = new HRDDLEntities();
            staffdeptlist = db.Database.SqlQuery<string>("select name from " +
            "(select B.*, A.*,c.*,d.*,e.*,f.* from " +
            "(select name from Website_Department_Structure where DepartmentType = 'AreaOfLaw') B " +
            "left join  " +
            "(select distinct Department_IT from Dlddbsrv6.hrddl.hrd.emp_details where ([start_date] <= GETDATE()) AND ([end_date] > GETDATE() OR [end_date] IS NULL OR [end_date] = '01/01/1900') AND ([Employed] = '1') and ([Admin_Staff] <> '1')) A  " +
            "on A.Department_IT collate DATABASE_DEFAULT = B.name  " +
            "left join " +
            "(select distinct department_covered_2 from Dlddbsrv6.hrddl.hrd.emp_details where ([start_date] <= GETDATE()) AND ([end_date] > GETDATE() OR [end_date] IS NULL OR [end_date] = '01/01/1900') AND ([Employed] = '1') and ([Admin_Staff] <> '1')) c  " +
            "on c.department_covered_2 collate DATABASE_DEFAULT = B.name  " +
            "left join " +
            "(select distinct department_covered_3 from Dlddbsrv6.hrddl.hrd.emp_details where ([start_date] <= GETDATE()) AND ([end_date] > GETDATE() OR [end_date] IS NULL OR [end_date] = '01/01/1900') AND ([Employed] = '1') and ([Admin_Staff] <> '1')) d  " +
            "on d.department_covered_3 collate DATABASE_DEFAULT = B.name  " +
            "left join " +
            "(select distinct department_covered_4 from Dlddbsrv6.hrddl.hrd.emp_details where ([start_date] <= GETDATE()) AND ([end_date] > GETDATE() OR [end_date] IS NULL OR [end_date] = '01/01/1900') AND ([Employed] = '1') and ([Admin_Staff] <> '1')) e  " +
            "on e.department_covered_4 collate DATABASE_DEFAULT = B.name  " +
            "left join " +
            "(select distinct department_covered_5 from Dlddbsrv6.hrddl.hrd.emp_details where ([start_date] <= GETDATE()) AND ([end_date] > GETDATE() OR [end_date] IS NULL OR [end_date] = '01/01/1900') AND ([Employed] = '1') and ([Admin_Staff] <> '1')) f  " +
            "on f.department_covered_5 collate DATABASE_DEFAULT = B.name) Main " +
            "where (Main.Department_IT is not null or department_covered_2  is not null or  department_covered_3  is not null or department_covered_4  is not null or  department_covered_5  is not null) order by name").ToList();

            staffdeptlist.Add("Immigration");

            List<SelectListItem> sl_sl = new List<SelectListItem>();
            sl_sl.Add(new SelectListItem { Text = "All", Value = "All", Selected = true });
            foreach (string str in staffdeptlist)
            {
                sl_sl.Add(new SelectListItem() { Text = str, Value = str, Selected = false });
            }
            sl_sl.Add(new SelectListItem() { Text = "Management Board", Value = "Management Board", Selected = false });
            //sl_sl.Add(new SelectListItem() { Text = "High Net Worth Divorce", Value = "High Net Worth Divorce", Selected = false });
            SelectList slsl = new SelectList(sl_sl, "Value", "Text");
            dict.Add("StaffDeptList", slsl);

            //  || staffdeptlist.Contains(x.department_covered_2) || staffdeptlist.Contains(x.department_covered_3) || staffdeptlist.Contains(x.department_covered_4) || staffdeptlist.Contains(x.department_covered_5
            List<SelectListItem> sli_staff = new List<SelectListItem>();
            sli_staff.Add(new SelectListItem { Text = "All", Value = "All" });


            string[] excludedepartmentlist = new string[]{"Office Administration", "Cost Drafting", "Information Technology", "Finance", "Marketing", "Human Resources", "Board of Directors", "Child Care/Family", "Practice Management", "Risk and Compliance", "Senior Director", "Mental Capacity", "Action Against Police"};
            stafflist =  allStatic.getcurrentemployedstafflist().Where(x => (staffdeptlist.Contains(x.department_it)) && (excludedepartmentlist.Contains(x.department_it) == false) && (x.reporting_consultant == false || x.reporting_consultant == null)) .ToList();/*&& x.jobtitle != "Legal Casework Assistant"*/
            foreach (Emp_Details staff in stafflist)
            {
                sli_staff.Add(new SelectListItem() { Text = staff.forename + " " + staff.surname, Value = staff.emp_code });
            }
            SelectList sls = new SelectList(sli_staff, "Value", "Text");
            dict.Add("SatffList", sls);



            //webpagesdeptlist = db.Database.SqlQuery<string>("select A.* from (select distinct department from Website_pages where company ='Duncan Lewis') A  left join  (select name from Website_Department_Structure) B on A.department = B.name").ToList();
            //webpagesdeptlist = db.Database.SqlQuery<string>("select name from Website_Department_Structure where contactstr1 is not null and contactstr1 > 0").ToList();

            List<SelectListItem> items = db.Website_Structure.Where(x => x.level == "Root").OrderBy(z => z.name).ToList().Select(z => new SelectListItem { Text = z.name, Value = z.id.ToString() }).ToList();

            items.Add(new SelectListItem { Text = "All", Value = "All" });
            items.Add(new SelectListItem { Text = "All Landing pages", Value = "All Landing pages" });
            items.Add(new SelectListItem { Text = "All pages", Value = "All pages" });
            items.Add(new SelectListItem { Text = "Website Pages with Videos", Value = "Website Pages with Videos" });
            

            SelectList slcwp = new SelectList(items,  "Value","Text");

            
            
            dict.Add("Webpagedeptlist", slcwp);

            DLWEBEntities dbweb = new DLWEBEntities();
            List<SelectListItem> Offices = dbweb.OfficesDLW.Where(x => x.Active == true).OrderBy(z => z.Name).ToList().Select(w => new SelectListItem { Text = w.Name, Value = w.ID.ToString() }).ToList();
            Offices.Add(new SelectListItem { Text = "All", Value = "All" });

            SelectList slOffices = new SelectList(Offices, "Value", "Text");
            dict.Add("OfficeList", slOffices);



            return dict;
            
            

        }
    }
}