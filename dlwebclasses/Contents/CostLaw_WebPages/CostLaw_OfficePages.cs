using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class CostLaw_OfficePages
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }
        public string canonicaltag { get; set; }

        public CostLaw_OfficePages(int id,AContents _Acontent)
        {
            DLWEBEntities db = new DLWEBEntities();
            var office = db.OfficesDLW.Where(x => x.Active == true && (x.Company == "Cost Law" || x.Company == "Both") && x.ID == id).FirstOrDefault();

            Title = "Costs Draftsmen | Lawyers | " +office.Name+" | Cost Law Services";
            Description = "Specialist Nationwide Costs Draftsmen and Lawyers at Cost Law Services providing a full range of Legal Bill drafting services, Inter Partes and Legal aid in " + office.Name + ", " + office.County;
            Keywords = "Cost Draftsmen " + office.Name;
            HeadingH1 =  "Cost Draftsmen in " + office.Name;
            canonicaltag = "https://www.costlaw.com/Cost-Drafting-" + office.Name + ".html";
            filepath = ConfigurationManager.AppSettings["RootpathCostLawWebsite"].ToString() + "\\Cost-Drafting-" + office.Name + ".html";

           

            StringBuilder SB = new StringBuilder();

            SB.AppendLine("<div class=\"row nopadding\">");
            SB.AppendLine("    <div class=\"col-sm-12 map\">");

            SB.AppendLine(office.Google_Map_String);

            SB.AppendLine("    </div>");
            SB.AppendLine("</div>");


            SB.AppendLine("        <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-8 col-sm-offset-2 applyblock centerdiv officepage\">");

            SB.AppendLine("            <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-3\">");

            SB.AppendLine("            <div class=\"officelistpanel\">");
            SB.AppendLine("            <h2>Our Offices</h2>");
            SB.AppendLine("            <ul>");
            var officelist = db.OfficesDLW.Where(x => x.Active == true && (x.Company == "Cost Law" || x.Company == "Both")).ToList();
            foreach (var off in officelist)
            {
                SB.AppendLine("<li><i class=\"fa fa-building\">&nbsp;</i><a href=\"/Cost-Drafting-" + off.Name + ".html\">" + off.Name + "</a></li>");
            }
            SB.AppendLine("            </ul>");
            SB.AppendLine("                </div>");
            SB.AppendLine("                </div>");

            SB.AppendLine("            <div class=\"col-sm-9 address\">");
            SB.AppendLine("<h1>" + office.Name + " Office" + "</h1>");
            SB.AppendLine("            <div class=\"row nopadding\">");
            SB.AppendLine("            <div class=\"col-sm-6 address\">");
            SB.AppendLine("<h3>Address</h3>");
            SB.AppendLine("<p>" + office.Address.Replace(",", "<br />") + "</p>");
            SB.AppendLine("                </div>");

            SB.AppendLine("            <div class=\"col-sm-6 streetview\">");
            SB.AppendLine("<h3>Street View</h3>");
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            var wod = dbit.website_Office_Direction.Where(x => x.officeid == office.ID && x.Category_Of_Site == "Street View").FirstOrDefault(); ;
            if (wod!=null)
            {
                SB.AppendLine(wod.Map_Of_Site.Replace("450", "250").Replace("600","400"));
            }
            SB.AppendLine("                </div>");
            SB.AppendLine("                </div>");
            SB.AppendLine("                </div>");
            SB.AppendLine("                </div>");
            SB.AppendLine("                </div>");
            SB.AppendLine("                </div>");

            Contents = SB;
        }
        
    }
}
