using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Footer_CostLaw:AFooter
    {
        public override StringBuilder getfooter(AContents _contents, Website_Pages webpage)
        {
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<div class=\"row nopadding blueback footertopbar\">");
            SB.AppendLine("                <div class=\"col-sm-12\">");
            SB.AppendLine("                    <div class=\"row nopadding\">");
            SB.AppendLine("                        <div class=\"col-sm-8 col-sm-offset-2 applyblock centerdiv\">");
            SB.AppendLine("                            <p>");
            SB.AppendLine("                                <span class=\"footer-line\"> For more information on our cost drafting and billing services call us on 020 3633 6261 or email <a href=\"mailto:info@costlaw.com\" style=\"color:#fff !important\">info@costlaw.com</a></span>");
            SB.AppendLine("                            </p>");
            SB.AppendLine("                        </div>");
            SB.AppendLine("                    </div>");
            SB.AppendLine("                </div>");
            SB.AppendLine("            </div>");
            SB.AppendLine("            <div class=\"row nopadding blackback\">");
            SB.AppendLine("                <div class=\"col-sm-12\">");
            SB.AppendLine("                    <div class=\"row nopadding\">");
            SB.AppendLine("                        <div class=\"col-sm-8 col-sm-offset-2 applyblock centerdiv\">");
            SB.AppendLine("                            <footer class=\"section footer-classic context-dark bg-image\">");
            SB.AppendLine("                                <div class=\"container\">");
            SB.AppendLine("                                    <div class=\"row row-30\">");
            SB.AppendLine("                                        <div class=\"col-md-4 col-xl-5\">");
            SB.AppendLine("                                            <h5>Useful Links</h5>");
            SB.AppendLine("                                            <ul class=\"nav-list\">");
            SB.AppendLine("                                                <li><a href=\"/\">Home</a></li>");
            SB.AppendLine("                                                <li><a href=\"/services.html\">Our Services</a></li>");
            SB.AppendLine("                                                <li><a href=\"/our-people.html\">Our People</a></li>");
            SB.AppendLine("                                                <li><a href=\"/recruitment.html\">Recruitment</a></li>");
            SB.AppendLine("                                                <li><a href=\"/contact.html\">Contact</a></li>");
            SB.AppendLine("                                                <li><a href=\"/blog.html\">Blog & News</a></li>");
            SB.AppendLine("                                            </ul>");

            SB.AppendLine("                                        </div>");
            SB.AppendLine("                                        <div class=\"col-md-5\">");
            SB.AppendLine("                                            <h5>Contacts</h5>");
            SB.AppendLine("                                            <dl class=\"contact-list\">");
            SB.AppendLine("                                                <dt>Address:</dt>");
            SB.AppendLine("                                                <dd>");
            SB.AppendLine("                                                    95 Mortimer Street,");
            SB.AppendLine("                                                    Ground Floor,");
            SB.AppendLine("                                                    London,");
            SB.AppendLine("                                                    W1W 7GB.");
            SB.AppendLine("                                                </dd>");
            SB.AppendLine("                                            </dl>");
            SB.AppendLine("                                            <dl class=\"contact-list\">");
            SB.AppendLine("                                                <dt>Email:</dt>");
            SB.AppendLine("                                                <dd><a href=\"mailto:#\">info@costlaw.com</a></dd>");
            SB.AppendLine("                                            </dl>");
            SB.AppendLine("                                            <dl class=\"contact-list\">");
            SB.AppendLine("                                                <dt>Phone:</dt>");
            SB.AppendLine("                                                <dd>");
            SB.AppendLine("                                                    <a href=\"tel:020 3633 6261\">020 3633 6261</a> <span>");
            SB.AppendLine("                                                        </a>");
            SB.AppendLine("                                                    </span>");
            SB.AppendLine("                                                </dd>");
            SB.AppendLine("                                            </dl>");
            SB.AppendLine("                         </div>");
            SB.AppendLine("                                        <div class=\"col-md-2 col-xl-3\">");
            SB.AppendLine("                                            <h5>Social Media:</h5>");
            SB.AppendLine("                                            <ul class=\"nav-list\">");
            SB.AppendLine("                                                <li>");
            SB.AppendLine("                                     <a href=\"https://www.facebook.com/CostLaw-Services-231194224244246/\" target=\"_blank\"><i class=\"fa fa-facebook\" aria-hidden=\"true\">&nbsp;</i></a>");
            SB.AppendLine("                                     <a href=\"https://twitter.com/CostServices\" target=\"_blank\"><i class=\"fa fa-twitter\" aria-hidden=\"true\">&nbsp;</i></a>");
            SB.AppendLine("                                                    <a href=\"https://www.linkedin.com/company/cost-law-services/?viewAsMember=true\" target =\"_blank\"><i class=\"fa fa-linkedin\">&nbsp;</i></a>");
            SB.AppendLine("                                                </li>");
            SB.AppendLine("                                            </ul><br />");
            SB.AppendLine("                                            <ul class=\"nav-list\">");
            SB.AppendLine("                           <li><a href=\"/Privacy-Notice.html\">Privacy Notice</a></li>");
            SB.AppendLine("                           <li><a href=\"/Cookie-Policy.html\">Cookies Policy</a></li>");
            SB.AppendLine("                                            </ul>");
            SB.AppendLine("                                        </div>");
            SB.AppendLine("                                    </div>");
            SB.AppendLine("                                </div>");

            SB.AppendLine("                            </footer>");
            SB.AppendLine("                        </div>");
            SB.AppendLine("                    </div>");
            SB.AppendLine("                </div>");
            SB.AppendLine("            </div>");
            SB.AppendLine("    <script src=\"/Scripts/site.min.js?v=01052019\"></script>");
            return SB;
        }
        }
}
