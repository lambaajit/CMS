using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using DLCMS.Models;
using dlwebclasses;
using Microsoft.Ajax.Utilities;

namespace DLCMS.Controllers
{
    [Authorize]
    public class CURD_WebsiteawardsController : BaseController
    {
        
        static int testint = 1;
        private DLCMS_ITDatabase db = new DLCMS_ITDatabase();

        // GET: /CURD_Websiteawards/
        public ActionResult Index()
        {
            return View(db.website_awards.ToList());
        }

        // GET: /CURD_Websiteawards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLCMS.Models.website_awards website_awards = db.website_awards.Find(id);
            if (website_awards == null)
            {
                return HttpNotFound();
            }
            return View(website_awards);
        }

        // GET: /CURD_Websiteawards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CURD_Websiteawards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include="id,IndividualCompany,StaffName,Year,LegalDirectory,LegalDirectoryArea,LegalDirectoryDepartment,DLOffice,DLDepartment,Blurb,LogosToUse")] DLCMS.Models.website_awards website_awards1)
        {
            if (ModelState.IsValid)
            {
                HRDDLEntities dbhr = new HRDDLEntities();
                website_awards1.StaffName = dbhr.Emp_Details.Where(x => x.emp_code == website_awards1.StaffName).Select(y => y.forename + " " + y.surname).FirstOrDefault();
                db.website_awards.Add(website_awards1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(website_awards1);
        }

        // GET: /CURD_Websiteawards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLCMS.Models.website_awards website_awards = db.website_awards.Find(id);
            if (website_awards == null)
            {
                return HttpNotFound();
            }
            return View(website_awards);
        }

        // POST: /CURD_Websiteawards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,IndividualCompany,StaffName,Year,LegalDirectory,LegalDirectoryArea,LegalDirectoryDepartment,DLOffice,DLDepartment,Blurb,LogosToUse")] DLCMS.Models.website_awards website_awards)
        {
            if (ModelState.IsValid)
            {
                db.Entry(website_awards).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(website_awards);
        }

        // GET: /CURD_Websiteawards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLCMS.Models.website_awards website_awards = db.website_awards.Find(id);
            if (website_awards == null)
            {
                return HttpNotFound();
            }
            return View(website_awards);
        }

        // POST: /CURD_Websiteawards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DLCMS.Models.website_awards website_awards = db.website_awards.Find(id);
            db.website_awards.Remove(website_awards);
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

        public ActionResult Test()
        {
            if ((int?)ViewBag.Test == null)
                ViewBag.Test = testint;

         
            website_Header_Pictures _website_Header_Pictures = new website_Header_Pictures();
            // Use type variables.
            // ... Then pass the variables as an argument.
            Type type1 = typeof(string[]);
            Type type2 = "string".GetType();
            Type type3 = typeof(Type);
            Type type4 = _website_Header_Pictures.GetType();

            Print(type1);
            Print(type2);
            Print(type3);
            Print(type4);

            return View(ViewBag.Test);
        }

        [HttpPost]
        public ActionResult Test(int Test)
        {
            ViewBag.Test = Test;
            return View(ViewBag.Test);
        }
    


        static void Print(Type type)
        {
            // Print some properties of the Type formal parameter.
            Debug.WriteLine("IsArray: {0}", type.IsArray);
            Debug.WriteLine("Name: {0}", type.Name);
            Debug.WriteLine("IsSealed: {0}", type.IsSealed);
            Debug.WriteLine("BaseType.Name: {0}", type.BaseType.Name);
            Debug.WriteLine("Assembly {0}", type.Assembly.FullName);
            Debug.WriteLine("Namespace {0}", type.Namespace.ToString());
            Debug.WriteLine(" ");
        }

    }
}
