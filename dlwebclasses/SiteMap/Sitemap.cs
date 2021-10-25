using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class SitemapDL
    {
        public SitemapDL() {
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();


            StreamWriter fp;
            fp = System.IO.File.CreateText(ConfigurationManager.AppSettings["RootpathNewWebsite"] + "\\Sitemap.xml");
            fp.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            fp.WriteLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");
            fp.WriteLine("<url>");
            fp.WriteLine("<loc>https://www.duncanlewis.co.uk</loc>");
            fp.WriteLine("</url>");
            foreach (var item in dbit.Website_Pages.Where(x => x.Company == "Duncan Lewis"))
            {
                fp.WriteLine("<url>");
                fp.WriteLine("<loc>https://www.duncanlewis.co.uk/" + item.Filename + ".html</loc>");
                fp.WriteLine("</url>");
            }


            //List<Emp_Details> ED = new List<Emp_Details>();
            //IEnumerable<Emp_Details> ED1;
            //ED1 = allStatic.getcurrentemployedstafflist();

            //ED = ED1.Where(x => x.Profile_website == true && x.admin_staff == "0" && (x.reporting_consultant == false || x.reporting_consultant == null)).OrderByDescending(x => x.Picture_website).ThenBy(x => x.forename).ToList();

            //foreach (var item in ED)
            //{
            //    fp.WriteLine("<url>");
            //    fp.WriteLine("<loc>https://www.duncanlewis.co.uk/" + allStatic.getRewriteUrlLinkForStaff(item) + "/</loc>");
            //    fp.WriteLine("</url>");
            //}

            fp.WriteLine("</urlset>");
            fp.Close();
        }
    }
    public class SitemapCostLaw
    {

        public SitemapCostLaw()
        {
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            DLWEBEntities dbweb = new DLWEBEntities();
            HRDDLEntities dbhr = new HRDDLEntities();

            StreamWriter fp;
            fp = System.IO.File.CreateText(ConfigurationManager.AppSettings["RootpathCostLawWebsite"] + "\\Sitemap.xml");
            fp.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            fp.WriteLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");
            fp.WriteLine("<url>");
            fp.WriteLine("<loc>https://www.costlaw.com</loc>");
            fp.WriteLine("</url>");
            foreach (var item in dbit.Website_Pages.Where(x => x.Company == "Cost Law"))
            {
                fp.WriteLine("<url>");
                fp.WriteLine("<loc>https://www.duncanlewis.co.uk/" + item.Filename + ".html</loc>");
                fp.WriteLine("</url>");
            }

            foreach (var item in dbweb.OfficesDLW.Where(x => x.Company == "Cost Law" || x.Company == "Both"))
            {
                fp.WriteLine("<url>");
                fp.WriteLine("<loc>https://www.costlaw.com/Cost-Drafting-" + item.Name.Replace(" ", "-") + ".html</loc>");
                fp.WriteLine("</url>");
            }

            foreach (var _emp_Details in dbhr.Emp_Details.Where(x => x.employed == "1" && x.start_date < DateTime.Now && (x.end_date == null || x.end_date > DateTime.Now || x.end_date.Value.ToString().Contains("1900")) && (x.company_name == "Cost Law Services Limited" || x.company_name == "Cost Law Limited")).OrderBy(y => y.forename).ToList())
            {
                fp.WriteLine("<url>");
                fp.WriteLine("<loc>https://www.costlaw.com/Profiles/" + _emp_Details.forename.Replace(" ", "-") + "-" + _emp_Details.surname.Replace(" ", "-") + ".html</loc>");
                fp.WriteLine("</url>");
            }

            fp.WriteLine("<loc>https://www.costlaw.com//our-people.html</loc>");

            fp.WriteLine("</urlset>");
            fp.Close();
        }
    }
}
