using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class HeadSection_CostLaw : AHeadSection
    {
        public override StringBuilder getheadsection(AContents _Contents)
        {
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<head>");
            SB.AppendLine("<link rel=\"icon\" href=\"/images/favicon.ico\" type=\"image/x-icon\" /> ");
            SB.AppendLine("<link rel=\"shortcut icon\" href=\"/images/favicon.ico\" type=\"image/x-icon\" />");
            SB.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            SB.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"> ");
            SB.AppendLine("<link rel=\"canonical\" href=\"" + _Contents.canonicaltag + "\" />");
            SB.AppendLine("<title>" + _Contents.title + "</title>");
            SB.AppendLine("<link href=\"https://fonts.googleapis.com/css?family=Handlee&display=swap\" rel=\"stylesheet\">");
            SB.AppendLine("<meta name=\"description\" content=\"" + _Contents.description + "\"/>");
            SB.AppendLine("<meta name=\"keywords\" content=\"" + _Contents.keywords + "\"/>");
            SB.AppendLine("<meta name=\"ROBOTS\" content=\"INDEX, FOLLOW\"/> <meta name=\"YahooSeeker\" content=\"INDEX, FOLLOW\"/> <meta name=\"msnbot\" content=\"INDEX, FOLLOW\"/> <meta name=\"googlebot\" content=\"INDEX, FOLLOW\"/>");
            SB.AppendLine("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            SB.AppendLine("<link href=\"/Content/site.min.css?v=100821\" rel=\"stylesheet\"/>");
            SB.AppendLine("    <link href=\"/Content/bootstrap.min.css\" rel=\"stylesheet\"/>");
            SB.AppendLine("    <script src=\"/Scripts/modernizr-2.6.2.min.js\"></script>");
            SB.AppendLine("    <script src=\"/Scripts/jquery-3.3.1.min.js\"></script>");
            SB.AppendLine("     <script src=\"/Scripts/bootstrap.min.js\"></script>");
            SB.AppendLine("     <script src=\"/Scripts/respond.min.js\"></script>");
            SB.AppendLine("<link href=\"https://fonts.googleapis.com/css?family=Courgette&display=swap\" rel =\"stylesheet\">");
            SB.AppendLine("    <link href=\"/Content/font-awesome.min.css\" rel=\"stylesheet\" />");

            SB.AppendLine("<!-- Global site tag (gtag.js) - Google Analytics -->");
            SB.AppendLine("<script async src=\"https://www.googletagmanager.com/gtag/js?id=UA-136090359-3\"></script>");
            SB.AppendLine("<script>");
            SB.AppendLine("  window.dataLayer = window.dataLayer || [];");
            SB.AppendLine("  function gtag(){dataLayer.push(arguments);}");
            SB.AppendLine("  gtag('js', new Date());");
            SB.AppendLine("  gtag('config', 'UA-136090359-3');");
            SB.AppendLine("</script>");


            if (_Contents.filepath.Contains("Index"))
            {
                SB.AppendLine(" <script type=\"text/javascript\">");
                SB.AppendLine(" window.cookieconsent_options = {\"message\":\"We use cookies on our website to enhance your browsing experience and to improve our site. By continuing to use this website, you agree to our use of cookies in the manner described in our\",\"dismiss\":\"Accept\",\"learnMore\":\"Cookie Policy\",\"link\":\"/Cookie-Policy.html\",\"theme\":\"light-bottom\"};");
                SB.AppendLine(" </script>");
                SB.AppendLine(" <script type=\"text/javascript\" src=\"//cdnjs.cloudflare.com/ajax/libs/cookieconsent2/1.0.10/cookieconsent.min.js\"></script>");
            }
            //SB.AppendLine("<script src=\"/Scripts/auto-update-chrome.js\"></script>");


            SB.AppendLine("</head>");
            return SB;
        }
    }
}
