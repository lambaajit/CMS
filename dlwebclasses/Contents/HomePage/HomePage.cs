using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dlwebclasses
{
    public class HomePage
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }

        IT_DatabaseEntities dbit = new IT_DatabaseEntities();
        List<Website_Department_Structure> DD = new List<Website_Department_Structure>();
        List<Updates_MainWebsites> news = new List<Updates_MainWebsites>();
        List<Updates_MainWebsites> reportedcases = new List<Updates_MainWebsites>();
        List<Updates_MainWebsites> inthepress = new List<Updates_MainWebsites>();
        List<Website_Videos> videolist = new List<Website_Videos>();
        


        public HomePage(HomePagetype htype = HomePagetype.Main)
        {
            DD = dbit.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").ToList();

            news = dbit.Updates_MainWebsites.Where(x => x.Department == "Main").Take(2).OrderByDescending(y => y.ID).ToList();
            reportedcases = dbit.Updates_MainWebsites.Where(x => x.Department == "Reported Case").Take(2).OrderByDescending(y => y.ID).ToList();
            inthepress = dbit.Updates_MainWebsites.Where(x => x.Department == "InThePress").Take(2).OrderByDescending(y => y.ID).ToList();
            videolist = dbit.Website_Videos.Take(2).OrderByDescending(y => y.id).ToList();

            StringBuilder _NewContent = new StringBuilder();
            if (htype == HomePagetype.Main)
            {
                //_NewContent.AppendLine("<div id=\"dialog\" title=\"Duncan Lewis Update\">");
                //_NewContent.AppendLine("<p style=\"font-size:10px !Important; line-height:14px !Important\"><b>We are open for business.</b> Our lawyers are still fully available to assist existing clients and take on new work by telephone, email and online conferencing.<br /><br />In light of the ongoing Coronavirus emergency we want to reassure our clients that we remain accessible and are fully prepared to continue our provision of legal advice and assistance across all our practice areas.<br /><br />Our Head Office in Harrow remains open and a number of our key offices are beginning to open in a phased manner for scheduled appointments and non-scheduled walk-in clients, these currently include Birmingham, Dalston, Luton and Milton Keynes. Our Shepherd’s Bush office is open for scheduled appointments only. <br /><br />Contact us for more details. Read about the Covid-19 Secure Office Safety Measures we have in place on <a href=\"https://www.duncanlewis.co.uk/Our-Response-Q-and-A.html\">‘Our Response’</a> page. <br /><br /><b><u>Existing Clients</u></b><br /><br />The vast majority of our legal team are following government advice and working from home, if you need to contact them please call on their direct line or email them directly. If unsure, our lawyer contact details can be found on our website at <a href=\"https://www.duncanlewis.co.uk/Our_Team.html\" style=\"font-size:10px !Important;\"><u>‘Our Team’</u></a>.<br /><br /><b><u>New Clients</u></b><br /><br />At this time we encourage all of our prospective clients to contact us via our online new client query form at <a href=\"https://www.duncanlewis.co.uk/Home/contact\" style=\"font-size:10px !Important;\"><u>‘Contact Us’</u></a> on our website. Your query will be received by our legal team and they will call/email you back as soon as possible.<br /><br />If you would like to know more about how Duncan Lewis is responding to the Coronavirus emergency, please visit the links below:<br /><ul style=\"font-size:10px !Important;line-height:14px !Important\"><li style=\"font-size:10px !Important;line-height:14px !Important\">Our CEO Message: <a href=\"https://www.duncanlewis.co.uk/CEO-Message-Coronavirus.html\" style=\"font-size:10px !Important; line-height:14px !Important\">https://www.duncanlewis.co.uk/CEO-Message-Coronavirus.html</a></li><li style=\"font-size:10px !Important; line-height:14px !Important\">Our Response: Q&As: <a href=\"https://www.duncanlewis.co.uk/Our-Response-Q-and-A.html\" style=\"font-size:10px !Important;\">https://www.duncanlewis.co.uk/Our-Response-Q-and-A.html</a></li></ul><span style=\"font-size:10px !Important;\">Thank you for your co-operation in advance.</span></p>");
                //_NewContent.AppendLine("<button class=\"btn btn-primary\" style=\"float:right\" onclick=\"closedialog();\">Close</button></div>");

                _NewContent.AppendLine("<div class=\"row nopadding\">");
                _NewContent.AppendLine("    <div class=\"col-md-12 col-lg-12 col-sm-12 nopadding\">");

                _NewContent.AppendLine("        <div id=\"carousel-example2\" class=\"carousel slide nopadding\" data-ride=\"carousel\" data-interval=\"false\">");
                _NewContent.AppendLine("            <div class=\"row nopadding\">");
                _NewContent.AppendLine("                <div class=\"col-lg-8 col-lg-offset-2 applyblock centerdiv\">");
                _NewContent.AppendLine("                    <div class=\"carousel-indicators nopadding\">");
                _NewContent.AppendLine("                        <a href=\"#carousel-example2\" data-slide-to=\"0\" class=\"col-lg-4 col-xs-4 indicatorleft active\">Private<span class=\"fa fa-chevron-down\"></span></a>");
                _NewContent.AppendLine("                        <a href=\"#carousel-example2\" data-slide-to=\"1\" class=\"col-lg-4 col-xs-4 indicatorright\">Legal Aid<span class=\"fa fa-chevron-down\"></span></a>");
                _NewContent.AppendLine("                        <a href=\"#carousel-example2\" data-slide-to=\"2\" class=\"col-lg-4 col-xs-4 indicatorright\">Business<span class=\"fa fa-chevron-down\"></span></a>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                </div>");
                _NewContent.AppendLine("            </div>");



                _NewContent.AppendLine("                <div class=\"carousel-inner\">");
                for (int s = 1; s <= 3; s++)
                {
                    List<Website_Department_Structure> dd1 = new List<Website_Department_Structure>();
                    string act = "";
                    if (s == 1)
                    {
                        act = " active";
                        dd1 = DD.Where(x => x.Private > 0).OrderBy(y => y.NameforHomePage).ToList();
                    }
                    else if (s == 2)
                    {
                        dd1 = DD.Where(x => x.LegalAid > 0).OrderBy(y => y.NameforHomePage).ToList();
                    }
                    else if (s == 3)
                    {
                        dd1 = DD.Where(x => x.Corporate > 0).OrderBy(y => y.Name).ToList();
                    }

                    _NewContent.AppendLine("                    <div class=\"item" + act + "\">");
                    _NewContent.AppendLine("                        <div class=\"row boxpadding\">");
                    _NewContent.AppendLine("                            <div class=\"col-lg-8 col-lg-offset-2 boxespanel applyblock centerdiv\">");
                    _NewContent.AppendLine("                                <div class=\"row\">");
                    int i = 1;
                    string colwid = "col-lg-3";
                    //if (s == 3)
                    //{
                    //    colwid = "col-lg-4";
                    //}


                    foreach (var item in dd1)
                    {
                        string namefordisplay = item.Name;
                        if (namefordisplay == "Business Immigration" && s == 1)
                            namefordisplay = "Immigration";
                        else if (namefordisplay == "Business Immigration" && s == 3)
                            namefordisplay = "Business Immigration";
                        else
                            namefordisplay = item.NameforHomePage;

                        _NewContent.AppendLine("                                    <div class=\"" + colwid + " col-xs-4 boxpadding\">");
                        _NewContent.AppendLine("                                        <div class=\"deptbox " + item.cssclass + " kolor\">");
                        if (s == 2 && namefordisplay == "Landlord & Tenant Disputes")
                            _NewContent.AppendLine("                                            <h3>Social Housing</h3>");
                        else
                            _NewContent.AppendLine("                                            <h3>" + namefordisplay + "</h3>");
                        _NewContent.AppendLine("                                            <a href=\"" + item.Overview1 + "\"><span class=\"fa fa-arrow-circle-right\" aria-hidden=\"true\"></span></a>");
                        _NewContent.AppendLine("                                            <div class=\"overlay\"><a href=\"" + item.Overview1 + "\"></a></div>");
                        _NewContent.AppendLine("                                        </div>");
                        _NewContent.AppendLine("                                    </div>");
                        i++;
                        if (i == 13)
                        {
                            _NewContent.AppendLine("                                </div>");
                            _NewContent.AppendLine("                                <div id=\"hiddenrow" + s.ToString() + "\" class=\"row collapse\">");
                        }
                    }

                    _NewContent.AppendLine("                                </div>");

                    _NewContent.AppendLine("                                <div class=\"row\">");
                    _NewContent.AppendLine("                                    <div class=\"col-lg-12\">");
                    _NewContent.AppendLine("                                        <div class=\"view-more\" data-toggle=\"collapse\" data-target=\"#hiddenrow" + s.ToString() + "\">View More</div>");
                    _NewContent.AppendLine("                                    </div>");
                    _NewContent.AppendLine("                                </div>");

                    _NewContent.AppendLine("                            </div>");
                    _NewContent.AppendLine("                        </div>");
                    _NewContent.AppendLine("                    </div>");
                }



                _NewContent.AppendLine("                </div>");
                _NewContent.AppendLine("            </div>");


                _NewContent.AppendLine("    </div>");
                _NewContent.AppendLine("</div>");



                _NewContent.AppendLine("<div class=\"row separator\"></div>");
                //foreach (var item in DD)
                //{
                //    _NewContent.AppendLine("." + item.cssclass +" .overlay {");
                //    _NewContent.AppendLine("    background-image: url('../Images/" + item.Name.Replace(" ","-") + "-thumb.JPG') !important;");
                //    _NewContent.AppendLine("}");
                //}


                if (htype != HomePagetype.Main)
                {
                    _NewContent.AppendLine("<div class=\"parentrowoffixedrow\">");
                    _NewContent.AppendLine("        <div class=\"row nopadding dept_default kolor deptheading\" data-spy=\"affix\" data-offset-top=\"500\">");
                    _NewContent.AppendLine("            <div class=\"col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv\">");
                    _NewContent.AppendLine("                <h1 class=\"dept_default\">" + htype.ToString().Replace("LegalAid","Legal Aid") + " Services</h1>");
                    _NewContent.AppendLine("            </div>");
                    _NewContent.AppendLine("        </div>");
                    _NewContent.AppendLine("    </div>");
                }


                _NewContent.AppendLine("<div class=\"row nopadding\">");
                _NewContent.AppendLine("    <div class=\"col-lg-8 col-lg-offset-2 applyblock centerdiv\">");
                _NewContent.AppendLine("        <div class=\"row\">");
                _NewContent.AppendLine("            <div class=\"col-lg-9 homepagetext\">");


                _NewContent.AppendLine("                <h1>Duncan Lewis Solicitors</h1>");
                _NewContent.AppendLine("                <a href=\"/video.html\" style=\"margin:10px\"><img src=\"/Images/HomeVideoImage.JPG\" class=\"VidoeImage img-responsive\" alt=\"Duncan Lewis Videos\" /></a>");
                _NewContent.AppendLine("                <p>&nbsp;</p>");
                _NewContent.AppendLine("                <p>We serve both corporate entities and private individual clients in over 25 areas of law. Headquartered in the City of London with offices in most of the major cities across England and Wales, we are recognised by The Legal 500 and Chambers & Partners UK independent legal directories as a top-tier law firm – <i>“a diligent and professional team that is prepared to go the extra mile for its clients”</i>. We are an award-winning national law firm. We are listed as one of The Times 200 Best Law Firms and have been recognised as an 'Outstanding Firm for Diversity & Inclusion' by the Chambers Europe Awards. Our motto and aim is to ‘give people a voice’ and we strive to achieve the best possible outcome for you through high-quality legal representation. </p>");
                _NewContent.AppendLine("                <p>&nbsp;</p>");
                _NewContent.AppendLine("                <p>We care about your wellbeing and are committed to providing the best possible service to you in the most considerate and careful manner. In addition to our private-client work, we are the largest provider of publicly funded (legal aid) services in the UK and have significant experience representing the most vulnerable people in society. We have specialist solicitors in Actions against Public Authorities, Commercial & Company, Child Care, Civil Liberties & Human Rights, Civil Litigation, Clinical Negligence, Court of Protection, Crime, Cross-Border Disputes, Education Law, Employment, Family, High Net-Worth Divorce, Housing, Immigration, Personal Injury and Public Law and Wills & Probate.</p>");
                _NewContent.AppendLine("                <p>&nbsp;</p>");
                _NewContent.AppendLine("                <p>Our lawyers combine an in depth knowledge of the law and its practical application to your case, with a firm belief in your right to legal assistance and to committed representation throughout your matter. Our solicitors place service to the public above all else and are able to advise on the best possible course of funding in the event you do not qualify for legal aid. Our rates are competitive and we can also explore the opportunity to fund your case on a fixed fee basis, through insurance and/or on a no win no fee basis (a conditional fee agreement).</p>");
                _NewContent.AppendLine("                <p>&nbsp;</p>");
                _NewContent.AppendLine("                <p>When you come to Duncan Lewis you come to a prominent and reputable national law firm with over 250 qualified solicitors and consultants (most of whom are Law Society Panel accredited or equivalent), and over 300 trainee solicitors, caseworkers, legal executives and support staff. They are all willing to take the time to listen to your problem, evaluate it correctly in terms of the law and where possible to speak out on your behalf in an attempt to present your point of view in the best light and achieve legal remedies which address your problem.</p>");
                _NewContent.AppendLine("                <p>&nbsp;</p>");
                _NewContent.AppendLine("                <p>We hold industry quality marks to evidence that we are a law firm that you can trust. The firm holds Law Society Lexcel Excellence in Practice Management and Client Care accreditation and the Investors in People, Gold Standard. We are a paperless law firm and take data protection and cyber security extremely seriously. We hold both ISO 27001 and Cyber Essentials Plus certifications which demonstrates we have defined and put in place best-practice information security processes. </p>");
                _NewContent.AppendLine("                <p>&nbsp;</p>");



                _NewContent.AppendLine("<a href=\"/The-Legal-500.html\"><h4>The Legal 500 - what they say about us</h4></a>");


                _NewContent.AppendLine("                <p>&nbsp;</p>");

                _NewContent.AppendLine("                <div class=\"lawlogo\">");
                _NewContent.AppendLine("                    <h4>Our Quality Marks<span class=\"fa fa-certificate\"></span></h4>");
                _NewContent.AppendLine("                    <div class=\"visible-lg visible-md visible-sm hidden-xs\">");
                _NewContent.AppendLine("                        <img src=\"/Images/Law-Logos.JPG\" class=\"img-responsive\" alt=\"Duncan Lewis Accreditation\" />");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                    <div class=\"visible-xs hidden-md hidden-sm hidden-lg\">");
                _NewContent.AppendLine("                        <img src=\"/Images/Law-Logos_M.JPG\" class=\"img-responsive\" alt=\"Duncan Lewis Accreditation\" />");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                </div>");

                _NewContent.AppendLine("                <p>&nbsp;</p>");

                _NewContent.AppendLine("                  <div class=\"row\">");
                _NewContent.AppendLine("<div class=\"col-md-4\">");

                _NewContent.AppendLine("                <div class=\"lawlogo\">");
                _NewContent.AppendLine("                    <h4>Our Regulator<span class=\"fa fa-certificate\"></span></h4>");
                _NewContent.AppendLine("                    <div style=\"max-width:275px;max-height:163px;\"><div style=\"position: relative;padding-bottom: 59.1%;height: auto;overflow: hidden;\"><iframe frameborder=\"0\" scrolling=\"no\" allowTransparency=\"true\" src=\"https://cdn.yoshki.com/iframe/55845r.html\" style=\"border:0px; margin:0px; padding:0px; backgroundColor:transparent; top:0px; left:0px; width:100%; height:100%; position: absolute;\"></iframe></div></div>");
                _NewContent.AppendLine("                </div>");
                _NewContent.AppendLine("                </div>");
                _NewContent.AppendLine("        <div class=\"col-md-8\">");
                _NewContent.AppendLine("                <div class=\"lawlogo\">");
                _NewContent.AppendLine("                    <h4>Not Sure About Email Received?<span class=\"fa fa-certificate\"></span></h4>");
                _NewContent.AppendLine(" <div class=\"panel panel-default\" style=\"padding:10px; display:inline-block !important\"><p>Not sure about an email received? Please be vigilant to cyber security risks at all times. If the email id from which an email came from does not end with @duncanlewis.com, this this is not a genuine email from Duncan Lewis Solicitors. Do not open any attachments or links contained therein and delete such emails received. It is a good practice to avoid clicking on any links in emails that you are not expecting to receive. In accordance with our regulatory obligations, to assist our clients and members of the public we maintain a history of scam alerts that have been brought to our attention – <a href=\"/Red-Alerts.html\">here</a>. If you wish to notify us of any concerns you have then please use this Contact Us Page > Other > Data Protection.</p></div>");
                _NewContent.AppendLine("                </div>");
                _NewContent.AppendLine("                </div>");
                _NewContent.AppendLine("                </div>");

                _NewContent.AppendLine(" <div class=\"panel panel-default\" style=\"padding:10px; margin-top:10px\">" +
                    "<p>From 25 May 2018, the new EU General Data Protection Regulation (GDPR) will be coming into effect. In order to comply with the new requirements of this law, and to ensure that we can best continue to serve you, Duncan Lewis has updated its <a href=\"/about_disclaimer.html\">Privacy Notice</a>. You can find the updated Policy which provides detailed information on how we use and protect your personal information, and your rights in relation to this <a href=\"/about_disclaimer.html\">here</a>.<br /><br />If you wish to unsubscribe from any communication from Duncan Lewis, please click <a href=\"mailto:dataprotection@duncanlewis.com\">here.</p></div>");


                _NewContent.AppendLine("            </div>");




                _NewContent.AppendLine("            <div class=\"col-lg-3\">");


                _NewContent.AppendLine("                <div class=\"panel panel-primary homepagepanels\">");
                _NewContent.AppendLine("                    <div class=\"panel-heading\">");
                _NewContent.AppendLine("                        <a data-toggle=\"collapse\" href=\"#panelClientFeedback\">What our clients say<span class=\"fa fa-caret-down\"></span></a>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                    <div id=\"panelClientFeedback\" class=\"panel-body panel-collapse collapse in\" style=\"padding:15px 15px 0px 15px !important\">");
                _NewContent.AppendLine("<div class=\"trustpilot-widget\" data-locale=\"en-US\" data-template-id=\"53aa8807dec7e10d38f59f32\" data-businessunit-id=\"59c105cb0000ff0005ab854d\" data-style-height=\"150px\" data-style-width=\"100%\" data-theme=\"light\">");
                _NewContent.AppendLine("<a href=\"https://www.trustpilot.com/review/duncanlewis.co.uk\" target=\"_blank\">Trustpilot</a>");
                _NewContent.AppendLine("</div>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                </div>");



                _NewContent.AppendLine("                <div class=\"panel panel-primary homepagepanels\">");
                _NewContent.AppendLine("                    <div class=\"panel-heading\">");
                _NewContent.AppendLine("                        <a data-toggle=\"collapse\" href=\"#panelQuickLinks\">Quick Links <span class=\"fa fa-caret-down\"></span></a>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                    <div id=\"panelQuickLinks\" class=\"panel-body panel-collapse collapse in\">");
                _NewContent.AppendLine("                        <ul>");
                _NewContent.AppendLine("                            <li>");
                _NewContent.AppendLine("                                <a href=\"/Video.html\">");
                _NewContent.AppendLine("                                    <img src=\"/Images/videos_Icon.png\" alt=\"Duncan Lewis Videos\" />Videos");
                _NewContent.AppendLine("                                </a>");
                _NewContent.AppendLine("                            </li>");
                _NewContent.AppendLine("                            <li>");
                _NewContent.AppendLine("                                <a href=\"Home/Payment\">");
                _NewContent.AppendLine("                                    <img src=\"/Images/Payment_Icon.PNG\" alt=\"Duncan Lewis Payments\" />Payments");
                _NewContent.AppendLine("                                </a>");
                _NewContent.AppendLine("                            </li>");
                _NewContent.AppendLine("                            <li>");
                _NewContent.AppendLine("                                <a href=\"/brochures.html\">");
                _NewContent.AppendLine("                                    <img src=\"/Images/Brochure_Icon.PNG\" alt=\"Duncan Lewis Brochures\" />Brochures");
                _NewContent.AppendLine("                                </a>");
                _NewContent.AppendLine("                            </li>");
                _NewContent.AppendLine("                            <li>");
                _NewContent.AppendLine("                                <a href=\"/Our_Team.html\">");
                _NewContent.AppendLine("                                    <img src=\"/Images/Team_icon.PNG\" alt=\"Duncan Lewis Team\" />Our Team");
                _NewContent.AppendLine("                                </a>");
                _NewContent.AppendLine("                            </li>");
                _NewContent.AppendLine("                            <li>");
                _NewContent.AppendLine("                                <a href=\"/Legal_News.html\">");
                _NewContent.AppendLine("                                    <img src=\"/Images/Legal_News_Icon.PNG\" alt=\"Duncan Lewis Legal News\" />Legal News");
                _NewContent.AppendLine("                                </a>");
                _NewContent.AppendLine("                            </li>");
                _NewContent.AppendLine("                            <li>");
                _NewContent.AppendLine("                                <a href=\"/Campaign.html\">");
                _NewContent.AppendLine("                                    <img src=\"/Images/Campaign_Icon.PNG\" alt=\"Duncan Lewis Campaign\" />Campaign");
                _NewContent.AppendLine("                                </a>");
                _NewContent.AppendLine("                            </li>");
                _NewContent.AppendLine("                            <li>");
                _NewContent.AppendLine("                                <a href=\"/findus.html\">");
                _NewContent.AppendLine("                                    <img src=\"/Images/find_us.PNG\" alt=\"Duncan Lewis Offices\" />Find Us");
                _NewContent.AppendLine("                                </a>");
                _NewContent.AppendLine("                            </li>");
                _NewContent.AppendLine("                            <li>");
                _NewContent.AppendLine("                                <a href=\"/European-Union-Solicitors.html\">");
                _NewContent.AppendLine("                                    <img src=\"/Images/EU_icon.PNG\" alt=\"Duncan Lewis EU\" />European Union");
                _NewContent.AppendLine("                                </a>");
                _NewContent.AppendLine("                            </li>");
                _NewContent.AppendLine("                            <li>");
                _NewContent.AppendLine("                                <a href=\"/Home/Contact\">");
                _NewContent.AppendLine("                                    <img src=\"/Images/contact_us_icon.PNG\" alt=\"Duncan Lewis Contact\" />Contact Us");
                _NewContent.AppendLine("                                </a>");
                _NewContent.AppendLine("                            </li>");
                _NewContent.AppendLine("                        </ul>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                </div>");




                _NewContent.AppendLine("                <div class=\"panel panel-primary homepagepanels\">");
                _NewContent.AppendLine("                    <div class=\"panel-heading\">");
                _NewContent.AppendLine("                        <a data-toggle=\"collapse\" href=\"#panelDLNews\">Duncan Lewis News<span class=\"fa fa-caret-down\"></span></a>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                    <div id=\"panelDLNews\" class=\"panel-body panel-collapse collapse in\">");
                _NewContent.AppendLine("                        <ul>");



                foreach (var item in news)
                {
                    GetLinkfromArticleRef _getlink = new GetLinkfromArticleRef();
                    _NewContent.AppendLine(_getlink.GetLink(item, null, ""));
                }
                _NewContent.AppendLine("<a href=\"/news.html\" style=\"padding:10px; float:right; margin-right:20px; display:inline-block\">Read More ...</a>");
                _NewContent.AppendLine("                        </ul>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                </div>");


                _NewContent.AppendLine("                <div class=\"panel panel-primary homepagepanels\">");
                _NewContent.AppendLine("                    <div class=\"panel-heading\">");
                _NewContent.AppendLine("                        <a data-toggle=\"collapse\" href=\"#panelInThePress\">In The Press<span class=\"fa fa-caret-down\"></span></a>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                    <div id=\"panelInThePress\" class=\"panel-body panel-collapse collapse in\">");
                _NewContent.AppendLine("                        <ul>");
                foreach (var item in inthepress)
                {
                    GetLinkfromArticleRef _getlink = new GetLinkfromArticleRef();
                    _NewContent.AppendLine(_getlink.GetLink(item, null, ""));
                }
                _NewContent.AppendLine("<a href=\"/inthepress.html\" style=\"padding:10px; float:right; margin-right:20px; display:inline-block\">Read More ...</a>");
                _NewContent.AppendLine("                        </ul>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                </div>");


                _NewContent.AppendLine("                <div class=\"panel panel-primary homepagepanels\">");
                _NewContent.AppendLine("                    <div class=\"panel-heading\">");
                _NewContent.AppendLine("                        <a data-toggle=\"collapse\" href=\"#panelReportedCases\">Reported Cases<span class=\"fa fa-caret-down\"></span></a>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                    <div id=\"panelReportedCases\" class=\"panel-body panel-collapse collapse in\">");
                _NewContent.AppendLine("                        <ul>");
                foreach (var item in reportedcases)
                {
                    GetLinkfromArticleRef _getlink = new GetLinkfromArticleRef();
                    _NewContent.AppendLine(_getlink.GetLink(item, null, ""));
                }
                _NewContent.AppendLine("<a href=\"/reportedcases.html\" style=\"padding:10px; float:right; margin-right:20px; display:inline-block\">Read More ...</a>");
                _NewContent.AppendLine("                        </ul>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                </div>");


                //_NewContent.AppendLine("                <div class=\"panel panel-primary homepagepanels\">");
                //_NewContent.AppendLine("                    <div class=\"panel-heading\">");
                //_NewContent.AppendLine("                        <a data-toggle=\"collapse\" href=\"#panelTwitterFeed\">Twitter Feed<span class=\"fa fa-caret-down\"></span></a>");
                //_NewContent.AppendLine("                    </div>");
                //_NewContent.AppendLine("                    <div id=\"panelTwitterFeed\" class=\"panel-body panel-collapse collapse in\">");
                //_NewContent.AppendLine("                        <ul>");
                //_NewContent.AppendLine("                            <li>");
                //_NewContent.AppendLine("                                <a href=\"#\">");
                //_NewContent.AppendLine("                                    Civil Partnerships for all? (9 May 2017)");
                //_NewContent.AppendLine("                                </a>");
                //_NewContent.AppendLine("                            </li>");
                //_NewContent.AppendLine("                        </ul>");
                //_NewContent.AppendLine("                    </div>");
                //_NewContent.AppendLine("                </div>");





                _NewContent.AppendLine("                <div class=\"panel panel-primary homepagepanels\">");
                _NewContent.AppendLine("                    <div class=\"panel-heading\">");
                _NewContent.AppendLine("                        <a data-toggle=\"collapse\" href=\"#panelVideos\">Videos<span class=\"fa fa-caret-down\"></span></a>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                    <div id=\"panelVideos\" class=\"panel-body panel-collapse collapse in\">");
                _NewContent.AppendLine("                        <ul>");
                foreach (var item in videolist)
                {
                    _NewContent.AppendLine("                            <li>");
                    _NewContent.AppendLine("                                    <a href=\"/Videos/" + item.id + "_Videos.html\"><img src=\"/Video-Images/" + item.id + ".jpg\" class=\"img-responsive\" alt=\"Duncan Lewis Videos\" /></a>");
                    _NewContent.AppendLine("                            </li>");
                }
                _NewContent.AppendLine("<a href=\"/videos.html\" style=\"padding:10px; float:right; margin-right:20px; display:inline-block\">Read More ...</a>");
                //_NewContent.AppendLine("                            <li>");
                //_NewContent.AppendLine("                                <a href=\"#\">");
                //_NewContent.AppendLine("                                    <img src=\"/Images/Video_img1.JPG\" class=\"img-responsive\" />");
                //_NewContent.AppendLine("                                </a>");
                //_NewContent.AppendLine("                            </li>");
                _NewContent.AppendLine("                        </ul>");
                _NewContent.AppendLine("                    </div>");
                _NewContent.AppendLine("                </div>");

                _NewContent.AppendLine("                </div>");
                _NewContent.AppendLine("                </div>");

                _NewContent.AppendLine("                </div>");
                _NewContent.AppendLine("                </div>");
                filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Index.html";
            }
            else
            {
                    List<Website_Department_Structure> dd1 = new List<Website_Department_Structure>();
                    if (htype == HomePagetype.Private)
                    {
                        dd1 = DD.Where(x => x.Private > 0).OrderBy(x => x.Sequence).ThenBy(y => y.NameforHomePage).ToList();
                        filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Private.html";
                    Title = "Duncan Lewis | Services for Private Clients";
                    Description = "Duncan Lewis Services for Private Clients";
                }
                    else if (htype == HomePagetype.LegalAid)
                    {
                        dd1 = DD.Where(x => x.LegalAid > 0).OrderBy(y => y.NameforHomePage).ToList();
                        filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\LegalAid.html";
                    Title = "Duncan Lewis | Services for Legal Aid Clients";
                    Description = "Duncan Lewis Services for Legal Aid Clients";

                }
                else if (htype == HomePagetype.Corporate)
                    {
                        dd1 = DD.Where(x => x.Corporate > 0).OrderBy(y => y.Name).ToList();
                        filepath = ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\Corporate.html";
                    Title = "Duncan Lewis | Services for Corporate Clients";
                    Description = "Duncan Lewis Services for Corporate Clients";
                }




                
                

                _NewContent.AppendLine("                        <div class=\"row boxpadding\">");
                    _NewContent.AppendLine("                            <div class=\"col-lg-8 col-lg-offset-2 boxespanel applyblock centerdiv\">");
                    _NewContent.AppendLine("                                <div class=\"row\">");
                    int i = 1;
                    string colwid = "col-lg-3";
                    //if (htype == HomePagetype.Corporate)
                    //{
                    //    colwid = "col-lg-4";
                    //}


                    foreach (var item in dd1)
                    {
                        string namefordisplay = item.NameforHomePage;
                        if (namefordisplay == "Immigration Advice for your Business" && htype == HomePagetype.Private)
                            namefordisplay = "Immigration";
                        else if (namefordisplay == "Immigration Advice for your Business" && htype == HomePagetype.Corporate)
                            namefordisplay = "Business Immigration";

                        _NewContent.AppendLine("                                    <div class=\"" + colwid + " col-xs-4 boxpadding\">");
                        _NewContent.AppendLine("                                        <div class=\"deptbox " + item.cssclass + " kolor\">");

                        if (htype == HomePagetype.LegalAid && namefordisplay == "Landlord & Tenant Disputes")
                            _NewContent.AppendLine("                                            <h3>Social Housing</h3>");
                        else
                            _NewContent.AppendLine("                                            <h3>" + namefordisplay + "</h3>");

                        _NewContent.AppendLine("                                            <a href=\"" + item.Overview1 + "\"><span class=\"fa fa-arrow-circle-right\" aria-hidden=\"true\"></span></a>");
                        _NewContent.AppendLine("                                            <div class=\"overlay\"><a href=\"" + item.Overview1 + "\"></a></div>");
                        _NewContent.AppendLine("                                        </div>");
                        _NewContent.AppendLine("                                    </div>");
                        i++;
                        if (i == 13)
                        {
                            _NewContent.AppendLine("                                </div>");
                            _NewContent.AppendLine("                                <div id=\"hiddenrow" + htype + "\" class=\"row collapse\">");
                        }
                    }

                    _NewContent.AppendLine("                                </div>");

                    _NewContent.AppendLine("                                <div class=\"row\">");
                    _NewContent.AppendLine("                                    <div class=\"col-lg-12\">");
                    _NewContent.AppendLine("                                        <div class=\"view-more\" data-toggle=\"collapse\" data-target=\"#hiddenrow"+htype+"\">View More</div>");
                    _NewContent.AppendLine("                                    </div>");
                    _NewContent.AppendLine("                                </div>");

                    _NewContent.AppendLine("                            </div>");
                    _NewContent.AppendLine("                        </div>");


            }
            
            Keywords = "legal aid, free legal advice, legal aid lawyers, legal aid services, legal aid family, legal aid lawyer, legal aid solicitor, legal aid funding, solicitors, free legal advice, solicitor, legal custody, domestic violence solicitor, Children solicitor, child and social services involvement, legal aid immigration solicitors, immigration lawyers professional negligence lawyers, personal injury solicitors, crime solicitors, criminal lawyers, criminal solicitor specialist fraud solicitor, benefit fraud solicitor, personal injury solicitor, solicitors negligence, Birmingham solicitors, Solicitors Cardiff, solicitors Leicester, solicitors London, Solicitors East London, Solicitors south east London, solicitors south London, solicitors west London, no win no fee, Divorce solicitor, divorce lawyer, child abduction solicitor, wardship solicitor, mental capacity solicitor, mental health solicitor, solicitor, mortgage repossession, housing disrepair solicitor";
            HeadingH1 = "Duncan Lewis Solicitors";
            Department = "";
            Contents = _NewContent;
            

        }
    }
}
