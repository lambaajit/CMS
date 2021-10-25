using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using dlwebclasses;

namespace DLCMS.Controllers
{
    [Authorize]
    public class NewsArticlesController : BaseController
    {
        //
        // GET: /CreateWebsitePages/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewslandingPages(string cbo_Newsdept, string cbo_years, string cbo_month, string cbo_category, string cbo_Type)
        {
            //if (cbo_Type == "Landing Page")
            //{
                if (cbo_Newsdept == "All")
                {
                    foreach (string str in newsarticlesdeptlist)
                    {
                        if (str != "Legal News")
                        Evaluateyears(str, cbo_years, cbo_month, cbo_category);
                    }
                }
                else
                {
                    Evaluateyears(cbo_Newsdept, cbo_years, cbo_month, cbo_category);
                }
                
            //}
            //else
            //{
                IT_DatabaseEntities db = new IT_DatabaseEntities();
                List<int> IDs = new List<int>();
                IDs = db.Database.SqlQuery<int>("select top 10 ID from Updates_MainWebsites order by ID desc").ToList();//and department = '" + cbo_Newsdept + "'
                //IDs = db.Database.SqlQuery<int>("select top 10 ID from Updates_MainWebsites order by ID desc").ToList();
                Content_NewsArticles NAL;
                foreach (int ID in IDs)
                { 
                    NAL = new Content_NewsArticles(ID);
                    CreateHTMLFiles Fl = new CreateHTMLFiles(NAL);
                }
            //}
            return View("Index");
        }


        public void Evaluateyears(string dept, string years, string month, string category)
        {
            if (years == "All")
            {
                int yrs;
                IT_DatabaseEntities db = new IT_DatabaseEntities();
                yrs = db.Database.SqlQuery<int>("SELECT DISTINCT TOP (1) YEAR(Date_Update) AS yr FROM         Updates_MainWebsites WHERE     (Department = '" + dept + "') ORDER BY yr").FirstOrDefault();

                for (int i = yrs; i <= DateTime.Now.Year; i++)
                {
                    if (dept == "Legal News")
                        Evaluatemonths(dept, i.ToString(), month, category);
                    else
                        Evaluatecategories(dept, i.ToString(), month, category);
                }
            }
            else
            {
                if (dept == "Legal News")
                    Evaluatemonths(dept, years, month, category);
                else
                    Evaluatecategories(dept, years, month, category);
            }
        }


        
        public void Evaluatecategories(string dept, string years, string month, string category)
        {
            Content_NewsArticlesLandingPages NAL;
            if (category == "All")
            {
                foreach (string str1 in categories)
                {
                    if (str1 != "NonDL" || dept != "Main")
                    {
                        NAL = new Content_NewsArticlesLandingPages(dept, str1, int.Parse(years), 1);
                        CreateHTMLFiles Fl = new CreateHTMLFiles(NAL);
                    }
                }
            }
            else
            {
                NAL = new Content_NewsArticlesLandingPages(dept, category, int.Parse(years), 1);
                CreateHTMLFiles Fl = new CreateHTMLFiles(NAL);
            }
            
        }


        public void Evaluatemonths(string dept, string years, string month, string category)
        {
            Content_NewsArticlesLandingPages NAL;
                if (month == "All")
                {
                    for (int j = 1; j <= 12; j++)
                    {
                         NAL = new Content_NewsArticlesLandingPages(dept,category, int.Parse(years), int.Parse(j.ToString()));
                         CreateHTMLFiles Fl = new CreateHTMLFiles(NAL);
                    }
                }
                else
                {
                    NAL = new Content_NewsArticlesLandingPages(dept,category, int.Parse(years), int.Parse(month.ToString()));
                    CreateHTMLFiles Fl = new CreateHTMLFiles(NAL);
                }
                
            }



    }


}

