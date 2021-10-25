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
    public class CURD_OfficeDirectionsController : BaseController
    {
        private DLCMS_ITDatabase db = new DLCMS_ITDatabase();

        // GET: /OfficeDirections/
        public ActionResult Index()
        {
            return View(db.website_Office_Direction.ToList());
        }

        // GET: /OfficeDirections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            website_Office_Direction website_office_direction = db.website_Office_Direction.Find(id);
            if (website_office_direction == null)
            {
                return HttpNotFound();
            }
            return View(website_office_direction);
        }

        // GET: /OfficeDirections/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: /OfficeDirections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include="Id,Direction_From_Site,Category_Of_Site,AddressandDescription_of_Site,Map_Of_Site,DirectionByWalk,DirectionByBus,officeid")] website_Office_Direction website_office_direction)
        {
            if (ModelState.IsValid)
            {
                db.website_Office_Direction.Add(website_office_direction);
                db.SaveChanges();
                createpreviewpage(website_office_direction.officeid ?? default(int));
                dlwebclasses.Content_Offices_NewWebsite NAL = new dlwebclasses.Content_Offices_NewWebsite(website_office_direction.officeid ?? default(int));
                dlwebclasses.CreateHTMLFIles_NEwWebsite CF = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL);
                ViewBag.filepath_NewWebsite = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Offices\\WebSite_Preview.html";
                return RedirectToAction("Edit", "CURD_OfficeDirections", new { id = website_office_direction.Id });
            }

            return View(website_office_direction);
        }

        // GET: /OfficeDirections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            website_Office_Direction website_office_direction = db.website_Office_Direction.Find(id);
            if (website_office_direction == null)
            {
                return HttpNotFound();
            }
            return View(website_office_direction);
        }

        // POST: /OfficeDirections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Direction_From_Site,Category_Of_Site,AddressandDescription_of_Site,Map_Of_Site,DirectionByWalk,DirectionByBus,officeid")] website_Office_Direction website_office_direction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(website_office_direction).State = EntityState.Modified;
                db.SaveChanges();
                createpreviewpage(website_office_direction.officeid ?? default(int));
                dlwebclasses.Content_Offices_NewWebsite NAL = new dlwebclasses.Content_Offices_NewWebsite(website_office_direction.officeid ?? default(int));
                dlwebclasses.CreateHTMLFIles_NEwWebsite CF = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL);
                ViewBag.filepath_NewWebsite = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Offices\\WebSite_Preview.html";
                return RedirectToAction("Edit", "CURD_OfficeDirections", new { id = website_office_direction.Id });
            }
            return View(website_office_direction);
        }

        // GET: /OfficeDirections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            website_Office_Direction website_office_direction = db.website_Office_Direction.Find(id);
            if (website_office_direction == null)
            {
                return HttpNotFound();
            }
            return View(website_office_direction);
        }

        // POST: /OfficeDirections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            website_Office_Direction website_office_direction = db.website_Office_Direction.Find(id);
            db.website_Office_Direction.Remove(website_office_direction);
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
            dlwebclasses.Content_Offices_NewWebsite NAL = new dlwebclasses.Content_Offices_NewWebsite(ID);
            string filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Offices\\WebSite_Preview.html";
            dlwebclasses.CreateHTMLFIles_NEwWebsite Fl = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL, filepath);
        }
    }
}
