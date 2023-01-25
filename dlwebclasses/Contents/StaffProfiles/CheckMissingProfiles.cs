using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class CheckMissingProfiles
    {
        public List<Emp_Details> getmissingprofiles(string company = null)
        {
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            HRDDLEntities hrdb = new HRDDLEntities();
            List<Emp_Details> _ed = new List<Emp_Details>();
            _ed = allStatic.getcurrentemployedstafflist();
            List<string> excludenames = new List<string>() { "Nina Joshi", "Shany Gupta", "Sridhar Ponnada" };
            _ed = _ed.Where(x => !excludenames.Contains(x.forename + " " + x.surname)).ToList();

            DateTime dt = DateTime.Now;

            if (company == null)
                _ed = _ed.Where(x => x.Profile_website == true && x.admin_staff == "0" && (x.reporting_consultant == false || x.reporting_consultant == null) && x.start_date < dt).ToList();
            else
                _ed = _ed.Where(x => x.company_name.Contains(company) && x.Profile_website == true && x.start_date < dt).ToList();

            List<Emp_Details> missinglist = new List<Emp_Details>();
            foreach (Emp_Details ed in _ed)
            {

                User_Profile_FinalDraft _up = new User_Profile_FinalDraft();
                _up = dbit.User_Profile_FinalDraft.Where(x => x.Emp_code == ed.emp_code).FirstOrDefault();
                if (_up == null)
                {
                    User_Profile _up1 = new User_Profile();
                    _up1 = dbit.User_Profile.Where(x => x.Emp_code == ed.emp_code).FirstOrDefault();
                    if (_up1 != null)
                    {
                        if (_up1.Status == false)
                            ed.bb_given = "Not Submitted by Fee earner";
                        else if (_up1.Quality_Status == false)
                            ed.bb_given = "Pending with Marketing Team";
                    }
                    else
                    {
                        ed.bb_given = "Not Submitted by Fee earner";
                    }
                        missinglist.Add(ed);
                }
            }
            return missinglist;
        }



        public List<Emp_Details> getmissingphotographs(string company = null)
        {
            IT_DatabaseEntities dbit = new IT_DatabaseEntities();
            HRDDLEntities hrdb = new HRDDLEntities();
            List<Emp_Details> _ed = new List<Emp_Details>();
            _ed = allStatic.getcurrentemployedstafflist();
            HRDDLEntities dbhr = new HRDDLEntities();
            List<string> excludenames = new List<string>() { "Azrina Bhunnoo",
"Karolina Natkaniec",
"Mohammed Kamran",
"Jarata Coker",
"Nazir Mirza",
"Lily J Meredith",
"Savvina Kostakou",
"Isabelle Piper",
"Gemma Motion",
"Usha Karathia",
"Dorcas Orimogunje",
"Angelique Hu ",
"Miranda Quashie",
"Vanessa Ugbo",
"Keziah Doudy-Yepmo",
"Miranda Quashie",
"Lily Kalati",
"Tommaso Poli",
"Rebecca Tomkins",
"Divinea Lyman",
"Oskar Butcher",
"Janine Williams",
"Emma Dawson",
"Shaista Ahmady",
"Hiba Warsame",
"Olivia Doherty",
"Eva Ford",
"Kyra Omondi",
"Naim Islam",
"Preeti Sarin",
"Joshua Munt",
"Daisy Tremlett",
"Chloe Palmer",
"Chloe Gilbert",
"Bunmi Alemoru",
"Yasmin Samra",
"Somayya Butt",
"Ezzatullah Zamani",
"Beatrice de Burgh",
"Oluwatobi Akinwande (Tobi)"
};
            DateTime dt = DateTime.Now;
            _ed = dbhr.Emp_Details.Where(x => x.employed == "1" && !x.forename.StartsWith("Donald") && !excludenames.Contains(x.forename + " " + x.surname)).OrderBy(x => x.office_code).ThenBy(x => x.forename).ToList();
            if (company == null)
                _ed = _ed.Where(x => x.start_date < dt && x.Profile_website == true && x.Picture_website == true && x.admin_staff == "0" && (x.reporting_consultant == false || x.reporting_consultant == null)).ToList();
            else
                _ed = _ed.Where(x => x.start_date < dt && x.company_name.Contains(company) && x.Profile_website == true && x.Picture_website == true).ToList();

            List<Emp_Details> missinglist = new List<Emp_Details>();
            foreach (Emp_Details ed in _ed)
            {
                if (System.IO.File.Exists("C:\\inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised_2017\\Photos\\StaffPics\\" + ed.forename + " " + ed.surname + ".png") == false)
                {
                    missinglist.Add(ed);
                }
            }
            return missinglist;
        }

    }
}
