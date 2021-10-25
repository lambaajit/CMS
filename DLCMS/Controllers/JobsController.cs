using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dlwebclasses;
using System.IO;

namespace DLCMS.Controllers
{
    public class JobsController : Controller
    {
        DLWEBEntities dlweb = new DLWEBEntities();
        IT_DatabaseEntities dbit = new IT_DatabaseEntities();
        //
        // GET: /Jobs/
        public ActionResult Index()
        {
            //dlweb.Recruitment_DlWeb.GroupBy(x => x.Department).Select(x => x.First()).Select(z => new SelectListItem { Text = z.Department, Value = z.Department }).ToList();
            List<SelectListItem> departments = dbit.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").Select(y => new SelectListItem { Text = y.Name, Value = y.Name }).ToList();
            departments.AddRange(new List<SelectListItem> {  new SelectListItem { Text = "Caseworker", Value = "Caseworker"},
                                                        new SelectListItem { Text = "Trainee", Value = "Trainee"},
                                                        new SelectListItem { Text = "Solicitor", Value = "Solicitor"},
                                                        new SelectListItem { Text = "Consultant", Value = "Consultant"},
                                                        new SelectListItem { Text = "Admin", Value = "Admin"},
                                                        new SelectListItem { Text = "Internship", Value = "Internship"},
                                                        new SelectListItem { Text = "Cost Draftsman and Billing", Value = "Cost Draftsman and Billing"},
                                                        new SelectListItem { Text = "Apprenticeship", Value = "Apprenticeship"},
                                                        new SelectListItem { Text = "All", Value = "All"}
                                                    });

            ViewBag.department = departments;
            ViewBag.category = new List<SelectListItem> {   
                                                            new SelectListItem { Value = "AreaOfLaw", Text = "AreaOfLaw" },
                                                            new SelectListItem { Value = "Category", Text = "Category" }
                                                        };
            return View();
        }

        public ActionResult createjobslandingpage(string category, string department)
        {
            List<SelectListItem> departments = new List<SelectListItem>();
            if (category == "AreaOfLaw")
            departments = dbit.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").Select(y => new SelectListItem { Text = y.Name, Value = y.Name }).ToList();
            else
            departments = new List<SelectListItem> {  new SelectListItem { Text = "Caseworker", Value = "Caseworker"},
                                                        new SelectListItem { Text = "Trainee", Value = "Trainee"},
                                                        new SelectListItem { Text = "Solicitor", Value = "Solicitor"},
                                                        new SelectListItem { Text = "Consultant", Value = "Consultant"},
                                                        new SelectListItem { Text = "Admin", Value = "Admin"},
                                                        new SelectListItem { Text = "Internship", Value = "Internship"},
                                                        new SelectListItem { Text = "Cost Draftsman and Billing", Value = "Cost Draftsman and Billing"},
                                                        new SelectListItem { Text = "Apprenticeship", Value = "Apprenticeship"},
                                                        new SelectListItem { Text = "All", Value = "All"}
                                                    };

            ViewBag.department = departments;
            ViewBag.category = new List<SelectListItem> {   
                                                            new SelectListItem { Value = "AreaOfLaw", Text = "AreaOfLaw" },
                                                            new SelectListItem { Value = "Category", Text = "Category" }
                                                        };

            
            
            
            
            Content_JobsLanding_NewWebsite NAL;
            NAL = new Content_JobsLanding_NewWebsite(department, category);
            CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
            //foreach (var item in departments)
            //{
            //    NAL = new Content_JobsLanding_NewWebsite(item.Value.Replace("&","and") , category);
            //    CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
            //}

            return View("Index");
        }

