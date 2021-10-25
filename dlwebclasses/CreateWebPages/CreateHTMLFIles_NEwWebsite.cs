using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace dlwebclasses
{
    public class CreateHTMLFIles_NEwWebsite
    {
        public CreateHTMLFIles_NEwWebsite(AContents NAL, string filepath = "")
        {
            GenerateWebPages_NewWebsite GWP = new GenerateWebPages_NewWebsite(NAL);
            StreamWriter fp;
            if (filepath == "")
                fp = System.IO.File.CreateText(NAL.filepath);
            else
                fp = System.IO.File.CreateText(filepath);

            fp.WriteLine(GWP.PageContent);
            fp.Close();
        }

        public void Create_MainNavigation()
        {
            StreamWriter fp;
            fp = System.IO.File.CreateText(ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\" + "MainNav.html");
            MainNavigationNewWebsite MN = new MainNavigationNewWebsite();
            fp.WriteLine(MN.getmainnavigation());
            fp.Close();
        }
    }
}
