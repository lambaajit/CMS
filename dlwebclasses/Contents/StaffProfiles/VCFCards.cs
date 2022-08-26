using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dlwebclasses.Contents.StaffProfiles
{
    public static class VCFCards
    {

        public static HRDDLEntities db = new HRDDLEntities();
        public static void generateVCFCards()
        {
            foreach (var item in db.Emp_Details.Where(x => x.employed == "1").ToList())
            {
                var office = db.Offices.Where(x => x.office_code == item.office_code).Select(x => x.office_address).FirstOrDefault();
                using (StreamWriter writetext = new StreamWriter("C:\\inetpub\\wwwroot\\DuncanLewis_NewWebsite_Revised\\VCFCards\\" + item.forename + " " + item.surname + ".vcf"))
                {
                    writetext.WriteLine("BEGIN:VCARD");
                    writetext.WriteLine("VERSION:2.1");
                    writetext.WriteLine("N:" + item.surname + ";" + item.forename + "");
                    writetext.WriteLine("FN:" + item.forename + " " + item.surname + "");
                    writetext.WriteLine("ORG:Duncan Lewis (Solicitors) Ltd");
                    writetext.WriteLine("TITLE:" + item.jobtitle + "");
                    writetext.WriteLine("NOTE:");
                    writetext.WriteLine("TEL;WORK;VOICE:+44 " + item.direct_dial_tel_number + "");
                    writetext.WriteLine("TEL;HOME;VOICE:+44 ");
                    writetext.WriteLine("TEL;WORK;FAX:+44 2031190846");
                    writetext.WriteLine("TEL;PREF:");
                    writetext.WriteLine("ADR;WORK:;;" + office.Replace(",",";") + "");
                    writetext.WriteLine("URL;WORK:http://www.duncanlewis.co.uk");
                    writetext.WriteLine("EMAIL;PREF;INTERNET:" + item.email + "");
                    writetext.WriteLine("REV:20220517T103820Z");
                    writetext.WriteLine("END:VCARD");

                }
            }
        }
    }
}
