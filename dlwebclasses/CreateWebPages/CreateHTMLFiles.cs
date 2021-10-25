using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dlwebclasses
{
    public class CreateHTMLFiles
    {
        public CreateHTMLFiles(AContents NAL, string filepath = "")
        {
            GenerateWebPage GWP = new GenerateWebPage(NAL);
            StreamWriter fp;
            if (filepath == "")
                fp = System.IO.File.CreateText(NAL.filepath);
            else
                fp = System.IO.File.CreateText(filepath);

            fp.WriteLine(GWP.PageContent);
            fp.Close();
        }

    }
}
