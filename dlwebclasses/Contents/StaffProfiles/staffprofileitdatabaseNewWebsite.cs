using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class staffprofileitdatabaseNewWebsite:IStaffProfile
    {
        public StringBuilder getstaffProfile(string staffcode)
        {
        StringBuilder _NewContents = new StringBuilder();
        IT_DatabaseEntities dbit = new IT_DatabaseEntities();
        User_Profile_FinalDraft UP = new User_Profile_FinalDraft();
        UP = dbit.User_Profile_FinalDraft.Where(x => x.Emp_code == staffcode).FirstOrDefault();
        Emp_Profile ep = new Emp_Profile();
        HRDDLEntities dbhr = new HRDDLEntities();
        StringBuilder Pro = new StringBuilder();
            if (UP == null)
            {

                ep = dbhr.Emp_Profile.Where(x => x.emp_code == staffcode).FirstOrDefault();
                
                if (ep == null)
                    Pro.Append("");
                else
                    Pro.Append(ep.experience);

                Pro = allStatic.replacelinespacewithbr(Pro);
            }

            var _emp_Details = dbhr.Emp_Details.Where(x => x.emp_code == staffcode);
        string department = _emp_Details.Select(y => y.department_it).FirstOrDefault();
        string cssclass = "";
        if (dbit.Website_Department_Structure.Where(x => x.Name == department).ToList().Count() > 0)
        {
            DepartmentDetails dd = new DepartmentDetails(department);
            cssclass = dd.cssclass;
        }
        else
        {
            cssclass = "dept_default";
        }


        string staffname = "";
        if (UP != null)
            staffname = UP.Emp_Name;
        else
            staffname = _emp_Details.Select(y => y.forename + " " + y.surname).FirstOrDefault();


        List<Updates_MainWebsites> Articles_Staff = new List<Updates_MainWebsites>();
        List<string> Articles_Links = new List<string>();
        //Articles_Staff = dbit.Updates_MainWebsites.Where(x => x.Staff1 == staffname || x.Staff2 == staffname || x.Staff3 == staffname).OrderByDescending(x => x.ID).GroupBy(y => y.Title).Select(z => z.First()).ToList();
        //Articles_Staff = dbit.Updates_MainWebsites.Where(x => x.Staff1 == staffname || x.Staff2 == staffname || x.Staff3 == staffname).OrderByDescending(x => x.ID).ToList();
        Articles_Staff = dbit.Updates_MainWebsites.Where(x => x.Staff1 == staffname || x.Staff2 == staffname || x.Staff3 == staffname || x.Staff4 == staffname || x.Staff5 == staffname || x.Staff6 == staffname || x.Staff7 == staffname || x.Staff8 == staffname || x.Staff9 == staffname || x.Staff10 == staffname).GroupBy(y => y.Title).Select(z => z.FirstOrDefault()).OrderByDescending(w => w.ID).ToList();
        if (Articles_Staff.Count > 0)
        {
            foreach (Updates_MainWebsites UM1 in Articles_Staff)
            {
                GetLinkfromArticleRef _getlink = new GetLinkfromArticleRef();
                Articles_Links.Add(_getlink.GetLink(UM1, null, "StaffPage"));
            }
        }


        string legal500logo = "";
        string chamberslogo = "";
        List<string> otherlogos = new List<string>();

        List<website_awards> wa = new List<website_awards>();
        wa = dbit.website_awards.Where(x => x.StaffName == staffname).OrderByDescending(y => y.Year).ThenByDescending(y => y.id).ToList();
        if (wa != null)
        {

                List<string> LegalDirectories = wa.GroupBy(x => x.LegalDirectory).Select(y => y.Key).ToList();// dbit.Database.SqlQuery<string>("Select LegalDirectory from website_awards where Staffname = '" + staffname + "' group by LegalDirectory").ToList();

                foreach (var item in LegalDirectories)
                {
                    var rec = wa.Where(x => x.LegalDirectory == item).OrderByDescending(y => y.Year).FirstOrDefault();
                    if (rec.LegalDirectory == "Legal 500")
                        legal500logo = "Legal-500-" + rec.Year + ".jpg";
                    else if (rec.LegalDirectory == "Chambers UK")
                        chamberslogo = rec.LogosToUse;
                    else
                        otherlogos.Add(rec.LogosToUse);
                }

                //foreach (var item in wa.Where(x => x.LegalDirectory != "Chambers UK" && x.LegalDirectory != "Legal 500" && x.LogosToUse != null))
                //{
                //    otherlogos.Add(item.LogosToUse);
                //}

                //if (yearlegal != null)
                //{
                //    legal500logo = "Legal-500-" + yearlegal.ToString() + ".jpg";
                //}

                //foreach (var item in wa.Where(x => x.LegalDirectory == "Chambers UK").OrderByDescending(y => y.Year).Take(1))
                //{
                //    chamberslogo = item.LogosToUse;
                //}

            }

            _NewContents.AppendLine("                    <nav class=\"profilenav " + cssclass + " kolor\" data-spy=\"affix\" data-offset-top=\"580\">");
            _NewContents.AppendLine("                        <div class=\"container-fluid\">");
            _NewContents.AppendLine("                            <div class=\"navbar-header\">");
            _NewContents.AppendLine("                                <button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\"#ProfileNavbar\">");
            _NewContents.AppendLine("                                    <span class=\"icon-bar\"></span>");
            _NewContents.AppendLine("                                    <span class=\"icon-bar\"></span>");
            _NewContents.AppendLine("                                    <span class=\"icon-bar\"></span>");
            _NewContents.AppendLine("                                </button>");
            _NewContents.AppendLine("                            </div>");
            _NewContents.AppendLine("                            <div>");
            _NewContents.AppendLine("                                <div class=\"collapse navbar-collapse " + cssclass + "\" id=\"ProfileNavbar\">");
            _NewContents.AppendLine("                                    <ul class=\"nav navbar-nav\">");
            _NewContents.AppendLine("                                        <li class=\"active\"><a href=\"#Profile\"><span class=\"fa fa-user-circle\"></span>Profile</a></li>");
            if (UP != null)
            {
                if (UP.Education_Status == "Yes")
                {
                    _NewContents.AppendLine("                                        <li><a href=\"#Education\"><span class=\"fa fa-graduation-cap\"></span>Education</a></li>");
                }
                if (UP.Career_Status == "Yes")
                {
                    _NewContents.AppendLine("                                        <li><a href=\"#Careers\"><span class=\"fa fa-suitcase\"></span>Career</a></li>");
                }
                if (UP.Client_Comments_Status == "Yes")
                {
                    _NewContents.AppendLine("                                        <li><a href=\"#Testimonials\"><span class=\"fa fa-comments\"></span>Testimonials</a></li>");
                }
                if (UP.Supreme_Court_Status == "Yes" || UP.Court_of_Appeal_Status == "Yes" || UP.High_Court_Status == "Yes" || UP.Criminal_Court_Status == "Yes" || UP.Civil_Court_Status == "Yes" || UP.Other_Supreme_Court_Status == "Yes" || UP.Other_Court_of_Appeal_Status == "Yes" || UP.Other_High_Court_Status == "Yes" || UP.Other_Criminal_Court_Status == "Yes" || UP.Other_Civil_Court_Status == "Yes")
                {
                    _NewContents.AppendLine("                                        <li><a href=\"#NotableCases\"><span class=\"fa fa-list\"></span>Cases</a></li>");
                }
                if (UP.MembershipAndAccreditations_Status == "Yes")
                {
                    _NewContents.AppendLine("                                        <li><a href=\"#Membership\"><span class=\"fa fa-trophy\"></span>Membership</a></li>");
                }
                if (UP.Dir_RecAndAwards_Status == "Yes")
                {
                    _NewContents.AppendLine("                                        <li><a href=\"#Awards\"><span class=\"fa fa-trophy\"></span>Awards</a></li>");
                }
                if (UP.Personal_Interests_Status == "Yes")
                {
                    _NewContents.AppendLine("                                        <li><a href=\"#Interests\"><span class=\"fa fa-umbrella\"></span>Interests</a></li>");
                }
                if (Articles_Links != null)
                {
                    _NewContents.AppendLine("                                        <li><a href=\"#Articles\"><span class=\"fa fa-list-alt\"></span>Articles</a></li>");
                }
            }
            _NewContents.AppendLine("                                    </ul>");
            _NewContents.AppendLine("                                </div>");
            _NewContents.AppendLine("                            </div>");
            _NewContents.AppendLine("                        </div>");
            _NewContents.AppendLine("                    </nav>");

            _NewContents.AppendLine("                    <div id=\"Profile\" class=\"container-fluid\">");
            _NewContents.AppendLine("                        <h3 class=\"" + cssclass + " lightkolor\">Profile / Experience<span class=\"fa fa-user-circle\"></span></h3>");
            _NewContents.AppendLine("                        <div class=\"sectionbody\">");

            if (wa != null && wa.Count() > 0)
            {

                _NewContents.AppendLine("                            <div class=\"legaldirectorypanel " + cssclass + " lightkolor deptbordercolor\">");
                _NewContents.AppendLine("                                <div class=\"row nopadding\">");
                _NewContents.AppendLine("                                    <div class=\"col-sm-4 nopadding\">");
                _NewContents.AppendLine("                                        <div class=\"awardtext\">Awards and Recommendations for " + staffname + "</div>");
                _NewContents.AppendLine("                                        <div class=\"legaldirectoryimgdiv\">");

                if (otherlogos != null)
                {
                    foreach (var item in otherlogos)
                    {
                        _NewContents.AppendLine("                                             <img style=\"border:solid 1px #000\" src=\"/Images/" + item + "\" alt=\"" + item + "\" />");
                    }
                }

                if (legal500logo != "")
                    _NewContents.AppendLine("                                            <img style=\"border:solid 1px #000\" src=\"/Images/" + legal500logo + "\" alt=\"Legal 500\" />");

                if (chamberslogo != "")
                    _NewContents.AppendLine("                                             <img style=\"border:solid 1px #000\" src=\"/Images/" + chamberslogo + "\" alt=\"Chambers\" />");




                _NewContents.AppendLine("                                        </div>");
                _NewContents.AppendLine("                                    </div>");
                _NewContents.AppendLine("                                    <div class=\"col-sm-8 nopadding\">");
                _NewContents.AppendLine("                                        <div class=\"row legaldirectory " + cssclass + " deptbordercolor\">");
                int i = 0;
                foreach (var item in wa)
                {
                    i++;
                    if (i == 3)
                    {
                        _NewContents.AppendLine("                                            <div class=\"col-sm-12 nopadding\">");
                        _NewContents.AppendLine("                                                <div class=\"row collapse nopadding\" id=\"moredirectorylisting\">");
                    }
                    _NewContents.AppendLine("                                            <div class=\"col-sm-12 nopadding\">");
                    _NewContents.AppendLine("                                                <div class=\"legaldirectoryblurb " + cssclass + " lightkolor\">");
                    _NewContents.AppendLine("                                                    <p class=\"" + cssclass + " lightkolor\">" + item.Blurb + "</p>");
                    _NewContents.AppendLine("                                                    <span class=\"" + cssclass + " forecolor deptbordercolor\">" + item.LegalDirectory.Replace("Leading Individual", "Legal 500").Replace("Next Generation Partner", "Legal 500") + " " + item.Year + " Edition.<br />" + item.LegalDirectoryDepartment + " / " + item.LegalDirectoryArea + "</span>");
                    _NewContents.AppendLine("                                                </div>");
                    _NewContents.AppendLine("                                            </div>");
                }
                if (i > 2)
                {
                    _NewContents.AppendLine("                                                </div>");
                    _NewContents.AppendLine("                                                <a class=\"legaldirectoryviewmore " + cssclass + " forecolor\" href=\"#moredirectorylisting\" data-toggle=\"collapse\"></a>");
                    _NewContents.AppendLine("                                            </div>");
                }
                


                _NewContents.AppendLine("                                        </div>");
                _NewContents.AppendLine("                                    </div>");
                _NewContents.AppendLine("                                </div>");
                _NewContents.AppendLine("                            </div>");
            }

            var _introVideo = dbit.Website_Videos.Where(x => x.emp_code == staffcode && x.Staff_Profile_Video == true).FirstOrDefault();
            if (_introVideo != null && _introVideo.VideoString != null)
            {
                _NewContents.AppendLine("<h6 font-size=\"14px\">Video Introduction of " + staffname + "</h6><br />");
                _NewContents.AppendLine(_introVideo.VideoString + "<br /><br />");
            }

            if (UP != null)
            {
                
                if ((UP.Profile2 != null && UP.Profile2.Length > 10) || (UP.Profile3 != null && UP.Profile3.Length > 10) || (UP.Profile4 != null && UP.Profile4.Length > 10))
                {
                    
                    _NewContents.AppendLine(UP.Profile);

                    if (UP.Profile2.ToString() != null && UP.Profile2.Length > 10)
                    {
                        _NewContents.AppendLine("<div class=\"extradept\" id=\"extradept" + UP.Dept2.Replace(" ", "") + "\">");
                        _NewContents.AppendLine("<h6 font-size=\"14px\">" + UP.Dept2 + "</h6>");
                        _NewContents.AppendLine(UP.Profile2);
                        _NewContents.AppendLine("                        </div>");
                    }


                    if (UP.Profile3.ToString() != null && UP.Profile3.Length > 10)
                    {

                        _NewContents.AppendLine("<div class=\"extradept\" id=\"extradept" + UP.Dept3.Replace(" ", "") + "\">");
                        _NewContents.AppendLine("<h6 font-size=\"14px\">" + UP.Dept3 + "</h6>");
                        _NewContents.AppendLine(UP.Profile3);
                        _NewContents.AppendLine("                        </div>");
                    }


                    if (UP.Profile4.ToString() != null && UP.Profile4.Length > 10)
                    {
                        //_NewContents.AppendLine("<a href=\"#\" name=\"" + UP.Dept4.Replace(" ", "") + "\">&nbsp;</a>");
                        _NewContents.AppendLine("<div class=\"extradept\" id=\"extradept" + UP.Dept4.Replace(" ", "") + "\">");
                        _NewContents.AppendLine("<h6 font-size=\"14px\">" + UP.Dept4 + "</h6>");
                        _NewContents.AppendLine(UP.Profile4);
                        _NewContents.AppendLine("                        </div>");
                    }

                }
                else
                {
                    _NewContents.AppendLine(UP.Profile);
                }
            }
            else
                _NewContents.AppendLine(Pro.ToString());

            var _subDepartmentProfile = dbit.SubDepartmentProfiles.Where(x => x.emp_code == staffcode && x.ApprovedProfile != null && x.ApprovedProfile.Length >20).ToList();
            if (_subDepartmentProfile != null)
            {
                _NewContents.AppendLine("<ul>");
                foreach (var subDepartmentProfile in _subDepartmentProfile)
                {
                    _NewContents.AppendLine("<li><a href=\"/" + subDepartmentProfile.SubDepartmentProfileStructure.SubDepartment.Replace(" ", "-").Replace("&", "and").Replace("/", "-") + "_ourteam/" + staffname.Replace(" ", "_").Replace("&", "and").Replace(" ", "") + ".html" + "\">View " + staffname + "’s \"" + subDepartmentProfile.SubDepartmentProfileStructure.SubDepartment + "\" profile</a></li>");
                }
                _NewContents.AppendLine("</ul><br /><br />");
            }


            _NewContents.AppendLine("                        </div>");
            _NewContents.AppendLine("                    </div>");
            if (UP != null)
            {
                if (UP.Education_Status == "Yes")
                {
                    _NewContents.AppendLine("                    <div id=\"Education\" class=\"container-fluid\">");
                    _NewContents.AppendLine("                        <h3 class=\"" + cssclass + " lightkolor\">Education<span class=\"fa fa-graduation-cap\"></span></h3>");
                    _NewContents.AppendLine("                        <div class=\"sectionbody\">");
                    _NewContents.AppendLine(UP.Education);
                    _NewContents.AppendLine("                        </div>");
                    _NewContents.AppendLine("                    </div>");
                }
                if (UP.Career_Status == "Yes")
                {
                    _NewContents.AppendLine("                    <div id=\"Careers\" class=\"container-fluid\">");
                    _NewContents.AppendLine("                        <h3 class=\"" + cssclass + " lightkolor\">Career<span class=\"fa fa-suitcase\"></span></h3>");
                    _NewContents.AppendLine("                        <div class=\"sectionbody\">");
                    _NewContents.AppendLine(UP.Career);
                    _NewContents.AppendLine("                        </div>");
                    _NewContents.AppendLine("                    </div>");
                }
                if (UP.Client_Comments_Status == "Yes")
                {
                    _NewContents.AppendLine("                    <div id=\"Testimonials\" class=\"container-fluid\">");
                    _NewContents.AppendLine("                        <h3 class=\"" + cssclass + " lightkolor\">Testimonials<span class=\"fa fa-suitcase\"></span></h3>");
                    _NewContents.AppendLine("                        <div class=\"sectionbody\">");
                    _NewContents.AppendLine(UP.Client_Comments);
                    _NewContents.AppendLine("                        </div>");
                    _NewContents.AppendLine("                    </div>");
                }
                if (UP.Dir_RecAndAwards_Status == "Yes")
                {
                    _NewContents.AppendLine("                    <div id=\"Awards\" class=\"container-fluid\">");
                    _NewContents.AppendLine("                        <h3 class=\"" + cssclass + " lightkolor\">Awards<span class=\"fa fa-suitcase\"></span></h3>");
                    _NewContents.AppendLine("                        <div class=\"sectionbody\">");
                    _NewContents.AppendLine(UP.Dir_RecAndAwards);
                    _NewContents.AppendLine("                        </div>");
                    _NewContents.AppendLine("                    </div>");
                }
                if (UP.Supreme_Court_Status == "Yes" || UP.Court_of_Appeal_Status == "Yes" || UP.High_Court_Status == "Yes" || UP.Criminal_Court_Status == "Yes" || UP.Civil_Court_Status == "Yes" || UP.Other_Supreme_Court_Status == "Yes" || UP.Other_Court_of_Appeal_Status == "Yes" || UP.Other_High_Court_Status == "Yes" || UP.Other_Criminal_Court_Status == "Yes" || UP.Other_Civil_Court_Status == "Yes")
                {
                    _NewContents.AppendLine("                    <div id=\"NotableCases\" class=\"container-fluid\">");
                    _NewContents.AppendLine("                        <h3 class=\"" + cssclass + " lightkolor\">Notable Cases<span class=\"fa fa-list\"></span></h3>");
                    _NewContents.AppendLine("                        <div class=\"sectionbody\">");

                    if (UP.Supreme_Court_Status == "Yes" || UP.Other_Supreme_Court_Status == "Yes")
                    {
                        _NewContents.AppendLine("                            <h6>Supreme Court</h6>");
                    }

                    if (UP.Supreme_Court_Status == "Yes")
                    {
                        _NewContents.AppendLine(UP.Supreme_Court);
                        _NewContents.AppendLine("                            <br>");

                    }
                    if (UP.Other_Supreme_Court_Status == "Yes")
                    {
                        _NewContents.AppendLine(UP.Other_Supreme_Court);
                        _NewContents.AppendLine("                            <br>");
                    }

                    if (UP.Court_of_Appeal_Status == "Yes" || UP.Other_Court_of_Appeal_Status == "Yes")
                    {
                        _NewContents.AppendLine("                            <h6>Court of Appeal</h6>");
                    }

                    if (UP.Court_of_Appeal_Status == "Yes")
                    {
                        _NewContents.AppendLine(UP.Court_of_Appeal);
                        _NewContents.AppendLine("                            <br>");

                    }
                    if (UP.Other_Court_of_Appeal_Status == "Yes")
                    {
                        _NewContents.AppendLine("                            <br>");
                        _NewContents.AppendLine(UP.Other_Court_of_Appeal);
                    }

                    if (UP.High_Court_Status == "Yes" || UP.Other_High_Court_Status == "Yes")
                    {
                        _NewContents.AppendLine("                            <h6>High Court</h6>");
                    }

                    if (UP.High_Court_Status == "Yes")
                    {
                        _NewContents.AppendLine(UP.High_Court);
                        _NewContents.AppendLine("                            <br>");
                    }
                    if (UP.Other_High_Court_Status == "Yes")
                    {
                        _NewContents.AppendLine(UP.Other_High_Court);
                        _NewContents.AppendLine("                            <br>");
                    }

                    if (UP.Criminal_Court_Status == "Yes" || UP.Other_Criminal_Court_Status == "Yes")
                    {
                        _NewContents.AppendLine("                            <h6>Criminal Court</h6>");
                    }
                    if (UP.Criminal_Court_Status == "Yes")
                    {
                        _NewContents.AppendLine(UP.Criminal_Court);
                        _NewContents.AppendLine("                            <br>");

                    }
                    if (UP.Other_Criminal_Court_Status == "Yes")
                    {
                        _NewContents.AppendLine(UP.Other_Criminal_Court);
                        _NewContents.AppendLine("                            <br>");
                    }

                    if (UP.Civil_Court_Status == "Yes" || UP.Other_Civil_Court_Status == "Yes")
                    {
                        _NewContents.AppendLine("                            <h6>Civil Court</h6>");
                    }

                    if (UP.Civil_Court_Status == "Yes")
                    {
                        _NewContents.AppendLine(UP.Civil_Court);
                        _NewContents.AppendLine("                            <br>");
                    }
                    if (UP.Other_Civil_Court_Status == "Yes")
                    {
                        _NewContents.AppendLine(UP.Other_Civil_Court);
                        _NewContents.AppendLine("                            <br>");
                    }
                    _NewContents.AppendLine("                        </div>");
                    _NewContents.AppendLine("                    </div>");
                }
                if (UP.MembershipAndAccreditations_Status == "Yes")
                {
                    _NewContents.AppendLine("                    <div id=\"Membership\" class=\"container-fluid\">");
                    _NewContents.AppendLine("                        <h3 class=\"" + cssclass + " lightkolor\">Membership & Accreditations<span class=\"fa fa-trophy\"></span></h3>");
                    _NewContents.AppendLine("                        <div class=\"sectionbody\">");
                    _NewContents.AppendLine(UP.MembershipAndAccreditations);
                    _NewContents.AppendLine("                        </div>");
                    _NewContents.AppendLine("                    </div>");
                }
                if (UP.Personal_Interests_Status == "Yes")
                {
                    _NewContents.AppendLine("                    <div id=\"Interests\" class=\"container-fluid\">");
                    _NewContents.AppendLine("                        <h3 class=\"" + cssclass + " lightkolor\">Interests<span class=\"fa fa-umbrella\"></span></h3>");
                    _NewContents.AppendLine("                        <div class=\"sectionbody\">");
                    _NewContents.AppendLine(UP.Personal_Interests);
                    _NewContents.AppendLine("                        </div>");
                    _NewContents.AppendLine("                    </div>");
                }
                if (Articles_Links.Count() > 0)
                {
                    _NewContents.AppendLine("                    <div id=\"Articles\" class=\"container-fluid\">");
                    _NewContents.AppendLine("                        <h3 class=\"" + cssclass + " lightkolor\">Articles<span class=\"fa fa-list-alt\"></span></h3>");
                    _NewContents.AppendLine("                        <div class=\"sectionbody\">");
                    _NewContents.AppendLine("<ul>");
                    foreach (var item in Articles_Links)
                    {
                        _NewContents.AppendLine(item);
                    }
                    _NewContents.AppendLine("</ul>");
                    _NewContents.AppendLine("                        </div>");
                    _NewContents.AppendLine("                    </div>");
                }
            }
            _NewContents = allStatic.replacelinespacewithbr(_NewContents);
            return _NewContents;

 	
}
}
}
