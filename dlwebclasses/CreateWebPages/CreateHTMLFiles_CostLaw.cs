using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class CreateHTMLFiles_CostLaw
    {
        public CreateHTMLFiles_CostLaw(AContents NAL, string filepath = "")
        {
            GenerateWebPage_CostLaw GWP = new GenerateWebPage_CostLaw(NAL);
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
