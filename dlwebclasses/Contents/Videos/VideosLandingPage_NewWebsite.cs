using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class VideosLandingPage_NewWebsite
    {
         public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }

        private DLWEBEntities dbo = new DLWEBEntities();
        public VideosLandingPage_NewWebsite(string dept, AContents _Acontent)
        {



            DepartmentDetails DD = new DepartmentDetails(dept.Replace("All","Videos"));
            Title = DD.Name.Replace("All","Duncan Lewis") + " video | Duncan Lewis";
            Description = DD.Name.Replace("All","Duncan Lewis") + " video, " + DD.Name.Replace("All","Duncan Lewis") + " Solicitors video, " + DD.Name.Replace("All","Duncan Lewis") + " Lawyers video, Duncan Lewis " + DD.Name.Replace("All","Duncan Lewis") + " video";
            Keywords = DD.Name.Replace("All","Duncan Lewis") + " video, " + DD.Name.Replace("All","Duncan Lewis") + " Solicitors video, " + DD.Name.Replace("All","Duncan Lewis") + " Lawyers video, Duncan Lewis " + DD.Name.Replace("All","Duncan Lewis") + " video";
            Department = DD.Name;
            HeadingH1 = DD.Name.Replace("Videos", "") + " Videos";
            if (dept == "All")
                filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Video.html";
            else
                filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\" + DD.Name.Replace(" ","-") + "-Video.html";

            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            List<Website_Videos> WV = new List<Website_Videos>();
            if (dept != "All")
                WV = dbit.Website_Videos.Where(x => x.Department == dept && x.Active == true).OrderByDescending(x => x.DateOfVideo).ToList();
            else
                WV = dbit.Website_Videos.Where(x => x.Active == true).OrderBy(x => x.Department).ThenByDescending(x => x.DateOfVideo).ToList();

            DepartmentNavigationNewWebsite Deptnav = new DepartmentNavigationNewWebsite();
             HRDDLEntities hrd = new HRDDLEntities();

            StringBuilder _NewContent = new StringBuilder();

_NewContent.AppendLine("<div class=\"row nopadding\">");
_NewContent.AppendLine("    <div class=\"col-sm-8 col-xs-12 col-sm-offset-2 nopadding applyblock centerdiv\">");
_NewContent.AppendLine("        <div class=\"row nopadding\">");
_NewContent.AppendLine("            <div class=\"col-sm-12 col-md-7 col-xs-12 col-md-offset-5 depttabs\" style=\"z-index:999\">");

            if (dept!="All")
            {
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.Our_Team1 + "\">Our Team<span class=\"fa fa-users\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.News1 + "\">News<span class=\"fa fa-newspaper-o\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.News1.Replace("news", "articles") + "\">Articles<span class=\"fa fa-book\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/" + DD.Video + "\">Videos<span class=\"fa fa-video-camera\"></span></a>");
            }
            else
            {
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/our_team.html\">Our Team<span class=\"fa fa-users\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/news.html\">News<span class=\"fa fa-newspaper-o\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/videos.html\">Videos<span class=\"fa fa-video-camera\"></span></a>");
                _NewContent.AppendLine("                <a class=\"" + DD.cssclass + " forecolor lightkolor over\" href=\"/brochures.html\">Brochures<span class=\"fa fa-book\"></span></a>");
            }

_NewContent.AppendLine("            </div>");
_NewContent.AppendLine("        </div>");
_NewContent.AppendLine("    </div>");
_NewContent.AppendLine("</div>");

_NewContent.AppendLine("<div class=\"row deptreverseband nopadding " + DD.cssclass + " lightkolor nopadding\">");
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

_NewContent.AppendLine(Deptnav.getDepartmentNavigation(_Acontent, 0,dept).ToString());

_NewContent.AppendLine("            </div>");



_NewContent.AppendLine("<div class=\"col-sm-9 col-xs-12 nopadding\">");
_NewContent.AppendLine("<div class=\"row nopadding\">");

            var _dept = "";
            int i = 0;
            foreach (var item in WV)
            {
                string staffname = "";
                if (hrd.Emp_Details.Where(x => x.emp_code == item.emp_code).Count() > 0)
                {
                    staffname = hrd.Emp_Details.Where(x => x.emp_code == item.emp_code).Select(y => y.forename + " " + y.surname).FirstOrDefault();
                }

                Website_Department_Structure WDS = new Website_Department_Structure();
                string cssclass = dbit.Website_Department_Structure.Where(x => x.Name == item.Department).Select(y => y.cssclass).FirstOrDefault();

                if (((i % 2 == 0) && i != 0) || _dept != item.Department)
                {
                    _NewContent.AppendLine("</div>");

                    if (_dept != item.Department)
                    {
                        _NewContent.AppendLine("                        <div class=\"col-xs-12 col-sm-12\">");
                        _NewContent.AppendLine("                            <div class=\"panel panel-primary videoimage " + cssclass + " deptbordercolor\">");
                        _NewContent.AppendLine("                                <div class=\"panel-heading " + cssclass + " kolor forecolorlight deptbordercolorlight videoimage\">");
                        _NewContent.AppendLine((item.Department == null ? item.Heading : item.Department) + "<span class=\"fa fa-caret-down " + cssclass + " forecolorlight\"></span>");
                        _NewContent.AppendLine("                                </div>");
                        _NewContent.AppendLine("                            </div>");
                        _NewContent.AppendLine("                        </div>");
                    }


                    _NewContent.AppendLine("<div class=\"row nopadding\">");
                }
                
                _NewContent.AppendLine("                        <div class=\"col-xs-12 col-sm-6\">");
                _NewContent.AppendLine("                            <div class=\"panel panel-primary videoimage " + cssclass + " deptbordercolor\">");
                _NewContent.AppendLine("                                <div class=\"panel-heading " + cssclass + " kolor forecolorlight deptbordercolorlight videoimage\">");
                _NewContent.AppendLine((item.Heading == null ? item.Department : item.Heading) + "<span class=\"fa fa-play-circle " + cssclass + " forecolorlight\"></span>");
                _NewContent.AppendLine("                                </div>");
                _NewContent.AppendLine("                                <div class=\"videoimage panel-body\">");
               _NewContent.AppendLine("                                    <p>" + ((staffname.Length < 4) ? "" : "By:" + staffname) + " <a href=\"/Videos/" + item.id + "_Videos.html\"><span class=\"fa fa-play-circle " + cssclass + " forecolorlight\"></span></a><a href=\"#\">Watch This Video</a><font size=\"3\" style=\"padding-top:10px; display:block\">Department: " + item.Department + "</font></p>");
                _NewContent.AppendLine("                                    <a href=\"/Videos/" + item.id + "_Videos.html\"><img src=\"/Video-Images/" + item.id + ".jpg\" class=\"img-responsive\" alt=\"" + item.name + "\" /></a>");
                _NewContent.AppendLine("                                </div>");
                _NewContent.AppendLine("                            </div>");
                _NewContent.AppendLine("                        </div>");
                i++;
                _dept = item.Department;
            }
            _NewContent.AppendLine("                </div>");

            _NewContent.AppendLine("                </div>");

            _NewContent.AppendLine("                </div>");
            _NewContent.AppendLine("                </div>");
            _NewContent.AppendLine("                </div>");

            Contents = _NewContent;
        }
    }
}
