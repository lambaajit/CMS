using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class PageHeader_CostLaw:APageHeader
    {
        public override StringBuilder getpageheader()
        {

            StringBuilder SB = new StringBuilder();
            SB.AppendLine(" <div class=\"row nopadding\">");
            SB.AppendLine("                 <div class=\"col-sm-12 headercontents\">");
            SB.AppendLine("                     <div class=\"row nopadding\">");
            SB.AppendLine("                         <div class=\"col-sm-8 col-sm-offset-2 applyblock centerdiv\">");
            SB.AppendLine("                             <ul>");
            SB.AppendLine("                                 <li>");
            SB.AppendLine("                                     <i class=\"fa fa-mobile\" aria-hidden=\"true\"></i>");
            SB.AppendLine("                                     <a href=\"tel:020 633 6221\"><span class=\"hidden-xs\">Call us on:</span> 020 3633 6261</a>");
            SB.AppendLine("                                 </li>");
            SB.AppendLine("                                 <li>");
            SB.AppendLine("                                     <i class=\"fa fa-clock-o hidden-xs\" aria-hidden=\"true\"></i>");
            SB.AppendLine("                                     <span class=\"hidden-xs\"> Mon - Fri 9:30 - 17:30 </span>");
            SB.AppendLine("                                 </li>");
            SB.AppendLine("                                 <li>");
            SB.AppendLine("                                     <i class=\"fa fa-at hidden-xs\" aria-hidden=\"true\"> </i>");
            SB.AppendLine("                                     <span class=\"hidden-xs\"> Email us to : <a href=\"mailto:info@costlaw.com\">info@costlaw.com</a> </span>");
            SB.AppendLine("                                 </li>");
            SB.AppendLine("                                 <li class=\"SocialMedia\">");
            SB.AppendLine("                                     <span class=\"hidden-xs\">Find us on Social Media:</span>");
            SB.AppendLine("                                     <a href=\"https://www.facebook.com/CostLaw-Services-231194224244246/\" target=\"_blank\"> <i class=\"fa fa-facebook\" aria-hidden=\"true\">&nbsp;</i></a>");
            SB.AppendLine("                                     <a href=\"https://twitter.com/CostServices\" target=\"_blank\"><i class=\"fa fa-twitter\" aria-hidden=\"true\">&nbsp;</i> </a>");
            SB.AppendLine("                                     <a href=\"https://www.linkedin.com/company/cost-law-services/?viewAsMember=true\" target =\"_blank\"> <i class=\"fa fa-linkedin\">&nbsp;</i></a>");
            SB.AppendLine("                                 </li>");
            SB.AppendLine("                             </ul>");
            SB.AppendLine("                         </div>");
            SB.AppendLine("                     </div>");
            SB.AppendLine("                 </div>");
            SB.AppendLine("             </div>");


            SB.AppendLine("             <div class=\"row nopadding\">");
            SB.AppendLine("                 <div class=\"col-sm-12\">");
            SB.AppendLine("                     <div class=\"row nopadding\">");
            SB.AppendLine("                         <div class=\"col-sm-8 col-sm-offset-2 col-xs-12 applyblock centerdiv\">");
            SB.AppendLine("                             <nav class=\"navbar\">");
            SB.AppendLine("                                 <div class=\"container\">");
            SB.AppendLine("                                     <!-- Brand and toggle get grouped for better mobile display -->");
            SB.AppendLine("                                     <div class=\"navbar-header\">");
            SB.AppendLine("                                         <button type=\"button\" class=\"navbar-toggle collapsed\" data-toggle=\"collapse\" data-target=\"#navbar-collapse-1\">");
            SB.AppendLine("                                             <span class=\"sr-only\">Toggle navigation</span>");
            SB.AppendLine("                                             <span class=\"icon-bar\"></span>");
            SB.AppendLine("                                             <span class=\"icon-bar\"></span>");
            SB.AppendLine("                                             <span class=\"icon-bar\"></span>");
            SB.AppendLine("                                         </button>");
            SB.AppendLine("                                         <a class=\"navbar-brand logo\" href=\"/\">");
            SB.AppendLine("                                             <img src=\"/images/Costlaw-Logo_Final.png\" alt=\"Costlaw Services Ltd\" class=\"img-responsive\" />");
            SB.AppendLine("                                         </a>");
            SB.AppendLine("                                     </div>");

            SB.AppendLine("                                     <div class=\"collapse navbar-collapse\" id=\"navbar-collapse-1\">");
            SB.AppendLine("                                         <ul class=\"nav navbar-nav navbar-right\">");
            SB.AppendLine("                                             <li><a href=\"/Index.html\">Home</a></li>");
            SB.AppendLine("                                           <li class=\"dropdown\"><a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">Services</a>");
            SB.AppendLine("                                             <ul class=\"dropdown-menu dropdown-menu-left\">");
            SB.AppendLine("							                        <li><a href=\"/services.html\">Overview</a></li>");
            SB.AppendLine("                                                 <li><a href=\"/Bill-Preparation-Inter-partes.html\">Bill Preparation</a></li>");
            SB.AppendLine("                                                <li><a href=\"/Legal-Aid-Billing-Specialists.html\">Legal Aid Billing</a></li>");
            SB.AppendLine("                                                <li><a href=\"/Other-Costs-Services.html\">Other Costs Services</a></li>");
            SB.AppendLine("                                                </ul>");
            SB.AppendLine("                                             </li>");
            SB.AppendLine("                                             <li><a href=\"/our-people.html\">Our People</a></li>");
            SB.AppendLine("                                             <li><a href=\"/recruitment.html\">Recruitment</a></li>");
            SB.AppendLine("                                             <li><a href=\"/our-charges.html\">Our Charges</a></li>");
            SB.AppendLine("                                             <li><a href=\"/contact.html\">Contact</a></li>");
            SB.AppendLine("                                             <li><a href=\"/blog.html\">Blog & News</a></li>");
            SB.AppendLine("                                         </ul>");

            SB.AppendLine("                                     </div>");
            SB.AppendLine("                                 </div>");
            SB.AppendLine("                             </nav>");
            SB.AppendLine("                         </div>");
            SB.AppendLine("                     </div>");
            SB.AppendLine("                 </div>");
            SB.AppendLine("             </div>");
            return SB;
        }
    }
}
