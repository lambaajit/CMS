using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Office_LandingPages_NewWebsite
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }

        private DLWEBEntities dbo = new DLWEBEntities();
        public Office_LandingPages_NewWebsite(int id, AContents _Acontent)
        {

            List<OfficeDLW> office = new List<OfficeDLW>();
            
            
            Title = "Find Us | Duncan Lewis Solicitors | offices Nationwide";
            Description = "Duncan Lewis Solicitors, Find us, London, Cardiff, Leicester, Birmingham, nationwide, Legal aid";
            Keywords = "Duncan Lewis, Duncan Lewis Solicitors, Solicitor, Lawyers, Divorce Solicitors, Crime Solicitors, Childcare Solicitors, Immigration Solicitors, Immigration Lawyers, Housing Solicitors, Mental Health, Divorce lawyers, Personal Injury, Domestic Violence Solicitors, Solicitors Duncan Lewis, fraud solicitor, Lawyers Duncan Lewis, Legal Aid Solicitors Duncan Lewis, Solicitors in Duncan Lewis, Lawyers in Duncan Lewis, Solicitor in Duncan Lewis, Lawyer in Duncan Lewis, Birmingham, Cardiff, London, Harrow, Leicester, hackney, Shepherds Bush, Tooting, Southall, Uxbridge, Bradford, Islington, Brent, Cambridge, New Cross Gate, Newham, Barking, Romford, Leeds, Sheffield, Hounslow, Lambeth, Slough, Bristol, Brighton, Liverpool, Manchester.";

            if (id == 1)
            {
                filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\findus.html";
                Title = "Find Us | Duncan Lewis Solicitors | offices Nationwide";
                Description = "Duncan Lewis Solicitors, Find us, London, Cardiff, Leicester, Birmingham, nationwide, Legal aid";
                HeadingH1 = "Solicitors &amp; Lawyers in UK";
                office = dbo.OfficesDLW.Where(x => x.Active == true && (x.Company== "Duncan Lewis" || x.Company=="Both")).OrderBy(y => y.Name).ToList();
            }
            else if (id == 2)
            {
                filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Office_InLondon.html";
                Title = "Offices Outside London | Duncan Lewis Solicitors";
                Description = "Duncan Lewis Solicitors, Offices Outside London";
                HeadingH1 = "Solicitors &amp; Lawyers in London";
                office = dbo.OfficesDLW.Where(x => x.Active == true && x.In_Out_London == "In" && (x.Company == "Duncan Lewis" || x.Company == "Both")).OrderBy(y => y.Name).ToList();
            }
            else if (id == 3)
            {
                filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Office_OutLondon.html";
                HeadingH1 = "Solicitors &amp; Lawyers Outside London";
                Title = "Offices Inside London | Duncan Lewis Solicitors";
                Description = "Duncan Lewis Solicitors, Offices Inside London";
                office = dbo.OfficesDLW.Where(x => x.Active == true && x.In_Out_London == "Out" && (x.Company == "Duncan Lewis" || x.Company == "Both")).OrderBy(y => y.Name).ToList();
            }

            
            Department = "Find Us";
            DepartmentDetails DD = new DepartmentDetails("Find Us");
            DepartmentNavigationNewWebsite Deptnav = new DepartmentNavigationNewWebsite();
            
            
                
                StringBuilder _NewContent = new StringBuilder();
            if (id == 1)
            {
                _NewContent.AppendLine("<div id=\"dialog\" title=\"Duncan Lewis Update\">");
                _NewContent.AppendLine("<p><b>To help protect the health and well-being of our clients, colleagues and communities our offices nationwide are now temporarily closed.<br /><br />Our Head Office in Harrow remains open and a number of our key offices are beginning to open in a phased manner for scheduled appointments and non-scheduled walk-in clients, these currently include Birmingham, Dalston, Luton and Milton Keynes. Our Shepherd’s Bush office is open for scheduled appointments only.<br /><br />Contact us for more details. Read about the Covid-19 Secure Office Safety Measures we have in place on <a href=\"https://www.duncanlewis.co.uk/Our-Response-Q-and-A.html\">‘Our Response’</a> page.  <br /><br />We are open for business. Our lawyers are still fully available to assist existing clients and take on new work by telephone, email and online conferencing.</b><br /><br /><b><u>Existing Clients</u></b><br /><br />The vast majority of our legal team are following government advice and working from home, if you need to contact them please call on their direct line or email them directly. If unsure, our lawyer contact details can be found on our website at <a href=\"https://www.duncanlewis.co.uk/Our_Team.html\"><u>‘Our Team’</u></a>.<br /><br /><b><u>New Clients</u></b><br /><br />At this time we encourage all of our prospective clients to contact us via our online new client query form at <a href=\"https://www.duncanlewis.co.uk/Home/contact\"><u>‘Contact Us’</u></a> on our website. You query will be received by our legal team and they will call/email you back as soon as possible.<br /><br />If you would like to know more about how Duncan Lewis is responding to the Coronavirus emergency, please visit the links below:<br /><br /><ul><li>Our CEO Message: <a href=\"https://www.duncanlewis.co.uk/CEO-Message-Coronavirus.html\">https://www.duncanlewis.co.uk/CEO-Message-Coronavirus.html</a></li><li>Our Response: Q&As: <a href=\"https://www.duncanlewis.co.uk/Our-Response-Q-and-A.html\">https://www.duncanlewis.co.uk/Our-Response-Q-and-A.html</a></li></ul><br />Thank you for your co-operation in advance.</p>");
                _NewContent.AppendLine("<button class=\"btn btn-primary\" style=\"float:right\" onclick=\"closedialog();\">Close</button></div>");

            }
            _NewContent.AppendLine("<div class=\"row nopadding\">");
                _NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
                _NewContent.AppendLine("        <div class=\"row nopadding\">");
                _NewContent.AppendLine("            <div class=\"col-sm-12 col-md-7 col-xs-12 col-md-offset-5 depttabs\">");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/findus.html\">All Offices<span class=\"fa fa-building\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"Office_InLondon.html\">Offices In London<span class=\"fa fa-building\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"Office_OutLondon.html\">Offices Outside London<span class=\"fa fa-building\"></span></a>");
                _NewContent.AppendLine("            </div>");
                _NewContent.AppendLine("        </div>");
                _NewContent.AppendLine("    </div>");
                _NewContent.AppendLine("</div>");

                _NewContent.AppendLine("<div class=\"row deptreverseband nopadding " + DD.cssclass + " lightkolor\">");
                _NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
                _NewContent.AppendLine("        <div class=\"row nopadding\">");
                _NewContent.AppendLine("            <div class=\"col-sm-9 col-xs-12 col-sm-offset-3 breadcrumbs\">");
                _NewContent.AppendLine("<p><a  class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\"><p>Home</a><span class=\"fa fa-angle-double-right\"></span><a  class=\"" + DD.cssclass + " forecolor\" href=\"/findus.html\"><p>Our Offices</a><span class=\"fa fa-angle-double-right\"></span>" + HeadingH1 +"</p>");
                _NewContent.AppendLine("            </div>");
                _NewContent.AppendLine("        </div>");

                _NewContent.AppendLine("    </div>");
                _NewContent.AppendLine("</div>");

                _NewContent.AppendLine("<div class=\"row nopadding\">");
                _NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
                _NewContent.AppendLine("        <div class=\"row\">");
                _NewContent.AppendLine("            <div class=\"col-sm-3 col-xs-12\">");

                _NewContent.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, id * 1000).ToString());

                _NewContent.AppendLine("            </div>");



                _NewContent.AppendLine("<div id=\"maincontent\" class=\"col-sm-9 col-xs-12 nopadding\">");
                _NewContent.AppendLine("                <div class=\"row nopadding\">");
                foreach (var item in office)
                {
                    string redscript = "";
                    if (item.Appointment == "Yes")
                    redscript ="<sup class=\"redsuperscript\">*</sup>";
                    _NewContent.AppendLine("                    <div class=\"col-sm-4 col-xs-12 nopadding\">");
                    _NewContent.AppendLine("                        <div class=\"officelandingpagepanel row nopadding\"><div class=\"col-xs-3\"><span class=\"fa fa-map-marker\"></span></div><div class=\"col-xs-9\"><a href=\"\\offices\\" + item.Name + "_office.html\">" + item.Name + redscript + "</a><p>" + item.County + ", " + item.Postcode + "</p></div></div>");
                    _NewContent.AppendLine("                    </div>");
                }
                _NewContent.AppendLine("                </div>");

                _NewContent.AppendLine("                <div class=\"row\">");
                _NewContent.AppendLine("                        <div class=\"col-xs-12 officescheduleblurb\"><sup class=\"redsuperscript\">*</sup>&nbsp;These offices are for scheduled appointments only</div>");
                _NewContent.AppendLine("                </div>");

                _NewContent.AppendLine("                </div>");

                _NewContent.AppendLine("                </div>");
                _NewContent.AppendLine("                </div>");
                _NewContent.AppendLine("                </div>");

                Contents = _NewContent;
            
        }
    }
}