        [HttpPost]
        public ActionResult createconsultnatjobs()
        {
            List<SelectListItem> departments = dbit.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").Select(y => new SelectListItem { Text = y.Name, Value = y.Name }).ToList();
            departments.AddRange(new List<SelectListItem> {  new SelectListItem { Text = "Caseworker", Value = "Caseworker"},
                                                        new SelectListItem { Text = "Trainee", Value = "Trainee"},
                                                        new SelectListItem { Text = "Solicitor", Value = "Solicitor"},
                                                        new SelectListItem { Text = "Consultant", Value = "Consultant"},
                                                        new SelectListItem { Text = "Admin", Value = "Admin"},
                                                        new SelectListItem { Text = "Internship", Value = "Internship"},
                                                        new SelectListItem { Text = "Cost Draftsman and Billing", Value = "Cost Draftsman & Billing"},
                                                        new SelectListItem { Text = "Apprenticeship", Value = "Apprenticeship"},
                                                        new SelectListItem { Text = "All", Value = "All"}
                                                    });

            ViewBag.department = departments;
            ViewBag.category = new List<SelectListItem> {
                                                            new SelectListItem { Value = "AreaOfLaw", Text = "AreaOfLaw" },
                                                            new SelectListItem { Value = "Category", Text = "Category" }
                                                        };

            Content_JobsLanding_NewWebsite NAL;


            DLWEBEntities db = new DLWEBEntities();
            List<string> depts = db.Database.SqlQuery<string>("select distinct replace(department,'&','and') from [Recruitment_DlWeb] where Job_Type = 'Freeleance' and live = '1'").ToList();
            foreach (var dept in depts)
            {
                    NAL = new Content_JobsLanding_NewWebsite(dept, "Consultancy");
                    CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
            }

            return View("Index");
        }

        public ActionResult createjobspage(string category, string department, string JobsIDs = "")
        {
            if (string.IsNullOrEmpty(JobsIDs) == false)
            {
                DLWEBEntities dlweb = new DLWEBEntities();
                List<Recruitment_DlWeb> recruitment = new List<Recruitment_DlWeb>();
                if (department == "Admin")
                    department = "Support";



                //List<int> jobids = new List<int> { 11905,11878,11820,11808,11913,11882,11881,11878,11859,11856, 11820,11808,11794,11755,11754,4676,4761,4762,4850,4891,4892,4905,4936,11922,11919,11910,11904,11888,11887,11885,11801,11800,4702,4768,4823,4857,4855,4913,593,4719,4749,4865,4897,11906,11902,11901,11839,11838,11792,11791,11790 };
                List<int> jobids = StringToIntList(JobsIDs).ToList();
                
                List<string> depts = new List<string>() { "Family", "Child Care", "Housing" };
                recruitment = dlweb.Recruitment_DlWeb.Where(x => x.Live == true && jobids.Contains(x.Job_Ref_Code)).OrderByDescending(z => z.Job_Ref_Code).ToList();//&& jobids.Contains(x.Job_Ref_Code) && x.Job_Type == "Permanent"
                                                                                                                                                                                   //

                //

                Content_JobsPage_NewWebsite NAL;
                foreach (var item in recruitment)
                {
                    NAL = new Content_JobsPage_NewWebsite(item.Job_Ref_Code);
                    CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
                    StreamWriter fp;
                    fp = System.IO.File.CreateText(Server.MapPath("~") + "/lastid.txt");
                    fp.WriteLine(item.Job_Ref_Code);
                    fp.Close();
                }
            }

            ViewBag.JobsIDs = JobsIDs;

            List<SelectListItem> departments = dbit.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").Select(y => new SelectListItem { Text = y.Name, Value = y.Name }).ToList();
            departments.AddRange(new List<SelectListItem> {  new SelectListItem { Text = "Caseworker", Value = "Caseworker"},
                                                        new SelectListItem { Text = "Trainee", Value = "Trainee"},
                                                        new SelectListItem { Text = "Solicitor", Value = "Solicitor"},
                                                        new SelectListItem { Text = "Consultant", Value = "Consultant"},
                                                        new SelectListItem { Text = "Admin", Value = "Admin"},
                                                        new SelectListItem { Text = "Internship", Value = "Internship"},
                                                        new SelectListItem { Text = "Cost Draftsman and Billing", Value = "Cost Draftsman and Billing"},
                                                        new SelectListItem { Text = "Apprenticeship", Value = "Apprenticeship"},
                                                        new SelectListItem { Text = "All", Value = "All"}
                                                    });

            ViewBag.department = departments;
            ViewBag.category = new List<SelectListItem> {   
                                                            new SelectListItem { Value = "AreaOfLaw", Text = "AreaOfLaw" },
                                                            new SelectListItem { Value = "Category", Text = "Category" }
                                                        };

            return View("Index");
        }

        public static IEnumerable<int> StringToIntList(string str)
        {
            if (String.IsNullOrEmpty(str))
                yield break;

            foreach (var s in str.Split(','))
            {
                int num;
                if (int.TryParse(s, out num))
                    yield return num;
            }
        }
    }
}