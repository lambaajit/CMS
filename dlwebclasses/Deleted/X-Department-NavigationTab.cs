//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace dlwebclasses
//{



//    public partial class deptchildcare : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Child &amp; Children Custody<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Child-Or-Children-Custody.html\" style=\"text-decoration:none\">Child Or Children Custody</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Contact-Access-Arrangements.html\"  style=\"text-decoration:none\">Contact Access Arrangements</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Residence-Orders.html\"  style=\"text-decoration:none\">Residence Orders</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Specific-Issue-Choice-of-School.html\"  style=\"text-decoration:none\">Specific Issue Choice of School</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Parental-Responsibility.html\"  style=\"text-decoration:none\">Parental Responsibility</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Prohibited-Steps-Order.html\"  style=\"text-decoration:none\">Prohibited Steps Order</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Leave-to-Remove-Application.html\"  style=\"text-decoration:none\">Leave to Remove Application</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Children-and-Finances.html\"  style=\"text-decoration:none\">Children and Finances</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Extended-Family-Law.html\"  style=\"text-decoration:none\">Extended Family Law</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Child-Law-and-Separation.html\"  style=\"text-decoration:none\">Child Law and Separation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Child-Name-Change.html\"  style=\"text-decoration:none\">Child Name Change</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Changing-your-Childs-Religion.html\"  style=\"text-decoration:none\">Changing your Child’s Religion</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Children-Court-Orders.html\"  style=\"text-decoration:none\">Children Court Orders</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Child-Mediation.html\"  style=\"text-decoration:none\">Child Mediation</a></li> ");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Adoption</a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_international.html\" style=\"text-decoration:none\">International Adoption</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_placement.html\"  style=\"text-decoration:none\">Placement Orders</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_Guardianship.html\"  style=\"text-decoration:none\">Special Guardianship</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Social Services<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_SocialServices.html\" style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_Accommodationchildren.html\" style=\"text-decoration:none\">Accommodation for Children</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_ChildProtection.html\"  style=\"text-decoration:none\">Child Protection Conference</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_ChildInNeed.html\"  style=\"text-decoration:none\">Children in Need</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_kinship.html\"  style=\"text-decoration:none\">Kinship</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_Pre-proceedings.html\"  style=\"text-decoration:none\">Pre-proceedings Meetings</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_SocialServices.html\"  style=\"text-decoration:none\">Social Services Solicitors</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_LocalAuthority.html\"  style=\"text-decoration:none\">Your Local Authority Duties</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_CourtPowers.html\"  style=\"text-decoration:none\">Powers of Court Care Order</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_CareOrder.html\"  style=\"text-decoration:none\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Care Order</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_NoOrder.html\"  style=\"text-decoration:none\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;No Order</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_PoliceProtectionOrder.html\"  style=\"text-decoration:none\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Police Protection Orders</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_SupervisionOrder .html\"  style=\"text-decoration:none\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Supervision Orders</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/family_Divorce.html\">Divorce &amp; Family</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_ourteam.html\">Our Team</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare_News.html\">DL News</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/childcare_articles.html\">Articles</a></li>");
//            return departmentnav1;

//        }
//    }

//    public partial class deptcivillitigation : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/litigation.html\">Overview</a></li>");

//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Alternate-dispute-resolution.html\">Alternate dispute resolution</a></li>");



//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Banking & Finance<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Bank-charges-dispute.html\"  style=\"text-decoration:none\">Bank charges dispute</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Breach-of-mandate.html\"  style=\"text-decoration:none\">Breach of mandate</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Consumer-credit-disputes.html\"  style=\"text-decoration:none\">Consumer credit disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Fraud.html\"  style=\"text-decoration:none\">Fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Loan-disputes-BF.html\"  style=\"text-decoration:none\">Loan disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Misrepresentation.html\"  style=\"text-decoration:none\">Misrepresentation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Professional-negligence-BF.html\"  style=\"text-decoration:none\">Professional negligence</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Bankruptcy<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Bankruptcy-petition.html\"  style=\"text-decoration:none\">Bankruptcy Petition</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/debt-Bankruptcy.html\"  style=\"text-decoration:none\">Debt</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Insolvency-Proceedings-Bankruptcy.html\"  style=\"text-decoration:none\">Insolvency Proceedings</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/IVAs.html\"  style=\"text-decoration:none\">IVAs</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Statutory-Demands.html\"  style=\"text-decoration:none\">Statutory Demands</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Trustee-in-Bankruptcy.html\"  style=\"text-decoration:none\">Trustee in Bankruptcy</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Winding-up-petitions-Bankruptcy.html\"  style=\"text-decoration:none\">Winding up petitions</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Contentious-Probate.html\">Contentious Probate</a></li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Contract<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Agency-disputes.html\"  style=\"text-decoration:none\">Agency disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Breach-of-contract.html\"  style=\"text-decoration:none\">Breach of contract</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Capacity.html\"  style=\"text-decoration:none\">Capacity</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Collateral-Warranties.html\"  style=\"text-decoration:none\">Collateral Warranties</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Illegality.html\"  style=\"text-decoration:none\">Illegality</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Misrepresentation-contract.html\"  style=\"text-decoration:none\">Misrepresentation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Mistake-and-frustration.html\"  style=\"text-decoration:none\">Mistake and frustration</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Repudiatory-breaches-of-contract.html\"  style=\"text-decoration:none\">Repudiatory breaches of contract</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Timeshare-disputes .html\"  style=\"text-decoration:none\">Timeshare disputes </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Tradesman-Builders-disputes-contract.html\"  style=\"text-decoration:none\">Tradesman / Builders disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Undue-influence-and-duress.html\"  style=\"text-decoration:none\">Undue influence and duress</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Defamation.html\">Defamation</a></li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">International<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Cross-border-litigation.html\"  style=\"text-decoration:none\">Cross-border litigation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/International-enforcement.html\"  style=\"text-decoration:none\">International enforcement </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/International-litigation.html\"  style=\"text-decoration:none\">International litigation</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Company & Commercial<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Banking-Disputes.html\"  style=\"text-decoration:none\">Banking Disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Breach-of-directors-fiduciary-duties.html\"  style=\"text-decoration:none\">Breach of director^s fiduciary duties</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Contractual-disputes.html\"  style=\"text-decoration:none\">Contractual disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Corporate-breach-of-warranty-claims.html\"  style=\"text-decoration:none\">Corporate breach of warranty claims</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Debt-recovery.html\"  style=\"text-decoration:none\">Debt recovery</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Director-and-Shareholder-disputes.html\"  style=\"text-decoration:none\">Director and Shareholder disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Intellectual-property-disputes.html\"  style=\"text-decoration:none\">Intellectual property disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Loan-agreement-disputes.html\"  style=\"text-decoration:none\">Loan agreement disputes </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Misappropriating-company-funds-CC.html\"  style=\"text-decoration:none\">Misappropriating company funds </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Partnership-disputes-CC.html\"  style=\"text-decoration:none\">Partnership disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Professional-Negligence-CC.html\"  style=\"text-decoration:none\">Professional Negligence</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Sale-of-goods-supply-of-services-disputes.html\"  style=\"text-decoration:none\">Sale of goods/supply of services disputes</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Debt Recovery & Enforcement<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Asset-tracing.html\"  style=\"text-decoration:none\">Asset Tracing</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Attachment-on-earnings.html\"  style=\"text-decoration:none\">Attachment on earnings </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Bailiffs-and-High-Court-Enforcement-Officers.html\"  style=\"text-decoration:none\">Bailiffs and High Court Enforcement Officers </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Bankruptcy-petition.html\"  style=\"text-decoration:none\">Bankruptcy petition </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Bankruptcy-petitions.html\"  style=\"text-decoration:none\">Bankruptcy petitions</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Charging-orders.html\"  style=\"text-decoration:none\">Charging orders</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Enforcement-international-and-domestic-enforcement.html\"  style=\"text-decoration:none\">Enforcement (international and domestic enforcement) </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Freezing-injunctions.html\"  style=\"text-decoration:none\">Freezing injunctions </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/High-Court-Writs.html\"  style=\"text-decoration:none\">High Court Writs</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Insolvency-proceedings.html\"  style=\"text-decoration:none\">Insolvency proceedings</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Loan-disputes.html\"  style=\"text-decoration:none\">Loan disputes </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Partnership-disputes.html\"  style=\"text-decoration:none\">Partnership disputes </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Recovery-of-claims.html\"  style=\"text-decoration:none\">Recovery of claims  </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Statutory-demands.html\"  style=\"text-decoration:none\">Statutory demands</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Third-party-debt-orders.html\"  style=\"text-decoration:none\">Third party debt orders  </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Winding-up-petitions.html\"  style=\"text-decoration:none\">Winding up petitions </a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Fraud<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Civil-fraud.html\"  style=\"text-decoration:none\">Civil fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Criminal-fraud.html\"  style=\"text-decoration:none\">Criminal fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Misappropriating-company-funds-fraud.html\"  style=\"text-decoration:none\">Misappropriating company funds </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Misrepresentation-fraud.html\"  style=\"text-decoration:none\">Misrepresentation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Mortgage-fraud.html\"  style=\"text-decoration:none\">Mortgage fraud  </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Receipt-of-bribes-and-secret-profits.html\"  style=\"text-decoration:none\">Receipt of bribes and secret profits </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Serious-wrongdoing-misconduct.html\"  style=\"text-decoration:none\">Serious wrongdoing / misconduct </a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");



