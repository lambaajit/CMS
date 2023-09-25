using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DLCMS.Models;
using System.Configuration;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Collections;
using System.Text;

namespace DLCMS.Controllers
{
    public class CURD_WebSitePagesController : BaseController
    {
        private DLCMS_ITDatabase db = new DLCMS_ITDatabase();

        // GET: /CURD_WebSitePages/
        public ActionResult Index()
        {
            return View(db.Website_Pages.ToList());
        }

        // GET: /CURD_WebSitePages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Website_Pages website_pages = db.Website_Pages.Find(id);
            if (website_pages == null)
            {
                return HttpNotFound();
            }
            return View(website_pages);
        }

        // GET: /CURD_WebSitePages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CURD_WebSitePages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include="Name,Department,Sub_Department,Keywords,Title,Description,Text,Sub_Sub_Department,Filename,VideoId")] Website_Pages website_pages,string Sub_Sub_Sub_Department)
        {
            website_pages.Company = "Duncan Lewis";
            if (ModelState.IsValid)
            {
                int linkedid = 0;
                if (Sub_Sub_Sub_Department != string.Empty && Sub_Sub_Sub_Department != null)
                    linkedid = Convert.ToInt16(Sub_Sub_Sub_Department);
                else if (website_pages.Sub_Sub_Department != string.Empty && website_pages.Sub_Sub_Department != null)
                    linkedid = Convert.ToInt16(website_pages.Sub_Sub_Department);
                else if (website_pages.Sub_Department != string.Empty && website_pages.Sub_Department != null)
                    linkedid = Convert.ToInt16(website_pages.Sub_Department);
                else if (website_pages.Department != string.Empty && website_pages.Department != null)
                    linkedid = Convert.ToInt16(website_pages.Department);

                int dept = int.Parse(website_pages.Department);
                website_pages.Department = db.Website_Structure.Where(x => x.id == dept).Select(y => y.name).FirstOrDefault();
                if (website_pages.Sub_Department != null)
                {
                    int deptsub = int.Parse(website_pages.Sub_Department);
                    website_pages.Sub_Department = db.Website_Structure.Where(x => x.id == deptsub).Select(y => y.name).FirstOrDefault();
                }
                if (website_pages.Sub_Sub_Department != null)
                {
                    int deptsubsub = int.Parse(website_pages.Sub_Sub_Department);
                    website_pages.Sub_Sub_Department = db.Website_Structure.Where(x => x.id == deptsubsub).Select(y => y.name).FirstOrDefault();
                }

                int dup_id;
                db.Website_Pages.Add(website_pages);
                db.SaveChanges();
                dup_id = db.Database.SqlQuery<int>("Select Max(ID) from Website_Pages").FirstOrDefault();

                

                Website_Structure ws = new Website_Structure();
                ws.level = "ContentNode";
                ws.underwhichnode = linkedid;
                ws.name = website_pages.Name;
                ws.linkedid = dup_id;
                db.Website_Structure.Add(ws);
                db.SaveChanges();
                createpreviewpage_NewWebsite(dup_id);
                createpreviewpage(dup_id);
                dlwebclasses.Content_WebsitePages_NewWebsite NAL = new dlwebclasses.Content_WebsitePages_NewWebsite(dup_id);
                dlwebclasses.CreateHTMLFIles_NEwWebsite CF = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL);
                return RedirectToAction("Edit", "CURD_WebSitePages", new { id = dup_id });
            }

