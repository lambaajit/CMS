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

        public override List<string> getofficesInLondonList(Website_Pages webpage = null)
        {
            List<OfficeDLW> li = new List<OfficeDLW>();
            li = DLW.OfficesDLW.Where(x => x.In_Out_London == "In" && x.Active == true && (x.Company == "Duncan Lewis" || x.Company == "Both")).OrderBy(y => y.Name).ToList();
            List<string> Officelist = new List<string>();
            string _prefixFOrOffice = department;
            if (webpage != null)
                _prefixFOrOffice = GetPrefix(webpage, _prefixFOrOffice);
            foreach (OfficeDLW l1 in li)
            {
                Officelist.Add("<li><a href=\"/offices/" + l1.Name + "-Solicitors.html\">" + (_prefixFOrOffice.Contains("Solicitor") ? " " + _prefixFOrOffice + " " : " " + _prefixFOrOffice + " Solicitors ") + l1.Name + "</a></li>");
            }
            return Officelist;
        }



        public override List<string> getofficesOutLondonList(Website_Pages webpage = null)
        {
            List<OfficeDLW> li = new List<OfficeDLW>();
            li = DLW.OfficesDLW.Where(x => x.In_Out_London == "Out" && x.Active == true && (x.Company == "Duncan Lewis" || x.Company == "Both")).OrderBy(y => y.Name).ToList();
            List<string> Officelist = new List<string>();
            string _prefixFOrOffice = department;
            if (webpage != null)
                _prefixFOrOffice = GetPrefix(webpage, _prefixFOrOffice);
            foreach (OfficeDLW l1 in li)
            {
                Officelist.Add("<li><a href=\"/offices/" + l1.Name + "-Solicitors.html\">" + (_prefixFOrOffice.Contains("Solicitor") ? " " + _prefixFOrOffice + " " : " " + _prefixFOrOffice + " Solicitors ") + l1.Name + "</a></li>");
            }
            return Officelist;
        }

        private static string GetPrefix(Website_Pages webpage, string _prefixFOrOffice)
        {
            IT_DatabaseEntities db = new IT_DatabaseEntities();
            var _websiteStructureContentNode = db.Website_Structure.Where(x => x.linkedid == webpage.ID).FirstOrDefault();
            if (_websiteStructureContentNode != null)
            {
                if (_websiteStructureContentNode.IsTextUsedOnFooter != true)
                {
                    var _websiteStructureUnderwhichNode = db.Website_Structure.Where(x => x.id == _websiteStructureContentNode.underwhichnode && x.IsTextUsedOnFooter == true).FirstOrDefault();
                    if (_websiteStructureUnderwhichNode != null)
                        _prefixFOrOffice = _websiteStructureUnderwhichNode.name;
                }
                else
                    _prefixFOrOffice = !string.IsNullOrEmpty(_websiteStructureContentNode.TextUsedOnFooter) ? _websiteStructureContentNode.TextUsedOnFooter : _websiteStructureContentNode.name;
            }
            return _prefixFOrOffice;
        }
    }
}