//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Property Litigation<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Boundary-disputes.html\"  style=\"text-decoration:none\">Boundary disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Easements-Right-of-way.html\"  style=\"text-decoration:none\">Easements / Right of way</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Landlord-and-Tenant-Private.html\"  style=\"text-decoration:none\">Landlord and Tenant (Private) </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Nuisance.html\"  style=\"text-decoration:none\">Nuisance </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Party-wall-disputes.html\"  style=\"text-decoration:none\">Party wall disputes </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Possession-proceedings-Landlord.html\"  style=\"text-decoration:none\">Possession proceedings (Landlord) </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Property-related-insolvency.html\"  style=\"text-decoration:none\">Property related insolvency </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Restrictive-covenants.html\"  style=\"text-decoration:none\">Restrictive covenants </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Tradesman-Builders-disputes.html\"  style=\"text-decoration:none\">Tradesman / Builders disputes </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Trespassing.html\"  style=\"text-decoration:none\">Trespassing </a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");



//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Professional Negligence<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Accountants-Litigation.html\"  style=\"text-decoration:none\">Accountants</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Architects-Litigation.html\"  style=\"text-decoration:none\">Architects</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Banks-Litigation.html\"  style=\"text-decoration:none\">Banks</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Barristers-Litigation.html\"  style=\"text-decoration:none\">Barristers </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Financial-Advisers-Litigation.html\"  style=\"text-decoration:none\">Financial Advisers</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Solicitors-Litigation.html\"  style=\"text-decoration:none\">Solicitors</a></li><li role=\"presentation\"><a href=\"/Surveyors-Litigation.html\"  style=\"text-decoration:none\">Surveyors</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/litigation_ourteam.html\">Team</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/litigation_news.html\">DL News</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/litigation_articles.html\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptLitigation : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/litigation.html\">Overview</a></li>");

//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Alternate-dispute-resolution.html\">Alternate dispute resolution</a></li>");



//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Banking & Finance<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Bank-charges-dispute.html\"  style=\"text-decoration:none\">Bank charges dispute</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Breach-of-mandate.html\"  style=\"text-decoration:none\">Breach of mandate</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Consumer-credit-disputes.html\"  style=\"text-decoration:none\">Consumer credit disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Fraud.html\"  style=\"text-decoration:none\">Fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Loan-disputes-BF.html\"  style=\"text-decoration:none\">Loan disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Misrepresentation.html\"  style=\"text-decoration:none\">Misrepresentation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Professional-negligence-BF.html\"  style=\"text-decoration:none\">Professional negligence</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Bankruptcy<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Bankruptcy-petition.html\"  style=\"text-decoration:none\">Bankruptcy Petition</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/debt-Bankruptcy.html\"  style=\"text-decoration:none\">Debt</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Insolvency-Proceedings-Bankruptcy.html\"  style=\"text-decoration:none\">Insolvency Proceedings</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/IVAs.html\"  style=\"text-decoration:none\">IVAs</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Statutory-Demands.html\"  style=\"text-decoration:none\">Statutory Demands</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Trustee-in-Bankruptcy.html\"  style=\"text-decoration:none\">Trustee in Bankruptcy</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Winding-up-petitions-Bankruptcy.html\"  style=\"text-decoration:none\">Winding up petitions</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Contentious-Probate.html\">Contentious Probate</a></li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Contract<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Agency-disputes.html\"  style=\"text-decoration:none\">Agency disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Breach-of-contract.html\"  style=\"text-decoration:none\">Breach of contract</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Capacity.html\"  style=\"text-decoration:none\">Capacity</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Collateral-Warranties.html\"  style=\"text-decoration:none\">Collateral Warranties</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Illegality.html\"  style=\"text-decoration:none\">Illegality</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Misrepresentation-contract.html\"  style=\"text-decoration:none\">Misrepresentation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Mistake-and-frustration.html\"  style=\"text-decoration:none\">Mistake and frustration</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Repudiatory-breaches-of-contract.html\"  style=\"text-decoration:none\">Repudiatory breaches of contract</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Timeshare-disputes .html\"  style=\"text-decoration:none\">Timeshare disputes </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Tradesman-Builders-disputes-contract.html\"  style=\"text-decoration:none\">Tradesman / Builders disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Undue-influence-and-duress.html\"  style=\"text-decoration:none\">Undue influence and duress</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Defamation.html\">Defamation</a></li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">International<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Cross-border-litigation.html\"  style=\"text-decoration:none\">Cross-border litigation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/International-enforcement.html\"  style=\"text-decoration:none\">International enforcement </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/International-litigation.html\"  style=\"text-decoration:none\">International litigation</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Company & Commercial<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Banking-Disputes.html\"  style=\"text-decoration:none\">Banking Disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Breach-of-directors-fiduciary-duties.html\"  style=\"text-decoration:none\">Breach of director^s fiduciary duties</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Contractual-disputes.html\"  style=\"text-decoration:none\">Contractual disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Corporate-breach-of-warranty-claims.html\"  style=\"text-decoration:none\">Corporate breach of warranty claims</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Debt-recovery.html\"  style=\"text-decoration:none\">Debt recovery</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Director-and-Shareholder-disputes.html\"  style=\"text-decoration:none\">Director and Shareholder disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Intellectual-property-disputes.html\"  style=\"text-decoration:none\">Intellectual property disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Loan-agreement-disputes.html\"  style=\"text-decoration:none\">Loan agreement disputes </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Misappropriating-company-funds-CC.html\"  style=\"text-decoration:none\">Misappropriating company funds </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Partnership-disputes-CC.html\"  style=\"text-decoration:none\">Partnership disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Professional-Negligence-CC.html\"  style=\"text-decoration:none\">Professional Negligence</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Sale-of-goods-supply-of-services-disputes.html\"  style=\"text-decoration:none\">Sale of goods/supply of services disputes</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Debt Recovery & Enforcement<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Asset-tracing.html\"  style=\"text-decoration:none\">Asset Tracing</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Attachment-on-earnings.html\"  style=\"text-decoration:none\">Attachment on earnings </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Bailiffs-and-High-Court-Enforcement-Officers.html\"  style=\"text-decoration:none\">Bailiffs and High Court Enforcement Officers </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Bankruptcy-petition.html\"  style=\"text-decoration:none\">Bankruptcy petition </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Bankruptcy-petitions.html\"  style=\"text-decoration:none\">Bankruptcy petitions</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Charging-orders.html\"  style=\"text-decoration:none\">Charging orders</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Enforcement-international-and-domestic-enforcement.html\"  style=\"text-decoration:none\">Enforcement (international and domestic enforcement) </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Freezing-injunctions.html\"  style=\"text-decoration:none\">Freezing injunctions </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/High-Court-Writs.html\"  style=\"text-decoration:none\">High Court Writs</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Insolvency-proceedings.html\"  style=\"text-decoration:none\">Insolvency proceedings</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Loan-disputes.html\"  style=\"text-decoration:none\">Loan disputes </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Partnership-disputes.html\"  style=\"text-decoration:none\">Partnership disputes </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Recovery-of-claims.html\"  style=\"text-decoration:none\">Recovery of claims  </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Statutory-demands.html\"  style=\"text-decoration:none\">Statutory demands</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Third-party-debt-orders.html\"  style=\"text-decoration:none\">Third party debt orders  </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Winding-up-petitions.html\"  style=\"text-decoration:none\">Winding up petitions </a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Fraud<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Civil-fraud.html\"  style=\"text-decoration:none\">Civil fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Criminal-fraud.html\"  style=\"text-decoration:none\">Criminal fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Misappropriating-company-funds-fraud.html\"  style=\"text-decoration:none\">Misappropriating company funds </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Misrepresentation-fraud.html\"  style=\"text-decoration:none\">Misrepresentation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Mortgage-fraud.html\"  style=\"text-decoration:none\">Mortgage fraud  </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Receipt-of-bribes-and-secret-profits.html\"  style=\"text-decoration:none\">Receipt of bribes and secret profits </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Serious-wrongdoing-misconduct.html\"  style=\"text-decoration:none\">Serious wrongdoing / misconduct </a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");



