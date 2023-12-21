using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using DLCMS.Areas.WebsitePages.Controllers;
using DLCMS.Models;
using dlwebclasses;

namespace DLCMS.Areas.NewsArticles.Controllers
{
    public class Updates_MainWebsitesController : GenericBaseController<dlwebclasses.Updates_MainWebsites, Updates_MainWebsitesSearch, IT_DatabaseEntities>
    {
        private IT_DatabaseEntities db = new IT_DatabaseEntities();


        public override void PolulateList()
        {
            ViewBag.DepartmentList = db.Updates_MainWebsite_Departments.OrderBy(x => x.Department).Select(x => new SelectListItem { Text = x.Department, Value = x.Department }).ToList();
        }



        [ValidateInput(false)]
        public override ActionResult CreateUpdate(dlwebclasses.Updates_MainWebsites record, int Id = 0)
        {
            
            if (record.fileUploaded != null)
                record.Image = true;
            else
                record.Image = false;
 
            
            
            if (record.ID == 0)
            {
                record.Date_Added = DateTime.Now;
                record.category = record.DLorNonDL;
                record.KeywordsToBeUsed = "Yes";
                record.video = false;
                record.Live = true;
                if (record.Title.ToString().Length > 160)
                    record.filename = record.Title.ToString().Replace("'", "^").Replace("?", "").Replace("-", "").Replace("%", "").Replace("/", "").Replace(" ", "_").Replace("\"", "").Substring(0, 160);
                else
                    record.filename = record.Title.ToString().Replace("'", "^").Replace("?", "").Replace("-", "").Replace("%", "").Replace("/", "").Replace(" ", "_").Replace("\"", "");

                record.Duplicate_ID = (int)db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('updates_mainwebsites')").FirstOrDefault() + 1;
            }
            else
                record.Duplicate_ID = db.Updates_MainWebsites.Find(record.ID).Duplicate_ID;

            
            


            if (record.ID != 0)
            {
                var _updateMainwesites = db.Updates_MainWebsites.Where(x => x.Duplicate_ID == record.Duplicate_ID).ToList();
                var last = _updateMainwesites.Last();
                foreach (var _updateMainwesite in _updateMainwesites)
                {
                    dlwebclasses.Updates_MainWebsites _updates_MainWebsites = db.Updates_MainWebsites.Find(_updateMainwesite.ID);
                    _updateMainwesite.Contents = record.Contents;
                    _updateMainwesite.Blog_Department = record.Blog_Department;
                    _updateMainwesite.Brief = record.Brief;
                    _updateMainwesite.category = record.category;
                    _updateMainwesite.Title = record.Title;
                    _updateMainwesite.Date_Update = record.Date_Update;
                    _updateMainwesite.Page_Title = record.Page_Title;
                    _updateMainwesite.Keywords = record.Keywords;
                    _updateMainwesite.Live = record.Live;
                    _updateMainwesite.Description = record.Description;
                    _updateMainwesite.DLorNonDL =   record.DLorNonDL;
                    _updateMainwesite.Staff1 = record.Staff1;
                    _updateMainwesite.Staff2 = record.Staff2;
                    _updateMainwesite.Staff3 = record.Staff3;
                    _updateMainwesite.Staff4 = record.Staff4;
                    _updateMainwesite.Staff5 = record.Staff5;
                    _updateMainwesite.Staff6 = record.Staff6;
                    _updateMainwesite.Staff7 = record.Staff7;
                    _updateMainwesite.Staff8 = record.Staff8;
                    _updateMainwesite.Staff9 = record.Staff9;
                    _updateMainwesite.Staff10 = record.Staff10;

                    if (record.fileUploaded != null)
                        saveDocuemnt(record.fileUploaded, _updateMainwesite.ID, record.Department);

                    


                    if (_updateMainwesite.Equals(last))
                        return base.CreateUpdate(_updates_MainWebsites, _updates_MainWebsites.ID);
                    else
                    {
                        base.CreateUpdateRecord(_updates_MainWebsites, _updates_MainWebsites.ID);
                        db.Entry(_updates_MainWebsites).State = EntityState.Detached;
                    }
                }
            }
            else
            {
                record.ExtraDepartments.Add(record.Department);
                if (record.Department == "InThePress")
                    record.ExtraDepartments = new List<string>() { "InThePress" };

                string last = record.ExtraDepartments.Last();
                foreach (var _dept in record.ExtraDepartments.Distinct())
                {
                    if (record.fileUploaded != null)
                    {
                        var nextid = (int)db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('updates_mainwebsites')").FirstOrDefault() + 1;
                        saveDocuemnt(record.fileUploaded, nextid, record.Department);
                    }

                    record.Department = _dept;

                    if (_dept.Equals(last))
                        return base.CreateUpdate(record, Id);
                    else
                        base.CreateUpdateRecord(record, Id);
                }
            }
            return base.CreateUpdate(record, Id);
        }


