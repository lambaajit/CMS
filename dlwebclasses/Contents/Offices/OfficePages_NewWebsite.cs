using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class OfficePages_NewWebsite
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }

        private DLWEBEntities dbo = new DLWEBEntities();
        public OfficePages_NewWebsite(int id, AContents _Acontent)
        {

            OfficeDLW office = new OfficeDLW();
            office = dbo.OfficesDLW.Where(x => x.ID == id).FirstOrDefault();
            Title = "Solicitors &amp; Lawyers " + office.Name.ToString() + " | Competitive Rates | Legal Aid";
            if (!string.IsNullOrEmpty(office.PageTitle))
                Title = office.PageTitle;
            Description = "Nationwide, solicitors in " + office.Name.ToString() + " offering Legal Aid, No Win No Fee for some cases & competitive rates/Fixed Fees.  You can call us on: 033 3772 0409.";
            if (!string.IsNullOrEmpty(office.MetaDescription))
                Description = office.MetaDescription;
            string keywords = "Solicitors [Office name], Lawyers [Office name], Legal Aid Lawyer [Office name], Divorce Solicitors [Office name], Criminal Defence Solicitor [Office name], Fraud Defence Lawyer [Office name], Immigration Solicitors [Office name], Child & Children Custody Lawyer, Housing Disrepair and Eviction, Homelessness Appeals, Contesting A Will, Child or children taken by social services, Mental Capacity and Court of Protection Solicitor, Probate Solicitor [Office name], Property Litigation Lawyer [Office name], Company Disputes Lawyer, Medical Negligence Lawyer [Office name], Personal Injury Solicitor [Office name], Debt Insolvency & Bankruptcy Solicitor, Domestic Abuse, Violence, Child Abduction Solicitor, Free Legal Advice [Office name], Inquest Solicitors [Office name]";

            Keywords = keywords.Replace("[Office name]", office.Name.ToString());
            if (!string.IsNullOrEmpty(office.MetaKeywords))
                Keywords = office.MetaKeywords;

            HeadingH1 = "Solicitors &amp; Lawyers in " + office.Name.ToString();
            Department = "Find Us";
            filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\offices\\" + office.Name.ToString() + "-Solicitors.html";

            DepartmentDetails DD = new DepartmentDetails("Find Us");

            DepartmentNavigationNewWebsite Deptnav = new DepartmentNavigationNewWebsite();

            List<website_Office_Direction> WOD = new List<website_Office_Direction>();

            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            WOD = dbit.website_Office_Direction.Where(x => x.officeid == id).ToList();

            StringBuilder _NewContent = new StringBuilder();

            _NewContent.AppendLine("<div class=\"row nopadding\">");
            _NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            _NewContent.AppendLine("        <div class=\"row nopadding\">");
            _NewContent.AppendLine("            <div class=\"col-sm-8 col-xs-12 col-lg-offset-4 depttabs\" style=\"z-index:999\">");
            _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/findus.html\">All Offices<span class=\"fa fa-building\"></span></a>");
            _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Office_InLondon.html\">Offices In London<span class=\"fa fa-building\"></span></a>");
            _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Office_OutLondon.html\">Offices Outside London<span class=\"fa fa-building\"></span></a>");
            _NewContent.AppendLine("            </div>");
            _NewContent.AppendLine("        </div>");
            _NewContent.AppendLine("    </div>");
            _NewContent.AppendLine("</div>");

            _NewContent.AppendLine("<div class=\"row deptreverseband nopadding " + DD.cssclass + " lightkolor\">");
            _NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            _NewContent.AppendLine("        <div class=\"row nopadding\">");
            _NewContent.AppendLine("            <div class=\"col-sm-9 col-xs-12 col-lg-offset-3 breadcrumbs\">");
            _NewContent.AppendLine("<p><a  class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\"><p>Home</a><span class=\"fa fa-angle-double-right\"></span><a  class=\"" + DD.cssclass + " forecolor\" href=\"/findus.html\"><p>Our Offices</a><span class=\"fa fa-angle-double-right\"></span>" + office.Name + " Office</p>");
            _NewContent.AppendLine("            </div>");
            _NewContent.AppendLine("        </div>");

            _NewContent.AppendLine("    </div>");
            _NewContent.AppendLine("</div>");

            _NewContent.AppendLine("<div class=\"row nopadding\">");
            _NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            _NewContent.AppendLine("        <div class=\"row\">");
            _NewContent.AppendLine("            <div class=\"col-sm-3 col-xs-12\">");

            _NewContent.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, office.ID).ToString());

            _NewContent.AppendLine("            </div>");

            bool svavailable = false;
            if (WOD.Where(x => x.Category_Of_Site == "Street View").Count() > 0)
                svavailable = true;

            _NewContent.AppendLine("<div id=\"maincontent\" class=\"col-sm-9 col-xs-12\">");
            if (office.Active == false)
            {
                _NewContent.AppendLine("<div style=\"font-size:20px; font-weight:bold; color:red; width:100%; text-align:center;\">We are no longer based at this office location. <br />Please click <a href=\"/findus.html\" style=\"color:blue; font-size:20px !important \">here</a> to find out nearest office to you. ");
            }

            _NewContent.AppendLine("                <div class=\"col-xs-12 panel panel-primary nopadding officedetails dept_default deptbordercolor\">");
            _NewContent.AppendLine("                    <div class=\"panel-heading dept_default kolor deptbordercolor\">Address<span class=\"fa fa-map-marker\"></span></div>");
            _NewContent.AppendLine("                    <div class=\"panel-body\">");
            _NewContent.AppendLine("                        <div class=\"row\">");
            _NewContent.AppendLine("                            <div class=\"col-sm-6 col-xs-12\">");
            _NewContent.AppendLine("                                <h3>" + office.Name + "</h3>");
            _NewContent.AppendLine("                                <h5>" + office.Address.Replace(",", "<br />") + "</h5>");
            if (svavailable == true)
                _NewContent.AppendLine("<br />" + office.Google_Map_String.Substring(0, office.Google_Map_String.IndexOf("</iframe>") + 9).Replace("350", "100"));

            _NewContent.AppendLine("                            </div>");
            if (svavailable == true)
            {
                _NewContent.AppendLine("                            <div class=\"col-sm-6 col-xs-12\">");
                _NewContent.AppendLine(WOD.Where(x => x.Category_Of_Site == "Street View").Select(y => y.Map_Of_Site).FirstOrDefault().ToString().Replace("600", "100%").Replace("450", "300").Replace("style=\"", "style=\"border:Solid 1px #0b1a55\""));
                _NewContent.AppendLine("                            </div>");
            }
            else
            {
                _NewContent.AppendLine("                            <div class=\"col-sm-6 col-xs-12\">");
                _NewContent.AppendLine(office.Google_Map_String.Substring(0, office.Google_Map_String.IndexOf("</iframe>") + 9).Replace("350", "200"));
                _NewContent.AppendLine("                            </div>");
            }

            _NewContent.AppendLine("                        </div>");

            _NewContent.AppendLine("                    </div>");
            _NewContent.AppendLine("                </div>");


            if (office.VideoId != null && office.VideoId > 0)
            {
                var WV = dbit.Website_Videos.Where(x => x.id == office.VideoId && x.Active == true).FirstOrDefault();
                if (WV != null)
                {
                    _NewContent.AppendLine("                <div class=\"col-xs-12 panel panel-primary nopadding officedetails dept_default deptbordercolor\">");
                    _NewContent.AppendLine("                    <div class=\"panel-heading dept_default kolor deptbordercolor\">Office Video<span class=\"fa fa-pencil-square-o\"></span></div>");
                    _NewContent.AppendLine("                        <div class=\"panel-body\">");
                    _NewContent.AppendLine(WV.VideoString);
                    _NewContent.AppendLine("                        </div>");
                    _NewContent.AppendLine("                        </div>");
                }
            }

            var _customContents = WOD.Where(x => x.Category_Of_Site == "Custom Text and Heading").ToList();
            if (_customContents.Count == 0)
            {

                _NewContent.AppendLine("                <div class=\"col-xs-12 panel panel-primary nopadding officedetails dept_default deptbordercolor\">");
                _NewContent.AppendLine("                    <div class=\"panel-heading dept_default kolor deptbordercolor\">Our Services<span class=\"fa fa-pencil-square-o\"></span></div>");
                _NewContent.AppendLine("                        <div class=\"panel-body\">");
                _NewContent.AppendLine("                            <div class=\"row\">");
                _NewContent.AppendLine("                                <ul><li>Our solicitors in " + office.Name.ToString() + " can assist in over 25 areas of law such as Criminal Defence, Fraud Defence, Immigration, Medical Negligence & Mental Capacity/Court of Protection matters.</li>");
                _NewContent.AppendLine("                                <li>Our highly experienced award winning Family lawyers & solicitors in " + office.Name.ToString() + ", can also assist with Divorce, Financial Disputes, Child Custody, Social Services & Child Abduction issues.</li>");
                _NewContent.AppendLine("                                <li>Our Litigation lawyers are able to assist with Company Disputes, Negligence Claims, Consumer, Debt, Property and Wills & Probate Disputes.</li>");
                _NewContent.AppendLine("                                <li>Our Housing lawyers in " + office.Name.ToString() + " can guide you through the maze of Landlord & Tenant law issues, including, Disrepair, Eviction & Homelessness Appeals.</li></ul>");
                _NewContent.AppendLine("                        </div>");
                _NewContent.AppendLine("                        </div>");

                _NewContent.AppendLine("                    </div>");
            }
            else
            {
                foreach (var item in _customContents.Where(x => x.Sequence < 10).OrderBy(x => x.Sequence))
                {
                    _NewContent.AppendLine("                <div class=\"col-xs-12 panel panel-primary nopadding officedetails dept_default deptbordercolor\">");
                    _NewContent.AppendLine("                    <div class=\"panel-heading dept_default kolor deptbordercolor\">" + item.Heading + "<span class=\"fa fa-pencil-square-o\"></span></div>");
                    _NewContent.AppendLine("                        <div class=\"panel-body\">");
                    _NewContent.AppendLine(item.Text);
                    _NewContent.AppendLine("                        </div>");

                    _NewContent.AppendLine("                    </div>");
                }
            }

            _NewContent.AppendLine("                <div class=\"col-xs-12 panel panel-primary nopadding officedetails dept_default deptbordercolor\">");
            _NewContent.AppendLine("                    <div class=\"panel-heading dept_default kolor deptbordercolor\">Contact Details<span class=\"fa fa-pencil-square-o\"></span></div>");
            _NewContent.AppendLine("                        <div class=\"panel-body\">");
            _NewContent.AppendLine("                            <div class=\"row\">");
            _NewContent.AppendLine("                                <div class=\"col-xs-12 col-sm-4\"><h5><a href=\"tel:0333 772 0409\"><span class=\"fa fa-phone\"></span>" + office.Dedicated_Numbers.ToString() + "</a></h5></div>");
            _NewContent.AppendLine("                                <div class=\"col-xs-12 col-sm-4\"><h5><a href=\"/contactUs.aspx\"><span class=\"fa fa-envelope\"></span>Contact Us</a></h5></div>");
            _NewContent.AppendLine("                                <div class=\"col-xs-12 col-sm-4\"><h5><a href=\"mailto:contact@duncanlewis.com\"><span>@</span>Email Us</a></h5></div>");
            _NewContent.AppendLine("                        </div>");
            _NewContent.AppendLine("                        </div>");

            _NewContent.AppendLine("                    </div>");

            _NewContent.AppendLine("                <div class=\"col-xs-12 panel panel-primary nopadding officedetails dept_default deptbordercolor\">");
            _NewContent.AppendLine("                    <div class=\"panel-heading dept_default kolor deptbordercolor\">Working Hours<span class=\"fa fa-clock-o\"></span></div>");
            _NewContent.AppendLine("                    <div class=\"panel-body\">");

            if (office.Appointment == "Yes")
                _NewContent.AppendLine("                        <div class=\"col-xs-12 officescheduleblurb\">This office is for scheduled appointments only</div>");
            else
                _NewContent.AppendLine("                        <div class=\"col-xs-12 officescheduleblurb\">This office is open for public</div>");

            _NewContent.AppendLine("                        <div class=\"col-sm-4 col-xs-12\">");
            _NewContent.AppendLine("                            <p>Monday-Friday: 9:30 - 5:30</p>");
            _NewContent.AppendLine("                        </div>");
            _NewContent.AppendLine("                        <div class=\"col-sm-4 col-xs-12\">");
            _NewContent.AppendLine("                            <p>Saturday-Sunday: Closed</p>");
            _NewContent.AppendLine("                        </div>");
            _NewContent.AppendLine("                        <div class=\"col-sm-4 col-xs-12\">");
            _NewContent.AppendLine("                            <p>Bank Holidays: Closed</p>");
            _NewContent.AppendLine("                        </div>");
            _NewContent.AppendLine("                    </div>");


            _NewContent.AppendLine("                </div>");

            if (_customContents.Count > 0)
            { 
                foreach (var item in _customContents.Where(x => x.Sequence > 10).OrderBy(x => x.Sequence))
                {
                    _NewContent.AppendLine("                <div class=\"col-xs-12 panel panel-primary nopadding officedetails dept_default deptbordercolor\">");
                    _NewContent.AppendLine("                    <div class=\"panel-heading dept_default kolor deptbordercolor\">" + item.Heading + "<span class=\"fa fa-pencil-square-o\"></span></div>");
                    _NewContent.AppendLine("                        <div class=\"panel-body\">");
                    _NewContent.AppendLine(item.Text);
                    _NewContent.AppendLine("                        </div>");

                    _NewContent.AppendLine("                    </div>");
                }
        }


            foreach (var item in WOD.Where(x => x.Category_Of_Site != "Custom Text and Heading").ToList())
            {
                if (item.Category_Of_Site != "Street View" && item.Category_Of_Site != "Details")
                {
                    string categoryicon = "";
                    if (item.Category_Of_Site == "Car Park")
                        categoryicon = "fa-car";
                    else if (item.Category_Of_Site == "Overground Station" || item.Category_Of_Site == "Train Station" || item.Category_Of_Site == "Underground Station")
                        categoryicon = "fa-train";
                    else if (item.Category_Of_Site == "Bus Stop" || item.Category_Of_Site == "Bus Station")
                        categoryicon = "fa-bus";


                    _NewContent.AppendLine("                <div class=\"col-xs-12 panel panel-primary nopadding officedetails dept_default deptbordercolor\">");
                    _NewContent.AppendLine("                    <div class=\"panel-heading dept_default kolor deptbordercolor\">Nearest " + item.Category_Of_Site + ": " + item.Direction_From_Site + " (Directions and Details)<span class=\"fa " + categoryicon + "\"></span></div>");
                    _NewContent.AppendLine("                    <div class=\"panel-body\">");


                    _NewContent.AppendLine("<ul class=\"nav nav-tabs\">");
                    _NewContent.AppendLine("    <li class=\"active\"><a data-toggle=\"tab\" href=\"#Address" + item.ID + "\">Address &amp; Details</a></li>");
                    if (!string.IsNullOrEmpty(item.DirectionByWalk))
                        _NewContent.AppendLine("    <li><a data-toggle=\"tab\" href=\"#DirectionsbyWalk" + item.ID + "\">Directions By Walk&nbsp;<span class=\"fa fa-road\"></span></a></li>");
                    if (!string.IsNullOrEmpty(item.DirectionByBus))
                        _NewContent.AppendLine("    <li><a data-toggle=\"tab\" href=\"#DirectionsbyBus" + item.ID + "\">Directions By Bus&nbsp;<span class=\"fa fa-bus\"></span></a></li>");
                    _NewContent.AppendLine("  </ul>");

                    _NewContent.AppendLine("<div class=\"tab-content\">");
                    _NewContent.AppendLine("    <div id=\"Address" + item.ID + "\" class=\"tab-pane fade in active\">");
                    _NewContent.AppendLine("<div class=\"row\">");
                    _NewContent.AppendLine("<div class=\"col-sm-6 col-xs-12\" style=\"padding:15px\">");
                    _NewContent.AppendLine("      <p>" + item.AddressandDescription_of_Site.Replace(Environment.NewLine, "<br />").Replace(",", "<br />") + "</p>");
                    _NewContent.AppendLine("    </div>");
                    _NewContent.AppendLine("<div class=\"col-sm-6 col-xs-12\" style=\"padding:15px\">");

                    if (item.Map_Of_Site != null)
                    _NewContent.AppendLine(item.Map_Of_Site.ToString().Replace("600", "100%").Replace("450", "200").Replace("style=\"", "style=\"border:Solid 1px #0b1a55\""));

                    _NewContent.AppendLine("    </div>");
                    _NewContent.AppendLine("    </div>");
                    _NewContent.AppendLine("    </div>");
                    if (!string.IsNullOrEmpty(item.DirectionByWalk))
                    {
                        _NewContent.AppendLine("    <div id=\"DirectionsbyWalk" + item.ID + "\" class=\"tab-pane fade\">");
                        _NewContent.AppendLine(item.DirectionByWalk.ToString().Replace("600", "100%").Replace("450", "200"));
                        _NewContent.AppendLine("    </div>");
                    }
                    if (!string.IsNullOrEmpty(item.DirectionByBus))
                    {
                        _NewContent.AppendLine("    <div id=\"DirectionsbyBus" + item.ID + "\" class=\"tab-pane fade\">");
                        _NewContent.AppendLine(item.DirectionByBus.ToString().Replace("600", "100%").Replace("450", "200"));
                        _NewContent.AppendLine("    </div>");
                    }
                    _NewContent.AppendLine("  </div>");


                    _NewContent.AppendLine("                    </div>");
                    _NewContent.AppendLine("                </div>");
                }
            }

            _NewContent.AppendLine("                </div>");

            _NewContent.AppendLine("                </div>");
            _NewContent.AppendLine("                </div>");
            _NewContent.AppendLine("                </div>");

            Contents = _NewContent;
        }
    }
}