//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Property Litigation<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Boundary-disputes.html\"  style=\"text-decoration:none\">Boundary disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Easements-Right-of-way.html\"  style=\"text-decoration:none\">Easements / Right of way</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Landlord-and-Tenant-Private.html\"  style=\"text-decoration:none\">Landlord and Tenant (Private) </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Nuisance.html\"  style=\"text-decoration:none\">Nuisance </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Party-wall-disputes.html\"  style=\"text-decoration:none\">Party wall disputes </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Possession-proceedings-Landlord.html\"  style=\"text-decoration:none\">Possession proceedings (Landlord) </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Property-related-insolvency.html\"  style=\"text-decoration:none\">Property related insolvency </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Restrictive-covenants.html\"  style=\"text-decoration:none\">Restrictive covenants </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Tradesman-Builders-disputes.html\"  style=\"text-decoration:none\">Tradesman / Builders disputes </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Trespassing.html\"  style=\"text-decoration:none\">Trespassing </a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");



//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Professional Negligence<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Accountants-Litigation.html\"  style=\"text-decoration:none\">Accountants</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Architects-Litigation.html\"  style=\"text-decoration:none\">Architects</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Banks-Litigation.html\"  style=\"text-decoration:none\">Banks</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Barristers-Litigation.html\"  style=\"text-decoration:none\">Barristers </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Financial-Advisers-Litigation.html\"  style=\"text-decoration:none\">Financial Advisers</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Solicitors-Litigation.html\"  style=\"text-decoration:none\">Solicitors</a></li><li role=\"presentation\"><a href=\"/Surveyors-Litigation.html\"  style=\"text-decoration:none\">Surveyors</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/litigation_ourteam.html\">Team</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/litigation_news.html\">DL News</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/litigation_articles.html\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptCommunityCare : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptConveyancing : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptCrime : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {

//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\" >Criminal Defence<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/criminal-defence.html\"  style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Crown-court-representation.html\"  style=\"text-decoration:none\">Crown court representation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Legal-Aid-for-Criminal-defence.html\"  style=\"text-decoration:none\">Legal Aid for Criminal defence</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Magistrates-Court-representation.html\"  style=\"text-decoration:none\">Magistrates’ Court representation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Mental-health-and-crime.html\"  style=\"text-decoration:none\">Mental health and crime</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Police-station-interview-and-24-7-representation.html\"  style=\"text-decoration:none\">Police station interview and 24/7 representation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Pre-charge-investigations-and-representation.html\"  style=\"text-decoration:none\">Pre-charge investigations and representation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Private-paying-clients–fixed-fee-for-some-matters-and-competitively-hourly-rates-serious-cases-and-Insurance-funding.html\"  style=\"text-decoration:none\">Private paying clients – fixed fee </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Youth-crime.html\"  style=\"text-decoration:none\">Youth crime</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Fraud<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/crime_fraud.html\"  style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Advance-fee-fraud.html\"  style=\"text-decoration:none\">Advance fee fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Benefit-fraud-investigation-DSS-and-DWP.html\"  style=\"text-decoration:none\">Benefit fraud – investigation DSS and DWP</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Boiler-Room-fraud.html\"  style=\"text-decoration:none\">Boiler Room fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Computer-hacking-fraud-IT-crime.html\"  style=\"text-decoration:none\">Computer hacking fraud/IT crime</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Conspiracy-to-defraud.html\"  style=\"text-decoration:none\">Conspiracy to defraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Corruption-and-bribery.html\"  style=\"text-decoration:none\">Corruption and bribery</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Counterfeit-goods.html\"  style=\"text-decoration:none\">Counterfeit goods</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Crash-for-cash.html\"  style=\"text-decoration:none\">Crash for cash</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Credit-fraud-credit-card-and-debit-card-fraud.html\"  style=\"text-decoration:none\">Credit card and Debit card fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Defence-of-City-of-London-fraud-investigation-work.html\"  style=\"text-decoration:none\">Defence of City of London fraud investigation work</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Fraudulently-claiming-public-funding.html\"  style=\"text-decoration:none\">Fraudulently claiming public funding</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/HM-Revenue-and-Customs-fraud.html\"  style=\"text-decoration:none\">HM Revenue and Customs fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Immigration-fraud-related-offences.html\"  style=\"text-decoration:none\">Immigration fraud related offences</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Individual-fraud.html\"  style=\"text-decoration:none\">Individual fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Insurance-fraud.html\"  style=\"text-decoration:none\">Insurance fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Investment-fraud-Ponzi-Pyramid-fraud.html\"  style=\"text-decoration:none\">Investment fraud - Ponzi/Pyramid fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Mortgage-fraud.html\"  style=\"text-decoration:none\">Mortgage fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Passport-and-ID-fraud.html\"  style=\"text-decoration:none\">Passport and ID fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Public-sector-fraud-fraud-against-local-authority.html\"  style=\"text-decoration:none\">Public sector fraud – fraud against local authority</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Recovery-room-fraud.html\"  style=\"text-decoration:none\">Recovery room fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Serious-fraud.html\"  style=\"text-decoration:none\">Serious fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Tax-investigations.html\"  style=\"text-decoration:none\">Tax investigations</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Timeshare-fraud.html\"  style=\"text-decoration:none\">Timeshare fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/White-collar-crime.html\"  style=\"text-decoration:none\">White collar crime</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Business Fraud<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Carousel-fraud-or-MTIC-Missing-Trader-intra-Community-fraud.html\"  style=\"text-decoration:none\">Carousel fraud or MTIC</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Company-fraud.html\"  style=\"text-decoration:none\">Company fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Diversion-fraud-inc-wine-beer-spirits-cigarettes.html\"  style=\"text-decoration:none\">Diversion fraud – inc wine, beer, spirits, cigarettes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/False-Accounting.html\"  style=\"text-decoration:none\">False Accounting</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Financial-fraud.html\"  style=\"text-decoration:none\">Financial fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Insider-Trading.html\"  style=\"text-decoration:none\">Insider Trading</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/SFO-investigations-and-prosecutions.html\"  style=\"text-decoration:none\">SFO investigations and prosecutions</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Share-dealing-fraud.html\"  style=\"text-decoration:none\">Share dealing fraud</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/VAT-Fraud.html\"  style=\"text-decoration:none\">VAT Fraud</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Other Offences<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Anti-social-behaviour-orders.html\"  style=\"text-decoration:none\">Anti-social behaviour orders</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Burglary.html\"  style=\"text-decoration:none\">Burglary</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Child-neglect-and-cruelty.html\"  style=\"text-decoration:none\">Child neglect and cruelty</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Closure-Orders.html\"  style=\"text-decoration:none\">Closure Orders</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Conspiracy.html\"  style=\"text-decoration:none\">Conspiracy</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Cyber-and-Internet-crime.html\"  style=\"text-decoration:none\">Cyber and Internet crime</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Dangerous-dogs.html\"  style=\"text-decoration:none\">Dangerous dogs</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Drug-importation.html\"  style=\"text-decoration:none\">Drug importation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Drugs-supply-Drug-Possession-Class-A-and-B.html\"  style=\"text-decoration:none\">Drugs supply – Drug Possession Class A&B</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Football-related-offences.html\"  style=\"text-decoration:none\">Football related offences</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Handling-stolen-property.html\"  style=\"text-decoration:none\">Handling stolen property</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Human-trafficking.html\"  style=\"text-decoration:none\">Human trafficking</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Money-laundering.html\"  style=\"text-decoration:none\">Money laundering</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Perjury.html\"  style=\"text-decoration:none\">Perjury</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Public-Order-Offences.html\"  style=\"text-decoration:none\">Public Order Offences</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Squatting.html\"  style=\"text-decoration:none\">Squatting</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Theft-and-robbery.html\"  style=\"text-decoration:none\">Theft and robbery</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Confiscation<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Cash-and-asset-forfeiture-and-cash-seizure.html\"  style=\"text-decoration:none\">Cash and asset forfeiture and cash seizure</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Confiscation-Order-proceedings-and-negotiations.html\"  style=\"text-decoration:none\">Confiscation Order proceedings and negotiations</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Dawn-raids-and-seizure.html\"  style=\"text-decoration:none\">Dawn raids and seizure</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Restraint-Orders.html\"  style=\"text-decoration:none\">Restraint Orders</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Search-warrants.html\"  style=\"text-decoration:none\">Search warrants</a></li>  \t  ");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\" href=\"/crime_motoring_law.html\">Motoring Law<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Appealing-parking-fines.html\"  style=\"text-decoration:none\">Appealing parking fines</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Appeals-against-a-road-traffic-conviction.html\"  style=\"text-decoration:none\">Appeals against a road traffic conviction</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Applying-for-early-reinstatement-of-your-licence.html\"  style=\"text-decoration:none\">Applying for early reinstatement of your licence</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Caught-speeding.html\"  style=\"text-decoration:none\">Caught speeding</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Causing-death-by-careles-or-inconsiderate-driving.html\"  style=\"text-decoration:none\">Causing death by careless or inconsiderate driving</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Causing-death-by-dangerous-driving.html\"  style=\"text-decoration:none\">Causing death by dangerous driving</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Dangerous-driving.html\"  style=\"text-decoration:none\">Dangerous driving</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Drink-driving-solicitors.html\"  style=\"text-decoration:none\">Drink driving solicitors</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Driving-while-disqualified.html\"  style=\"text-decoration:none\">Driving while disqualified</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Driving-while-using-your-mobile.html\"  style=\"text-decoration:none\">Driving while using your mobile</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Driving-with-wor-tyres.html\"  style=\"text-decoration:none\">Driving with worn tyres</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Driving-without-insurance.html\"  style=\"text-decoration:none\">Driving without insurance</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Driving-without-MOT.html\"  style=\"text-decoration:none\">Driving without MOT</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Failure-to-report-an-accident.html\"  style=\"text-decoration:none\">Failure to report an accident</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Failure-to-stop-after-an-accident.html\"  style=\"text-decoration:none\">Failure to stop after an accident</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/HGV-offences.html\"  style=\"text-decoration:none\">HGV offences</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Impaired-driving.html\"  style=\"text-decoration:none\">Impaired driving</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Indictabl-road-traffic-offences.html\"  style=\"text-decoration:none\">Indictable road traffic offences</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Motor-cycling-offences.html\"  style=\"text-decoration:none\">Motor cycling offences</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Motoring-offence-solicitors-and-driving-offence-solicitors.html\"  style=\"text-decoration:none\">Motoring offence solicitors and driving offence solicitors</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Totting-up-and-disqualification-consequences-of-losing-your-licence-12 points-on-job-dropping-kids-to-school.html\"  style=\"text-decoration:none\">Totting up and disqualification</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");



