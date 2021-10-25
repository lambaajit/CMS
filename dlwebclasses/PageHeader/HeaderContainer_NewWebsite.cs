using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class HeaderContainer_NewWebsite:AHeaderContainer
    {
        IT_DatabaseEntities db = new IT_DatabaseEntities();
        public override StringBuilder getheadercontainer(DepartmentDetails DD, AContents _content)
        {

            string cssclass = "";
            cssclass = DD.cssclass;
            StringBuilder SB = new StringBuilder();
            if (DD.Name == "Fees & Funding" || DD.Name == "Misleneous" || DD.Name == "Videos")
                DD = new DepartmentDetails("About Us");

            List<website_Header_Pictures> whp = new List<website_Header_Pictures>();
            whp = db.website_Header_Pictures.Where(x => x.department == DD.Name).ToList();
            if (DD.Name != "HomePage")
            {
                SB.AppendLine("<div class=\"row nopadding crouselsection " + cssclass + " deptbordercolor\">");
                SB.AppendLine("    <div class=\"col-md-12 col-lg-12 col-sm-12 nopadding\">");
                if (_content.GetType() != typeof(Content_Offices_NewWebsite))
                {
                    SB.AppendLine("        <div id=\"deptpage-carousel\" class=\"carousel slide nopadding\" data-ride=\"carousel\" data-interval=\"18000\">");
                    SB.AppendLine("            <ol class=\"carousel-indicators\">");
                    int i = 0;
                    foreach (var item in whp)
                    {
                        SB.AppendLine("                <li class=\"" + cssclass + " kolor\" data-target=\"#deptpage-carousel\" data-slide-to=\"" + i.ToString() + "\" ></li>");
                        i++;
                    }
                    SB.AppendLine("            </ol>");

                    SB.AppendLine("            <div class=\"carousel-inner\">");

                    //string active = " active ";

                    foreach (var item in whp)
                    {
                        SB.AppendLine("                <div class=\"item\">");
                        SB.AppendLine("                    <a href=\"\">");
                        SB.AppendLine("                        <img src=\"/WebBanners/" + item.imgfilename + "\" class=\"visible-lg visible-md visible-sm hidden-xs\" alt=\"" + item.Picture_Heading.Replace("<h3>", "").Replace("<h4>", "").Replace("</h3>", "").Replace("</h4>", "") + "\" width=\"100%\"  />");
                        SB.AppendLine("                        <img src=\"/WebBanners/" + item.mobileimgfilename + "\" class=\"hidden-lg hidden-md hidden-sm visible-xs\" alt=\"" + item.Picture_Heading.Replace("<h3>","").Replace("<h4>", "").Replace("</h3>", "").Replace("</h4>", "") + "\" width=\"100%\" />");
                        SB.AppendLine("                    </a>");
                        SB.AppendLine("                    <div class=\"deptpage-carousel-caption\">");
                        SB.AppendLine("                        <h3 class=\"" + cssclass + " forecolorlight\">" + item.Picture_Heading + "</h3>");
                        SB.AppendLine("                        <h4 class=\"" + cssclass + " forecolorlight deptbordercolorlight\">" + item.Picture_Blurb + "</h4>");
                        SB.AppendLine("                    </div>");
                        SB.AppendLine("                </div>");
                        //active = "";
                    }



                    SB.AppendLine("            </div>");
                    SB.AppendLine("            <a class=\"left carousel-control\" href=\"#deptpage-carousel\" data-slide=\"prev\">");
                    SB.AppendLine("                <span class=\"fa fa-caret-left deptcarouselcontrol " + cssclass + " forecolor\"></span>");
                    SB.AppendLine("            </a>");
                    SB.AppendLine("            <a class=\"right carousel-control\" href=\"#deptpage-carousel\" data-slide=\"next\">");
                    SB.AppendLine("                <span class=\"fa fa-caret-right deptcarouselcontrol " + cssclass + " forecolor\"></span>");
                    SB.AppendLine("            </a>");
                    SB.AppendLine("        </div>");
                }
                else
                {
                    string officename = _content.HeadingH1.Replace("Solicitors &amp; Lawyers in ", "");
                    DLWEBEntities dlweb = new DLWEBEntities();
                    string googlestring = dlweb.OfficesDLW.Where(x => x.Name == officename).Select(y => y.Google_Map_String).FirstOrDefault();
                    SB.AppendLine(googlestring.Substring(0, googlestring.IndexOf("</iframe>") + 9).Replace("350", "400").Replace("style=\"border:Solid 1px #0b1a55\"", ""));
                }

                SB.AppendLine("    </div>");
                SB.AppendLine("    <div class=\"parentrowoffixedrow\">");
                SB.AppendLine("        <div class=\"row nopadding " + cssclass + " kolor deptheading\" data-spy=\"affix\" data-offset-top=\"500\">");
                SB.AppendLine("            <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
                SB.AppendLine("                <h1 class=\"" + cssclass + "\">" + _content.HeadingH1.Replace("<br />", " ").Replace("InThePress", "In The Press") + "</h1>");
                SB.AppendLine("            </div>");
                SB.AppendLine("        </div>");
                SB.AppendLine("    </div>");
                SB.AppendLine("</div>");

                return SB;
            }
            else
            {
                string[] lscolors = new string[] { "dept_AAP", "dept_Crime", "dept_Family", "dept_RegulatoryMatters", "dept_ChildCare", "dept_ClinicalNegligence" };
                SB.AppendLine("<div class=\"row nopadding\">");
                SB.AppendLine("    <div class=\"col-md-12 col-lg-12 col-sm-12 nopadding\">");
                SB.AppendLine("    <div class=\"outerhomepagecarousel\">");
                SB.AppendLine("        <div id=\"carousel-example1\" class=\"carousel slide\" data-ride=\"carousel\" data-interval=\"18000\">");
                SB.AppendLine("            <ol class=\"carousel-indicators\">");
                for (int i = 0; i <= whp.Count()-1; i++)
                {
                    SB.AppendLine("                <li data-target=\"#carousel-example1\" data-slide-to=\"" + i.ToString() + "\"></li>");
                }
                SB.AppendLine("            </ol>");

                SB.AppendLine("            <div class=\"carousel-inner\">");
                int u = 0;
                foreach (var item in whp)
                {
                    SB.AppendLine("                <div class=\"item\">");
                    SB.AppendLine("                    <a href=\"\">");
                    SB.AppendLine("                        <img src=\"/WebBanners/" + item.imgfilename + "\" class=\"visible-lg visible-md visible-sm hidden-xs\" alt=\"" + item.Picture_Heading.Replace("<h3>", "").Replace("<h4>", "").Replace("</h3>", "").Replace("</h4>", "") + "\" width=\"100%\" />");
                    SB.AppendLine("                        <img src=\"/WebBanners/" + item.mobileimgfilename + "\" class=\"hidden-lg hidden-md hidden-sm visible-xs\" alt=\"" + item.Picture_Heading.Replace("<h3>", "").Replace("<h4>", "").Replace("</h3>", "").Replace("</h4>", "") + "\" width=\"100%\" />");
                    SB.AppendLine("                    </a>");
                    SB.AppendLine("                    <div class=\"carousel-caption\">");
                    SB.AppendLine(item.Picture_Heading.Replace("<h3>", "<h3 class=\"" + lscolors[u].ToString() + " forecolor\">").Replace("<h4>", "<h4 class=\"" + lscolors[u].ToString() + " forecolor\">"));
                    SB.AppendLine("                            <span>" + item.Picture_Blurb + "</span>");
                    SB.AppendLine("                    </div>");
                    SB.AppendLine("                </div>");
                    u++;
                }


                SB.AppendLine("            </div>");
                SB.AppendLine("            <a class=\"left carousel-control\" href=\"#carousel-example1\" data-slide=\"prev\">");
                SB.AppendLine("                <span class=\"fa fa-caret-left carouselcontrol\"></span>");
                SB.AppendLine("            </a>");
                SB.AppendLine("            <a class=\"right carousel-control\" href=\"#carousel-example1\" data-slide=\"next\">");
                SB.AppendLine("                <span class=\"fa fa-caret-right carouselcontrol\"></span>");
                SB.AppendLine("            </a>");
                SB.AppendLine("        </div>");


                SB.AppendLine("    </div>");
                SB.AppendLine("</div>");
                SB.AppendLine("</div>");
                return SB;
            }
        }
        
    }
}
