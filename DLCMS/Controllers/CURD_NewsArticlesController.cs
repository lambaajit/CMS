using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DLCMS.Models;
using System.Diagnostics;
using System.Data.Entity.Validation;
using System.Text;
using System.Configuration;


namespace DLCMS.Controllers
{
    [Authorize(Roles = "Removed")]
    public class CURD_NewsArticlesController : BaseController
    {
        private DLCMS_ITDatabase db = new DLCMS_ITDatabase();

        // GET: /CURD_NewsArticles/
        public ActionResult Index(string searchString = null, string searchon = null)
        {
            ViewBag.searchString = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                try
                {
                    if (searchon == "ID" && searchString.Length > 0)
                    {
                        int id = Int32.Parse(searchString);
                        return View(db.Updates_MainWebsites.Where(x => x.ID == id).ToList());
                    }
                    else if (searchon == "Title" && searchString.Length > 4)
                    {
                        return View(db.Updates_MainWebsites.Where(x => x.Title.StartsWith(searchString)).ToList());
                    }
                    else
                    {
                        return View(db.Updates_MainWebsites.Where(x => x.Date_Added.Value.Day == DateTime.Now.Day && x.Date_Added.Value.Month == DateTime.Now.Month && x.Date_Added.Value.Year == DateTime.Now.Year).ToList());
                    }
                }
                catch
                {
                    return View(db.Updates_MainWebsites.Where(x => x.Date_Added.Value.Day == DateTime.Now.Day && x.Date_Added.Value.Month == DateTime.Now.Month && x.Date_Added.Value.Year == DateTime.Now.Year).ToList());
                }
            }
            else
            return View(db.Updates_MainWebsites.Where(x => x.Date_Added.Value.Day == DateTime.Now.Day && x.Date_Added.Value.Month == DateTime.Now.Month && x.Date_Added.Value.Year == DateTime.Now.Year).ToList());
        }

