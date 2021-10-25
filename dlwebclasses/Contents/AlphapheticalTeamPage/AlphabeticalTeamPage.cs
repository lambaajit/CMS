using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace dlwebclasses
{
    public class AlphabeticalTeamPage
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string HeadingH1 { get; set; }
        public string Department { get; set; }
        public StringBuilder Contents { get; set; }
        public string filepath { get; set; }

        public AlphabeticalTeamPage(char Alphabet)
        {
            Title = "Solicitors| lawyers | Trainees | our team | Duncan Lewis";
            Description = "Duncan Lewis has over 500 solicitors, Lawyers, trainees, caseworkers and administrative staff working at its offices nationwide.";
            Keywords = "Solicitor, Solicitor in London, legal aid solicitor, lawyers, specialist solicitor, solicitors speaking a language, solicitor profiles, solicitor in London, solicitor in Birmingham, solicitor in Cardiff, solicitor in Leicester, Legal Help, Solicitors in Middlesex, UK Solicitors, solicitors at Duncan Lewis, directors at Duncan Lewis, staff at Duncan Lewis, Legal 500 solicitors, Chambers listed solicitors, solicitor panel members, law society accredited solicitors";
            Department = "About Us";
            HeadingH1 = "Our Team";
            filepath = ConfigurationManager.AppSettings["Rootpath"].ToString() + "\\Our_Team_Alphabetic_" + Alphabet + ".html";

            HRDDLEntities db = new HRDDLEntities();

            List<Emp_Details> ED = new List<Emp_Details>();
            IEnumerable<Emp_Details> ED1;
            ED1 = allStatic.getcurrentemployedstafflist();
            List<string> WDS= new List<String>();
            IT_DatabaseEntities db1 = new IT_DatabaseEntities();
            WDS = db1.Website_Department_Structure.Where(x => x.departmenttype == "AreaOfLaw").Select(x => x.Name).ToList();
            ED = ED1.Where(x => (x.forename.StartsWith(Alphabet.ToString())) && x.Profile_website == true && WDS.Contains(x.department_it)).OrderBy(x => x.forename).ToList();
            StringBuilder SB = new StringBuilder();

            foreach (Emp_Details _ed in ED)
            {
                string Name = _ed.forename + ' ' + _ed.surname;
                string Jobtitle = allStatic.filterjobtitle(_ed);
                string _Office = _ed.Office.office_name.Replace("Dalston", "Hackney");

                string name1 = "";
                if (Name.Length > 16)
                {
                    name1 = _ed.forename.ToString().Substring(0, 1) + " " + _ed.surname.ToString();
                    if (name1.Length > 16)
                        name1 = name1.Substring(0, 16).ToString();
                }
                else
                    name1 = Name;

                string rewriteurllink = allStatic.getRewriteUrlLinkForStaff(_ed);




                SB.AppendLine("<div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12 nopadding\"><div class=\"ourpeoplediv\"><a href=\"" + rewriteurllink + "/\">" + name1 + "</a><p>" + _Office + "</p></div></div>");
            }


            StringBuilder SB1 = new StringBuilder();

            SB1.AppendLine("    <div class=\"alphabets\">");
            for (int vf = 65; vf <= 90; vf++)
            {
                if ((char)vf == Alphabet)
                {
                    SB1.AppendLine("<a href=\"Our_Team_Alphabetic_" + (char)vf + ".html\"><font color=\"#0b1a55\">" + (char)vf + "</font></a>");
                }
                else
                {
                    SB1.AppendLine("<a href=\"Our_Team_Alphabetic_" + (char)vf + ".html\">" + (char)vf + "</a>");
                }
            }
            SB1.AppendLine("</div>");


            SB1.AppendLine("    <div class=\"container-fluid\">    ");
            SB1.AppendLine("        <div class=\"row\">");
            SB1.AppendLine("<div class=\"col-lg-12 nopadding\">");



                SB1.AppendLine("    <div class=\"container-fluid\">    ");
                SB1.AppendLine("        <div class=\"row\">");
                SB1.AppendLine("    <div class=\"container-fluid\">    ");
                SB1.AppendLine("        <div class=\"row\" style=\"border-bottom:Solid 10px #74d1f6;\">");
                SB1.AppendLine("            <div class=\"col-lg-4 col-sm-4 col-md-4 hidden-xs\">");
                SB1.AppendLine("            &nbsp;");
                SB1.AppendLine("            </div>");
                SB1.AppendLine("            <div id=\"staff_nav\" class=\"col-lg-8 col-sm-8 col-md-8 col-xs-12\">");
                SB1.AppendLine("      <h3>Staff Listing (Alphabet - " + Alphabet + ")</h3>");
                SB1.AppendLine("            </div>");
                SB1.AppendLine("        </div>");
                SB1.AppendLine("        </div>    ");


                SB1.AppendLine("    <div id=\"maincontent\">");
                SB1.AppendLine(SB.ToString());
                SB1.AppendLine("    </div>");



            SB1.AppendLine("    </div> ");
            SB1.AppendLine("    </div> ");
            SB1.AppendLine("    </div> ");
            SB1.AppendLine("    </div> ");
            SB1.AppendLine("    </div> ");

            Contents = SB1;
            filepath = ConfigurationManager.AppSettings["Rootpath"] + "\\Our_Team_Alphabetic_" + Alphabet + ".html";
        }
    }
}
