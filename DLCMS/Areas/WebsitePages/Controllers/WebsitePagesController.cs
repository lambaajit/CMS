using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DLCMS.Models;
using dlwebclasses;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DLCMS.Areas.WebsitePages.Controllers
{
    public class WebsitePagesController : GenericBaseController<dlwebclasses.Website_Pages, WebsitePagesSearch, IT_DatabaseEntities>
    {
        private IT_DatabaseEntities db = new IT_DatabaseEntities();

        public ActionResult GetSubDepartment(int value)
        {
        string _dept = db.Website_Department_Structure.Where(x => x.ID == value).Select(x => x.Name).FirstOrDefault();
            _dept = _dept == "Immigration" ? "Legal Aid: Immigration and Asylum" : _dept;
            var _underWhichNode = db.Website_Structure.Where(x => x.name == _dept && x.level == "Root").Select(x => x.id).FirstOrDefault();
        var _websiteStructureRootNodes = db.Website_Structure.Where(x => x.underwhichnode == _underWhichNode && x.level != "ContentNode").OrderBy(x => x.name).Select(x => new SelectListItem() { Text = x.name, Value = x.id.ToString() }).Distinct().ToList();
            return Json(_websiteStructureRootNodes, JsonRequestBehavior.AllowGet);
    }

        public ActionResult GetSubSubDepartment(int value)
        {
            return Json(db.Website_Structure.Where(x => x.underwhichnode == value && x.level != "ContentNode").OrderBy(x => x.name).Select(x => new SelectListItem() { Text = x.name, Value = x.id.ToString() }).Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }

        public override PartialViewResult EditPartial(int id)
        {
            var _result = base.EditPartial(id);
            var model = (dlwebclasses.Website_Pages)_result.Model;
            var _website_structure = db.Website_Structure.Where(x => x.linkedid == model.ID && x.level == "ContentNode").FirstOrDefault();
            List<dlwebclasses.Website_Structure> _list = new List<dlwebclasses.Website_Structure>();
            var _allUpwardsNodes = GetAllNodesUpwards(_list, _website_structure);
            var _allIds = _allUpwardsNodes.Select(x => x.id).ToList();
            var _rootNode = _allUpwardsNodes.Where(x => x.level == "Root").FirstOrDefault();
            model.DepartmentInt = db.Website_Department_Structure.Where(x => (x.NameforHomePage == _rootNode.name && x.NameforHomePage != null) || x.Name == _rootNode.name).Select(x => x.ID).FirstOrDefault(); 
            var _subDeptNode = db.Website_Structure.Where(x => x.underwhichnode == _rootNode.id && _allIds.Contains(x.id) && x.level != "ContentNode").FirstOrDefault();
            
            if (_subDeptNode != null)
            {
                model.Sub_DepartmentInt = _subDeptNode.id;
                ViewBag.SubDepartmentList = new SelectList(db.Website_Structure.Where(x => x.underwhichnode == _rootNode.id && x.level != "ContentNode").Select(x => new SelectListItem() { Text = x.name, Value = x.id.ToString()}).ToList(),"Value","Text");
                var _subSubDeptNode = db.Website_Structure.Where(x => x.underwhichnode == _subDeptNode.id && _allIds.Contains(x.id) && x.level != "ContentNode").FirstOrDefault();
                if (_subSubDeptNode != null)
                {
                    model.Sub_Sub_DepartmentInt = _subSubDeptNode.id;
                    ViewBag.SubSubDepartmentList = new SelectList(db.Website_Structure.Where(x => x.underwhichnode == _subDeptNode.id && x.level != "ContentNode").Select(x => new SelectListItem() { Text = x.name, Value = x.id.ToString() }).ToList(),"Value","Text");
                }
            }
            return _result;
        }

        public List<dlwebclasses.Website_Structure> GetAllNodesUpwards(List<dlwebclasses.Website_Structure> list,dlwebclasses.Website_Structure website_Structure)
        {
            while (website_Structure.level != "Root")
            {
                var _node = db.Website_Structure.Where(x => x.id == website_Structure.underwhichnode).FirstOrDefault();
                list.Add(_node);
                GetAllNodesUpwards(list, _node);
                return list;
            }

            return list;
        }

        [ValidateInput(false)]
        public override PartialViewResult CreateUpdatePartial(dlwebclasses.Website_Pages record, int Id = 0)
        {
            int linkedid = 0;
            if (record.Sub_Sub_DepartmentInt != null)
                linkedid = Convert.ToInt16(record.Sub_Sub_DepartmentInt);
            else if (record.Sub_DepartmentInt != null)
                linkedid = Convert.ToInt16(record.Sub_DepartmentInt);
            else if (record.DepartmentInt != null)
                linkedid = Convert.ToInt16(record.DepartmentInt);

            int? dept = record.DepartmentInt;
            record.Department = db.Website_Department_Structure.Where(x => x.ID == dept).Select(y => y.Name).FirstOrDefault();
            if (record.Sub_DepartmentInt != null)
            {
                int? deptsub = record.Sub_DepartmentInt;
                record.Sub_Department = db.Website_Structure.Where(x => x.id == deptsub).Select(y => y.name).FirstOrDefault();
            }
            if (record.Sub_Sub_Department != null)
            {
                int deptsubsub = int.Parse(record.Sub_Sub_Department);
                record.Sub_Sub_Department = db.Website_Structure.Where(x => x.id == deptsubsub).Select(y => y.name).FirstOrDefault();
            }

            if (Id == 0)
            {

                var dup_id = db.Database.SqlQuery<int>("Select Max(ID) from Website_Pages").FirstOrDefault() + 1;
                dlwebclasses.Website_Structure ws = new dlwebclasses.Website_Structure();
                ws.level = "ContentNode";
                ws.underwhichnode = linkedid;
                ws.name = record.Name;
                //ws.linkedid = dup_id;
                record.Website_Structure = new List<dlwebclasses.Website_Structure>() { ws };
            }
            

            var _result = base.CreateUpdatePartial(record, Id);

            return _result;
        }

        public override void CreateWebPages(bool Created, int Id)
        {
            if (Id == 0)
                Id = db.Website_Pages.Max(x => x.ID);

            dlwebclasses.Content_WebsitePages_NewWebsite NAL = new dlwebclasses.Content_WebsitePages_NewWebsite(Id);
            dlwebclasses.CreateHTMLFIles_NEwWebsite CF = new dlwebclasses.CreateHTMLFIles_NEwWebsite(NAL);
        }

        public override void PolulateList()
        {
            ViewBag.DepartmentList = db.Website_Department_Structure.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).Distinct().ToList();
            ViewBag.CompanyList = db.Website_Pages.Select(x => new SelectListItem { Text = x.Company, Value = x.Company }).Distinct().ToList();
            ViewBag.VideoList = db.Website_Videos.Where(x => x.Active==true).Select(x => new SelectListItem { Text = x.Heading + " - (" + x.id + ")", Value = x.id.ToString() }).Distinct().ToList();
            ViewBag.SubDepartmentList = new SelectList(Enumerable.Empty<SelectListItem>());
            ViewBag.SubSubDepartmentList = new SelectList(Enumerable.Empty<SelectListItem>());
        }

        public override PartialViewResult GetFilteredRecords(WebsitePagesSearch search)
        {
            Session["WebsitePagesSearch"] = search;
            var _result = base.GetFilteredRecords(search);
            var model = (BaseViewModelWithList<dlwebclasses.Website_Pages>)_result.Model;
            
            if (!string.IsNullOrEmpty(search.Name))
                model.list = model.list.Where(x => x.Name.Contains(search.Name)).AsQueryable();
            if (!string.IsNullOrEmpty(search.Filename))
                model.list = model.list.Where(x => x.Filename.Contains(search.Filename.Replace(".html","").Replace("http://www.duncanlewis.co.uk/","").Replace("https://www.duncanlewis.co.uk/",""))).AsQueryable();
            if (search.VideoId != null && search.VideoId>0)
                model.list = model.list.Where(x => x.VideoId==search.VideoId).AsQueryable();
            if (!string.IsNullOrEmpty(search.Company))
                model.list = model.list.Where(x => x.Company == search.Company).AsQueryable();
            if (!string.IsNullOrEmpty(search.Department))
            {
                var _deptId = int.Parse(search.Department);
                var _dept = db.Website_Department_Structure.Where(x => x.ID == _deptId).FirstOrDefault().Name;
                model.list = model.list.Where(x => x.Department == _dept).AsQueryable();
            }


            model.NumberOfRecordsPerPage = search.NumberOfRecordsPerPages == 0 ? 50 : search.NumberOfRecordsPerPages;
            model.PageIndex = search.PageIndex;
            GetFilteredRecordsSkipTake(model);
            return PartialView("/Areas/" + model.AreaName + "/Views/" + model.ControllerName + "/Index.cshtml", model);
        }

    }

    public class WebsitePagesSearch : AbstractSearch<dlwebclasses.Website_Pages>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Filename { get; set; }
        public string Company { get; set; }
        public int? VideoId { get; set; }


        public WebsitePagesSearch() : base()
        {
            this.SortOn = "ID";
            this.OrderBy = "DESC";
            this.ClassProperties.Where(x => x.Name == "ID"
                                    || x.Name == "Name"
                                    || x.Name == "Department"
                                    || x.Name == "Sub_Department"
                                    || x.Name == "Filename"
                                    ).ToList().ForEach(x => x.IsSelected = true);
        }
    }
}
