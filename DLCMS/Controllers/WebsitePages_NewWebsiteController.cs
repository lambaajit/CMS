using dlwebclasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DLCMS.Controllers
{
    public class WebsitePages_NewWebsiteController : BaseController
    {
        //
        // GET: /WebsitePages_NewWebsite/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createwebsitepages(string cbo_WebPagedept)
        {
            if (cbo_WebPagedept == "All")
            {

                foreach (string str in webpagesdeptlist)
                {
                    cwp(str);
                }
            }
            else
            {
                cwp(cbo_WebPagedept);
            }
            return View("Index");
        }

        public void cwp(string dept)
        {
            Content_WebsitePages_NewWebsite NAL;
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            

            List<Website_Pages> WP = new List<Website_Pages>();
            if (dept == "All Landing pages")
            {
                List<string> landingfilename = db.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").Select(y => y.Overview1.Replace(".html", "")).ToList();
                WP = db.Website_Pages.Where(x => x.Company == "Duncan Lewis" && landingfilename.Contains(x.Filename) && x.Enabled == true).ToList();//
            }
            else if (dept == "All pages")
            {
                List<int> ids = new List<int>() { 62, 63, 81, 82 };
                WP = db.Website_Pages.Where(x => x.Company == "Duncan Lewis" && x.Title.Contains("Duncan Lewis") && x.Title.Length < 60 && x.Enabled == true).ToList();
            }
            else if (dept == "Website Pages with Videos")
            {
                WP = db.Website_Pages.Where(x => x.VideoId != null && x.VideoId > 0 && x.Enabled == true).ToList();
            }
            else
            {
                List<int> ids = new List<int>() { 342, 433, 11, 1699, 1700, 1598, 1599, 1644, 1645, 12, 13, 28 };
                int Department = int.Parse(dept);
                string Dept = db.Website_Department_Structure.Where(x => x.ID == Department).Select(y => y.Name).FirstOrDefault();
                WP = db.Website_Pages.Where(x => x.Company == "Duncan Lewis" && x.Department == Dept && x.Enabled == true).ToList();
            }
            //.Take(1)
            foreach (Website_Pages _WP in WP)
            {
                try
                {
                    NAL = new Content_WebsitePages_NewWebsite(_WP.ID);
                    CreateHTMLFIles_NEwWebsite Fl = new CreateHTMLFIles_NEwWebsite(NAL);
                }
                catch
                {
                    
                }
            }
        }

        public ActionResult CreateCostLaw()
        {
            Content_CostLawWebpages NAL;
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            List<Website_Pages> WP = new List<Website_Pages>();
            WP = db.Website_Pages.Where(x => x.Company == "Cost Law").ToList();
            //.Take(1)
            foreach (Website_Pages _WP in WP)
            {
                NAL = new  Content_CostLawWebpages(_WP.ID);
                CreateHTMLFiles_CostLaw Fl = new CreateHTMLFiles_CostLaw(NAL);
            }

            SitemapCostLaw sitemapCostLaw = new SitemapCostLaw();

            //IT_DatabaseEntities db = new IT_DatabaseEntities();
            //var res1 = db.Website_Pages.Where(x => x.Company == "Cost Law").ToList();
            //foreach (var res in res1)
            //{
            //    StringBuilder sb = new StringBuilder();


            //    sb.AppendLine("<!DOCTYPE html>");
            //    sb.AppendLine("<html>");
            //    sb.AppendLine("<head>");
            //    sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            //    sb.AppendLine("<title>" + res.Title + "</title>");
            //    sb.AppendLine("<meta name=\"description\" content=\"" + res.Description + "\"/>");
            //    sb.AppendLine("<meta name=\"keywords\" content=\"" + res.Keywords + "\"/>");
            //    sb.AppendLine("<meta name=\"google-site-verification\" content=\"9Hr7np4-HK1FXFPe_7pcZF3m51QmzK_f3btleLnLa90\" />");
            //    sb.AppendLine("<link rel=\"stylesheet\" href=\"/bootstrap-assets/bootstrap.css\">");
            //    sb.AppendLine("<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\">");
            //    sb.AppendLine("<script src=\"/bootstrap-assets/jquery.js\"></script>");
            //    sb.AppendLine("<script src=\"/bootstrap-assets/bootstrap.js\"></script> ");
            //    sb.AppendLine("<script async src=\"https://www.googletagmanager.com/gtag/js?id=UA-136090359-1\"></script>");

            //    sb.AppendLine("<script >");
            //    sb.AppendLine("window.dataLayer = window.dataLayer || [];function gtag() { dataLayer.push(arguments); } gtag('js', new Date());" +
            //        "gtag('config', 'UA-136090359-1');");
            //    sb.AppendLine("</script > ");
            //    sb.AppendLine("<link href=\"/lawcost-styles.css\" rel=\"stylesheet\" type=\"text/css\" />");
            //    sb.AppendLine("</head>");
            //    sb.AppendLine("<body>");
            //    sb.AppendLine("<div class=\"container-fluid main-div\">");
            //    sb.AppendLine("<div class=\"col-lg-10 col-lg-offset-1 header\">");
            //    sb.AppendLine("<div class=\"col-md-7\"><img src=\"/Images/logo.png\" class=\"img-responsive\"/> </div>");
            //    sb.AppendLine("<div class=\"col-md-5 head-right hidden-xs\">");
            //    sb.AppendLine("<ul class=\"social\">");
            //    sb.AppendLine("<li> <i class=\"fa fa-facebook-square\" style=\"font-size:20px; color:#d0c2b2;\"></i> <a href=\"#\" class=\"text-white\">Facebook</a> </li>");
            //    sb.AppendLine("<li> <i class=\"fa fa-twitter-square\" style=\"font-size:20px;color:#d0c2b2;\"></i> <a href =\"#\" class=\"text-white\">Twitter</a> </li>");
            //    sb.AppendLine("<li> <i class=\"fa fa-linkedin-square\" style=\"font-size:20px; color:#d0c2b2;\"></i> <a href=\"#\" class=\"text-white\">Linked in</a> </li>");
            //    sb.AppendLine("</ul></div></div></div>");
            //    sb.AppendLine(" <div class=\"col-lg-10 col-lg-offset-1\">");
            //    sb.AppendLine("<nav class=\"navbar navbar-default\" role=\"navigation\">");
            //    sb.AppendLine("<div class=\"navbar-header\">");
            //    sb.AppendLine("<button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\"#bs-example-navbar-collapse-1\">");
            //    sb.AppendLine("<span class=\"sr-only\">Toggle navigation</span>");
            //    sb.AppendLine("<span class=\"icon-bar\"></span><span class=\"icon-bar\"></span><span class=\"icon-bar\"></span>");
            //    sb.AppendLine("</button></div>");
            //    sb.AppendLine("<div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">");
            //    sb.AppendLine("<ul class=\"nav navbar-nav\">");
            //    sb.AppendLine("<li ><a href=\"/index.html\" > Home </a></li >");
            //    sb.AppendLine("<li ><a href=\"/services.html\">Our Cost Drafting and Billing Services</a></li>");
            //    sb.AppendLine("<li><a href=\"/our-people.html\"> Our People</a></li>");
            //    sb.AppendLine("<li><a href=\"/recruitment.html\"> Recruitment </a></li>");
            //    sb.AppendLine(" <li><a href=\"/contact.html\"> Contact </a></li>");
            //    sb.AppendLine("<li><a href=\"/blog.html\"> Blog &amp; News</a></li>");
            //    sb.AppendLine("</ul>    </div></nav></div>");


            //    sb.AppendLine(res.Text);


            //    sb.AppendLine("<footer class=\"footer bg-dark\">");
            //    sb.AppendLine("<div class=\"bg-prime\">");
            //    sb.AppendLine("<div class=\"container\">");
            //    sb.AppendLine("<div class=\"row\">");
            //    sb.AppendLine("<h4 class=\"white-text\">You can Call us on 0203 633 6261 or Email us to info&#64;costlaw.com </h4>");
            //    sb.AppendLine("</div></div></div>");
            //    sb.AppendLine("<div class=\"container-fluid\" style=\"margin-bottom:15px;\">");
            //    sb.AppendLine("<div class=\"col-lg-10 col-lg-offset-1\">");
            //    sb.AppendLine("<div class=\"col-md-3 col-lg-3\">");
            //    sb.AppendLine("<h4>Cost Law Services Limited</h4>");
            //    sb.AppendLine("<hr class=\"bg-white\">");
            //    sb.AppendLine("<p><strong>95 Mortimer Street,<br />Ground Floor,<br />London,</strong><br/><strong>W1W 7GB </strong></p></div>");
            //    sb.AppendLine("<div class=\"col-md-4 col-lg-4\">");
            //    sb.AppendLine("<h4>Useful links</h4>");
            //    sb.AppendLine("<hr class=\"bg-white\">");
            //    sb.AppendLine("<ul style=\"list-style-type:none; margin:0px !important; padding:0px !important; line-height:2\">");
            //    sb.AppendLine("<li><a href=\"/index.html\" class=\"text-white\">Home</a></li>");
            //    sb.AppendLine("<li><a href=\"/services.html\" class=\"text-white\">Our Cost Drafting and Billing services</a></li>");
            //    sb.AppendLine("<li><a href=\"/our-people.html\" class=\"text-white\">Our People</a> </li>");
            //    sb.AppendLine("<li><a href=\"/recruitment.html\" class=\"text-white\">Recruitment</a> </li>");
            //    sb.AppendLine("<li><a href=\"/contact.html\" class=\"text-white\">Contact</a> </li>");
            //    sb.AppendLine("<li><a href=\"/blog.html\" class=\"text-white\">Blog</a> </li>");
            //    sb.AppendLine("</ul></div>");
            //    sb.AppendLine("<div class=\"col-md-3 col-lg3\">");
            //    sb.AppendLine("<h4>Contact</h4>");
            //    sb.AppendLine("<hr class=\"bg-white\">");
            //    sb.AppendLine("<p><i class=\"fa fa-envelope mr-3\"></i> info&#64;costlaw.com</p>");
            //    sb.AppendLine("<p><i class=\"fa fa-phone mr-3\"></i> 0203 633 6261</p>");
            //    sb.AppendLine("<p><i class=\"fa fa-print mr-3\"></i> 0203 633 6261</p>");
            //    sb.AppendLine("</div>");
            //    sb.AppendLine("<div class=\"col-md-2 col-lg-2 col-xl-2\">");
            //    sb.AppendLine("<h4>Social Links</h4>");
            //    sb.AppendLine("<hr class=\"bg-white\">");
            //    sb.AppendLine("<p><i class=\"fa fa-facebook-square\" style=\"font-size:24px\"></i> <a href=\"https://www.facebook.com/CostLaw-Services-231194224244246/\" class=\"text-white\">Facebook</a></p>");
            //    sb.AppendLine("<p><i class=\"fa fa-twitter-square\" style=\"font-size:24px\"></i> <a href=\"https://twitter.com/costlawservices\" class=\"text-white\">Twitter</a></p>");
            //    sb.AppendLine("<p><i class=\"fa fa-linkedin-square\" style=\"font-size:24px\"></i> <a href=\"https://linkedin.com/in/costlawservices-b50968170\" class=\"text-white\">Linked in</a></p>");
            //    sb.AppendLine("</div> </div></div>");
            //    sb.AppendLine("<div class=\"container-fluid center-block\" style=\"background-color:#000 !important;\">");
            //    sb.AppendLine("<p style=\"color:#fff !important; text-align:center\"> © 2018 Copyright Cost Law Services Limited </p>");
            //    sb.AppendLine("</div>");
            //    sb.AppendLine("</footer>");
            //    sb.AppendLine("</body>");
            //    sb.AppendLine("</html>");
            //    if (res.Sub_Department != null && res.Sub_Department.Equals("Profiles"))
            //    {
            //        System.IO.File.WriteAllText("c:/inetpub/wwwroot/costlaw/Profiles/" + res.Filename + ".html", sb.ToString());
            //    }
            //    else
            //    {
            //        System.IO.File.WriteAllText("c:/inetpub/wwwroot/costlaw/" + res.Filename + ".html", sb.ToString());
            //    }

            //}
            return View("Index");


        }


        public ActionResult Create247Website()
        {
            string title = "";
            string description = "";
            string keywords = "";
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            var webpages = db.Website_Pages.Where(x => x.Company == "24-7languageServices").ToList();

            StringBuilder footerlist = new StringBuilder();
            StringBuilder langlist = new StringBuilder();
            langlist.AppendLine("<div class=\"row langlist\">"); 
            langlist.AppendLine("<div class=\"col-sm-4 col-xs-6 foterpanelunderline\">");
            footerlist.AppendLine("<div class=\"col-sm-2 col-xs-6 foterpanelunderline\">");
            int i = 0;
            foreach (var wp in webpages.Where(x => x.Sub_Sub_Department != "Other").OrderBy(y => y.Name))
            {
                if (i == 25)
                {
                    langlist.AppendLine("</div><div class=\"col-sm-4 col-xs-6 foterpanelunderline\">");
                    footerlist.AppendLine("</div><div class=\"col-sm-2 col-xs-6 foterpanelunderline\">");
                    i = 0;
                }
                footerlist.AppendLine("<a href=\"" + wp.Filename.ToString().Replace(" ", "") + "-interpreting-interpreters-translations-translators\">" + wp.Name.ToString() + " Interpreters</a>");
                langlist.AppendLine("<a href=\"" + wp.Filename.ToString().Replace(" ", "") + "-interpreting-interpreters-translations-translators\">" + wp.Name.ToString() + " Interpreters</a>");

                i++;
            }
            footerlist.AppendLine("</div>");
            langlist.AppendLine("</div></div>");

            foreach (var wp in webpages)
            {
                StreamWriter fp;
                fp = System.IO.File.CreateText("C:\\Inetpub\\wwwroot\\24X7Language\\NewWebsite\\" + wp.Filename.ToString().Replace(" ", "") + ".html");


                if (wp.Keywords.ToString() == "Language")
                {
                    title = wp.Name.ToString() + " Translator | " + wp.Name.ToString() + " Interpretor";
                    description = "Nationwide specialist " + wp.Name.ToString() + " translation, " + wp.Name.ToString() + " interpreting service. Competitive rates. Work undertaken by professional " + wp.Name.ToString() + " interpreter, " + wp.Name.ToString() + " translator. London, Birmingham, Leeds, Cardiff, Brighton";
                    keywords = wp.Name.ToString() + " translation services, " + wp.Name.ToString() + " translation service, " + wp.Name.ToString() + "  interpreting service, " + wp.Name.ToString() + " translator, " + wp.Name.ToString() + " interpreter, " + wp.Name.ToString() + " interpreter, " + wp.Name.ToString() + " interpreter service, professional " + wp.Name.ToString() + " translation, professional " + wp.Name.ToString() + " interpreter, professional " + wp.Name.ToString() + " translator, professional " + wp.Name.ToString() + " interpreting, document translation English to " + wp.Name.ToString() + ", " + wp.Name.ToString() + " to English translation, " + wp.Name.ToString() + " website translation, certified " + wp.Name.ToString() + " translation, specialist " + wp.Name.ToString() + " translator, specialist " + wp.Name.ToString() + " translation, " + wp.Name.ToString() + " legal translation, " + wp.Name.ToString() + " medical translation, " + wp.Name.ToString() + " interpreter London, " + wp.Name.ToString() + " interpreter Birmingham, " + wp.Name.ToString() + " interpreter Leeds, " + wp.Name.ToString() + " interpreter Cardiff, " + wp.Name.ToString() + " interpreter Brighton, interpreters for business meetings, " + wp.Name.ToString() + " court interpreters, consecutive " + wp.Name.ToString() + " interpreting , face to face " + wp.Name.ToString() + " interpreting";
                                    }
                else
                {
                    title = wp.Title.ToString();
                    description = wp.Description.ToString();
                    keywords = wp.Keywords.ToString();
                }

                fp.WriteLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                fp.WriteLine("<html xmlns=\"https://www.w3.org/1999/xhtml\" lang=\"en\">");
                fp.WriteLine("<head>");
                fp.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
                fp.WriteLine("<link rel=\"icon\" href=\"/images/favicon.ico\" type=\"image/x-icon\" /> ");
                fp.WriteLine("<link rel=\"shortcut icon\" href=\"/images/favicon.ico\" type=\"image/x-icon\" />");
                fp.WriteLine("<link href=\"/Content/bootstrap.min.css\" rel=\"stylesheet\"/>");
                fp.WriteLine("<link href=\"/Content/site.min.css\" rel=\"stylesheet\"/>");
                fp.WriteLine("<link href=\"/Content/font-awesome.min.css\" rel=\"stylesheet\"/>");
                fp.WriteLine("<script src=\"/Scripts/modernizr-2.8.3.min.js\"></script>");
                
               fp.WriteLine("<title>" + title + "</title>");
                fp.WriteLine("<meta name=\"description\" content=\"" + description + "\"/>");
                fp.WriteLine("<meta name=\"keywords\" content=\"" + keywords + "\"/>");
                fp.WriteLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");

                if (wp.Filename == "Quote")
                    fp.WriteLine("<meta http-equiv=\"refresh\" content=\"0; URL = 'https://interpreters.24-7languageservices.com/AddBooking/Addbooking/Create?actiontoperform=Quote'\" />");

                fp.WriteLine("<script async src=\"https://www.googletagmanager.com/gtag/js?id=UA-49060798-1\"></script>");
                fp.WriteLine("<script>");
                fp.WriteLine("  window.dataLayer = window.dataLayer || [];");
                fp.WriteLine("  function gtag(){dataLayer.push(arguments);}");
                fp.WriteLine("  gtag('js', new Date());");
                fp.WriteLine("  gtag('config', 'UA-49060798-1');");
                fp.WriteLine("</script>");


                if (wp.Sub_Sub_Department != "Other")
                    fp.WriteLine("<link rel=\"canonical\" href=\"https://www.24-7languageservices.com/" + wp.Name.Replace(" ", "") + "-interpreting-interpreters-translations-translators\" />");
                else if (wp.Filename == "Index")
                    fp.WriteLine("<link rel=\"canonical\" href=\"https://www.24-7languageservices.com\" />");
                else
                    fp.WriteLine("<link rel=\"canonical\" href=\"https://www.24-7languageservices.com/" + wp.Filename + ".html\" />");

                fp.WriteLine("</head>");
                fp.WriteLine("<body>");




                fp.WriteLine("<div class=\"row nopadding\">");
fp.WriteLine("        <div class=\"col-sm-12 col-md-12 col-sm-12 col-xs-12 nopadding\">");

                fp.WriteLine("            <div class=\"row nopadding\">");
                fp.WriteLine("                <div class=\"col-sm-12 headerdiv\">");
                fp.WriteLine("                    <div class=\"row nopadding\">");
                fp.WriteLine("                        <div class=\"col-sm-8 col-sm-offset-2 headercontents applyblock centerdiv\">");
                fp.WriteLine("                            <div style=\"float:right !important;\" class=\"headerdivsub\">");
                fp.WriteLine("                                <a href=\"mailto:contact@24-7languageservices.com\">");
                fp.WriteLine("                                    <span class=\"fa fa-envelope\"></span>");
                fp.WriteLine("                                </a><a class=\"hidden-xs\" href=\"mailto:contact@24-7languageservices.com\">contact@24-7languageservices.com</a>");
                fp.WriteLine("                                <a href=\"tel:+44 01923 827 168\"><span class=\"fa fa-phone\"></span></a>");
                fp.WriteLine("                                <a href=\"tel:+44 01923 827 168\" class=\"hidden-xs\">+44 01923 827 168</a>");
                fp.WriteLine("                            </div>");
                fp.WriteLine("                            <div class=\"headerdivsub\">");
                fp.WriteLine("                                <span class=\"fa fa-map-marker\"></span>Unit 3C, Argyle House, Joel Street, Northwood Hills, Middlesex, HA6 1NW");
                fp.WriteLine("                            </div>");

                fp.WriteLine("                        </div>");
                fp.WriteLine("                    </div>");
                fp.WriteLine("                </div>");
                fp.WriteLine("            </div>");


                fp.WriteLine("            <div class=\"row custumnavbarmain nopadding\">");
                fp.WriteLine("                <div class=\"col-sm-12 custumnavbar\">");
                fp.WriteLine("                    <div class=\"row nopadding\">");
                fp.WriteLine("                        <div class=\"col-sm-8 col-sm-offset-2 custumnavbar applyblock centerdiv\">");
                fp.WriteLine("                            <nav class=\"navbar navbar-default\">");
                fp.WriteLine("                                <div class=\"container-fluid\">");
                fp.WriteLine("                                    <div class=\"navbar-header nopadding\">");
                fp.WriteLine("                                        <button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\"#myNavbar\">");
                fp.WriteLine("                                            <span class=\"icon-bar\"></span>");
                fp.WriteLine("                                            <span class=\"icon-bar\"></span>");
                fp.WriteLine("                                            <span class=\"icon-bar\"></span>");
                fp.WriteLine("                                        </button>");
                fp.WriteLine("                                        <a class=\"navbar-brand\" href=\"/\">");
                fp.WriteLine("                                            <img src=\"/images/logo.PNG\" alt=\"24-7 language Services\" />");
                fp.WriteLine("                                        </a>");
                fp.WriteLine("                                        <p>");
                fp.WriteLine("                                            Interpreting &amp;");
                fp.WriteLine("                                            Translation Services");
                fp.WriteLine("                                        </p>");
                fp.WriteLine("                                    </div>");
                fp.WriteLine("                                    <div class=\"collapse navbar-collapse\" id=\"myNavbar\">");
                fp.WriteLine("                                        <ul class=\"nav navbar-nav navbar-right\">");
                fp.WriteLine("                                            <li><a href=\"/\"><span>HOME</span><br /><i class=\"fa fa-sort-down\"></i></a></li>");
                fp.WriteLine("                                            <li>");
                fp.WriteLine("                                                <a class=\"dropdown\" href=\"#\" data-target=\"services\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\"><span>SERVICES</span><br /><i class=\"fa fa-sort-down\"></i></a>");
                fp.WriteLine("                                                <ul class=\"dropdown-menu\" id=\"services\">");
                fp.WriteLine("                                                    <li><a href=\"/Services.html\">Overview</a></li>");
                fp.WriteLine("                                                    <li><a href=\"/face-to-face-interpreting.html\">Face to face Interpreting</a></li>");
                fp.WriteLine("                                                    <li><a href=\"/telephone-interpretation.html\">Telephonic Interpreting</a></li>");
                fp.WriteLine("                                                    <li><a href=\"/translation-of-documents.html\">Translation of documents</a></li>");
                fp.WriteLine("                                                </ul>");
                fp.WriteLine("                                            </li>");
                fp.WriteLine("                                            <li><a href=\"https://interpreters.24-7languageservices.com/AddBooking/Addbooking/Create?actiontoperform=Quote\"><span>QUOTATION</span><br /><i class=\"fa fa-sort-down\"></i></a></li>");
                fp.WriteLine("                                            <li><a href=\"/Languages.html\"><span>LANGUAGES</span><br /><i class=\"fa fa-sort-down\"></i></a></li>");
                fp.WriteLine("                                            <li><a href=\"/Jobs.html\"><span>JOBS</span><br /><i class=\"fa fa-sort-down\"></i></a></li>");
                fp.WriteLine("                                            <li><a href=\"/ContactUs.html\"><span>CONTACT</span><br /><i class=\"fa fa-sort-down\"></i></a></li>");
                fp.WriteLine("                                            <li class=\"hidden-sm hidden-md hidden-lg\"><a href=\"https://interpreters.24-7languageservices.com/AddBooking/Addbooking/Create\"><span>BOOK AN INTERPRETER</span><br /><i class=\"fa fa-sort-down\"></i></a></li>");
                fp.WriteLine("                                            <li class=\"hidden-sm hidden-md hidden-lg\"><a href=\"/Quote.html\"><span>GET A FREE QUOTE</span><br /><i class=\"fa fa-sort-down\"></i></a></li>");
                fp.WriteLine("                                            <li class=\"hidden-sm hidden-md hidden-lg\"><a href=\"/24-7_TimeSheet.pdf\"><span>DOWNLOAD TIMESHEET</span><br /><i class=\"fa fa-sort-down\"></i></a></li>");
                fp.WriteLine("                                            <li class=\"hidden-sm hidden-md hidden-lg\"><a href=\"https://interpreters.24-7languageservices.com/Interpreters_Login.aspx\"><span>INTERPRETER LOGIN</span><br /><i class=\"fa fa-sort-down\"></i></a></li>");
                fp.WriteLine("                                        </ul>");

                fp.WriteLine("                                    </div>");
                fp.WriteLine("                                </div>");
                fp.WriteLine("                            </nav>");
                fp.WriteLine("                        </div>");
                fp.WriteLine("                    </div>");
                fp.WriteLine("                </div>");
                fp.WriteLine("            </div>");

                fp.WriteLine("            <div class=\"row nopadding\" style=\"border-bottom:solid #f2e1c3 5px\">");
                fp.WriteLine("                <div class=\"col-md-12 col-lg-12 col-sm-12 nopadding\">");
                fp.WriteLine("                    <div class=\"outerhomepagecarousel\">");
                fp.WriteLine("                        <div id=\"carousel-example1\" class=\"carousel slide\" data-ride=\"carousel\" data-interval=\"18000\">");
                fp.WriteLine("                            <ol class=\"carousel-indicators hidden-xs\">");
                fp.WriteLine("                                <li data-target=\"#carousel-example1\" data-slide-to=\"0\"></li>");
                fp.WriteLine("                                <li data-target=\"#carousel-example1\" data-slide-to=\"1\"></li>");
                fp.WriteLine("                                <li data-target=\"#carousel-example1\" data-slide-to=\"2\"></li>");
                fp.WriteLine("                                <li data-target=\"#carousel-example1\" data-slide-to=\"3\"></li>");
                fp.WriteLine("                                <li data-target=\"#carousel-example1\" data-slide-to=\"4\"></li>");
                fp.WriteLine("                                <li data-target=\"#carousel-example1\" data-slide-to=\"5\"></li>");
                fp.WriteLine("                            </ol>");
                fp.WriteLine("                            <div class=\"carousel-inner\">");
                fp.WriteLine("                                <div class=\"item\">");
                fp.WriteLine("                                        <img src=\"/images/Banner1.jpg\" class=\"visible-lg visible-md visible-sm hidden-xs\" alt=\"" + wp.AltTagIng1 + "\" />");
                fp.WriteLine("                                        <img src=\"/images/Banner1_M.jpg\" class=\"hidden-lg hidden-md hidden-sm visible-xs\" alt=\"" + wp.AltTagIng1 + "\" />");
                fp.WriteLine("                                    <div class=\"carousel-caption\">");
                fp.WriteLine("                                        <h3>BRINGING WORLD CLOSER</h3>");
                fp.WriteLine("                                        <span class=\"hidden-xs\">Interpreting languages throughout the world</span>");
                fp.WriteLine("                                    </div>");
                fp.WriteLine("                                </div>");
                fp.WriteLine("                                <div class=\"item\">");
                fp.WriteLine("                                        <img src=\"/images/Banner2.jpg\" class=\"visible-lg visible-md visible-sm hidden-xs\" alt=\"" + wp.AltTagIng2 + "\" />");
                fp.WriteLine("                                        <img src=\"/images/Banner2_M.jpg\" class=\"hidden-lg hidden-md hidden-sm visible-xs\" alt=\"" + wp.AltTagIng2 + "\" />");
                fp.WriteLine("                                    <div class=\"carousel-caption\">");
                fp.WriteLine("                                        <h3>SPEAK AND BE HEARD</h3>");
                fp.WriteLine("                                        <span class=\"hidden-xs\">More than 1500 registered interpreters</span>");
                fp.WriteLine("                                    </div>");
                fp.WriteLine("                                </div>");
                fp.WriteLine("                                <div class=\"item\">");
                fp.WriteLine("                                        <img src=\"/images/Banner3.jpg\" class=\"visible-lg visible-md visible-sm hidden-xs\" alt=\"" + wp.AltTagIng3 + "\" />");
                fp.WriteLine("                                        <img src=\"/images/Banner3_M.jpg\" class=\"hidden-lg hidden-md hidden-sm visible-xs\" alt=\"" + wp.AltTagIng3 + "\" />");
                fp.WriteLine("                                    <div class=\"carousel-caption\">");
                fp.WriteLine("                                        <h3>A COLLABORATIVE CULTURE OF COMMUNICATION</h3>");
                fp.WriteLine("                                        <span class=\"hidden-xs\">Covering public sector, law firms and government agencies</span>");
                fp.WriteLine("                                    </div>");
                fp.WriteLine("                                </div>");
                fp.WriteLine("                                <div class=\"item\">");
                fp.WriteLine("                                        <img src=\"/images/Banner4.jpg\" class=\"visible-lg visible-md visible-sm hidden-xs\" alt=\"" + wp.AltTagIng4 + "\" />");
                fp.WriteLine("                                        <img src=\"/images/Banner4_M.jpg\" class=\"hidden-lg hidden-md hidden-sm visible-xs\" alt=\"" + wp.AltTagIng4 + "\" />");
                fp.WriteLine("                                    <div class=\"carousel-caption\">");
                fp.WriteLine("                                        <h3>PROFESSIONAL & DEDICATED INTERPRETERS</h3>");
                fp.WriteLine("                                        <span class=\"hidden-xs\">Extensive experience in sensitive and personal matters</span>");
                fp.WriteLine("                                    </div>");
                fp.WriteLine("                                </div>");
                fp.WriteLine("                                <div class=\"item\">");
                fp.WriteLine("                                        <img src=\"/images/Banner5.jpg\" class=\"visible-lg visible-md visible-sm hidden-xs\" alt=\"" + wp.AltTagIng5 + "\" />");
                fp.WriteLine("                                        <img src=\"/images/Banner5_M.jpg\" class=\"hidden-lg hidden-md hidden-sm visible-xs\" alt=\"" + wp.AltTagIng5 + "\" />");
                fp.WriteLine("                                    <div class=\"carousel-caption\">");
                fp.WriteLine("                                        <h3>DEVELOPING INTERPRETERS OF THE WORLD</h3>");
                fp.WriteLine("                                        <span class=\"hidden-xs\">Extensive experience in sensitive and personal matters</span>");
                fp.WriteLine("                                    </div>");
                fp.WriteLine("                                </div>");
                fp.WriteLine("                                <div class=\"item\">");
                fp.WriteLine("                                        <img src=\"/images/Banner6.jpg\" class=\"visible-lg visible-md visible-sm hidden-xs\" alt=\"" + wp.AltTagIng6 + "\" />");
                fp.WriteLine("                                        <img src=\"/images/Banner6_M.jpg\" class=\"hidden-lg hidden-md hidden-sm visible-xs\" alt=\"" + wp.AltTagIng6 + "\" />");
                fp.WriteLine("                                    <div class=\"carousel-caption\">");
                fp.WriteLine("                                        <h3>TOGETHER WE LIGHT THE PATH OF SUCCESS</h3>");
                fp.WriteLine("                                        <span class=\"hidden-xs\">Building working relationship over the time</span>");
                fp.WriteLine("                                    </div>");
                fp.WriteLine("                                </div>");
                fp.WriteLine("                            </div>");
                fp.WriteLine("                            <a class=\"left carousel-control\" href=\"#carousel-example1\" data-slide=\"prev\">");
                fp.WriteLine("                                <span class=\"fa fa-caret-left carouselcontrol\"></span>");
                fp.WriteLine("                            </a>");
                fp.WriteLine("                            <a class=\"right carousel-control\" href=\"#carousel-example1\" data-slide=\"next\">");
                fp.WriteLine("                                <span class=\"fa fa-caret-right carouselcontrol\"></span>");
                fp.WriteLine("                            </a>");
                fp.WriteLine("                        </div>");
                fp.WriteLine("                    </div>");
                fp.WriteLine("                </div>");
                fp.WriteLine("            </div>");

                if (wp.Filename == "Index")
                    fp.WriteLine(wp.Text);
                else if (wp.Sub_Sub_Department != "Other")
                {
                    fp.WriteLine("<div class=\"row nopadding\">");
                    fp.WriteLine("<div class=\"col-sm-12\">");
                    fp.WriteLine("        <div class=\"row nopadding\">");
                    fp.WriteLine("            <div class=\"col-sm-8 col-sm-offset-2\">");
                    fp.WriteLine("<h1>" + wp.Name + " Interpreter and Translator</h1>");
                    fp.WriteLine(wp.Text);
                    fp.WriteLine("            </div>");
                    fp.WriteLine("            </div>");
                    fp.WriteLine("            </div>");
                    fp.WriteLine("            </div>");
                }
                else
                {
                    fp.WriteLine("<div class=\"row nopadding\">");
                    fp.WriteLine("<div class=\"col-sm-12\">");
                    fp.WriteLine("        <div class=\"row nopadding\">");
                    fp.WriteLine("            <div class=\"col-sm-8 col-sm-offset-2\">");
                    fp.WriteLine("<h1>" + wp.Name + "</h1>");
                    if (wp.Filename == "Languages")
                        fp.WriteLine(langlist);
                    else
                        fp.WriteLine(wp.Text);

                    fp.WriteLine("            </div>");
                    fp.WriteLine("            </div>");
                    fp.WriteLine("            </div>");
                    fp.WriteLine("            </div>");
                }

                fp.WriteLine("            <div class=\"row yellowbackcolor barpanels nopadding hidden-xs\" style=\"margin-bottom:0px !important; padding-top:0px !important\">");
                fp.WriteLine("                <div class=\"col-sm-12\">");
                fp.WriteLine("                    <div class=\"row nopadding\">");
                fp.WriteLine("                        <div class=\"col-sm-8 col-sm-offset-2 applyblock centerdiv\">");
                fp.WriteLine("                            <div id=\"div_footer\">");
                fp.WriteLine("                                <ul class=\"redbackcolor\">");
                fp.WriteLine("                                    <li><a href=\"Index.html\">Home</a></li>");
                fp.WriteLine("                                    <li><a href=\"Services.html\">Services</a></li>");
                fp.WriteLine("                                    <li><a href=\"Languages.html\">Languages</a></li>");
                fp.WriteLine("                                    <li><a href=\"Quote.html\">Quotation</a></li>");
                fp.WriteLine("                                    <li><a href=\"Jobs.html\">Jobs</a></li>");
                fp.WriteLine("                                    <li><a href=\"ContactUs.html\">Contact Us</a></li>");
                fp.WriteLine("                                </ul>");
                fp.WriteLine("                                <div id=\"footer_lang_container\">");

                fp.WriteLine(footerlist.ToString());

                fp.WriteLine("                                </div>");
                fp.WriteLine("                            </div>");
                fp.WriteLine("                        </div>");
                fp.WriteLine("                    </div>");
                fp.WriteLine("                </div>");
                fp.WriteLine("            </div>");

                fp.WriteLine("            <div class=\"row nopadding\" style=\"background-color:#441e00\">");
                fp.WriteLine("                <div class=\"col-sm-12 nopadding\">");
                fp.WriteLine("                    <div class=\"row nopadding\">");
                fp.WriteLine("                        <div class=\"col-sm-8 col-sm-offset-2 applyblock centerdiv\">");
                fp.WriteLine("                            <div class=\"footeraddress nopadding\">");
                fp.WriteLine("                                <span>24-7 Language Services Ltd</span>");
                fp.WriteLine("                                <p>");
                fp.WriteLine("                                    Company Registration Number 8345302, web: www.24-7languageservices.com, email: contact@24-7languageservices.com<br />");
                fp.WriteLine("                                    Copyright © 2013 24-7 Language Services. All rights reserved");
                fp.WriteLine("                                </p>");
                fp.WriteLine("                            </div>");
                fp.WriteLine("                        </div>");
                fp.WriteLine("                    </div>");
                fp.WriteLine("                </div>");
                fp.WriteLine("            </div>");



                fp.WriteLine("        </div>");
                fp.WriteLine("    </div>");
                fp.WriteLine("</body>");
                fp.WriteLine("</html>");







                fp.WriteLine(" <script src=\"/Scripts/jquery-3.3.1.min.js\"></script>");
                fp.WriteLine("<script src=\"/Scripts/bootstrap.min.js\"></script>");
                //fp.WriteLine("<script src=\"/Scripts/auto-update-chrome.js\"></script>");
                fp.WriteLine("<script src=\"/Scripts/site.min.js\"></script>");
                fp.Close();
            }
            return View("Index");
        }

        }
}