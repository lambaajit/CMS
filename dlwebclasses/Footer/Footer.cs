using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Footer:AFooter
    {

        public override StringBuilder getfooter(AContents _contents, Website_Pages webpage)
        {
            StringBuilder SB = new StringBuilder();
            if (_contents.GetType() != typeof(Content_NewsArticles_NewWebsite))
            { 
                SB.AppendLine("<div w3-include-html=\"/Footer.html\"></div>");
                return SB;
            }
            else
            {
                Offices _off;
                if (_contents.GetType() == typeof(Content_WebsitePages))
                {
                    DepartmentDetails DD = new DepartmentDetails(_contents.Department);
                    if (DD.departmenttype == "AreaOfLaw")
                    {
                        if (DD.Name == "Crime" || DD.Name == "Personal Injury" || DD.Name == "Clinical Negligence" || DD.Name == "Professional Negligence")
                            _off = new Offices(_contents.HeadingH1);
                        else
                            _off = new Offices(DD.Name);
                    }
                    else
                        _off = new Offices();
                }
                else
                {
                    _off = new Offices();
                }

               
                SB.AppendLine("<div class=\"container-fluid\">");
                SB.AppendLine("\t<div class=\"row\"> ");
                SB.AppendLine("            <div id=\"reportedtop\" class=\"col-lg-12  col-md-12  visible-lg visible-md\">");
                SB.AppendLine("                <div class=\"col-lg-3 col-md-3\">");
                SB.AppendLine("                        <div id=\"subheading\">");
                SB.AppendLine("                          <h6>About Us</h6>");
                SB.AppendLine("                        </div>");
                SB.AppendLine("                        <div id=\"HomeMenu\">");
                SB.AppendLine("                           <ul class=\"lsmenu1\">");
                SB.AppendLine("                              <li><a href=\"/onlineenquiry.html\">Contact Us</a></li>");
                SB.AppendLine("                              <li><a href=\"/branchLocator_DL_WithMap.aspx\">Find Nearest Branch</a></li>");
                SB.AppendLine("                              <li><a href=\"/Our_Team_Alphabetic_A.html\">Our Staff</a></li> ");
                SB.AppendLine("                              <li><a href=\"/about_languages.html\">We Speak</a></li>");
                SB.AppendLine("                              <li><a href=\"/about_managementboard.html\">Management Team</a></li>");
                SB.AppendLine("                              <li><a href=\"/brochures.html\">Brochures</a></li>");
                SB.AppendLine("                          </ul>");
                SB.AppendLine("                        </div>");
                SB.AppendLine("                        <div id=\"subheading\">");
                SB.AppendLine("                             <h6>Our Social Network</h6>");
                SB.AppendLine("                        </div>");
                SB.AppendLine("                        <div id=\"HomeMenu\">");
                SB.AppendLine("                            <ul class=\"lsmenu1\">");
                SB.AppendLine("<li><a href=\"https://www.facebook.com/duncanlewislawfirm\" title=\"Duncan Lewis\" class=\"socialIcons\"   rel=\"nofollow\"><img src=\"/images/Facebook.gif\" style=\"border: 0px;\" alt=\"Immigration Solicitors\" width=\"25\" height=\"24\" /></a><a href=\"http://twitter.com/DuncanLewis/\" target=\"_blank\" title=\"Duncan Lewis\" class=\"socialIcons\"   rel=\"nofollow\"><img src=\"/images/Twitter.gif\"  style=\"border: 0px;\" alt=\"Duncan Lewis Solicitors on Twitter\" width=\"23\" height=\"24\" /></a><a href=\"http://www.linkedin.com/companies/duncan-lewis-%26-co-solicitors-greater-london?trk=fc_badge\" class=\"socialIcons\"   rel=\"nofollow\" ><img src=\"/images/LinkedIn.gif\"  style=\"border: 0px;\" alt=\"Duncan Lewis Solicitors on Twitter\" width=\"25\" height=\"24\" /></a><a href=\"http://www.youtube.com/duncanlewislawyers\" class=\"socialIcons\"   rel=\"nofollow\" ><img src=\"/images/Youtube.gif\"  style=\"border: 0px;\" alt=\"Duncan Lewis Solicitors on Youtube\" width=\"25\" height=\"24\" /></a></li>");
                SB.AppendLine("                        </ul>");
                SB.AppendLine("                        </div>");
                SB.AppendLine("                </div>");
                SB.AppendLine("            <div class=\"col-lg-3 col-md-3\">");
                SB.AppendLine("                    <div id=\"subheading\">");
                SB.AppendLine("                      <h6>Our Team</h6>");
                SB.AppendLine("                    </div>");
                SB.AppendLine("                    <div id=\"HomeMenu\">");
                SB.AppendLine("                    <ul class=\"lsmenu1\">");
                SB.AppendLine("                  <li><a href=\"/businessimmigration_ourteam.html\">Business Immigration Solicitors</a></li>");
                SB.AppendLine("                  <li><a href=\"/childcare_ourteam.html\">Child Care Solicitors</a></li>");
                SB.AppendLine("                  <li><a href=\"/crime_ourteam.html\">Crime Solicitors</a></li>");
                SB.AppendLine("                  <li><a href=\"/ClinicalNegligence_ourteam.html\">Clinical Negligence Solicitors</a></li>");
                SB.AppendLine("                  <li><a href=\"/family_ourteam.html\">Divorce & Family Solicitors</a></li> ");
                SB.AppendLine("                  <li><a href=\"/family_ourteam.html\">Domestic Violence Solicitors</a></li>");
                SB.AppendLine("                  <li><a href=\"/employment_ourteam.html\">Employment Solicitors</a></li> ");
                SB.AppendLine("                  <li><a href=\"/crime_ourteam.html\">Fraud Solicitors</a></li>");
                SB.AppendLine("                  <li><a href=\"/housing_ourteam.html\">Housing, Landlord and Tenant Solicitors</a></li>");
                SB.AppendLine("                  <li><a href=\"/Immigration_ourteam.html\">Immigration Solicitors</a></li>");
                SB.AppendLine("                  <li><a href=\"/litigation_ourteam.html\">Litigation Solicitors</a></li>");
                SB.AppendLine("                  <li><a href=\"/mentalhealth_ourteam.html\">Mental Health Solicitors</a></li>");
                SB.AppendLine("                  <li><a href=\"/PersonalInjury_ourteam.html\">Personal Injury Solicitors</a></li>");
                SB.AppendLine("                  <li><a href=\"/prisonlaw_ourteam.html\">Prison Law Solicitors</a></li>");
                SB.AppendLine("                  <li><a href=\"/litigation_ourteam/Anthony_Okumah.html\">Professional Negligence Solicitors</a></li>");
                SB.AppendLine("                </ul>");
                SB.AppendLine("                </div>");
                SB.AppendLine("            </div>");
                SB.AppendLine("            <div class=\"col-lg-3 col-md-3\">");
                SB.AppendLine("                    <div id=\"subheading\">");
                SB.AppendLine("                      <h6>Our Team</h6>");
                SB.AppendLine("                    </div>");
                SB.AppendLine("                    <div id=\"HomeMenu\">");
                SB.AppendLine("                    <ul class=\"lsmenu1\">");
                SB.AppendLine(_off.getofficesInLondon().ToString());
                SB.AppendLine("                </ul>");
                SB.AppendLine("                </div>");
                SB.AppendLine("            </div>");
                SB.AppendLine("            <div class=\"col-lg-3 col-md-3\">");
                SB.AppendLine("                    <div id=\"subheading\">");
                SB.AppendLine("                      <h6>Our Team</h6>");
                SB.AppendLine("                    </div>");
                SB.AppendLine("                    <div id=\"HomeMenu\">");
                SB.AppendLine("                    <ul class=\"lsmenu1\">");
                SB.AppendLine(_off.getofficesOutLondon().ToString());
                SB.AppendLine("                </ul>");
                SB.AppendLine("                </div>");
                SB.AppendLine("            </div>");
                SB.AppendLine("            </div>    ");
                SB.AppendLine("</div>");
                SB.AppendLine("</div>");


                SB.AppendLine("  <div id=\"footer\" class=\"col-lg-12 col-md-12\">");
                SB.AppendLine("    <p> Duncan Lewis is the trading name of Duncan Lewis (Solicitors) Limited.");
                SB.AppendLine("      <br />");
                SB.AppendLine("      Registered Office is Spencer House, 29 Grove Hill Road, Harrow, HA1 3BN.");
                SB.AppendLine("      Company Reg. No. 3718422. VAT Reg. No. 718729013. <br />");
                SB.AppendLine("      A list of the company's");
                SB.AppendLine("      Directors is displayed at the registered offices address. ");
                SB.AppendLine("      Authorised and Regulated by the ");
                SB.AppendLine("      Solicitors Regulation Authority<br />. ");
                SB.AppendLine("    Offices also at Birmingham, Croydon, Hackney, Islington, Lewisham, Romford, Shepherds Bush, Tooting, Uxbridge & Watford.</p>");
                SB.AppendLine("    <p>©Duncan Lewis  &gt;&gt; <a href=\"about_disclaimer.html\">Legal");
                SB.AppendLine("        Disclaimer, Copyright &amp; Privacy");
                SB.AppendLine("      Policy</a>. Duncan Lewis do not accept service by email.</p>");
                SB.AppendLine("<a href=\"#\" class=\"back-to-top hidden-sm hidden-lg hidden-md\">Back to Top</a>");
                SB.AppendLine("  \t</div>");

                return SB;
            }
        }
    }
}
