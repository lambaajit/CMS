using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;

namespace DLCMS.Areas.WebsiteOfficeDirection.Controllers
{
    public class website_Office_DirectionController : GenericBaseController<website_Office_Direction, WebsiteOfficeDirectionSearch, IT_DatabaseEntities>
    {
        private IT_DatabaseEntities db = new IT_DatabaseEntities();
        private DLWEBEntities dbweb = new DLWEBEntities();
        public override void PolulateList()
        {
            ViewBag.OfficeList = new SelectList(dbweb.OfficesDLW.Where(x => x.Active ==  true).OrderBy(x => x.Name).Select(x => new SelectListItem() { Text = x.Name , Value=x.ID.ToString() }).ToList(),"Value","Text");
        }

        [ValidateInput(false)]
        public override PartialViewResult CreateUpdatePartial(website_Office_Direction record, int Id = 0)
        {
            return base.CreateUpdatePartial(record, Id);
        }

        public override PartialViewResult GetFilteredRecords(WebsiteOfficeDirectionSearch search)
        {
            Session["WebsiteOfficeDirectionSearch"] = search;
            var _result = base.GetFilteredRecords(search);
            var model = (BaseViewModelWithList<dlwebclasses.website_Office_Direction>)_result.Model;

            if (search.OfficeId != null)
                model.list = model.list.Where(x => x.officeid == search.OfficeId).AsQueryable();

            model.NumberOfRecordsPerPage = search.NumberOfRecordsPerPages == 0 ? 50 : search.NumberOfRecordsPerPages;
            model.PageIndex = search.PageIndex;
            GetFilteredRecordsSkipTake(model);
            return PartialView("/Areas/" + model.AreaName + "/Views/" + model.ControllerName + "/Index.cshtml", model);
        }

    }


    public class WebsiteOfficeDirectionSearch : AbstractSearch<dlwebclasses.website_Office_Direction>
    {
        public int? ID { get; set; }
        public int? OfficeId { get; set; }

        public WebsiteOfficeDirectionSearch() : base()
        {
            this.SortOn = "ID";
            this.OrderBy = "DESC";
            this.ClassProperties.Where(x => x.Name == "ID"
                                    || x.Name == "Category_Of_Site"
                                    || x.Name == "officeid"
                                    || x.Name == "Heading"
                                    ).ToList().ForEach(x => x.IsSelected = true);
        }
    }
}
