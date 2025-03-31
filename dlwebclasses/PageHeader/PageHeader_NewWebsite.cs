using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class PageHeader_NewWebsite:APageHeader
    {
        
        public override StringBuilder getpageheader()
        {

            StringBuilder SB = new StringBuilder();
            SB.AppendLine("            <div class=\"row nopadding\">");
            SB.AppendLine("                <div class=\"col-lg-8 col-sm-12 col-xs-12 col-lg-offset-2 applyblock centerdiv header nopadding\">");

            SB.AppendLine("                    <div class=\"row nopadding\">");
            SB.AppendLine("                        <div class=\"col-md-4 col-sm-5 col-xs-5 nopadding\">");
            SB.AppendLine("                            <a href=\"/index.html\"><img src=\"/Images/DL_Logo.PNG\" alt=\"Duncan Lewis Solicitors\" class=\"img-responsive dllogo\" /></a>");
            SB.AppendLine("                        </div>");

            SB.AppendLine("						<div class=\"col-md-5 hidden-sm hidden-xs nopadding\">");
            SB.AppendLine("							<div id=\"myCarousel\" class=\"carousel slide\" data-ride=\"carousel\">");
            SB.AppendLine("								<div class=\"carousel-inner\">");
            SB.AppendLine("								  <div class=\"item active\">");
            SB.AppendLine("									<a href=\"https://www.lexisnexis.co.uk/insights/lexisnexis-legal-awards-2024-law-firm-of-the-year/index.html\"><img src=\"https://www.duncanlewis.co.uk/Images/HeaderBannerPic1.jpg\" alt=\"Duncan Lewis Solicitors Lexis Nexis\" style=\"border:solid 1px #bcbcbc\"></a>");
            SB.AppendLine("								  </div>");
            SB.AppendLine("								  <div class=\"item\">");
            SB.AppendLine("								  <a href=\"https://www.duncanlewis.co.uk/news/Duncan_Lewis_Solicitors_Celebrates_Three_Prestigious_Wins_at_the_Modern_Law_Awards_2024_(8_March_2024).html\">");
            SB.AppendLine("									<img src=\"https://www.duncanlewis.co.uk/Images/HeaderBannerPic2.jpg\" alt=\"Duncan Lewis Solicitors Modern Law\" style=\"border:solid 1px #bcbcbc\">");
            SB.AppendLine("									</a>");
            SB.AppendLine("								  </div>");
            SB.AppendLine("								  <div class=\"item\">");
            SB.AppendLine("								  <a href=\"https://www.duncanlewis.co.uk/The-Legal-500.html\">");
            SB.AppendLine("									<img src=\"https://www.duncanlewis.co.uk/Images/HeaderBannerPic3.jpg\" alt=\"Duncan Lewis Solicitors Legal 500\" style=\"border:solid 1px #bcbcbc\">");
            SB.AppendLine("									</a>");
            SB.AppendLine("								  </div>");
            SB.AppendLine("								  <div class=\"item\">");
            SB.AppendLine("								  <a href=\"https://www.duncanlewis.co.uk/The-Legal-500.html\">");
            SB.AppendLine("									<img src=\"https://www.duncanlewis.co.uk/Images/HeaderBannerPic4.jpg\" alt=\"Duncan Lewis Solicitors Legal 500\" style=\"border:solid 1px #bcbcbc\">");
            SB.AppendLine("									</a>");
            SB.AppendLine("								  </div>");
            SB.AppendLine("								</div>");
            SB.AppendLine("						  </div>");
            SB.AppendLine("                        </div>");

            SB.AppendLine("                        <div class=\"col-md-3 col-sm-3 col-xs-7 nopadding\">");
            SB.AppendLine("                            <div class=\"headerright\">");
            SB.AppendLine("<form method=\"get\" action=\"https://www.google.co.uk/search\">");
            SB.AppendLine("                                <p><font class=\"lightcyantext\">Have a question?</font><br /><a href=\"tel:033 3772 0409\"><span class=\"fa fa-phone\"></span>033 3772 0409</a></p>");
            SB.AppendLine("                                <input type=\"text\" name=\"q\" id=\"q\" class=\"form-control hidden-xs\" />");
            SB.AppendLine("                                <button name=\"searchgoogle\" id=\"searchgoogle\" class=\"btn btn-primary hidden-xs\" value=\"search\"><span class=\"fa fa-search\"></span></button>");
            SB.AppendLine("</form>");
            SB.AppendLine("                            </div>");
            SB.AppendLine("                        </div>");
            SB.AppendLine("                    </div>");
            SB.AppendLine("                </div>");
            SB.AppendLine("            </div>");
            return SB;
        }
}
}