        public override void CreateWebPages(bool Created, int Id)
        {
            if (Id == 0)
                Id = db.Updates_MainWebsites.Max(x => x.ID);
            var _updateMainwesites = db.Updates_MainWebsites.Where(x => x.ID == Id).FirstOrDefault();
            var _allUpdateMainwesites = db.Updates_MainWebsites.Where(x => x.Duplicate_ID == _updateMainwesites.Duplicate_ID).OrderBy(x => x.ID).ToList();
            if (_allUpdateMainwesites.LastOrDefault().ID == Id)
            {
                foreach (string str in _allUpdateMainwesites.Select(x => x.Department).ToList())
                {
                    dlwebclasses.Content_NewsArticlesLandingPages_NewWebsite NAL;
                    NAL = new dlwebclasses.Content_NewsArticlesLandingPages_NewWebsite(str, _updateMainwesites.category, DateTime.Now.Year, DateTime.Now.Month);
                    dlwebclasses.CreateHTMLFIles_NEwWebsite Fl = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL);
                }

                foreach (int IDs in _allUpdateMainwesites.Select(x => x.ID).ToList())
                {
                    dlwebclasses.Content_NewsArticles_NewWebsite NAL;
                    NAL = new dlwebclasses.Content_NewsArticles_NewWebsite(IDs);
                    dlwebclasses.CreateHTMLFIles_NEwWebsite Fl = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL);
                }
            }
        }

        public void saveDocuemnt(HttpPostedFileBase file, int FID, string _dept)
        {
            if (_dept != "InThePress")
                file.SaveAs(ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "//ArticlesImages//" + FID + file.FileName.Substring(file.FileName.LastIndexOf("."), file.FileName.Length - file.FileName.LastIndexOf(".")));
            else
                file.SaveAs(ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "//InthePress//" + file.FileName.Replace("'", "").Replace(":", "") + ".pdf");
        }

public override PartialViewResult GetFilteredRecords(Updates_MainWebsitesSearch search)
        {
            Session["Updates_MainWebsitesSearch"] = search;
            var _result = base.GetFilteredRecords(search);
            var model = (BaseViewModelWithList<dlwebclasses.Updates_MainWebsites>)_result.Model;

            if (!string.IsNullOrEmpty(search.Title))
                model.list = model.list.Where(x => x.Title.Contains(search.Title)).AsQueryable();
            if (!string.IsNullOrEmpty(search.Department))
                model.list = model.list.Where(x => x.Department == search.Department).AsQueryable();
            if (search.DLorNonDL != null && search.DLorNonDL != "All")
                model.list = model.list.Where(x => x.DLorNonDL == search.DLorNonDL).AsQueryable();
            if (search.Date_Update != null)
                model.list = model.list.Where(x => x.Date_Update == search.Date_Update).AsQueryable();
            if (search.MonthYear != null)
                model.list = model.list.Where(x => x.Date_Update.Value.Month == search.MonthYear.Value.Month && x.Date_Update.Value.Year == search.MonthYear.Value.Year).AsQueryable();


            model.NumberOfRecordsPerPage = search.NumberOfRecordsPerPages == 0 ? 50 : search.NumberOfRecordsPerPages;
            model.PageIndex = search.PageIndex;
            GetFilteredRecordsSkipTake(model);
            return PartialView("/Areas/" + model.AreaName + "/Views/" + model.ControllerName + "/Index.cshtml", model);
        }
    }

    public class Updates_MainWebsitesSearch : AbstractSearch<dlwebclasses.Updates_MainWebsites>
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> Date_Update { get; set; }
        public Nullable<System.DateTime> MonthYear { get; set; }
        public string Department { get; set; }
        public string DLorNonDL { get; set; }

        public Updates_MainWebsitesSearch() : base()
        {
            this.SortOn = "ID";
            this.OrderBy = "DESC";
            this.ClassProperties.Where(x => x.Name == "ID"
                                    || x.Name == "Title"
                                    || x.Name == "Date_Update"
                                    || x.Name == "Department"
                                    || x.Name == "DLorNonDL"
                                    ).ToList().ForEach(x => x.IsSelected = true);
        }
    }
}
