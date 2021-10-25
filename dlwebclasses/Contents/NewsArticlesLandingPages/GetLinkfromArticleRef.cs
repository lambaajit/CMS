using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Configuration;

namespace dlwebclasses
{
    public class GetLinkfromArticleRef
    {
        public string GetLink(Updates_MainWebsites UM1, string dept = null, string fromwhere = "News Articles Landing Pages")
        {

               string Update_Title = "";
                string imgstr = "";
                string brief = "";
                string link = "";

                DepartmentDetails DD = new DepartmentDetails(UM1.Department);
                if (dept == null)
                {
                    dept = UM1.Department;
                }

                if (dept == "Reported Case" || dept == "InThePress")
                    if (dept == "Reported Case")
                    {
                        if (UM1.Contents.ToString().Length > 250)
                            brief = UM1.Contents.ToString().Substring(0, 250).Replace("*sm*", "<em>").Replace("*em*", "</em>");
                        else
                            brief = UM1.Contents.ToString().Replace("*sm*", "<em>").Replace("*em*", "</em>");
                    }
                    else
                        brief = UM1.Contents.ToString().Replace("*sm*", "<em>").Replace("*em*", "</em>");
                else
                    brief = UM1.Brief;

            if (fromwhere != "NewWebsite")
                if (dept == "Legal News")
                    imgstr = "<img style=\"padding-right:10px; padding-bottom:10px; float:left;\" src=\"images_newarticles/" + UM1.Blog_Department + ".jpg\" alt=\"Duncan Lewis:" + UM1.Department.ToString().Replace("'", "^") + "\" width=\"100px\" border=\"0px\" />";
                else if (UM1.Image == true && UM1.Department != "Reported Case" && UM1.Department != "InThePress")
                    imgstr = "<img style=\"padding-right:10px; padding-bottom:10px; float:left;\" src=\"http://www.duncanlewis.co.uk/ArticlesImages/" + UM1.ID + ".jpg\" alt=\"Duncan Lewis:" + UM1.Department.ToString().Replace("'", "^") + "\" width=\"100px\" border=\"0px\" />";
                else
                    imgstr = "<img style=\"padding-right:10px; padding-bottom:10px; float:left;\" src=\"http://www.duncanlewis.co.uk/ArticlesImages/DLStandardNewsImage.JPG\" alt=\"Duncan Lewis:" + UM1.Department.ToString().Replace("'", "^") + "\" width=\"100px\" border=\"0px\" />";
            else
                if (dept == "Legal News")
                    imgstr = "<img src=\"/images_newarticles/" + UM1.Blog_Department + ".jpg\" class=\"img-responsive\" alt=\"Duncan Lewis:" + UM1.Department.ToString().Replace("'", "^") + "\" />";
                else if (UM1.Image == true && UM1.Department != "Reported Case" && UM1.Department != "InThePress")
                    imgstr = "<img src=\"/ArticlesImages/" + UM1.ID + ".jpg\" class=\"img-responsive\" alt=\"Duncan Lewis:" + UM1.Department.ToString().Replace("'", "^") + "\" />";
                else
                    imgstr = "<img src=\"/ArticlesImages/DLStandardNewsImage.JPG\" class=\"img-responsive\" alt=\"Duncan Lewis:" + UM1.Department.ToString().Replace("'", "^") + "\" />";


                string Link_Title;
                Update_Title = UM1.Title.ToString().Replace("^", "'") + " (" + UM1.Date_Update.Value.Day + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(UM1.Date_Update.Value.Month) + " " + UM1.Date_Update.Value.Year + ")";
                Link_Title = UM1.filename.ToString().Replace("^", "") + " (" + UM1.Date_Update.Value.Day + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(UM1.Date_Update.Value.Month) + " " + UM1.Date_Update.Value.Year + ")";

                if (dept != "InThePress")
                    link = "/" + DD.folder1 + "/" + allStatic.refinenewarticlelink(Link_Title) + ".html";
                else
                    link = "/" + DD.folder1 + "/" + allStatic.refinenewarticlelink(UM1.filename) + ".pdf";

                string rtval;
                if (fromwhere == "News Articles Landing Pages")
                    rtval = "<div id=\"headsheadingthumb\" style=\"min-height:150px; display:block\"><h4>" + imgstr + "<a href=\"" + link + "\">" + Update_Title + "</a></h4><p>&nbsp;</p><p>" + brief + ". <a href=\"" + link + "\">&nbsp;&nbsp;Read more...</a></p></div>";
                else if (fromwhere == "NewWebsite")
                    rtval = "<div class=\"row nopadding newarticleslandingblock " + DD.cssclass + " deptbordercolor\"><div class=\"container\"><div class=\"col-sm-2 col-xs-4 nopadding\">" + imgstr + "</div><div class=\"col-sm-10 col-xs-8\"><h4><a class=\"" + DD.cssclass + " forecolor\" href=\"" + link + "\">" + Update_Title + "</a></h4><p>" + brief + "&nbsp;&nbsp;<a href=\"" + link + "\">Read more...</a></p></div></div></div>";
                else
                    rtval = "<li><a href=\"" + link + "\" style=\"padding-bottom:0px; margin-bottom:3px;\">" + Update_Title + "</a> </li>";
                

                return rtval;
        }
                    
    }
}