        // GET: /CURD_NewsArticles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Updates_MainWebsites updates_mainwebsites = db.Updates_MainWebsites.Find(id);
            if (updates_mainwebsites == null)
            {
                return HttpNotFound();
            }
            return View(updates_mainwebsites);
        }

        // GET: /CURD_NewsArticles/Create
        public ActionResult Create()
        {
            Updates_MainWebsites UM = new Updates_MainWebsites();
            UM.Date_Update = DateTime.Now;
            UM.Image = false;
            return View(UM);
        }

        // POST: /CURD_NewsArticles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)] 
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Brief,Contents,Date_Update,Description,Keywords,Blog_Department,Image,Page_Title,Staff1,Staff2,Staff3,Staff4,Staff5,Staff6,Staff7,Staff8,Staff9,Staff10,category,video")] dlwebclasses.Updates_MainWebsites updates_mainwebsites, List<string> cbo_Department, HttpPostedFileBase files, HttpPostedFileBase fileupload)
        {
            using (var _updates_MainWebsitesServices = new dlwebclasses.Updates_MainWebitesServices())
            {
                int dup_id = 0;
                ModelState.Remove("Duplicate_ID");
                ModelState.Remove("DLorNonDL");
                ModelState.Remove("filename");
                ModelState.Remove("Date_Added");
                ModelState.Remove("Department");



                updates_mainwebsites.KeywordsToBeUsed = "Yes";
                dup_id = (int)db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('updates_mainwebsites')").FirstOrDefault();
                dup_id = dup_id + 1;
                if (updates_mainwebsites.category == "NonDL")
                    updates_mainwebsites.DLorNonDL = "NonDL";
                else
                    updates_mainwebsites.DLorNonDL = "DL";

                updates_mainwebsites.Duplicate_ID = dup_id;
                updates_mainwebsites.Total_Comments = 0;
                updates_mainwebsites.Live = true;
                updates_mainwebsites.Date_Added = DateTime.Now;

                updates_mainwebsites.Contents = updates_mainwebsites.Contents.ToString().Replace(Environment.NewLine, "<br />");
                updates_mainwebsites.Brief = updates_mainwebsites.Brief.ToString().Replace(Environment.NewLine, "<br />");

                string fname = "";
                if (updates_mainwebsites.Title.ToString().Length > 160)
                    fname = updates_mainwebsites.Title.ToString().Replace("'", "^").Replace("?", "").Replace("-", "").Replace("%", "").Replace("/", "").Replace(" ", "_").Replace("\"", "").Substring(0, 160);
                else
                    fname = updates_mainwebsites.Title.ToString().Replace("'", "^").Replace("?", "").Replace("-", "").Replace("%", "").Replace("/", "").Replace(" ", "_").Replace("\"", "");

                updates_mainwebsites.filename = fname;

                bool modelvalid = false;
                foreach (string str in cbo_Department)
                {
                    updates_mainwebsites.Department = str;
                    var isSuccess = TryUpdateModel(updates_mainwebsites, "", null, new string[] { "ID" });
                    if (ModelState.IsValid)
                    {
                        _updates_MainWebsitesServices.Add(updates_mainwebsites);
                        _updates_MainWebsitesServices.SaveChanges();
                        modelvalid = true;
                        if (files != null && files.ContentLength > 0 && str == "InThePress")
                            files.SaveAs(ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "//InthePress//" + fname.Replace("'", "").Replace(":", "") + ".pdf");
                    }
                    else
                        modelvalid = false;

                    if (!isSuccess)
                    {
                        foreach (var modelState in ModelState.Values)
                        {
                            foreach (var error in modelState.Errors)
                            {
                                Debug.WriteLine(error.ErrorMessage);
                            }
                        }
                    }
                }


                createpreviewpage(dup_id);
                int new_id = dup_id;
                if (modelvalid == true)
                {
                    foreach (string str in cbo_Department)
                    {
                        dlwebclasses.Content_NewsArticlesLandingPages_NewWebsite NAL;
                        NAL = new dlwebclasses.Content_NewsArticlesLandingPages_NewWebsite(str, updates_mainwebsites.category, DateTime.Now.Year, DateTime.Now.Month);
                        dlwebclasses.CreateHTMLFIles_NEwWebsite Fl = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL);

                        if (fileupload != null && fileupload.ContentLength > 0 && updates_mainwebsites.Image == true)
                            fileupload.SaveAs(ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "//ArticlesImages//" + new_id.ToString() + ".jpg");

                        new_id = new_id + 1;
                    }

                    var UMID = db.Updates_MainWebsites.Where(x => x.filename == updates_mainwebsites.filename).Select(x => x.ID).ToList();
                    foreach (int IDs in UMID)
                    {
                        dlwebclasses.Content_NewsArticles_NewWebsite NAL;
                        NAL = new dlwebclasses.Content_NewsArticles_NewWebsite(IDs);
                        dlwebclasses.CreateHTMLFIles_NEwWebsite Fl = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL);
                    }
                    return RedirectToAction("Edit", "CURD_NewsArticles", new { id = dup_id });
                }
                else
                {
                    return View(updates_mainwebsites);
                }
            }
        }


        // GET: /CURD_NewsArticles/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Preview\\News_Preview.html";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Updates_MainWebsites updates_mainwebsites = db.Updates_MainWebsites.Find(id);
            if (updates_mainwebsites == null)
            {
                return HttpNotFound();
            }
            return View(updates_mainwebsites);
        }

        // POST: /CURD_NewsArticles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int ID, string Title, string Brief, string Contents, string Description, string Keywords, bool Image, string Page_Title, string Staff1, string Staff2, string Staff3, string Staff4, string Staff5, string Staff6, string Staff7, string Staff8, string Staff9, string Staff10, string submitButton)
        {
            using (dlwebclasses.Updates_MainWebitesServices _updates_MainWebsitesServices = new dlwebclasses.Updates_MainWebitesServices())
            {
                ViewBag.filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Preview\\News_Preview.html";
                dlwebclasses.Updates_MainWebsites UM1 = _updates_MainWebsitesServices.FindById(ID);
                var UMID = _updates_MainWebsitesServices.GetAll().Where(x => x.filename == UM1.filename).Select(x => x.ID).ToList();
                foreach (int id in UMID)
                {
                    var UM = _updates_MainWebsitesServices.FindById(id);
                    UM.Title = Title;
                    UM.Brief = Brief;
                    UM.Contents = Contents;
                    UM.Description = Description;
                    UM.Keywords = Keywords;
                    UM.Image = Image;
                    UM.Page_Title = Page_Title;
                    UM.Staff1 = Staff1;
                    UM.Staff2 = Staff2;
                    UM.Staff3 = Staff3;
                    UM.Staff4 = Staff4;
                    UM.Staff5 = Staff5;
                    UM.Staff6 = Staff6;
                    UM.Staff7 = Staff7;
                    UM.Staff8 = Staff8;
                    UM.Staff9 = Staff9;
                    UM.Staff10 = Staff10;
                    _updates_MainWebsitesServices.Update(UM);
                    _updates_MainWebsitesServices.SaveChanges();
                    

                    dlwebclasses.Content_NewsArticlesLandingPages_NewWebsite NAL;
                    NAL = new dlwebclasses.Content_NewsArticlesLandingPages_NewWebsite(UM.Department, UM.category, DateTime.Now.Year, DateTime.Now.Month);
                    dlwebclasses.CreateHTMLFIles_NEwWebsite Fl = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL);

                    dlwebclasses.Content_NewsArticles_NewWebsite NAL1;
                    NAL1 = new dlwebclasses.Content_NewsArticles_NewWebsite(id);
                    dlwebclasses.CreateHTMLFIles_NEwWebsite F2 = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL1);
                }

                createpreviewpage(ID);
                Updates_MainWebsites UM2 = db.Updates_MainWebsites.Find(ID);
                UM2.Title = Title;
                UM2.Brief = Brief;
                UM2.Contents = Contents;
                UM2.Description = Description;
                UM2.Keywords = Keywords;
                UM2.Image = Image;
                UM2.Page_Title = Page_Title;
                UM2.Staff1 = Staff1;
                UM2.Staff2 = Staff2;
                UM2.Staff3 = Staff3;
                UM2.Staff4 = Staff4;
                UM2.Staff5 = Staff5;
                UM2.Staff6 = Staff6;
                UM2.Staff7 = Staff7;
                UM2.Staff8 = Staff8;
                UM2.Staff9 = Staff9;
                UM2.Staff10 = Staff10;
                return View(UM2);
            }
        }

        // GET: /CURD_NewsArticles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Updates_MainWebsites updates_mainwebsites = db.Updates_MainWebsites.Find(id);
            if (updates_mainwebsites == null)
            {
                return HttpNotFound();
            }
            return View(updates_mainwebsites);
        }

        // POST: /CURD_NewsArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var _articles = db.Updates_MainWebsites.Where(x => x.Duplicate_ID == id).ToList();
            db.Updates_MainWebsites.RemoveRange(_articles);
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
            dlwebclasses.Content_NewsArticles_NewWebsite NAL = new dlwebclasses.Content_NewsArticles_NewWebsite(ID);
            string filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Preview\\News_Preview.html";
            dlwebclasses.CreateHTMLFIles_NEwWebsite Fl = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL, filepath);
        }
    }
}
