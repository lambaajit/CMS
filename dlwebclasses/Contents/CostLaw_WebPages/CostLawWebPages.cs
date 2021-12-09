using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class CostLawWebPages
    {
        private int id;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }
        public string canonicaltag { get; set; }

        public CostLawWebPages(int ID, AContents _Acontent)
        {
            id = ID;
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            Website_Pages WP = new Website_Pages();
            WP = db.Website_Pages.Where(x => x.ID == ID).FirstOrDefault();

            

            if (!string.IsNullOrEmpty(WP.Title))
                Title = WP.Title + (WP.Title.Length < 60 ? " | Cost Law" : "");
            else
                Title = WP.Name + ": " + WP.ID;

            if (!string.IsNullOrEmpty(WP.Keywords))
                Keywords = WP.Keywords;
            else
                Keywords = "Law Costdraftsman, Costing Lawyer, Legal Aid Billing, Interpartes billing, Cost Lawyer, Costs Lawyer, Cost Budgeting, Cost Drafting, Cost Advice";

            if (!string.IsNullOrEmpty(WP.Description))
                Description = WP.Description;
            else
                Description = "Cost Law Cost Drafting Services: " + WP.Name;

            HeadingH1 = WP.Name;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(getwebbanner.getwebbanners().ToString());

            sb.AppendLine("<div class=\"row nopadding\">");
            sb.AppendLine("    <div class=\"col-sm-12\">");
            sb.AppendLine("        <div class=\"row nopadding\">");
            sb.AppendLine("            <div class=\"col-sm-8 col-sm-offset-2 applyblock centerdiv test\">");

            sb.AppendLine("                <div class=\"row nopadding\">");
            sb.AppendLine("                    <div class=\"col-sm-9\">");
            sb.AppendLine("                        <h1>" + (WP.Department == "Blog" ? (string.IsNullOrEmpty(WP.AltTagIng7) ? WP.Name : WP.Name + " - written by " + WP.AltTagIng7 + " - " + WP.DateUpdated.Value.ToShortDateString()) : WP.Name) + "</h1>");
            if (WP.Filename == "Contact")
            {
                StringBuilder offlist = new StringBuilder();
                DLWEBEntities dbweb = new DLWEBEntities();
                foreach (var item in dbweb.OfficesDLW.Where(x => (x.Company == "Cost Law" || x.Company == "Both") && x.Name != "London" && x.Active == true).OrderBy(y => y.Address).ToList())
                {
                    offlist.AppendLine("      <p><span style=\"font-weight:bold; text-decoration:underline\"><a href=\"Cost-Drafting-" + item.Name + ".html\">" + item.Name + "</a></span><br />");
                    offlist.AppendLine(item.Address.Replace(",", "<br />") + "<p>&nbsp;</p>");
                }
                sb.AppendLine(WP.Text.Replace("[List of Offices]", offlist.ToString()));
            }
            else if (WP.Filename == "blog")
            {
                StringBuilder bloglist = new StringBuilder();
                foreach (var item in db.Website_Pages.Where(x => (x.Company == "Cost Law" || x.Company == "Both") && x.Department == "Blog").OrderByDescending(y => y.DateUpdated).ToList())
                {
                    bloglist.AppendLine("     <p class=\"news-title\"><a href=\"/Blog/" + item.Filename + ".html" + "\" class=\"news-titlea\">" + item.Name + (string.IsNullOrEmpty(item.AltTagIng7) ? "" : " - written by " + item.AltTagIng7) + " - " + item.DateUpdated.Value.ToShortDateString() + "</a></p><br />");

                }
                sb.AppendLine(WP.Text.Replace("[List of Blogs]", bloglist.ToString()));
            }
            else
            {
                sb.AppendLine(WP.Text);
            }


            sb.AppendLine("</div>");
            sb.AppendLine("<div class=\"col-sm-3 col-xs-12\">");
            sb.AppendLine(getrightcol().ToString());
            sb.AppendLine("</div");
            sb.AppendLine("</div");

            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");



            Contents = sb;
            if (WP.Department == "Blog")
            {
                filepath = ConfigurationManager.AppSettings["RootpathCostLawWebsite"].ToString() + "\\Blog\\" + WP.Filename.ToString() + ".html";
                canonicaltag = "https://www.costlaw.com/Blog/" + WP.Filename + ".html";
            }
            else
            {
                filepath = ConfigurationManager.AppSettings["RootpathCostLawWebsite"].ToString() + "\\" + WP.Filename.ToString() + ".html";
                canonicaltag = "https://www.costlaw.com/" + WP.Filename + ".html";
            }
                //canonicaltag = "<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk" + filepath.Replace(ConfigurationManager.AppSettings["RootpathNewWebsite"], "").Replace("\\", "/") + "\">";

            }

        public StringBuilder getrightcol()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("                        <h4 class=\"top-margin\">Our Services:</h4>");
            sb.AppendLine("                        <ul class=\"rightlist-ul\">");
            sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-cog\">&nbsp;</i> <a href=\"/Bill-Preparation-Inter-partes.html\">Bill Preparation</a></li>");
            sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-cog\">&nbsp;</i> <a href=\"/Legal-Aid-Billing-Specialists.html\">Legal Aid Billing</a></li>");
            sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-cog\">&nbsp;</i> <a href=\"/Other-Costs-Services.html\">Other Costs Services</a></li>");
            sb.AppendLine("                        </ul>");

            sb.AppendLine("                        <h4 class=\"top-margin\">Our Offices Across UK:</h4>");
            sb.AppendLine("                        <ul class=\"rightlist-ul\">");

            DLWEBEntities dbweb = new DLWEBEntities();
            
            foreach (var item in dbweb.OfficesDLW.Where(x => (x.Company == "Cost Law" || x.Company == "Both") && x.Active == true).OrderBy(y => y.Name).ToList())
            {
                sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-map-marker\">&nbsp;</i> <a href=\"/Cost-Drafting-" + item.Name + ".html\">" + item.Name + "</a></li>");
            }
            //sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-map-marker\">&nbsp;</i> <a href=\"/Cost-Drafting-Chatham.html\">Chattam Office</a></li>");
            //sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-map-marker\">&nbsp;</i> <a href=\"/Cost-Drafting-Birmingham.html\">Birmingham Office</a></li>");
            //sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-map-marker\">&nbsp;</i> <a href=\"/Cost-Drafting-Harrow.html\">Harrow Office</a></li>");
            //sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-map-marker\">&nbsp;</i> <a href=\"/Cost-Drafting-London.html\">London Office</a></li>");
            //sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-map-marker\">&nbsp </i> <a href=\"/Cost-Drafting-Manchester.html\">Manchester Office</a></li>");

            sb.AppendLine("                        </ul>");

            sb.AppendLine("                        <h4 class=\"top-margin\">Our team is made up of:</h4>");
            sb.AppendLine("                        <ul class=\"rightlist-ul\">");
            sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-user\">&nbsp;</i> <a href=\"/contact.html\"> Costs Lawyers</a></li>");
            sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-user\">&nbsp;</i> <a href=\"/contact.html\">Advocates</a></li>");
            sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-user\">&nbsp;</i> <a href=\"/contact.html\">Chartered Legal Executives</a></li>");
            sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-user\">&nbsp;</i> <a href=\"/contact.html\">Senior Law Costs Draftsman</a></li>");
            sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-user\">&nbsp </i> <a href=\"/contact.html\">Costs Draftsmen</a></li>");
            sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fa fa-user\">&nbsp;</i> <a href=\"/contact.html\">Costs Negotiators</a></li>");

            sb.AppendLine("                        </ul>");

            sb.AppendLine("                        <h4 class=\"top-margin\">Current Vacancies:</h4>");
            sb.AppendLine("                        <ul class=\"rightlist-ul\">");
            sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fas fa-user-tie\">&nbsp;</i> <a href=\"/costs-lawyers.html\">Costs Lawyers</a></li>");
            sb.AppendLine("                            <li class=\"right-list\"> <i class=\"fas fa-user-tie\">&nbsp;</i> <a href=\"/junior-costs-lawyers.html\"> Junior Costs Lawyers</a></li>");
            sb.AppendLine("                        </ul>");


            sb.AppendLine("                        <div class=\"yellow-box\">");
            sb.AppendLine("                            <h4 class=\"yellow-box-heading\">Cost Law Services</h4>");
            sb.AppendLine("                            <p class=\"box-text\"> Our Cost Lawyers and Cost Draftsmen, have considerable experience in dealing with a range of legal billing services.</p>");
            sb.AppendLine("                            <a href=\"/our-people.html\" class=\"btn btn-warning3\"> View More </a>");
            sb.AppendLine("                        </div>");
            return sb;
        }

        }

    public static class getwebbanner
    {
        public static StringBuilder getwebbanners()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"row nopadding\">");
            sb.AppendLine("    <div class=\"col-sm-12 nopadding\">");

            sb.AppendLine("        <div id=\"myCarousel\" class=\"carousel slide\" data-ride=\"carousel\" data-interval=\"10000\">");
            sb.AppendLine("            <!-- Indicators -->");
            sb.AppendLine("            <ol class=\"carousel-indicators hidden-xs\">");
            sb.AppendLine("                <li data-target=\"#myCarousel\" data-slide-to=\"0\"> </li>");
            sb.AppendLine("                <li data-target=\"#myCarousel\" data-slide-to=\"1\"> </li>");
            sb.AppendLine("                <li data-target=\"#myCarousel\" data-slide-to=\"2\"> </li>");
            sb.AppendLine("                <li data-target=\"#myCarousel\" data-slide-to=\"3\"> </li>");
            sb.AppendLine("                <li data-target=\"#myCarousel\" data-slide-to=\"4\"> </li>");
            sb.AppendLine("            </ol>");

            sb.AppendLine("            <!-- Wrapper for slides -->");
            sb.AppendLine("            <div class=\"carousel-inner\">");

            sb.AppendLine("                <div class=\"item\">");
            sb.AppendLine("                    <img src=\"/Images/banner1.jpg\" alt=\"Costs Lawyers\" class=\"img-responsive hidden-xs\" />");
            sb.AppendLine("                    <img src=\"/Images/banner1_M.jpg\" alt=\"Costs Lawyers\" class=\"img-responsive hidden-sm hidden-lg hidden-md\" />");
            sb.AppendLine("                    <div class=\"carousel-caption\">");
            sb.AppendLine("                        <h3 class=\"caption-title\">Legal Cost Drafting </h3>");
            sb.AppendLine("                        <p class=\"caption-text hidden-xs hidden-sm\">");
            sb.AppendLine("                            Costs Law Services is a niche Cost Drafting Company specialising in Bill Drafting and Costs Law. We deal with all areas of legal costs and can tailor our services to suit your needs.");
            sb.AppendLine("                        </p>");
            sb.AppendLine("                        <span class=\"slider-buttons hidden-xs\"> <a href=\"/services.html\" class=\"btn btn-primary\"> Our Services </a> <a href=\"/contact.html\" class=\"btn btn-warning\"> Contact us </a> </span>");
            sb.AppendLine("                    </div>");
            sb.AppendLine("                </div>");

            sb.AppendLine("                <div class=\"item\">");
            sb.AppendLine("                    <img src=\"/Images/banner2.jpg\" alt=\"Cost Law Services\" class=\"img-responsive hidden-xs\" />");
            sb.AppendLine("                    <img src=\"/Images/banner2_M.jpg\" alt=\"Cost Law Services\" class=\"img-responsive hidden-sm hidden-lg hidden-md\" />");
            sb.AppendLine("                    <div class=\"carousel-caption\">");
            sb.AppendLine("                        <h3 class=\"caption-title\">Specialist Law Costs Draftsmen</h3>");
            sb.AppendLine("                        <p class=\"caption-text hidden-xs hidden-sm\">\"Experienced Costs Draftsmen and Costs Lawyers to help maximize your costs recovery.\"</p>");
            sb.AppendLine("                        <span class=\"slider-buttons hidden-xs\"> <a href=\"/services.html\" class=\"btn btn-primary\"> Our Services </a> <a href=\"/contact.html\" class=\"btn btn-warning\"> Contact us </a> </span>");

            sb.AppendLine("                    </div>");
            sb.AppendLine("                </div>");

            sb.AppendLine("                <div class=\"item\">");
            sb.AppendLine("                    <img src=\"/Images/banner4.jpg\" alt=\"Costs Draftsmen\" class=\"img-responsive hidden-xs\" />");
            sb.AppendLine("                    <img src=\"/Images/banner4_M.jpg\" alt=\"Costs Draftsmen\" class=\"img-responsive hidden-sm hidden-lg hidden-md\" />");
            sb.AppendLine("                    <div class=\"carousel-caption\">");
            sb.AppendLine("                        <h3 class=\"caption-title\">Billing Services</h3>");
            sb.AppendLine("                        <p class=\"caption-text hidden-xs hidden-sm\">\"Specialist Costs Lawyers and Draftsmen offering a full spectrum of Legal Aid and Inter Partes Costs services.\"</p>");
            sb.AppendLine("                        <span class=\"slider-buttons hidden-xs\"> <a href=\"/services.html\" class=\"btn btn-primary\"> Our Services </a> <a href=\"/contact.html\" class=\"btn btn-warning\"> Contact us </a> </span>");
            sb.AppendLine("                    </div>");
            sb.AppendLine("                </div>");

            sb.AppendLine("                <div class=\"item\">");
            sb.AppendLine("                    <img src=\"/Images/banner5.jpg\" alt=\"Legal Aid Billing\" class=\"img-responsive hidden-xs\" />");
            sb.AppendLine("                    <img src=\"/Images/banner5_M.jpg\" alt=\"Legal Aid Billing\" class=\"img-responsive hidden-sm hidden-lg hidden-md\" />");
            sb.AppendLine("                    <div class=\"carousel-caption\">");
            sb.AppendLine("                        <h3 class=\"caption-title\">Our Reach</h3>");
            sb.AppendLine("                        <p class=\"caption-text hidden-xs hidden-sm\">\"Our Costs Lawyers and Costs draftsmen are able to provide a nationwide legal bill drafting service.\"</p>");
            sb.AppendLine("                        <span class=\"slider-buttons hidden-xs\"> <a href=\"/services.html\" class=\"btn btn-primary\"> Our Services </a> <a href=\"/contact.html\" class=\"btn btn-warning\"> Contact us </a> </span>");
            sb.AppendLine("                    </div>");
            sb.AppendLine("                </div>");

            sb.AppendLine("                <div class=\"item\">");
            sb.AppendLine("                    <img src=\"/Images/banner3.jpg\" alt=\"Law Costs Draftsmen\" class=\"img-responsive hidden-xs\" />");
            sb.AppendLine("                    <img src=\"/Images/banner3_M.jpg\" alt=\"Law Costs Draftsmen\" class=\"img-responsive hidden-sm hidden-lg hidden-md\" />");
            sb.AppendLine("                    <div class=\"carousel-caption\">");
            sb.AppendLine("                        <h3 class=\"caption-title\">Our Commitment & Quality</h3>");
            sb.AppendLine("                        <p class=\"caption-text hidden-xs hidden-sm\">\"Competitive legal bill drafting rates but not compromising on bill accuracy, quality of service and turnaround time.\"</p>");
            sb.AppendLine("                        <span class=\"slider-buttons hidden-xs\"> <a href=\"/services.html\" class=\"btn btn-primary\"> Our Services </a> <a href=\"/contact.html\" class=\"btn btn-warning\"> Contact us </a> </span>");
            sb.AppendLine("                    </div>");
            sb.AppendLine("                </div>");


            sb.AppendLine("            </div>");

            sb.AppendLine("            <!-- Left and right controls -->");
            sb.AppendLine("            <a class=\"left carousel-control\" href=\"#myCarousel\" data-slide=\"prev\">");
            sb.AppendLine("                <span class=\"glyphicon glyphicon-chevron-left\"></span>");
            sb.AppendLine("                <span class=\"sr-only\">Previous</span>");
            sb.AppendLine("            </a>");
            sb.AppendLine("            <a class=\"right carousel-control\" href=\"#myCarousel\" data-slide=\"next\">");
            sb.AppendLine("                <span class=\"glyphicon glyphicon-chevron-right\"></span>");
            sb.AppendLine("                <span class=\"sr-only\">Next</span>");
            sb.AppendLine("            </a>");
            sb.AppendLine("        </div>");
            sb.AppendLine("    </div>");
            sb.AppendLine("</div>");
            return sb;
        }
    }

}
