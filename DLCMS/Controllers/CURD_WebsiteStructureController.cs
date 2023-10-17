using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DLCMS.Models;

namespace DLCMS.Controllers
{
    [Authorize]
    public class CURD_WebsiteStructureController : Controller
    {
        private DLCMS_ITDatabase db = new DLCMS_ITDatabase();

        // GET: /CURD_WebsiteStructure/
        public ActionResult Index()
        {
            return View(db.Website_Structure.ToList());
        }

        // GET: /CURD_WebsiteStructure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Website_Structure website_structure = db.Website_Structure.Find(id);
            if (website_structure == null)
            {
                return HttpNotFound();
            }
            return View(website_structure);
        }

        // GET: /CURD_WebsiteStructure/Create
        public ActionResult Create()
        {
            List<Website_Structure> ls = new List<Website_Structure>();
            ls = db.Website_Structure.Where(x => x.level != "ContentNode").ToList();
            List<SelectListItem> ls1 = new List<SelectListItem>();
            foreach (var item in ls)
            {
                ls1.Add(new SelectListItem { Text = item.name, Value = item.id.ToString() });
            }
            ViewBag.underwhichnode = ls1;
            return View();
        }

        // POST: /CURD_WebsiteStructure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,underwhichnode,level,linkedid,sequence")] Website_Structure website_structure)
        {
            if (ModelState.IsValid)
            {
                db.Website_Structure.Add(website_structure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Website_Structure> ls = new List<Website_Structure>();
            ls = db.Website_Structure.Where(x => x.level != "ContentNode").ToList();
            List<SelectListItem> ls1 = new List<SelectListItem>();
            foreach (var item in ls)
            {
                ls1.Add(new SelectListItem { Text = item.name, Value = item.id.ToString() });
            }
            ViewBag.underwhichnode = ls1;
            return View(website_structure);
        }

        // GET: /CURD_WebsiteStructure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Website_Structure website_structure = db.Website_Structure.Find(id);
            if (website_structure == null)
            {
                return HttpNotFound();
            }
            return View(website_structure);
        }

        // POST: /CURD_WebsiteStructure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,underwhichnode,level,linkedid,sequence")] Website_Structure website_structure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(website_structure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(website_structure);
        }

        // GET: /CURD_WebsiteStructure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Website_Structure website_structure = db.Website_Structure.Find(id);
            if (website_structure == null)
            {
                return HttpNotFound();
            }
            return View(website_structure);
        }

        // POST: /CURD_WebsiteStructure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Website_Structure website_structure = db.Website_Structure.Find(id);
            db.Website_Structure.Remove(website_structure);
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
    }
}
