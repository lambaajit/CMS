using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    class HeadSection_NewWebsite:AHeadSection
    {
        public override StringBuilder getheadsection(AContents _Contents)
        {
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<head>");
            SB.AppendLine("<link rel=\"icon\" href=\"https://www.duncanlewis.co.uk/images/favicon.ico\" type=\"image/x-icon\" /> ");
            SB.AppendLine("<link rel=\"shortcut icon\" href=\"https://www.duncanlewis.co.uk/images/favicon.ico\" type=\"image/x-icon\" />");
            SB.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            SB.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"> ");
            if (typeof(Content_NewsArticles_NewWebsite) == _Contents.GetType())
            {
                if (_Contents.rightcolcontents.ToString() != null && _Contents.rightcolcontents.ToString() != "No" && _Contents.rightcolcontents.ToString().Length > 10)
                {
                    SB.AppendLine(_Contents.rightcolcontents.ToString());
                }
            }
            else if (typeof(Content_Offices_NewWebsite) == _Contents.GetType())
            {
                SB.AppendLine("<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk/" + _Contents.filepath.Substring(_Contents.filepath.IndexOf("offices"), _Contents.filepath.Length - _Contents.filepath.IndexOf("offices")).Replace("\\","/") + "\" />");
            }
            else if (typeof(Content_NewsArticlesLandingPages_NewWebsite) == _Contents.GetType())
            {
                SB.AppendLine(_Contents.canonicaltag);
            }
            else if (typeof(Content_WebsitePages_NewWebsite) == _Contents.GetType())
            {
                SB.AppendLine(_Contents.canonicaltag);
            }
            else if (typeof(Content_StaffProfileNewWebsite) == _Contents.GetType())
            {
                SB.AppendLine(_Contents.canonicaltag);
            }
            else if (typeof(Content_JobsLanding_NewWebsite) == _Contents.GetType())
            {
                SB.AppendLine(_Contents.canonicaltag);
            }
            else if (typeof(Content_TeamPages_NewWebsite) == _Contents.GetType())
            {
                SB.AppendLine(_Contents.canonicaltag);
            }
            else if (_Contents.filepath.ToLower().Contains("index.html"))
            {
                SB.AppendLine("<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk/\" />");
            }
            else if (_Contents.filepath.ToLower().Contains("about.html"))
            {
                SB.AppendLine("<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk/about.html\" />");
            }
            else if (_Contents.filepath.ToLower().Contains("careers.html"))
            {
                SB.AppendLine("<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk/careers.html\" />");
            }
            else if (_Contents.filepath.ToLower().Contains("crime_ourteam.html"))
            {
                SB.AppendLine("<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk/crime_ourteam.html\" />");
            }
            else if (_Contents.filepath.ToLower().Contains("inthepress.html"))
            {
                SB.AppendLine("<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk/inthepress.html\" />");
            }
            else if (_Contents.filepath.ToLower().Contains("reportedcases.html"))
            {
                SB.AppendLine("<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk/reportedcases.html\" />");
            }
            else if (_Contents.filepath.ToLower().Contains("video.html"))
            {
                SB.AppendLine("<link rel=\"canonical\" href=\"https://www.duncanlewis.co.uk/video.html\" />");
            }


            SB.AppendLine("<title>" + _Contents.title + "</title>");
            SB.AppendLine("<meta name=\"description\" content=\"" + _Contents.description + "\"/>");
            SB.AppendLine("<meta name=\"keywords\" content=\"" + _Contents.keywords + "\"/>");
            SB.AppendLine("<meta name=\"ROBOTS\" content=\"INDEX, FOLLOW\"/> <meta name=\"YahooSeeker\" content=\"INDEX, FOLLOW\"/> <meta name=\"msnbot\" content=\"INDEX, FOLLOW\"/> <meta name=\"googlebot\" content=\"INDEX, FOLLOW\"/>");
            SB.AppendLine("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            SB.AppendLine("<link href=\"/Content/site.min.css\" rel=\"stylesheet\"/>");
            //SB.AppendLine("<link rel=\"stylesheet\" href=\"../css/text.css\" type=\"text/css\" title=\"A\" />");
            //SB.AppendLine("<link rel=\"alternate stylesheet\" href=\"../css/text-A+.css\" type=\"text/css\" title=\"A+\" />");
            //SB.AppendLine("<link rel=\"alternate stylesheet\" href=\"../css/text-A++.css\" type=\"text/css\" title=\"A++\" />");
            SB.AppendLine("    <link href=\"/Content/bootstrap.min.css\" rel=\"stylesheet\"/>");
            SB.AppendLine("    <script src=\"/Scripts/modernizr-2.6.2.min.js\"></script>");
            SB.AppendLine("    <script src=\"/Scripts/jquery.min.js\"></script>");
            SB.AppendLine("     <script src=\"/Scripts/bootstrap.min.js\"></script>");
            SB.AppendLine("     <script src=\"/Scripts/respond.min.js\"></script>");
            //SB.AppendLine("     <script src=\"/Scripts/CSSRefresh.js\"></script>");

            SB.AppendLine("<!-- Global site tag (gtag.js) - Google Analytics -->");
            SB.AppendLine("<script async src=\"https://www.googletagmanager.com/gtag/js?id=UA-2714165-1\"></script>");
            SB.AppendLine("<script>");
            SB.AppendLine("  window.dataLayer = window.dataLayer || [];");
            SB.AppendLine("  function gtag(){dataLayer.push(arguments);}");
            SB.AppendLine("  gtag('js', new Date());");

            SB.AppendLine("  gtag('config', 'UA-2714165-1');");
            SB.AppendLine("</script>");


            SB.AppendLine("    <script src=\"/Scripts/Custom.min.js?v=01052019\"></script>");            
            SB.AppendLine("<link href=\"https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,300i,700|Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i\" rel=\"stylesheet\">");
            SB.AppendLine("<link href=\"https://fonts.googleapis.com/css?family=Dosis\" rel=\"stylesheet\">");
            SB.AppendLine("    <link href=\"/Content/font-awesome-4.7.0/css/font-awesome.min.css\" rel=\"stylesheet\" />");
            //SB.AppendLine("<script src=\"/Scripts/auto-update-chrome.js\"></script>");

            if (_Contents.GetType() == typeof(Content_HomePage))
            {
                
                SB.AppendLine("<script type=\"text/javascript\" src=\"//widget.trustpilot.com/bootstrap/v5/tp.widget.bootstrap.min.js\" async></script>");
                SB.AppendLine("<script type=\"text/javascript\">");
                SB.AppendLine("window.cookieconsent_options = {\"message\":\"We use cookies on our website to enhance your browsing experience and to improve our site. By continuing to use this website, you agree to our use of cookies in the manner described in our\",\"dismiss\":\"Accept\",\"learnMore\":\"Cookie Policy\",\"link\":\"https://www.duncanlewis.co.uk/cookie-policy.html\",\"theme\":\"light-bottom\"};");
                SB.AppendLine("</script>");
                SB.AppendLine("<script type=\"text/javascript\" src=\"//cdnjs.cloudflare.com/ajax/libs/cookieconsent2/1.0.10/cookieconsent.min.js\"></script>");
 
            }

            if (_Contents.GetType() == typeof(Content_OfficesLanding_NewWebsite) || _Contents.GetType() == typeof(Content_HomePage))
            {
                SB.AppendLine("<link href=\"/Content/jquery-ui.min.css\" rel=\"stylesheet\" />");
                SB.AppendLine("<script src=\"/Scripts/jquery-ui.min.js\"></script>");
                SB.AppendLine("<script>");
                SB.AppendLine("$(function() {");
                SB.AppendLine("$(\"#dialog\").dialog({height:450, width:750});");
                SB.AppendLine("} );");
                SB.AppendLine("function closedialog(){");
                SB.AppendLine("$(\"#dialog\").dialog(\"close\");");
                SB.AppendLine("};");
                SB.AppendLine("</script>");
            }


            SB.AppendLine("</head>");
            return SB;
        }
    }
}
