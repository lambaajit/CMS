using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;
using System.Linq.Dynamic.Core;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Reflection;




namespace DLCMS
{
    
        [Authorize]
        public class GenericBaseController<T, S, D> : GenericBaseClass where T : class, ITrackedEntity where S : AbstractSearch<T>, new() where D : DbContext, new()
        {
            public DbContext db = null;
            public DbSet<T> table = null;

            public GenericBaseController()
            {
                this.db = new D();
                if (this.db == null)
                {
                    var _allCOntext = Assembly.GetAssembly(typeof(allStatic)).GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(DbContext)));
                    foreach (Type type in _allCOntext)
                    {
                        foreach (var _property in type.GetProperties())
                        {
                            if (_property.Name == typeof(T).Name)
                            {
                                this.db = (DbContext)Activator.CreateInstance(type);
                                break;
                            }
                        }
                    }
                }


                //this.db = context;
                table = db.Set<T>();
            }


            public virtual PartialViewResult GetList()
            {
                var _search = new S();
                var _model = GetModel();
                var _result = GetFilteredRecords(_search);
                var record = (BaseViewModelWithList<T>)_result.Model;
                var _property = typeof(T).GetProperties().Where(x => x.Name == _search.SortOn).FirstOrDefault()?.Name;

                if (_property == null)
                    _property = typeof(T).GetProperties().FirstOrDefault().Name;


                if (_search.OrderBy == "ASC")
                    record.list = record.list.OrderBy(_property);
                else
                    record.list = record.list.OrderBy(_property + " descending");

                GetFilteredRecordsSkipTake(record);
                return PartialView("/Areas/" + _model.AreaName + "/Views/" + _model.ControllerName + "/Index.cshtml", record);
            }

            public virtual BaseViewModelWithList<T> GetRecords()
            {
                var model = GetModel();
                BaseViewModelWithList<T> _model = new BaseViewModelWithList<T>(model.AreaName, model.ControllerName, model.EntityName, model.CanBeEdited, model.CanBeEditedAfterHalfHour, model.CanBeDeleted, model.NotesExist, model.FileUploadExist, 1, 1, 1);
                _model.list = table.AsQueryable();
                _model.PageIndex = 0;
                _model.NumberOfRecordsPerPage = 50;
                return _model;
            }

            public virtual PartialViewResult GetFilteredRecordsWithPagination(int startIndexOfList, int numberOfRecordsToTake)
            {
                var _search = (S)Session[typeof(S).Name];
                if (_search == null)
                    _search = new S();
                _search.PageIndex = startIndexOfList;
                _search.NumberOfRecordsPerPages = numberOfRecordsToTake;
                return GetFilteredRecords(_search);
            }

            public virtual PartialViewResult GetFilteredRecordsWithSorting(string SortOn)
            {
                var _search = (S)Session[typeof(S).Name];
                if (_search == null)
                    _search = new S();
                _search.SortOn = SortOn;
                return GetFilteredRecords(_search);
            }

            public virtual PartialViewResult GetFilteredRecords(S search)
            {
                var _model = GetRecords();
                string _AscOrDesc = "ASC";
                if ((string)Session["SortOn"] == search.SortOn)
                {
                    if (search.OrderBy == "ASC")
                    {
                        _AscOrDesc = "DESC";
                        search.OrderBy = _AscOrDesc;
                    }
                    else
                        search.OrderBy = "ASC";
                }
                else
                    _AscOrDesc = search.OrderBy;

                Session["SortOn"] = search.SortOn;

                if (!string.IsNullOrEmpty(search.SortOn))
                    _model.list = _model.list.OrderBy(search.SortOn + " " + _AscOrDesc);
                else
                {
                    var _property = typeof(T).GetProperties().FirstOrDefault().Name;
                    _model.list = _model.list.OrderBy(_property);
                }


                return PartialView("/Areas/" + _model.AreaName + "/Views/" + _model.ControllerName + "/Index.cshtml", _model);
            }

            public BaseViewModelWithList<T> GetFilteredRecordsSkipTake(BaseViewModelWithList<T> model)
            {
                model.TotalNumberOfRecords = model.list.Count();
                model.list = model.list.Skip(model.PageIndex * model.NumberOfRecordsPerPage).Take(model.NumberOfRecordsPerPage);
                return model;
            }

            public BaseViewModel GetModel()
            {
                var model = new BaseViewModel();
                model.AreaName = HttpContext.Request.RequestContext.RouteData.DataTokens["area"].ToString();
                model.ControllerName = HttpContext.Request.RequestContext.RouteData.Values["controller"].ToString();

                var _displayNameAttribute = (NameToBeDisplayedOnUIAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(NameToBeDisplayedOnUIAttribute));
                model.EntityName = _displayNameAttribute == null ? table.FirstOrDefault().GetType().Name.changePascelCaseToSpaces() : _displayNameAttribute.getDisplayname();
                var _editAttribute = (CanBeEditedAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(CanBeEditedAttribute));
                if (_editAttribute != null)
                    model.CanBeEdited = _editAttribute.getCanBeEdited();
                else
                    model.CanBeEdited = true;

                var _editedAfterHalfHourAttribute = (CanBeEditedAfterHalfHourAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(CanBeEditedAfterHalfHourAttribute));
                if (_editedAfterHalfHourAttribute != null)
                    model.CanBeEditedAfterHalfHour = _editedAfterHalfHourAttribute.getCanBeEdited();
                else
                    model.CanBeEditedAfterHalfHour = false;

                var _deleteAttribute = (CanBeDeletedAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(CanBeDeletedAttribute));
                if (_deleteAttribute != null)
                    model.CanBeDeleted = _deleteAttribute.getCanBeDeleted();
                else
                    model.CanBeDeleted = false;

                var _notesExistAttribute = (NotesExistAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(NotesExistAttribute));
                if (_notesExistAttribute != null)
                    model.NotesExist = _notesExistAttribute.getNotesExist();
                else
                    model.NotesExist = false;

                if (typeof(T).GetProperties().Where(x => x.PropertyType.Name == "HttpPostedFileBase").FirstOrDefault() != null)
                    model.FileUploadExist = true;
                else
                    model.FileUploadExist = false;
                return model;
            }

            public ActionResult Index()
            {
                return View("/Views/GenericBase/Index.cshtml", GetModel());
            }


            public ActionResult Details(object id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var record = table.Find(id);
                if (record == null)
                {
                    return HttpNotFound();
                }
                return View(record);
            }


            public ActionResult Create()
            {
                return View();
            }

            public virtual PartialViewResult CreatePartial()
            {

                var _model = GetModel();
                T record = null;
                PolulateList();
                return PartialView("/Areas/" + _model.AreaName + "/Views/" + _model.ControllerName + "/Create.cshtml", record);
            }

            public virtual PartialViewResult SearchPartial()
            {

                var _model = GetModel();
                //T record = null;
                PolulateList();
                var _search = new S();
                Session[typeof(S).Name] = _search;
                return PartialView("/Areas/" + _model.AreaName + "/Views/" + _model.ControllerName + "/Search.cshtml", _search);
            }

            [HttpPost]
            public virtual PartialViewResult CreateUpdatePartial(T record, int Id = 0)
            {
                CreateUpdateRecord(record, Id);
                return GetLastSearch();
            }

            [HttpPost]
            public virtual ActionResult CreateUpdate(T record, int Id = 0)
            {
                CreateUpdateRecord(record, Id);
                return View("/Views/GenericBase/Index.cshtml", GetModel());
            }

            public void CreateUpdateRecord(T record, int Id = 0)
            {
                PolulateList();
                record.ip_address = (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();

            if (Id == 0)
                {
                    record.CreatedDate = DateTime.Now;
                    record.CreatedBy = User.Identity.Name;
                    table.Add(record);
                    db.SaveChanges();
                    CreateWebPages(true,0);
                }
                else
                {
                    record.ModifiedDate = DateTime.Now;
                    record.ModifiedBy = User.Identity.Name;
                    table.Attach(record);
                    db.Entry(record).State = EntityState.Modified;
                    db.SaveChanges();
                    CreateWebPages(false, Id);
                }
            
            }

        public virtual void CreateWebPages(bool Created, int Id)
        {

        }

            [HttpPost]
            public ActionResult Create(T record)
            {
                if (ModelState.IsValid)
                {
                    record.CreatedDate = DateTime.Now;
                    record.CreatedBy = User.Identity.Name;
                    table.Add(record);
                    db.SaveChanges();
                }
                return View(record);
            }


            public ActionResult Edit(object id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var record = table.Find(id);
                if (record == null)
                {
                    return HttpNotFound();
                }
                return View(record);
            }


            public virtual PartialViewResult EditPartial(int id)
            {
                PolulateList();
                var record = table.Find(id);
                var _model = GetModel();
                return PartialView("/Areas/" + _model.AreaName + "/Views/" + _model.ControllerName + "/Create.cshtml", record);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(T record)
            {
                if (ModelState.IsValid)
                {
                    record.ModifiedDate = DateTime.Now;
                    record.ModifiedBy = User.Identity.Name;
                    table.Attach(record);
                    db.Entry(record).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(record);
            }

            public ActionResult Delete(object id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                T record = table.Find(id);
                if (record == null)
                {
                    return HttpNotFound();
                }
                return View(record);
            }

            [HttpPost]
            public PartialViewResult DeletePartial(int DeleteId)
            {

                T record = table.Find(DeleteId);
                table.Remove(record);
                db.SaveChanges();
                var _model = GetModel();
                return GetLastSearch();
            }

            public PartialViewResult GetLastSearch()
            {
                var _search = (S)Session[typeof(S).Name];
                if (_search == null)
                    _search = new S();
                return GetFilteredRecords(_search);
            }

            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {

                T record = table.Find(id);
                table.Remove(record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            public virtual void PolulateList()
            {

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

        public static class converttoModel<T> where T : class
        {
            public static BaseViewModelWithColumnHeaders converToBaseViewModelWithColumnHeaders(BaseViewModelWithList<T> model)
            {
                return new BaseViewModelWithColumnHeaders(
                    model.AreaName,
                    model.ControllerName,
                    model.EntityName,
                    model.CanBeEdited,
                    model.CanBeEditedAfterHalfHour,
                    model.CanBeDeleted,
                    model.NotesExist,
                    model.FileUploadExist,
                    model.PageIndex,
                    model.NumberOfRecordsPerPage,
                    model.TotalNumberOfRecords
                );
            }

        }





        public class BaseViewModel
        {
            public BaseViewModel()
            {
            }

            public BaseViewModel(string areaName, string controllerName, string entityName, bool canBeEdited, bool canBeEditedAfterHalfHour, bool canBeDeleted, bool notesExist, bool fileUploadExist, int pageIndex, int numberOfRecordsPerPage, int totalNumberOfRecords)
            {
                AreaName = areaName;
                ControllerName = controllerName;
                EntityName = entityName;
                CanBeEdited = canBeEdited;
                CanBeEditedAfterHalfHour = canBeEditedAfterHalfHour;
                CanBeDeleted = canBeDeleted;
                NotesExist = notesExist;
                FileUploadExist = fileUploadExist;
                PageIndex = pageIndex;
                NumberOfRecordsPerPage = numberOfRecordsPerPage;
                TotalNumberOfRecords = totalNumberOfRecords;
            }

            public string AreaName { get; set; }
            public string ControllerName { get; set; }
            public string EntityName { get; set; }
            public bool CanBeEdited { get; set; }
            public bool CanBeEditedAfterHalfHour { get; set; }
            public bool CanBeDeleted { get; set; }
            public bool NotesExist { get; set; }
            public bool FileUploadExist { get; set; }
            public int PageIndex { get; set; }
            public int NumberOfRecordsPerPage { get; set; }
            public int TotalNumberOfRecords { get; set; }


        }

        public class BaseViewModelWithColumnHeaders : BaseViewModel
        {
            public BaseViewModelWithColumnHeaders(string AreaName, string ControllerName, string EntityName, bool CanBeEdited, bool CanBeEditedAfterHalfHour, bool CanBeDeleted, bool noteExist, bool fileUploadExist, int pageIndex, int numberOfRecordsPerPage, int totalNumberOfRecords) : base(AreaName, ControllerName, EntityName, CanBeEdited, CanBeEditedAfterHalfHour, CanBeDeleted, noteExist, fileUploadExist, pageIndex, numberOfRecordsPerPage, totalNumberOfRecords)
            {
            }
            public List<string> ColumnHeaders { get; set; }
            public List<CheckBoxListItem> ClassProperties { get; set; }

        }

        public class BaseViewModelWithList<T> : BaseViewModel
        {
            public BaseViewModelWithList(string AreaName, string ControllerName, string EntityName, bool CanBeEdited, bool CanBeEditedAfterHalfHour, bool CanBeDeleted, bool notesExist, bool fileUploadExist, int pageIndex, int numberOfRecordsPerPage, int totalNumberOfRecords) : base(AreaName, ControllerName, EntityName, CanBeEdited, CanBeEditedAfterHalfHour, CanBeDeleted, notesExist, fileUploadExist, pageIndex, numberOfRecordsPerPage, totalNumberOfRecords)
            {

            }
            public IQueryable<T> list { get; set; }
            public List<T> listAsEnumerable { get; set; }
            public List<Tuple<string, bool>> ClassProperties { get; set; }
        }



        public class GenericBaseClass : Controller { }
    }



