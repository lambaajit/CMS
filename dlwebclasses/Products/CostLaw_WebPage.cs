using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class CostLaw_WebPage
    {
        private AContents _contents;
        private APageHeader _pageheader;
        private AHeadSection _headsection;
        private AFooter _footer;

        public CostLaw_WebPage(AWebPage WP, AContents _DContent)
        {
            _headsection = WP.createHeadSection();
            _pageheader = WP.CreatePageHeader();
            _footer = WP.CreateFooter();
            _contents = WP.CreateContent(_DContent);
            _contents.getcontents();
        }

        public StringBuilder getheadsection()
        {
            StringBuilder SB = new StringBuilder();
            SB = _headsection.getheadsection(_contents);
            return SB;
        }

        public StringBuilder getpageheader()
        {
            StringBuilder SB = new StringBuilder();
            SB = _pageheader.getpageheader();
            return SB;
        }
        public StringBuilder getfooter()
        {
            StringBuilder SB = new StringBuilder();
            //DepartmentDetails dd = new DepartmentDetails(_contents.Department);
            SB = _footer.getfooter(_contents);
            return SB;
        }

        public StringBuilder getcontents()
        {
            StringBuilder SB = new StringBuilder();
            return _contents.contents;
        }

    }
}