//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Sexual Offences<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Assault-by-penetration.html\"  style=\"text-decoration:none\">Assault by penetration</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Indecent-assault.html\"  style=\"text-decoration:none\">Indecent assault</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Rape.html\"  style=\"text-decoration:none\">Rape</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Sexual-offences-against-children-indecent-images.html\"  style=\"text-decoration:none\">Sexual offences against children indecent images</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Sexual-touching.html\"  style=\"text-decoration:none\">Sexual touching</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Terrorism<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Breach-of-Control-Orders.html\"  style=\"text-decoration:none\">Breach of Control Orders</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Encouraging-Inciting-terrorism.html\"  style=\"text-decoration:none\">Encouraging Inciting terrorism</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Possession-of-articles-for-terrorist-purposes.html\"  style=\"text-decoration:none\">Possession of articles for terrorist purposes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Preparation-of-terrorist-acts.html\"  style=\"text-decoration:none\">Preparation of terrorist acts</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Supporting-a-proscribed-organisation.html\"  style=\"text-decoration:none\">Supporting a proscribed organisation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Terrorist-fund-raising.html\"  style=\"text-decoration:none\">Terrorist fund raising</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Training-for-terrorism.html\"  style=\"text-decoration:none\">Training for terrorism</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Violent Crime<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Gun-and-knife-crime-and-offensive-weapons.html\"  style=\"text-decoration:none\">Gun and knife crime & offensive weapons</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Murder-manslaughter.html\"  style=\"text-decoration:none\">Murder manslaughter</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Offences-against-the-person–ABH-Assault-GBH.html\"  style=\"text-decoration:none\">Offences against the person – ABH, Assault, GBH</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Extradition Solicitors<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Appeals-against-extraditions.html\"  style=\"text-decoration:none\">Appeals against extraditions</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Extradition-hearing-categories-1-and-2.html\"  style=\"text-decoration:none\">Extradition hearing categories 1 and 2</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Initial-extradition-hearing.html\"  style=\"text-decoration:none\">Initial extradition hearing</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Criminal Appeals<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Appeals-to-the-Court-of-Appeal.html\"  style=\"text-decoration:none\">Appeals to the Court of Appeal</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Conviction-appeal.html\"  style=\"text-decoration:none\">Conviction appeal</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Criminal-Cases-Review-Commission.html\"  style=\"text-decoration:none\">Criminal Cases Review Commission</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Sentence-appeal.html\"  style=\"text-decoration:none\">Sentence appeal</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");



//            departmentnav1.AppendLine("        <li role=\"presentation\" ><a href=\"/Judicial-Review-And-Crime.html\">Judicial Review</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/prisonlaw.html\">Prison Law</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/crime_news.html\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/crime_articles.html\">Articles</a></li>");
//            return departmentnav1;

//        }
//    }

//    public partial class deptDebt : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {

//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptEmployment : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {

//            departmentnav1.AppendLine("   \t    <li role=\"presentation\"><a href=\"employment.html\">Overview</a></li>");
//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Services<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Breach-of-Contract .html\"  style=\"text-decoration:none\">Breach of Contract </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Disciplinary-and-Grievance-procedure.html\"  style=\"text-decoration:none\">Disciplinary and Grievance procedure</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Discrimination-and-equal-opportunities.html\"  style=\"text-decoration:none\">Discrimination and equal opportunities</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/employment.html\"  style=\"text-decoration:none\">Employment Claims</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Equal-pay.html\"  style=\"text-decoration:none\">Equal pay</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Flexible-working.html\"  style=\"text-decoration:none\">Flexible working </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Health-and-Safety.html\"  style=\"text-decoration:none\">Health and Safety</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Maternity-and-Paternity-rights .html\"  style=\"text-decoration:none\">Maternity and Paternity rights </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Minimum-wage-and-Working-Time-Regulations.html\"  style=\"text-decoration:none\">Minimum wage and Working Time Regulations</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Redundancy.html\"  style=\"text-decoration:none\">Redundancy</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Restrictive-covenants.html\"  style=\"text-decoration:none\">Restrictive covenants</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/employment_services.html\"  style=\"text-decoration:none\">Services</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Settlement-Agreements.html\"  style=\"text-decoration:none\">Settlement Agreements</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Unfair-dismissal.html\"  style=\"text-decoration:none\">Unfair dismissal </a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("         <li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Employees<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Bullying-and-harassment-in-the-workplace.html\"  style=\"text-decoration:none\">Bullying and harassment in the workplace</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Financial-crime-investigation.html\"  style=\"text-decoration:none\">Financial crime investigation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Holiday-pay-issues.html\"  style=\"text-decoration:none\">Holiday pay issues </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Part-time-workers .html\"  style=\"text-decoration:none\">Part-time workers </font></a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Pay-issues-at-work.html\"  style=\"text-decoration:none\">Pay issues at work</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Privacy-and-data-protection.html\"  style=\"text-decoration:none\">Privacy and data protection </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Reviewing-employment-contracts.html\"  style=\"text-decoration:none\">Reviewing employment contracts</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Stress-at-work.html\"  style=\"text-decoration:none\">Stress at work</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/TUPE.html\"  style=\"text-decoration:none\">TUPE</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Whistle-blowing-claims.html\"  style=\"text-decoration:none\">Whistle blowing claims</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("         <li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Employers<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Changing-Terms-and-Conditions-of-Employment.html\"  style=\"text-decoration:none\">Changing Terms and Conditions of Employment</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Creating-and-updating-employment-contracts-and-policies .html\"  style=\"text-decoration:none\">Creating and updating employment contracts and policies </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Day-to-day-HR-advice.html\"  style=\"text-decoration:none\">Day-to-day HR advice</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Dealing-with-employee-absence .html\"  style=\"text-decoration:none\">Dealing with employee absence</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Dealing-with-flexible-working-requests .html\"  style=\"text-decoration:none\">Dealing with flexible working requests </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Defending-employment-tribunal-claims .html\"  style=\"text-decoration:none\">Defending employment tribunal claims </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Drafting-and-enforcing-restrictive-covenants.html\"  style=\"text-decoration:none\">Drafting and enforcing restrictive covenants</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Managing-disciplinary-and-grievance-procedures.html\"  style=\"text-decoration:none\">Managing disciplinary and grievance procedures</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Maternity-paternity-and-family-friendly-policies.html\"  style=\"text-decoration:none\">Maternity/paternity and family friendly policies</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Redundancy-Employers.html\"  style=\"text-decoration:none\">Redundancy</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/TUPE-Employers.html\"  style=\"text-decoration:none\">TUPE</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/employment_ourteam.html\">Our Team</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/employment_news.html\">DL News</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/employment_articles.html\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptFamily : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Divorce<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/family_divorce.html\"  style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Fixed-Fee-Divorce.html\"  style=\"text-decoration:none\">Fixed Fee Divorce</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/High-net-worth-individuals.html\"  style=\"text-decoration:none\">High net worth individuals</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/International-divorce.html\"  style=\"text-decoration:none\">International divorce</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Dowry-disputes.html\"  style=\"text-decoration:none\">Dowry disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Informal-separation.html\"  style=\"text-decoration:none\">Informal separation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Formal-separation.html\"  style=\"text-decoration:none\">Formal separation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Judicial-separation.html\"  style=\"text-decoration:none\">Judicial separation</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\" >Domestic Violence<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/domestic-abuse-domestic-violence-solicitors\"  style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/What-is-Domestic-Violence.html\"  style=\"text-decoration:none\">What is Domestic Violence?</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Help-with-domestic-violence.html\"  style=\"text-decoration:none\">Help with domestic violence</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Help-with-domestic-violence.html#Injunction\"  style=\"text-decoration:none\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Injunction</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Help-with-domestic-violence.html#Nonmolestationorder\"  style=\"text-decoration:none\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Non-molestation Orders</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Help-with-domestic-violence.html#OccupationalOrder\"  style=\"text-decoration:none\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Occupational Orders</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Domestic-Violence-on-Children.html\"  style=\"text-decoration:none\">Domestic Violence on Children</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Forced-Marriage-Solicitors.html\"  style=\"text-decoration:none\">Forced Marriage Solicitors</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/The-Protection-against-Harassment-Act-1997.html\"  style=\"text-decoration:none\">Protection against Harassment Act 1997</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Domestic-Violence-in-Same-Sex-Couples.html\"  style=\"text-decoration:none\">Domestic Violence in Same Sex Couples</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Legal-Aid-for-Domestic-Violence.html\"  style=\"text-decoration:none\">Legal Aid for Domestic Violence</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Finances &amp; Property<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/family_children_Finance.html\"  style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Finances-and-Property-in-Divorce.html\"  style=\"text-decoration:none\">Finances and Property in Divorce</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Finances-after-Divorce.html\"  style=\"text-decoration:none\">Finances after Divorce</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Pensions-in-Divorce-and-Separation.html\"  style=\"text-decoration:none\">Pensions in Divorce and Separation</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Civil Partnership/Dissolution<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Civil-Partnership-Dissolution.html\"  style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Civil-Partnership-Act-2004.html\"  style=\"text-decoration:none\">Civil Partnership Act 2004</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Civil-Partnership-Registration-Process.html\"  style=\"text-decoration:none\">Civil Partnership Registration Process</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Legal-Rights-when-Registered.html\"  style=\"text-decoration:none\">Legal Rights when Registered</a></li>  \t  ");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/How-to-obtain-Dissolution-of-my-civil-partnership.html\"  style=\"text-decoration:none\">Dissolution of my civil partnership?</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">International<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/International.html\"  style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/International-Divorce-and-Jurisdictional-Issues.html\"  style=\"text-decoration:none\">International Divorce & Jurisdictional</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/International-Financial-Disputes.html\"  style=\"text-decoration:none\">International Financial Disputes</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/International-Child-Abduction-Lawyers.html\"  style=\"text-decoration:none\">International Child Abduction Lawyers</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/International-Wardship.html\"  style=\"text-decoration:none\">International Wardship</a></li>  \t");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Abandoned-Spouses.html\"  style=\"text-decoration:none\">Abandoned Spouses</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/International-Surrogacy.html\"  style=\"text-decoration:none\">International Surrogacy</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/International-Adoption.html\"  style=\"text-decoration:none\">International Adoption</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/childcare.html\">Children</a>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Prenuptial &amp; Post Nuptial Agreements<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Prenuptial-And-Post-Nuptial-Agreements.html\"  style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Prenuptial-Agreements.html\"  style=\"text-decoration:none\">Prenuptial Agreements</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Post-Nuptial-Agreements.html\"  style=\"text-decoration:none\">Post Nuptial Agreements</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Cohabitation-Agreements.html\"  style=\"text-decoration:none\">Cohabitation Agreements</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Separation-Agreements.html\"  style=\"text-decoration:none\">Separation Agreements</a></li>  \t  ");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Family Mediation<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/family_mediation.html\"  style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/What-is-Family-Mediation.html\"  style=\"text-decoration:none\">What is Family Mediation?</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/How-does-Family-Mediation-Work.html\"  style=\"text-decoration:none\">How does Family Mediation Work?</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/How-long-does-Family-Mediation-take.html\"  style=\"text-decoration:none\">How long does Family Mediation take?</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Who-is-Family-Mediation-For.html\"  style=\"text-decoration:none\">Who is Family Mediation For?</a></li>  \t  ");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Cost-of-Family-Mediation.html\"  style=\"text-decoration:none\">Cost of Family Mediation</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Lawyers-Supported-Mediation.html\"  style=\"text-decoration:none\">Lawyers Supported Mediation</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Islamic_Law.html\">Islamic Legal Services</a>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/family_ourteam.html\">Team</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/family_news.html\">DL News</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/family_articles.html\">Articles</a></li>");
//            return departmentnav1;

