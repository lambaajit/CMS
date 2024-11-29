using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Videos_NewWebsite
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }

        public Videos_NewWebsite(int id, AContents _Acontent)
        {

            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            Website_Videos WV = new Website_Videos();
            WV = dbit.Website_Videos.Where(x => x.id == id).FirstOrDefault();
            DepartmentDetails DD = new DepartmentDetails(WV.Department);

            
            Title = "Video Reference: " + WV.id + " | " + DD.Name.Replace("All", "Duncan Lewis") + " video";

            if (WV.MetaDescription == string.Empty)
                Description = DD.Name.Replace("All", "Duncan Lewis") + " video, " + DD.Name.Replace("All", "Duncan Lewis") + " Solicitors video, " + DD.Name.Replace("All", "Duncan Lewis") + " Lawyers video, Duncan Lewis " + DD.Name.Replace("All", "Duncan Lewis") + " video";
            else
                Description = WV.MetaDescription;

            if (WV.MetaKeyword == string.Empty)
                Keywords = DD.Name.Replace("All", "Duncan Lewis") + " video, " + DD.Name.Replace("All", "Duncan Lewis") + " Solicitors video, " + DD.Name.Replace("All", "Duncan Lewis") + " Lawyers video, Duncan Lewis " + DD.Name.Replace("All", "Duncan Lewis") + " video";
            else
                Keywords = WV.MetaKeyword;

            Department = DD.Name;
            HeadingH1 = DD.Name.Replace("Videos", "") + " Videos";

            filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Videos\\" + allStatic.getVideoURL(WV.Heading, WV.Department);
            DepartmentNavigationNewWebsite Deptnav = new DepartmentNavigationNewWebsite();
            HRDDLEntities hrd = new HRDDLEntities();

            StringBuilder _NewContent = new StringBuilder();

            _NewContent.AppendLine("<div class=\"row nopadding\">");
            _NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-sm-offset-2 nopadding applyblock centerdiv\">");
            _NewContent.AppendLine("        <div class=\"row nopadding\">");
            _NewContent.AppendLine("            <div class=\"col-sm-12 col-md-7 col-xs-12 col-md-offset-5 depttabs\" style=\"z-index:999\">");

            if (DD.Name == "Find Us")
            {
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/findus.html\">All Offices<span class=\"fa fa-building\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Office_InLondon.html\">Offices In London<span class=\"fa fa-building\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/Office_OutLondon.html\">Offices Outside London<span class=\"fa fa-building\"></span></a>");

            }
            else
            {
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.Our_Team1 + "\">Our Team<span class=\"fa fa-users\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.News1 + "\">News<span class=\"fa fa-newspaper-o\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.News1.Replace("news", "articles") + "\">Articles<span class=\"fa fa-book\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.Video + "\">Videos<span class=\"fa fa-video-camera\"></span></a>");
            }


            _NewContent.AppendLine("            </div>");
            _NewContent.AppendLine("        </div>");
            _NewContent.AppendLine("    </div>");
            _NewContent.AppendLine("</div>");

            _NewContent.AppendLine("<div class=\"row deptreverseband nopadding " + DD.cssclass + " lightkolor\">");
            _NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-sm-offset-2 nopadding applyblock centerdiv\">");
            _NewContent.AppendLine("        <div class=\"row nopadding\">");
            _NewContent.AppendLine("            <div class=\"col-sm-9 col-xs-12 col-sm-offset-3 breadcrumbs\">");
            _NewContent.AppendLine("<p><a  class=\"" + DD.cssclass + " forecolor\" href=\"/index.html\"><p>Home</a><span class=\"fa fa-angle-double-right\"></span><a  class=\"" + DD.cssclass + " forecolor\" href=\"/" + DD.Overview1 + "\"><p>" + DD.Name + "</a><span class=\"fa fa-angle-double-right\"></span>" + DD.Name + " Videos</p>");
            _NewContent.AppendLine("            </div>");
            _NewContent.AppendLine("        </div>");

            _NewContent.AppendLine("    </div>");
            _NewContent.AppendLine("</div>");

            _NewContent.AppendLine("<div class=\"row nopadding\">");
            _NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
            _NewContent.AppendLine("        <div class=\"row nopadding\">");
            _NewContent.AppendLine("            <div class=\"col-sm-3 col-xs-12 nopadding\">");

            _NewContent.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, 0, DD.Name).ToString());

            _NewContent.AppendLine("            </div>");



            _NewContent.AppendLine("<div class=\"col-sm-9 col-xs-12\">");

            _NewContent.AppendLine("<div class=\"jobdetails " + DD.cssclass + " deptbordercolor\"><h4 class=\"" + DD.cssclass + " forecolor\">" + ((WV.Heading == null ? "" : WV.Heading).Length < 4 ? (WV.website_filename != null ? WV.website_filename.Replace("-", " ").Replace(".html", "") : WV.Department) : WV.Heading) + "</h4></div>");
            _NewContent.AppendLine(WV.VideoString);

            _NewContent.AppendLine("<p style=\"font-size:12px !important; color: gray !important\">Date when Video was Published: " + WV.DateOfVideo.Value.ToShortDateString() + "</p>");

            _NewContent.AppendLine("<div class=\"jobdetails " + DD.cssclass + " deptbordercolor\"><h4 class=\"" + DD.cssclass + " forecolor\">Script for the above Video</h4></div>");
            _NewContent.AppendLine(WV.content);

           

            if (!string.IsNullOrEmpty(DD.contactstr1) && DD.Name != "Mental Health")
            {
                _NewContent.AppendLine("<br /><br /><div class=\"deptcontactus " + DD.cssclass + " lightkolor\"><span class=\"" + DD.cssclass + " forecolor\">For all " + DD.Name + " related matters contact us online now.</span><a  class=\"deptcontactus " + DD.cssclass + " kolor\" href=\"/Home/Contact?dept=" + DD.Name + "\">Contact Us</a></div><br />");
            }

            _NewContent.AppendLine("	<p style=\"font-size: 10px!important; line-height: 12px!important\"><u style=\"font-size : 12px!important\">Disclaimer</u>");
            _NewContent.AppendLine("	<br /><br />");
            _NewContent.AppendLine("This video content was created on " + WV.DateOfVideo.Value.ToShortDateString() + " to provide an overview of the legal position and the information was correct at the time this video was created.  This video has been produced for purposes of generic information and marketing purposes only.  While the information on this site is about legal issues, it is not intended as legal advice or as a substitute for the particularised advice of your own legal advisor. Please consult one of our lawyers to provide you with advice and assistance on any matters touched on this video.  Viewing of this video does not create legally binding advice and does not create a retainer with Duncan Lewis Solicitors.");
            _NewContent.AppendLine("This video is Copyrighted at Duncan Lewis Solicitors " + WV.DateOfVideo.Value.Year + ". Any illegal reproduction of this content is prohibited and will result in immediate legal action.</p>");


            _NewContent.AppendLine("                </div>");

            _NewContent.AppendLine("                </div>");
            _NewContent.AppendLine("                </div>");
            _NewContent.AppendLine("                </div>");

            Contents = _NewContent;
        }
    }
}
