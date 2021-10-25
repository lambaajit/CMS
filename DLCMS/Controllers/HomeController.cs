using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;
using System.IO;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Security.Cryptography;
using System.Data;
using DLCMS.Models;

namespace DLCMS.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public string fnListAllUser()
        {

            var credentials = new NetworkCredential("ajitl@duncanlewis.com", "Chitraarti1$", "dlhdc1.duncanlewis.local:389");
            var serverId = new LdapDirectoryIdentifier("dlhdc1.duncanlewis.local:389");
            LdapConnection connection = new LdapConnection(serverId, credentials);



            var sha1 = new SHA1Managed();
            var digest = Convert.ToBase64String(sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes("Chitraarti1$")));
            var request = new CompareRequest(string.Format("uid={0},ou=users,dc=example,dc=com", "ajitl@duncanlewis.com"),
                "userPassword", "{SHA}" + digest);


            var response = (CompareResponse)connection.SendRequest(request);
            return (response.ResultCode == ResultCode.CompareTrue).ToString();

            //DirectoryEntry directoryEntry = new DirectoryEntry
            //        ("LDAPS://dlhdc1.duncanlewis.local", "ajitl@duncanlewis.com", "Chitraarti1$", AuthenticationTypes.Encryption);
            //string userNames = "";
            //string authenticationType = "";
            //foreach (DirectoryEntry child in directoryEntry.Children)
            //{
            //    if (child.SchemaClassName == "User")
            //    {
            //        userNames += child.Name +
            //            Environment.NewLine; //Iterates and binds all user using a newline
            //        authenticationType += child.Username + Environment.NewLine;
            //    }
            //}
            //Console.WriteLine("************************Users************************");
            //Console.WriteLine(userNames);
            //Console.WriteLine("*****************Authentication Type*****************");
            //Console.WriteLine(authenticationType);




            //return "AJIT";
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            //MainNavigationNewWebsite Nav = new MainNavigationNewWebsite();
            //using (StreamWriter writetext = new StreamWriter("c:/write.txt"))
            //{
            //    writetext.Write(Nav.getmainnavigation());
            //}
            //DepartmentNavigationNewWebsite DeptNav = new DepartmentNavigationNewWebsite();
            //using (StreamWriter writetext = new StreamWriter("c:/write.txt"))
            //{
            //    DepartmentDetails DD = new DepartmentDetails("Child Care");
            //    writetext.Write(DeptNav.getDepartmentNavigation(DD, 3961));
            //}

            foreach (var item1 in "A".ToList())
            {
                using (StreamWriter writetext = new StreamWriter("c:/write" + item1 + ".txt"))
                {
                    //staffprofileitdatabaseNewWebsite spnd = new staffprofileitdatabaseNewWebsite();
                    //writetext.Write(spnd.getstaffProfile("ParmarK"));
                    DepartmentDetails dd = new DepartmentDetails("Public Law");
                    StringBuilder sb = new StringBuilder();
                    var Dictionary = (Dictionary<string, SelectList>)ViewBag.Dict;
                    SelectList sl;
                    sl = (SelectList)Dictionary["SatffList"];
                    List<SelectListItem> sl1 = sl.Where(x => x.Text.StartsWith(item1.ToString()) && x.Text != "All").Select(y => new SelectListItem { Text = y.Text, Value = y.Value }).ToList();
                    foreach (var item in sl1)
                    {
                        staffprofileitdatabaseNewWebsite sp = new staffprofileitdatabaseNewWebsite();
                        sb.AppendLine("<div class=\"NameStaff\">" + item.Text + "</div>");
                        sb.AppendLine(sp.getstaffProfile(item.Value).ToString());
                    }
                    writetext.Write(sb);
                    writetext.Close();
                }
            }



            //using (StreamWriter writetext = new StreamWriter("c:/write.txt"))
            //{
            //    Content_WebsitePages cw = new Content_WebsitePages(98);
            //    cw.getcontents();
            //    Footer_NewWebsite FNW = new Footer_NewWebsite();
            //    writetext.Write(FNW.getfooter(cw));
            //}
            return View();
        }


        public ActionResult updateexcel()
        {
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            DataTable dt = new DataTable();
            int i = 0;
            dt = allStatic.readexcelasdatatable("c:/SubAreas2.xlsx", "Sheet1");
            foreach (DataRow dc in dt.Rows)
            {
                //Website_Custom_SubDepartments WCS = new Website_Custom_SubDepartments();
                //WCS.SubDepartment = dc[1].ToString();
                //WCS.Department = dc[0].ToString();
                //WCS.SubDepartment_Switchboard = dc[0].ToString();
                //db.Website_Custom_SubDepartments.Add(WCS);
                //db.SaveChanges();
                string pagename = dc[0].ToString();
                var sp = db.Website_Pages.Where(x => x.Name == pagename).FirstOrDefault();
                if (sp != null)
                {
                    sp.CustomSubDepartment = dc[2].ToString();
                    sp.SubDepartmentSwitchboard = dc[2].ToString();
                    if (dc[1].ToString() == "Immigration - Asylum / Human Rights" || dc[1].ToString() == "Immigration - Private & Business")
                    {
                        sp.CustomDepartment = dc[1].ToString();
                    }

                    db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    i++;
                }

            }
            ViewBag.TotalCount = i.ToString();
            return View(dt);
        }

        public ActionResult SubDepartmentDropdownlist()
        {
            List<dlwebclasses.SubDepartmentListModel> subDepartmentListModel = new List<SubDepartmentListModel>();
            subDepartmentListModel = allStatic.CreateSubDepartmentList();
            return View(subDepartmentListModel.Select(x => x.SubDepartment + " - - - " + x.Department).ToList());
        }

        public ActionResult ViewSubDepartments()
        {
            DLWEBEntities dbweb = new DLWEBEntities();
            List<ListSubDepartments> LSD = dbweb.SubDepartments.GroupBy(y => new { y.Department,y.SubDepartment1 }).Select(x => new ListSubDepartments { department = x.Key.Department.Trim(), subdepartment = x.Key.SubDepartment1.Trim() }).ToList();
            return View(LSD);
        }

        public ActionResult SubDepartmentsForWebpages()
        {
            dlwebclasses.IT_DatabaseEntities db = new IT_DatabaseEntities();
            //DLWEBEntities dbweb = new DLWEBEntities();
            //foreach (var item in dbweb.WebsitePagesSubDepartments)
            //{
            //    dbweb.WebsitePagesSubDepartments.Remove(item);
            //    dbweb.SaveChanges();
            //}
            List<dlwebclasses.Website_Pages> WPs = db.Website_Pages.Where(x => x.Company == "Duncan Lewis").ToList();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var WP in WPs)
            {
                try
                {
                    dict.Add(WP.Name, getsubdepartmentforclientreferral.getsubdept(WP));
                }
                catch
                {

                }
                    }
            return View(dict);
        }


        public string SubDeptSwitchboard()
        {
            allStatic.SubDepartmentSwitchboard();
            return "Working";
        }
    }
}