using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Offices:AOffices
    {
        DLWEBEntities DLW = new DLWEBEntities();
        public string department { get; set; }
        public Offices()
        {
            department = "Solicitor in ";
        }
        public Offices(string dept)
        {
            department = dept + " Solicitor in ";
        }
        public override StringBuilder getofficesInLondon()
        {

            List<OfficeDLW> li = new List<OfficeDLW>();
            li = DLW.OfficesDLW.Where(x => x.In_Out_London == "In" && (x.Company == "Duncan Lewis" || x.Company == "Both")).ToList();
            StringBuilder Officelist = new StringBuilder();
            foreach (OfficeDLW l1 in li)
            {
                Officelist.AppendLine("<li><a href=\"/offices/" + l1.Name + "-Solicitors.html\">" + department + l1.Name + "</a></li>");
            }
            return Officelist;
        }

        public override StringBuilder getofficesOutLondon()
        {
            List<OfficeDLW> li = new List<OfficeDLW>();
            li = DLW.OfficesDLW.Where(x => x.In_Out_London == "Out" && (x.Company == "Duncan Lewis" || x.Company == "Both")).ToList();
            StringBuilder Officelist = new StringBuilder();
            foreach (OfficeDLW l1 in li)
            {
                Officelist.AppendLine("<li><a href=\"/offices/" + l1.Name + "-Solicitors.html\">" + department +l1.Name + "</a></li>");
            }
            return Officelist;
        }

        public override List<string> getofficesInLondonList()
        {
            List<OfficeDLW> li = new List<OfficeDLW>();
            li = DLW.OfficesDLW.Where(x => x.In_Out_London == "In" && x.Active == true && (x.Company == "Duncan Lewis" || x.Company == "Both")).OrderBy(y => y.Name).ToList();
            List<string> Officelist = new List<string>();
            foreach (OfficeDLW l1 in li)
            {
                Officelist.Add("<li><a href=\"/offices/" + l1.Name + "-Solicitors.html\">" + department + l1.Name + "</a></li>");
            }
            return Officelist;
        }

        public override List<string> getofficesOutLondonList()
        {
            List<OfficeDLW> li = new List<OfficeDLW>();
            li = DLW.OfficesDLW.Where(x => x.In_Out_London == "Out" && x.Active == true && (x.Company == "Duncan Lewis" || x.Company == "Both")).OrderBy(y => y.Name).ToList();
            List<string> Officelist = new List<string>();
            foreach (OfficeDLW l1 in li)
            {
                Officelist.Add("<li><a href=\"/offices/" + l1.Name + "-Solicitors.html\">" + department + l1.Name + "</a></li>");
            }
            return Officelist;
        }
    }
}