            return View(website_pages);
        }

        // GET: /CURD_WebSitePages/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.filepath = ConfigurationManager.AppSettings["Rootpath"].ToString() + "\\WebSite_Preview.html";
            ViewBag.filepath_NewWebsite = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\WebSite_Preview.html";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Website_Pages website_pages = db.Website_Pages.Find(id);
            if (website_pages == null)
            {
                return HttpNotFound();
            }
            return View(website_pages);
        }

        // POST: /CURD_WebSitePages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int ID, string Name, string Text, string Title, string Description, string Keywords, string Department, string AltTagIng1, string AltTagIng2, string AltTagIng3, string AltTagIng4, string AltTagIng5, string AltTagIng6, string AltTagIng7, string VideoId)
        {
            Website_Pages WP = new Website_Pages();
            WP = db.Website_Pages.Find(ID);
            WP.Text = Text;
            WP.Name = Name;
            WP.Keywords = Keywords;
            WP.Title = Title;
            WP.AltTagIng1 = AltTagIng1;
            WP.AltTagIng2 = AltTagIng2;
            WP.AltTagIng3 = AltTagIng3;
            WP.AltTagIng4 = AltTagIng4;
            WP.AltTagIng5 = AltTagIng5;
            WP.AltTagIng6 = AltTagIng6;
            WP.AltTagIng7 = AltTagIng7;
            WP.DateUpdated = DateTime.Now;
            WP.Description = Description;
            int Videoid = 0;
            int.TryParse(VideoId,out Videoid);
            
            if (Videoid != 0)
                WP.VideoId = Videoid;

            db.Entry(WP).State = EntityState.Modified;
            db.SaveChanges();
            if (WP.Company == "Duncan Lewis")
            {
                createpreviewpage(ID);
                createpreviewpage_NewWebsite(ID);
                dlwebclasses.Content_WebsitePages_NewWebsite NAL = new dlwebclasses.Content_WebsitePages_NewWebsite(ID);
                dlwebclasses.CreateHTMLFIles_NEwWebsite CF = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL);
                ViewBag.filepath = ConfigurationManager.AppSettings["Rootpath"].ToString() + "\\WebSite_Preview.html";
                ViewBag.filepath_NewWebsite = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\WebSite_Preview.html";
            }
            return RedirectToAction("getlistofwebpages", "CURD_WebSitePages", new { id = Department });
        }

        // GET: /CURD_WebSitePages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Website_Pages website_pages = db.Website_Pages.Find(id);
            if (website_pages == null)
            {
                return HttpNotFound();
            }
            return View(website_pages);
        }

        // POST: /CURD_WebSitePages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Website_Pages website_pages = db.Website_Pages.Find(id);
            db.Website_Pages.Remove(website_pages);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void createpreviewpage(int ID)
        {
            dlwebclasses.Content_WebsitePages NAL = new dlwebclasses.Content_WebsitePages(ID);
            string filepath = ConfigurationManager.AppSettings["Rootpath"].ToString() + "\\WebSite_Preview.html";
            dlwebclasses.CreateHTMLFiles Fl = new dlwebclasses.CreateHTMLFiles(NAL, filepath);
        }

        public void createpreviewpage_NewWebsite(int ID)
        {
            dlwebclasses.Content_WebsitePages_NewWebsite NAL = new dlwebclasses.Content_WebsitePages_NewWebsite(ID);
            string filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\WebSite_Preview.html";
            dlwebclasses.CreateHTMLFIles_NEwWebsite Fl = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL, filepath);
        }

        public ActionResult getnodesundernode(int? id = null)
        {
            List<WebsiteNodes> dict = new List<WebsiteNodes>();
            if (id == null)
            {
                dict = db.Website_Structure.Where(x => x.level == "Root").Select(x => new WebsiteNodes { id = x.id, name = x.name }).ToList();
            }
            else
            {
                //dict = db.Website_Structure.Where(x => x.underwhichnode == id).Select(x => new KeyValuePair<int, string>(x.id, x.name)).ToDictionary(pair => pair.Key, pair => pair.Value);
                dict = db.Website_Structure.Where(x => x.underwhichnode == id && x.level != "ContentNode").Select(x => new WebsiteNodes { id = x.id, name = x.name }).ToList();
            }
            
            //return Json(dict, JsonRequestBehavior.AllowGet);
            return Json(dict, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getlistofwebpages(string id = null)
        {
            List<DLCMS.Models.Website_Pages> wp = new List<DLCMS.Models.Website_Pages>();
            if (id == null)
            {
                wp = db.Website_Pages.Where(x => x.Company == "Duncan Lewis").ToList();
            }
            else
            {
                wp = db.Website_Pages.Where(x => x.Company == "Duncan Lewis" && x.Department == id).ToList();
            }
            return View(wp);
        }

        public ActionResult getlistofwebpages247()
        {
            List<DLCMS.Models.Website_Pages> wp = new List<DLCMS.Models.Website_Pages>();
            wp = db.Website_Pages.Where(x => x.Company == "24-7languageServices").OrderBy(y => y.Name).ToList();
            return View(wp);
        }

        public ActionResult getlistofwebpagesCostLaw()
        {
            List<DLCMS.Models.Website_Pages> wp = new List<DLCMS.Models.Website_Pages>();
            wp = db.Website_Pages.Where(x => x.Company == "Cost Law").OrderBy(y => y.Name).ToList();
            return View("~/Views/CURD_WebSitePages/getlistofwebpages.cshtml",wp);
        }



        // GET: CostLaw





    }
}

