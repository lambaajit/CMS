using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class BrochurePages_NewWebsite
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }

        private DLWEBEntities dbo = new DLWEBEntities();
        public BrochurePages_NewWebsite(int id, AContents _Acontent)
        {

        Brochure brochure = new Brochure();
            brochure = dbo.Brochures.Where(x => x.ID == id).FirstOrDefault();
        Title = "Duncan Lewis - " + brochure.Name + " solicitors London";
        Description = brochure.Name + " speaking solicitor, " + brochure.Name + " Lawyers, London, UK";
        string keywords = brochure.Name + " speaking solicitor, " + brochure.Name + " speaking Lawyer, " + brochure.Name + " speaking Lawyer London, " + brochure.Name + " speaking Lawyer UK, " + brochure.Name + " speaking solicitor UK, Duncan Lewis, " + brochure.Name + " speaking immigration solicitor, " + brochure.Name + " Solicitor, " + brochure.Name + " Solicitors, " + brochure.Name + " Lawyer London, " + brochure.Name + " Solicitor London, " + brochure.Name + " Solicitor UK, " + brochure.Name + " Solicitor England";
            
        
            HeadingH1 = "Farsi Speaking Solicitors";
            Department ="About Us";
            filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\brochures_" + brochure.Name.ToString() + ".html";

            DepartmentDetails DD = new DepartmentDetails("About Us");

            DepartmentNavigationNewWebsite Deptnav = new DepartmentNavigationNewWebsite();
           
            StringBuilder _NewContent = new StringBuilder();

_NewContent.AppendLine("<div class=\"row nopadding\">");
_NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
_NewContent.AppendLine("        <div class=\"row nopadding\">");
            _NewContent.AppendLine("            <div class=\"col-sm-12 col-md-7 col-xs-12 col-md-offset-5 depttabs\">");
            _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/our_team.html\">Our Team<span class=\"fa fa-users\"></span></a>");
            _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/news.html\">News<span class=\"fa fa-newspaper-o\"></span></a>");
            _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/video.html\">Videos<span class=\"fa fa-video-camera\"></span></a>");
            _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/brochures.html\">Brochures<span class=\"fa fa-book\"></span></a>");
            _NewContent.AppendLine("            </div>");
            _NewContent.AppendLine("        </div>");
_NewContent.AppendLine("    </div>");
_NewContent.AppendLine("</div>");

_NewContent.AppendLine("<div class=\"row deptreverseband nopadding " + DD.cssclass + " lightkolor\">");
_NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
_NewContent.AppendLine("        <div class=\"row nopadding\">");
_NewContent.AppendLine("            <div class=\"col-sm-9 col-xs-12 col-lg-offset-3 breadcrumbs\">");
_NewContent.AppendLine("<p><a  class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\"><p>Home</a><span class=\"fa fa-angle-double-right\"></span><a  class=\"" + DD.cssclass + " forecolor\" href=\"/brochures.html\"><p>Brochures</a><span class=\"fa fa-angle-double-right\"></span>" + brochure.Name + " Brochure</p>");
_NewContent.AppendLine("            </div>");
_NewContent.AppendLine("        </div>");

_NewContent.AppendLine("    </div>");
_NewContent.AppendLine("</div>");

_NewContent.AppendLine("<div class=\"row nopadding\">");
_NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
_NewContent.AppendLine("        <div class=\"row\">");
_NewContent.AppendLine("            <div class=\"col-sm-3 col-xs-12\">");

_NewContent.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, brochure.ID).ToString());

_NewContent.AppendLine("            </div>");


_NewContent.AppendLine("<div id=\"maincontent\" class=\"col-sm-9 col-xs-12\">");
_NewContent.AppendLine("                        <div class=\"row\">");
_NewContent.AppendLine("                            <div class=\"col-sm-12 col-xs-12\">");
_NewContent.AppendLine("                                <h3>Legal services provided by " + brochure.Name + " speaking solicitors in London</h3><br />");
_NewContent.AppendLine("            <p><a href=\"brochures/" + brochure.Name + ".pdf\" target=\"_blank\"><img src=\"images/" + brochure.Name + ".jpg\" style=\"border: Solid 1px #0b1a55; width:100%\" alt=\"" + brochure.Name + "\" /></a>");
_NewContent.AppendLine("                </div>");




            _NewContent.AppendLine("                </div>");

            _NewContent.AppendLine("                </div>");
            _NewContent.AppendLine("                </div>");
            _NewContent.AppendLine("                </div>");

            Contents = _NewContent;
        }
    }
}
