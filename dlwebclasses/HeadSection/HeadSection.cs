using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class HeadSection:AHeadSection
    {

        public override StringBuilder getheadsection(AContents _Contents)
        {
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<head>");
            SB.AppendLine("<link rel=\"icon\" href=\"http://www.duncanlewis.co.uk/images/favicon.ico\" type=\"image/x-icon\" /> ");
            SB.AppendLine("<link rel=\"shortcut icon\" href=\"http://www.duncanlewis.co.uk/images/favicon.ico\" type=\"image/x-icon\" />");
            SB.AppendLine("<link href='http://fonts.googleapis.com/css?family=Paytone+One' rel='stylesheet' type='text/css'>");
            SB.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            SB.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"> ");
            SB.AppendLine("<title>" + _Contents.title + "</title>");
            SB.AppendLine("<meta name=\"description\" content=\"" + _Contents.description + "\"/>");
            SB.AppendLine("<meta name=\"keywords\" content=\"" + _Contents.keywords + "\"/>");
            SB.AppendLine("<meta name=\"ROBOTS\" content=\"INDEX, FOLLOW\"/> <meta name=\"YahooSeeker\" content=\"INDEX, FOLLOW\"/> <meta name=\"msnbot\" content=\"INDEX, FOLLOW\"/> <meta name=\"googlebot\" content=\"INDEX, FOLLOW\"/>");
            SB.AppendLine("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            SB.AppendLine("<link href=\"../css/stylesheet.css\" rel=\"stylesheet\" type=\"text/css\" />");
            SB.AppendLine("<link rel=\"stylesheet\" href=\"../css/text.css\" type=\"text/css\" title=\"A\" />");
            SB.AppendLine("<link rel=\"alternate stylesheet\" href=\"../css/text-A+.css\" type=\"text/css\" title=\"A+\" />");
            SB.AppendLine("<link rel=\"alternate stylesheet\" href=\"../css/text-A++.css\" type=\"text/css\" title=\"A++\" />");
            SB.AppendLine("<link href=\"../css/bootstrap.css\" rel=\"stylesheet\">");
            SB.AppendLine("<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js\"></script>");
            SB.AppendLine("<script language=\"JavaScript1.2\" src=\"../js/styleswitcher.js\" type=\"text/javascript\"></script>");
            SB.AppendLine("<script src=\"../js/bootstrap.min.js\"></script>");
            SB.Append("</head>");



            return SB;
        }
    }
}