//        }
//    }

//    public partial class deptHousing : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {

//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/property-Disputes.html\">Property Disputes</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptMentalHealth : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {

//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/mentalcapacity.html\">Mental Capacity</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;

//        }
//    }

//    public partial class deptMentalCapacity : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/mentalcapacity.html\">Mental Capacity</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptPublicLaw : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;

//        }
//    }


//    public partial class deptWelfareBenefits : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }


//    public partial class deptImmigration : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {

//            departmentnav1.AppendLine(" <li role=\"presentation\"><a href=\"/immigration.html\">Overview</a></li>");
//            departmentnav1.AppendLine(" <li role=\"presentation\"><a href=\"/Immigrtion-individuals-settling-working-studying-in-UK/\">Individuals - Settling, Work, Study in the UK</a></li>");
//            departmentnav1.AppendLine(" <li role=\"presentation\"><a href=\"/asylum-and-human-rights-immigration/\">Asylum / Human Rights</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" ><a href=\"/immigration_advocacy.html\">Appeals / Upper Tribunal</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/immigration_detention.html\">Detention/Fast track</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/UKBA-delay-Home-office-delay-immigration/\">UKBA Delay</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/immigration-medical-treatment.html\">Medical Treatment</a></li>");
//            departmentnav1.AppendLine(" <li role=\"presentation\"><a href=\"uk-visas-uk-immigration.html\">Business Immigration</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/immigration_News.html\">DL News</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/immigration_articles.html\">Articles</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/immigration_ourteam.html\">Team</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptNews : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
//            string strMonthName = mfi.GetMonthName(DateTime.Now.Month).ToString();
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\"><font color=\"#74d1f6\">News</font></a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">In the Press</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + News1 + "\">Reported Cases</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\" ><a href=\"/Legal_News_" + strMonthName + "-" + DateTime.Now.Year.ToString() + ".html\">Legal News</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptInThePress : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
//            string strMonthName = mfi.GetMonthName(DateTime.Now.Month).ToString();
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">News</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\"><font color=\"#74d1f6\">In the Press</font></a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + News1 + "\">Reported Cases</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\" ><a href=\"/Legal_News_" + strMonthName + "-" + DateTime.Now.Year.ToString() + ".html\">Legal News</a></li>");
//            return departmentnav1;
//        }
//    }
//    public partial class deptLegalNews : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
//            string strMonthName = mfi.GetMonthName(DateTime.Now.Month).ToString();
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">News</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">In the Press</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + News1 + "\">Reported Cases</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\" ><a href=\"/Legal_News_" + strMonthName + "-" + DateTime.Now.Year.ToString() + ".html\"><font color=\"#74d1f6\">Legal News</font></a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptReportedCase : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
//            string strMonthName = mfi.GetMonthName(DateTime.Now.Month).ToString();
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">News</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">In the Press</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + News1 + "\"><font color=\"#74d1f6\">Reported Cases</font></a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\" ><a href=\"/Legal_News_" + strMonthName + "-" + DateTime.Now.Year.ToString() + ".html\">Legal News</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptClinicalNegligence : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;

//        }
//    }


//    public partial class deptProfessionalNegligence : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {

