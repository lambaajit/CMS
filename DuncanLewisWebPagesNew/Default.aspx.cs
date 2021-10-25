using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dlwebclasses;
using Ninject;
using System.Reflection;
using System.Text;
using System.IO;

namespace DuncanLewisWebPagesNew
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Staff Profile
            //AContents _content = new Content_StaffProfile("PackerJ");
            //AWebPage WP = new WebPage();

            //WebPage
            //AContents _content = new Content_WebsitePages(19);
            //AWebPage WP = new WebPage();

            //WebPage
            //AContents _content = new Content_NewsArticles(11112);
            //AWebPage WP = new WebPage();

            //Team Pages
            //AContents _content = new Content_TeamPages("Immigration");
            //AWebPage WP = new WebPage();

            //News Landing Pages
            AContents _content = new Content_NewsArticlesLandingPages("Immigration","NonDL",2016,10);
            AWebPage WP = new WebPage();
            client_WebPage cwp = new client_WebPage(WP, _content);
            StringBuilder SB = new StringBuilder();

            
            //Start of document

            SB.AppendLine("<!DOCTYPE html>");
            SB.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            SB.AppendLine(cwp.getheadsection().ToString());

            SB.Append("<body>");
            SB.AppendLine("<div class=\"container-fluid\">");
            SB.AppendLine("\t<div  class=\"row\">");
            SB.AppendLine("\t<div id=\"top-most-div\" class=\"col-lg-8 col-md-8 col-sm-12 col-xs-12 col-lg-offset-2 col-md-offset-2\" style=\"padding:0px; background-color:#FFF\" >");

            SB.AppendLine(cwp.getpageheader().ToString());

            //Start of Middle block including right coloumn
            SB.AppendLine("    <div class=\"container-fluid  dynamicpadding\">");
            SB.AppendLine("    <div class=\"row\">      ");
            SB.AppendLine("<div class=\"col-lg-9 col-md-9 col-sm-9\" style=\"padding:0px;\">");

            SB.AppendLine(cwp.getheadercontainer().ToString());


            SB.AppendLine("<div class=\"container-fluid\">");
            SB.AppendLine("<div class=\"row\">");

            Dictionary<string, StringBuilder> Dict = new Dictionary<string, StringBuilder>();
            Dict = cwp.getAreasOfLaws();
            SB.AppendLine(Dict["Mobile"].ToString());

            SB.AppendLine(cwp.getDepartmentNavigation().ToString());

            SB.AppendLine("</div>");
            SB.AppendLine("</div>");

            SB.AppendLine("<div class=\"container-fluid\">");
            SB.AppendLine("<div class=\"row\">");

            SB.AppendLine(Dict["Desktop"].ToString());

            SB.AppendLine("<div class=\"col-lg-9 col-md-9 col-sm-9 col-xs-12 middlecolpaddingcontrol\">");
            SB.AppendLine(cwp.getcontents().ToString());

            SB.AppendLine("</div>");
            SB.AppendLine("</div>");
            SB.AppendLine("</div>");
            SB.AppendLine("</div>");

            SB.AppendLine(cwp.getrightcoloumn().ToString());

            SB.AppendLine("</div>");
            SB.AppendLine("</div>");
            //End Of Middle Block
            //Start of Footer

            SB.AppendLine(cwp.getfooter().ToString());
            SB.AppendLine("</div>");
            SB.AppendLine("</div>");
            SB.AppendLine("</div>");

            Response.Write(cwp.getpagescripts());
            SB.AppendLine("</body>");
            SB.AppendLine("</html>");

            StreamWriter fp;
            //staffprofile path
            //fp = File.CreateText("C:\\inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised\\publiclaw_ourteam\\James Packer1.html");

            //webpagepath path
            //fp = File.CreateText("C:\\inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised\\Housing_News\\Preview_News.html");

            //Team Pages
            fp = File.CreateText("C:\\inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised\\Preview_ImmArticles.html");
            fp.WriteLine(SB.ToString());
            fp.Close();
        }
    }
}