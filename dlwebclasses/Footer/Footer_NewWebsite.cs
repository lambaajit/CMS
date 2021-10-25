using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Footer_NewWebsite:AFooter
    {

        public override StringBuilder getfooter(AContents _contents)
        {
            string cssclass = "";
            Offices _off;
            DepartmentDetails DD = null;
            if (_contents.Department != null)
            {
                 DD = new DepartmentDetails(_contents.Department);
                cssclass = DD.cssclass;
                if (DD.departmenttype == "AreaOfLaw" && _contents.HeadingH1.Contains("Videos") == false)
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

            List<string> offInLondon = _off.getofficesInLondonList();
            List<string> offOutLondon = _off.getofficesOutLondonList();

            List<string> AreasofLaws = new List<string>();
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            List<string> DepartmenttoExclude = new List<string>(new string[]{"Debt", "Civil Liberties & Human rights", "Islamic Law", "Professional Regulation Law", "Court of Protection"});
            AreasofLaws = db.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw" && DepartmenttoExclude.Contains(x.Name) == false).Select(x => "<li><a href=\"/" + x.Overview1 + "\">" + x.Name + "</a></li>").ToList();


            StringBuilder SB = new StringBuilder();
            SB.AppendLine("            <div class=\"row footerrowtop  " + cssclass + "  kolor nopadding\">");
            SB.AppendLine("                <div class=\"col-sm-12 col-xs-12 col-sm-offset-2 applyblock centerdiv nopadding\">");

            if (DD == null || DD.contactstr1 == "" || DD.contactstr1 == null || DD.contactstr1 == String.Empty)
                SB.AppendLine("                    Call us now on 033 3772 0409 or click <a href=\"/Home/contact\">here to send online enquiry</a>.");
            else
                SB.AppendLine("                    Call us now on 033 3772 0409 or click <a href=\"/Home/contact\">here to send online enquiry</a>.");

            SB.AppendLine("                </div>");
            SB.AppendLine("            </div>");
            SB.AppendLine("            <div class=\"row nopadding footerrowmiddle  " + cssclass + "  lightkolor\">");
            SB.AppendLine("                <div class=\"col-sm-8 col-xs-12 col-sm-offset-2 applyblock centerdiv\">");
            SB.AppendLine("                    <div class=\"row\">");
            SB.AppendLine("                        <div class=\"col-sm-2 col-xs-12 footercolumn socialicons  " + cssclass + "  forecolor\">");
            SB.AppendLine("                            <h6>Our Social Network</h6>");
            SB.AppendLine("                            <a class=\"" + cssclass + " forecolor\" href=\"https://twitter.com/DuncanLewis/\" target=\"_blank\" title=\"Duncan Lewis\" class=\"socialIcons\"   ><span class=\"fa fa-twitter-square\"></span></a>");
            SB.AppendLine("                            <a class=\"" + cssclass + " forecolor\" href=\"https://www.youtube.com/duncanlewislawyers\" class=\"socialIcons\"  ><span class=\"fa fa-youtube-square\"></span></a>");
            SB.AppendLine("                            <a class=\"" + cssclass + " forecolor\" href=\"https://www.linkedin.com/companies/duncan-lewis-%26-co-solicitors-greater-london?trk=fc_badge\" class=\"socialIcons\"  ><span class=\"fa fa-linkedin-square\"></span></a>");
            SB.AppendLine("                            <a class=\"" + cssclass + " forecolor\" href=\"https://www.facebook.com/duncanlewislawfirm\" title=\"Duncan Lewis\" class=\"socialIcons\" ><span class=\"fa fa-facebook-square\"></span></a>");
            SB.AppendLine("                        </div>");

            SB.AppendLine("                        <div class=\"col-sm-2 col-xs-12 footercolumn\">");
            SB.AppendLine("                            <h6 class=\" " + cssclass + "  forecolor\">Our Services</h6>");
            SB.AppendLine("                            <ul>");
            foreach (var item in AreasofLaws)
            {
                SB.AppendLine(item);
                //i++;
                //if (i == 17)
                //{
                //    SB.AppendLine("                            </ul>");
                //    SB.AppendLine("                        </div>");



                //    SB.AppendLine("                        <div class=\"col-sm-2 col-xs-12 footercolumn\">");
                //    SB.AppendLine("                            <h6 class=\" " + cssclass + "  forecolor\">Offices Outside London</h6>");
                //    SB.AppendLine("                            <ul>");
                //}
            }
            SB.AppendLine("                            </ul>");
            SB.AppendLine("                        </div>");



            SB.AppendLine("                        <div class=\"col-sm-2 col-xs-12 footercolumn\">");
            SB.AppendLine("                            <h6 class=\" " + cssclass + "  forecolor\">About Us</h6>");
            SB.AppendLine("                            <ul class=\"footeraboutlinks\">");
            SB.AppendLine("                                <li><a href=\"/Home/Contact\">Contact Us</a></li>");
            SB.AppendLine("                                <li><a href=\"/branchLocator_DL_WithMap.aspx\">Find Nearest Branch</a></li>");
            SB.AppendLine("                                <li><a href=\"/Our_Team_Alphabetic_A.html\">Our Staff</a></li>");
            SB.AppendLine("                                <li><a href=\"/about_languages.html\">We Speak</a></li>");
            SB.AppendLine("                                <li><a href=\"/about_managementboard.html\">Management Team</a></li>");
            SB.AppendLine("                                <li><a href=\"/brochures.html\">Brochures</a></li>");
            SB.AppendLine("                            </ul>");
            SB.AppendLine("                        </div>");

            SB.AppendLine("                        <div class=\"col-sm-2 col-xs-12 footercolumn\">");
            SB.AppendLine("                            <h6 class=\" " + cssclass + "  forecolor\">Offices In London</h6>");
            SB.AppendLine("                            <ul>");
            int i = 1;
            foreach (var item in offInLondon)
            {
                SB.AppendLine(item);
            }

            SB.AppendLine("                            </ul>");
            SB.AppendLine("                        </div>");


            SB.AppendLine("                        <div class=\"col-sm-2 col-xs-12 footercolumn\">");
            SB.AppendLine("                            <h6 class=\" " + cssclass + "  forecolor\">Offices Outside London</h6>");
            SB.AppendLine("                            <ul>");
            i = 1;
            foreach (var item in offOutLondon)
            {
                SB.AppendLine(item);
                i++;
                if (i == 18)
                {
                    SB.AppendLine("                            </ul>");
                    SB.AppendLine("                        </div>");



                    SB.AppendLine("                        <div class=\"col-sm-2 col-xs-12 footercolumn\">");
                    SB.AppendLine("                            <h6 class=\" " + cssclass + "  forecolor\">Offices Outside London</h6>");
                    SB.AppendLine("                            <ul>");
                }
            }

            SB.AppendLine("                            </ul>");
            SB.AppendLine("                        </div>");




            SB.AppendLine("                    </div>");
            SB.AppendLine("                </div>");
            SB.AppendLine("            </div>");

            SB.AppendLine("            <div class=\"row footerrowbottom nopadding\">");
            SB.AppendLine("                <div class=\"col-sm-8 col-sm-offset-2 applyblock centerdiv nopadding\">");
            SB.AppendLine("                    Duncan Lewis is the trading name of Duncan Lewis (Solicitors) Limited.");
            SB.AppendLine("                    Registered Office is 143-149 Fenchurch St, London, EC3M 6BL. Company Reg. No. 3718422. VAT Reg. No. 718729013.");
            SB.AppendLine("                    A list of the company's Directors is displayed at the registered offices address. Authorised and Regulated by the Solicitors Regulation Authority");
            SB.AppendLine("                    . Offices all across London and in major cities in the UK.");

            SB.AppendLine("                    ©Duncan Lewis >><a href=\"/about_disclaimer.html\" style=\"font-size:9px  !important\">Legal Disclaimer</a>, Copyright & Privacy Policy. Duncan Lewis do not accept service by email.");

            if (_contents.GetType() == typeof(Content_HomePage))
                SB.AppendLine("<br />We can offer services in your language from 24-7 Language Services, <a href =\"https://www.24-7languageservices.com\" style=\"font-size:9px !important\">www.24-7languageservices.com</a>");

                SB.AppendLine("                </div>");
            SB.AppendLine("            </div>");

            return SB;

        }
    }
}