//            departmentnav1.AppendLine("   \t    <li role=\"presentation\"><a href=\"/Professionalnegligence.html\">Overview</a></li>");
//            departmentnav1.AppendLine("         <li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Solicitors Negligence<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("      <ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence-Commercial-Transaction-Negligence.html\"  style=\"text-decoration:none\">Commercial Transaction Negligence</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence-Conveyancing-and-property.html\"  style=\"text-decoration:none\">Conveyancing and property</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-NegligenceEmployment-case-claims.html\"  style=\"text-decoration:none\">Employment case claims</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence-Failure-of-Solicitor-to-advise-on-Legal-Aid-Statutory-Charge.html\"  style=\"text-decoration:none\">Failure of Solicitor to advise on Legal Aid Statutory Charge</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence-Failure-to-properly-draft-and-serve-documents.html\"  style=\"text-decoration:none\">Failure to properly draft and serve documents</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence-Immigration-Case-Negligence .html\"  style=\"text-decoration:none\">Immigration Case Negligence</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence-Litigation-case-claims.html\"  style=\"text-decoration:none\">Litigation case claims</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence-Missed-Deadline-by-Solicitor.html\"  style=\"text-decoration:none\">Missed Deadline by the Solicitor</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence-Missed-time-limit-by-solicitor.html\"  style=\"text-decoration:none\">Missed time limit by solicitor</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence-Pensions-Settlement-in-Divorce-Negligence.html\"  style=\"text-decoration:none\">Pensions Settlement in Divorce Negligence</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence-Personal-injury.html\"  style=\"text-decoration:none\">Personal injury</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence-Wills-and-Probate-Case-Negligence.html\"  style=\"text-decoration:none\">Wills and Probate Case Negligence</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence-Wrong-advice-by-Solicitor.html\"  style=\"text-decoration:none\">Wrong advice by a Solicitor</a></li>");
//            departmentnav1.AppendLine("      </ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("         <li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Other Negligence Services<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("  \t  <ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Professional-Negligence-Accountant-Negligence.html\"  style=\"text-decoration:none\">Accountant’s Negligence</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Professional-Negligence-Architects-Negligence.html\"  style=\"text-decoration:none\">Architect’s Negligence</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Professional-Negligence-Barristers-Negligence.html\"  style=\"text-decoration:none\">Barristers Negligence</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Professional-Negligence-Builders-Negligence.html\"  style=\"text-decoration:none\">Builder’s Negligence</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Professional-Negligence-Claims-against-Insurance-Brokers.html\"  style=\"text-decoration:none\">Claims against Insurance Brokers</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Professional-Negligence-Mortgage-Broker-Negligence.html\"  style=\"text-decoration:none\">Financial Advisor and Mortgage Broker Negligence</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Professional-Negligence-Interest-Rate-SWAP-Agreement-Claims.html\"  style=\"text-decoration:none\">Interest Rate SWAP Agreement Claims</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Professional-Negligence-Negligent-Claims-against-Engineers.html\"  style=\"text-decoration:none\">Negligent Claims against Engineers</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Professional-Negligence-Negligent-Investment-Advice.html\"  style=\"text-decoration:none\">Negligent Investment Advice</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Professional-Negligence-Negligent-Pensions-Advice.html\"  style=\"text-decoration:none\">Negligent Pensions Advice</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Professional-Negligence-Negligent-Tax-Advice.html\"  style=\"text-decoration:none\">Negligent Tax Advice</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/professionalnegligence.html\"  style=\"text-decoration:none\">Professional Negligence</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Professional-Negligence-Surveyors-Negligence.html\"  style=\"text-decoration:none\">Surveyor’s Negligence</a></li>");
//            departmentnav1.AppendLine("      <li role=\"presentation\"><a href=\"/Solicitors-Negligence.html\"  style=\"text-decoration:none\">Solicitors Negligence</a></li>");
//            departmentnav1.AppendLine("      </ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("         <li role=\"presentation\"><a href=\"/litigation_ourteam/Anthony_Okumah.html\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/Professionalnegligence_news.html\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/Professionalnegligence_articles.html\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptIslamicLaw : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Islamic_Law.html\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"http://www.duncanlewis.co.uk/Aina-Khan-Family-Solicitor-Dalston-London/\">Our Team</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Islamic_news.html\">DL News</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/Islamic_articles.html\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptPersonalInjury : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }






//    public partial class deptAboutUs : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/about.html\">About Us</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/about_expertise.html\">Expertise</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Our_Team.html\">Our Team</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/about_managementboard.html\">Management Team</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/about_quality.html\">Quality</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/about_languages.html\">Languages</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/about_corporatesocial.html\">Corporate Social Responsibility</a></li>");
//            return departmentnav1;
//        }
//    }


//    public partial class deptPrisonLaw : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("   \t    <li role=\"presentation\"><a href=\"/prisonlaw.html\">Overview</a></li>");
//            departmentnav1.AppendLine("   \t    <li role=\"presentation\"><a href=\"/prisonlaw_services.html\">Services</a></li>");
//            departmentnav1.AppendLine("         <li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Legal Aid<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Adjudications-before-the-Governor-under-the-Tarrant-rules.html\"  style=\"text-decoration:none\">Adjudications under the Tarrant rules</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Appeals-against-conviction.html\"  style=\"text-decoration:none\">Appeals against conviction</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Appeals-against-sentence.html\"  style=\"text-decoration:none\">Appeals against sentence</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Challenges-to-sentence-dates.html\"  style=\"text-decoration:none\">Challenges to sentence dates</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Independent-adjudications.html\"  style=\"text-decoration:none\">Independent adjudications</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Judicial Review and Human rights challenges.html\"  style=\"text-decoration:none\">Judicial Review and Human rights challenges </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Parole-review-for-IPP-and-lifers.html\"  style=\"text-decoration:none\">Parole review for IPP and lifers</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Parole-reviews-for-recall .html\"  style=\"text-decoration:none\">Parole reviews for recall</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("         <li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Private<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Advice of your OASys report.html\"  style=\"text-decoration:none\">Advice of your OASys report</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Appeals-of-licence-conditions.html\"  style=\"text-decoration:none\">Appeals of licence conditions</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Guittard-applications.html\"  style=\"text-decoration:none\">Guittard applications</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/HDC-applications-and-appeals.html\"  style=\"text-decoration:none\">HDC applications and appeals</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/PDs-DSPDs-TCs-and-PIPES.html\"  style=\"text-decoration:none\">PDs, DSPDs, TCs and PIPES</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Pre-tariff-reviews.html\"  style=\"text-decoration:none\">Pre-tariff reviews</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Prison-transfers.html\"  style=\"text-decoration:none\">Prison transfers</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Recategorisation-and-appeals-against-knock-backs.html\"  style=\"text-decoration:none\">Recategorisation and appeals against knock backs</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/ROTL-applications-and-appeals.html\"  style=\"text-decoration:none\">ROTL applications and appeals</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Sentence-planning-matters.html\"  style=\"text-decoration:none\">Sentence planning matters</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Visits-and-appeals-against-closed-visits.html\"  style=\"text-decoration:none\">Visits and appeals against closed visits</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Appeals-to-the-Court-of-Appeal.html\">Criminal Appeals</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/prisonlaw_ourteam.html\">Our Team</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/crime_news.html\">DL News</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/crime_articles.html\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptProfessionalRegulation : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {

//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;

//        }
//    }

//    public partial class deptHumanRights : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }


//    public partial class deptCareers : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/careers.html\">Careers</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/Jobs_Caseworker.html\">Paralegal Jobs</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/trainees.html\">Trainees</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/Jobs_Solicitors.html\">Solicitor Jobs</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/JobsConsultancy.html\">Consultant Solicitors Jobs</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/Jobs_Admin.html\">Admin Jobs</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"http://www.dalstonsolicitors.co.uk/internship.aspx\">Internship</a></li>");
//            return departmentnav1;
//        }
//    }


//    public partial class deptConsultancy : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/careers.html\">Careers</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/Jobs_Caseworker.html\">Paralegal Jobs</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/trainees.html\">Trainees</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/Jobs_Solicitors.html\">Solicitor Jobs</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/JobsConsultancy.html\">Consultant Solicitors Jobs</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/Jobs_Admin.html\">Admin Jobs</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"http://www.dalstonsolicitors.co.uk/internship.aspx\">Internship</a></li>");
//            return departmentnav1;
//        }
//    }


