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
        public CreateHTMLFIles_NEwWebsite(AContents NAL, string filepath = "", Website_Pages webpage = null)
        {
            GenerateWebPages_NewWebsite GWP = new GenerateWebPages_NewWebsite(NAL, webpage);
            StreamWriter fp;
            if (string.IsNullOrEmpty(filepath))
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


        public void Create_GeneralFooter()
        {
            StreamWriter fp;
            fp = System.IO.File.CreateText(ConfigurationManager.AppSettings["RootpathNewWebsite"].ToString() + "\\" + "Footer.html");
            Footer_NewWebsite _footer = new Footer_NewWebsite();
            Content_HomePage NAL = NAL = new Content_HomePage(HomePagetype.Main);
            NAL.getcontents();
            fp.WriteLine(_footer.getfooter(NAL));
            fp.Close();
        }
    }
}
