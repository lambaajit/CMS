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

namespace DLCMS.Controllers
{
    [Authorize]
    public class CURD_WebsiteVideosController : Controller
    {
        private DLCMS_ITDatabase db = new DLCMS_ITDatabase();

        // GET: /CURD_WebsiteVideos/
        public ActionResult Index()
        {
            return View(db.Website_Videos.ToList());
        }

        // GET: /CURD_WebsiteVideos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Website_Videos website_videos = db.Website_Videos.Find(id);
            if (website_videos == null)
            {
                return HttpNotFound();
            }
            return View(website_videos);
        }

        // GET: /CURD_WebsiteVideos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CURD_WebsiteVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include= "id,Department,VideoString,emp_code,MetaTitle,MetaKeyword,MetaDescription,Heading,Description,name,website_filename,content,thumbnailpic,DoneBy,Active,DateOfVideo,Staff_Profile_Video")] dlwebclasses.Website_Videos website_videos)
        {
            using (var _website_VideosServices = new dlwebclasses.Website_VideosServices())
            {
                if (ModelState.IsValid)
                {
                    _website_VideosServices.Add(website_videos);
                    _website_VideosServices.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(website_videos);
            }
        }

        // GET: /CURD_WebsiteVideos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Website_Videos website_videos = db.Website_Videos.Find(id);
            if (website_videos == null)
            {
                return HttpNotFound();
            }
            return View(website_videos);
        }

        // POST: /CURD_WebsiteVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Department,VideoString,emp_code,MetaTitle,MetaKeyword,MetaDescription,Heading,Description,name,website_filename,content,thumbnailpic,DoneBy,Active,DateOfVideo,Staff_Profile_Video")] dlwebclasses.Website_Videos website_videos)
        {
            using (var _website_VideosServices = new dlwebclasses.Website_VideosServices())
            {
                if (ModelState.IsValid)
                {
                    _website_VideosServices.Update(website_videos);
                    _website_VideosServices.SaveChanges();
                    createpreviewpage_NewWebsite(website_videos.id);
                    ViewBag.filepath_NewWebsite = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\WebSite_Preview.html";
                    return RedirectToAction("Edit", "CURD_WebsiteVideos", new { id = website_videos.id });
                }
                return RedirectToAction("Edit", "CURD_WebsiteVideos", new { id = website_videos.id });
            }
        }

        // GET: /CURD_WebsiteVideos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Website_Videos website_videos = db.Website_Videos.Find(id);
            if (website_videos == null)
            {
                return HttpNotFound();
            }
            return View(website_videos);
        }

        // POST: /CURD_WebsiteVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Website_Videos website_videos = db.Website_Videos.Find(id);
            db.Website_Videos.Remove(website_videos);
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

        public void createpreviewpage_NewWebsite(int ID)
        {
            dlwebclasses.Content_Video_NewWebsite NAL = new dlwebclasses.Content_Video_NewWebsite(ID);
            string filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\WebSite_Preview.html";
            dlwebclasses.CreateHTMLFIles_NEwWebsite Fl = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL, filepath);
            dlwebclasses.CreateHTMLFIles_NEwWebsite F2 = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL);
        }
    }
}