//    public partial class deptBusinessImmigration : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-uk-immigration.html\">Overview</a></li>");
//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Individual Immigration<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-immigration-services.html\"  style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-tier-4-students.html\"  style=\"text-decoration:none\">Tier 4 Students</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-spouse-unmarried-partner-visa.html\"  style=\"text-decoration:none\">Spouse/Unmarried Partner Visas</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-child-adult-dependents.html\"  style=\"text-decoration:none\">Child and Adult Dependents</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-EEA-family-permit-residence-card-permanent-residence.html\"  style=\"text-decoration:none\">Family Members of EEA Nationals</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-indefinite-leave-to-remain.html\"  style=\"text-decoration:none\">Indefinite Leave to Remain</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-british-citizenship-naturalisation.html\"  style=\"text-decoration:none\">British Citizenship & Nationality</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-visiting-the-uk.html\"  style=\"text-decoration:none\">Visitor Visa</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-uk-general-immigration.html\"  style=\"text-decoration:none\">General Immigration</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-same-day-premium-service.html\"  style=\"text-decoration:none\">Same Day (Premium) Service</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-uk-appeals.html\"  style=\"text-decoration:none\">Immigration Appeals</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Business Immigration<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-uk-business-immigration.html\"  style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-tier-2-sponsorship-licence.html\"  style=\"text-decoration:none\">Tier 2 Sponsorship Licence</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-tier-4-sponsorship-licence.html\"  style=\"text-decoration:none\">Tier 4 Sponsorship Licence</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-tier-5-sponsorship-licence.html\"  style=\"text-decoration:none\">Tier 5 Sponsorship Licence</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-compliance-audit.html\"  style=\"text-decoration:none\">Compliance/Audit & HR Support</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-tier-2-tier-5-skilled-workers.html\"  style=\"text-decoration:none\">Sponsoring Migrants under Tier 2 and Tier 5 of the Points Based System </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-preventing-illegal-workers.html\"  style=\"text-decoration:none\">Preventing Employment of Illegal Workers</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-landlords-tenants-immigration-checks.html\"  style=\"text-decoration:none\">Landlords – Tenant Immigration Checks</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-sole-representative.html\"  style=\"text-decoration:none\">Sole Representative Visas</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-business-visitor.html\"  style=\"text-decoration:none\">Business Visitors</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-uk-appeals-business-immigration.html\"  style=\"text-decoration:none\">Appeals</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");
//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">High Net Worth Individuals<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-high-net-worth-individuals.html\"  style=\"text-decoration:none\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-uk-appeals-HNWI.html\"  style=\"text-decoration:none\">Immigration Appeals - HNWI</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-tier-1-investor.html\"  style=\"text-decoration:none\">Investor</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-tier-1-entrepreneur.html\"  style=\"text-decoration:none\">Entrepreneurs</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/uk-visas-tier-1-visas.html\"  style=\"text-decoration:none\">Other Tier 1 Categories</a></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Company Director<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"ceo-senior-official.html\"  style=\"text-decoration:none\">Ceo/Senior official</font></a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Elected-officers-and-representatives.html\"  style=\"text-decoration:none\">Elected Officers and Representatives</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Functional-managers-and-directors.html\"  style=\"text-decoration:none\">Functional Managers and Directors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Human-resource-managers-and-directors.html\"  style=\"text-decoration:none\">Human Resource Managers and Directors</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Engineers<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"Aircraft-Pilots-and-Flight-Engineers.html\"  style=\"text-decoration:none\">Aircraft Pilots and Flight Engineers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Civil-Engineers.html\"  style=\"text-decoration:none\">Civil Engineers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Design-and-Development-Engineers.html\"  style=\"text-decoration:none\">Design and Development Engineers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Electrical-Engineers.html\"  style=\"text-decoration:none\">Electrical Engineers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Electronic--engineers.html\"  style=\"text-decoration:none\">Electronic Engineers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Engineering-professional-not-classified-elsewhere.html\"  style=\"text-decoration:none\">Engineering Professional Not Classified Elsewhere</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Mechanical-Engineers.html\"  style=\"text-decoration:none\">Mechanical Engineers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Production-and-Process-Engineers.html\"  style=\"text-decoration:none\">Production and Process Engineers</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Information Technology<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"information-technology-and-telecommunications.html\"  style=\"text-decoration:none\">Information Technology and Telecommunications</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Information-technology-and-telecommunications-directors.html\"  style=\"text-decoration:none\">Information Technology and Telecommunications Directors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"it-business-analysts-architects-and-systems-designers.html\"  style=\"text-decoration:none\">IT Business Analysts, Architects and Systems Designers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"IT-project-and-programme-managers.html\"  style=\"text-decoration:none\">IT Project and Programme Managers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"IT-specialist-managers.html\"  style=\"text-decoration:none\">IT Specialist Managers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"programmers-and-software-development-professionals.html\"  style=\"text-decoration:none\">Programmers and Software Development Professionals</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"web-design-and-development-professionals.html\"  style=\"text-decoration:none\">Web Design and Development Professionals</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Conservation & Environment<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"conservation-professionals.html\"  style=\"text-decoration:none\"><font color=\"#74d1f6\">Conservation Professionals</font></a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"environment-professionals.html\"  style=\"text-decoration:none\">Environment Professionals</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Medical Staff<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"dental-practitioner.html\"  style=\"text-decoration:none\">Dental Practitioner</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Health-Professional.html\"  style=\"text-decoration:none\">Health Professional</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"medical-radiographers.html\"  style=\"text-decoration:none\">Medical Radiographers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"medical practitioner.html\"  style=\"text-decoration:none\">Medical-Practitioner</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"midwives.html\"  style=\"text-decoration:none\">Midwives</a></h6></li><li><h6><a href=\"nurses.html\"  style=\"text-decoration:none\">Nurses</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Occupational-therapists.html\"  style=\"text-decoration:none\">Occupational Therapists</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"ophthalmic-opticians.html\"  style=\"text-decoration:none\">Ophthalmic Opticians</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"paramedics.html\"  style=\"text-decoration:none\">Paramedics</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"pharmacists.html\"  style=\"text-decoration:none\">Pharmacists</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"physiotherapists.html\"  style=\"text-decoration:none\">Physiotherapists</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"podiatrists.html\"  style=\"text-decoration:none\">Podiatrists</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"psychologists.html\"  style=\"text-decoration:none\">Psychologists</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Speech-and-Language-Therapists.html\"  style=\"text-decoration:none\">Speech and Language Therapists</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Therapy-Professionals.html\"  style=\"text-decoration:none\">Therapy Professionals</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"veterinarians.html\"  style=\"text-decoration:none\">Veterinarians</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Teaching<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"education-advisers-and-school-inspectors.html\"  style=\"text-decoration:none\">Education Advisers and School Inspectors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Further-Education-Teaching-Professionals.html\"  style=\"text-decoration:none\">Further Education Teaching Professionals</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Primary-and-nursery-education-teaching-professionals.html\"  style=\"text-decoration:none\">Primary and Nursery Education Teaching Professionals</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Secondary-Education-Teaching-Professionals.html\"  style=\"text-decoration:none\">Secondary Education Teaching Professionals</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Senior-professionals-of-educational-establishments.html\"  style=\"text-decoration:none\">Senior Professionals of Educational Establishments</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"special-needs-education-teaching-professionals.html\"  style=\"text-decoration:none\">Special Needs Education Teaching Professionals</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"teaching-and-other-educational-professional.html\"  style=\"text-decoration:none\">Teaching and Other Educational Professionals</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Legal<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"barristers-and-judges.html\"  style=\"text-decoration:none\">Barristers and Judges</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Legal-Professionals-not-elsewhere-classified.html\"  style=\"text-decoration:none\">Legal Professionals Not Elsewhere Classified</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"solicitors-business-immigration.html\"  style=\"text-decoration:none\">Solicitors</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Finance<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"actuaries-economists-and-statisticians.html\"  style=\"text-decoration:none\">Actuaries, Economists and Statisticians</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"brokers.html\"  style=\"text-decoration:none\">Brokers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"business-and-financial-project-management-professionals.html\"  style=\"text-decoration:none\">Business and Financial Project Management Professionals</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"Chartered-and-certified-accountants.html\"  style=\"text-decoration:none\">Chartered and Certified Accountants</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"finance-and-investment-analysts-and-advisers.html\"  style=\"text-decoration:none\">Finance and Investment Analysts and Advisers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"financial-accounts-manager.html\"  style=\"text-decoration:none\">Financial Accounts Managers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"financial-institution-managers-and-directors.html\"  style=\"text-decoration:none\">Financial Institution Managers and Directors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"financial-managers-and-directors.html\"  style=\"text-decoration:none\">Financial Managers and Directors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"management-consultants-and-business-analysts.html\"  style=\"text-decoration:none\">Management Consultants and Business Analysts</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"taxation-experts.html\"  style=\"text-decoration:none\">Taxation Experts</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Marketing<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"advertising-accounts-managers-and-creative-directors.html\"  style=\"text-decoration:none\">advertising accounts managers and creative directors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"advertising-and-public-relations-directors.html\"  style=\"text-decoration:none\">advertising and public relations directors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"business-and-related-research-professionals.html\"  style=\"text-decoration:none\">Business and Related Research Professionals</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"business-research-and-related-professionals.html\"  style=\"text-decoration:none\">Business, Research and Related Professionals</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"marketing-and-sales-directors.html\"  style=\"text-decoration:none\">Marketing and Sales Directors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"purchasing-managers-and-directors.html\"  style=\"text-decoration:none\">Purchasing Managers and Directors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"sales-accountants-and-business-development-managers.html\"  style=\"text-decoration:none\">Sales, Accounts and Business Development Managers</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Property<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"architects.html\"  style=\"text-decoration:none\">Architects</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"chartered-surveyors.html\"  style=\"text-decoration:none\">Chartered Surveyors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"quantity-surveyors.html\"  style=\"text-decoration:none\">Quantity Surveyors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"town-planning-officers.html\"  style=\"text-decoration:none\">Town Planning Officers</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Production/Project Managers<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"construction-project-managers-and-related-professionals.html\"  style=\"text-decoration:none\">Construction Project Managers and Related Professionals</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"production-managers-and-directors-in-construction.html\"  style=\"text-decoration:none\">Production Managers and Directors in Construction</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"production-managers-and-directors-in-manufacturing.html\"  style=\"text-decoration:none\">Production Managers and Directors in Manufacturing</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"production-managers-and-directors-in-mining-and-energy.html\"  style=\"text-decoration:none\">Production Managers and Directors in Mining and Energy</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Public Services<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"archivists.html\"  style=\"text-decoration:none\">Archivists</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"environmental-health-professionals.html\"  style=\"text-decoration:none\">Environmental Health Professionals</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"health-services-and-public-health-managers-and-directors.html\"  style=\"text-decoration:none\">Health Services and Public Health Managers and Directors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"librarians.html\"  style=\"text-decoration:none\">Librarians</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"managers-and-directors-in-transport-and-distribution.html\"  style=\"text-decoration:none\">Managers and Directors in Transport and Distribution</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"probation-officers.html\"  style=\"text-decoration:none\">Probation Officers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"quality-assurance-and-regulatory-professionals.html\"  style=\"text-decoration:none\">Quality Assurance and Regulatory Professionals</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"quality-control-and-planning-engineers.html\"  style=\"text-decoration:none\">Quality Control and Planning Engineers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"senior-officers-in-fire-ambulance-prison-and-related-services.html\"  style=\"text-decoration:none\">Senior Officers in Fire, Ambulance, Prison and Related Services</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"senior-police-officers.html\"  style=\"text-decoration:none\">Senior Police Officers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"social-services-managers-and-directors.html\"  style=\"text-decoration:none\">Social Services Managers and Directors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"social-workers.html\"  style=\"text-decoration:none\">Social Workers</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"welfare-professionals.html\"  style=\"text-decoration:none\">Welfare Professionals</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");


//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Media and Arts<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"arts-officers-producers-and-directors.html\"  style=\"text-decoration:none\">Arts Officers, Producers and Directors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"journalists-newspaper-and-periodical-editors.html\"  style=\"text-decoration:none\">Journalists, Newspaper and Periodical Editors</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"musicians.html\"  style=\"text-decoration:none\">Musicians</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"public-relations-professionals.html\"  style=\"text-decoration:none\">Public Relations Professionals</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/businessimmigration_ourteam.html\">Team</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/businessimmigration_News.html\">News</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/businessimmigration_articles.html\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }


//    public partial class deptFeesFunding : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/fees.html\">Fees & Funding</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/fees_publicfunding.html\">Legal Aid / Public Funding </a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/fees_complaintprocedure.html\">Complaint Procedures</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/fees_franchises.html\">Franchises</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/fees_eligibility.html\">Eligibility</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/fees_Right-to-Cancel.html\">Right to Cancel</a></li>");
//            return departmentnav1;
//        }
//    }


//    public partial class deptMisleneous : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/index.html\">Home</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptActionAgainstPolice : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/Actions-Aganist-The-Police.html\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/Actions-Aganist-The-Police_ourteam.html\" >Our Team</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptFindUs : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/findus.html\">Our Offices</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/branchLocator_DL_WithMap.aspx\">Branch Locator</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptManagementBoard : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\">Overview</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">Services</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Our_Team1 + "\">Our Team</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + News1 + "\">DL News</a></li>");
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\" class=\"lastmenuitem\"><a href=\"/" + News1.Replace("news", "articles") + "\">Articles</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptWillsandProbate : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"willsandprobate.html\"  style=\"text-decoration:none\">Overview</a></h6></li>");
//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Wills<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"applications-to-the-court-of-protection.html\"  style=\"text-decoration:none\">Applications to the Court of Protection</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"compensation-protection-services-trusts.html\"  style=\"text-decoration:none\">Compensation protection services (trusts)</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"dealing-with-an-estate.html\"  style=\"text-decoration:none\">Dealing with an Estate</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"duncan-lewis-probate-solicitors–estate-administration-probate-intestacy.html\"  style=\"text-decoration:none\">Duncan Lewis Probate Solicitors – Estate Administration (probate/ intestacy)</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"duncan-lewis-wills-and-probate-solicitors- writing-or-updating-a-Will.html\"  style=\"text-decoration:none\">Duncan Lewis Wills and Probate Solicitors – Writing or Updating a Will</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"duncan-lewis-wills-and-probate-solicitors–contesting-a-will.html\"  style=\"text-decoration:none\">Duncan Lewis Wills and Probate Solicitors–Contesting a Will</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"elderly-and-vulnerable-care-for-people-concerned-about-care-home-fees-and-protecting-their-inheritance.html\"  style=\"text-decoration:none\">Elderly and vulnerable care (for people concerned about care home fees and protecting their inheritance)</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"family-break-up-wills.html\"  style=\"text-decoration:none\">Family Break up Wills</a></h6></li><li role=\"presentation\"><a href=\"international-wills.html\"  style=\"text-decoration:none\">International Wills</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"lasting-powers-of-attorney.html\"  style=\"text-decoration:none\">Lasting Powers of Attorney</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"living-wills-advice-and-representation-on-all-mental-capacity-matters.html\"  style=\"text-decoration:none\">Living wills,advice and representation on all mental capacity matters</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"making-a-will-and-children.html\"  style=\"text-decoration:none\">Making a Will & Children</a></h6></li><li role=\"presentation\"><a href=\"making-a-will–trust-and-trustees.html\"  style=\"text-decoration:none\">Making a Will–Trust and Trustees</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"mirror-wills.html\"  style=\"text-decoration:none\">Mirror Wills</a></h6></li><li role=\"presentation\"><a href=\"statutory-wills-and-trust.html\"  style=\"text-decoration:none\">Statutory Wills and Trust</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"trusts.html\"  style=\"text-decoration:none\">Trusts</a></h6></li><li role=\"presentation\"><a href=\"Wills-tenants-in-common.html\"  style=\"text-decoration:none\">Wills & Tenants in Common</a></h6></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"wills–donating-to-charity.html\"  style=\"text-decoration:none\">Wills – Donating to Charity</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Probate<span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"executor-duties-explained.html\"  style=\"text-decoration:none\">Executor Duties Explained</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"fixed-fee-probate-quotation.html\"  style=\"text-decoration:none\">Fixed Fee Probate Quotation</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"how-do-i-know-if-and-when-probate-is-required.html\"  style=\"text-decoration:none\">How do I know if and when probate is required?</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"international-estate-administration.html\"  style=\"text-decoration:none\">International estate administration</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"obtaining-a-copy-of-the-will.html\"  style=\"text-decoration:none\">Obtaining a Copy of the Will</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"probate-and-inheritance-tax.html\"  style=\"text-decoration:none\">Probate & Inheritance Tax</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"probate–what-is-probate-and-when-is-probate-required.html\"  style=\"text-decoration:none\">Probate – what is probate and when is probate required?</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"probate-services.html\"  style=\"text-decoration:none\">Probate Services</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"probate-without-a-will.html\"  style=\"text-decoration:none\">Probate without a Will</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"rules-of-intestacy.html\"  style=\"text-decoration:none\">Rules of Intestacy</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"uk-and-international-probate.html\"  style=\"text-decoration:none\">UK and International Probate</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">Inheritance Tax Planning <span style=\"margin-top:0px;\" class=\"caret\"></span></a>");
//            departmentnav1.AppendLine("<ul class=\"dropdown-menu\">");
//            departmentnav1.AppendLine("<li><h6><a href=\"arranging-affidavits-of-foreign-law.html\"  style=\"text-decoration:none\">Arranging Affidavits of Foreign Law</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"inheritance-taxation-and-planning.html\"  style=\"text-decoration:none\">Inheritance Taxation and Planning</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"preparation-of-public-deeds.html\"  style=\"text-decoration:none\">Preparation of public deeds</a></h6></li>");
//            departmentnav1.AppendLine("<li><h6><a href=\"transfer-of-securities-and-bank-account-funds.html\"  style=\"text-decoration:none\">Transfer of securities and bank account funds</a></h6></li>");
//            departmentnav1.AppendLine("</ul>");
//            departmentnav1.AppendLine("</li>");

//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"http://www.duncanlewis.co.uk/Diane-Liston-Civil-Litigation-Solicitor-Harrow-/\">Our Team</a></li>");
//            return departmentnav1;
//        }
//    }

//    public partial class deptEU : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            departmentnav1.AppendLine("<li role=\"presentation\"><a href=\"/European-Union-Solicitors.html\">Overview</a></li>");
//            departmentnav1.AppendLine("<li role=\"presentation\" class=\"lastmenuitem\"><a href=***EU_Staff_Member***>Our Team</a></li>");
//            return departmentnav1;
//        }
//    }


//    public partial class deptCampaign : DepartmentDetails
//    {
//        public override StringBuilder getDepartmentnavigation()
//        {
//            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
//            string strMonthName = mfi.GetMonthName(DateTime.Now.Month).ToString();
//            departmentnav1.AppendLine("  \t    <li role=\"presentation\"><a href=\"/" + Overview1 + "\"><font color=\"#74d1f6\">News</font></a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + Services1 + "\">In the Press</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\"><a href=\"/" + News1 + "\">Reported Cases</a></li>");
//            departmentnav1.AppendLine("        <li role=\"presentation\" ><a href=\"/Legal_News_" + strMonthName + "-" + DateTime.Now.Year.ToString() + ".html\">Legal News</a></li>");
//            return departmentnav1;
//        }
//    }

//}
