using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class client_WebPage
    {
        private AContents _contents;
        private APageHeader _pageheader;
        private AHeadSection _headsection;
        private AHeaderContainer _headerContainer;
        private AAreasOfLaw _areasoflaws;
        private ADepartmentNavigation _departmentnavigation;
        private ARightColoumn _rightcoloumn;
        private AFooter _footer;
        private APageScripts _pagescripts;

        public client_WebPage(AWebPage WP, AContents _DContent)
        {
            _headsection = WP.createHeadSection();
            _pageheader = WP.CreatePageHeader();
            _headerContainer = WP.CreateHeaderContainer();
            _areasoflaws = WP.CreateAreasOfLaws();
            _departmentnavigation = WP.CreateDepartmentNavigation();
            _rightcoloumn = WP.CreateRightColoumn();
            _footer = WP.CreateFooter();
            _pagescripts = WP.CreatePageScripts();
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

        public StringBuilder getheadercontainer()
        {
            StringBuilder SB = new StringBuilder();
            DepartmentDetails dd = new DepartmentDetails(_contents.Department);
            SB = _headerContainer.getheadercontainer(dd, _contents);
            return SB;
        }

        public Dictionary<string, StringBuilder> getAreasOfLaws()
        {
            Dictionary<string, StringBuilder> Dict = new Dictionary<string, StringBuilder>();
            DepartmentDetails dd = new DepartmentDetails(_contents.Department);
            Dict = _areasoflaws.getareasoflaw(dd);
            return Dict;
        }

        public StringBuilder getDepartmentNavigation()
        {
            StringBuilder SB = new StringBuilder();
            DepartmentDetails dd = new DepartmentDetails(_contents.Department);
            SB = _departmentnavigation.getDepartmentNavigation(dd);
            return SB;
        }
        public StringBuilder getrightcoloumn()
        {
            StringBuilder SB = new StringBuilder();
            DepartmentDetails dd = new DepartmentDetails(_contents.Department);
            SB = _rightcoloumn.getRightColoumn(dd, _contents);
            return SB;
        }
        public StringBuilder getfooter()
        {
            StringBuilder SB = new StringBuilder();
            DepartmentDetails dd = new DepartmentDetails(_contents.Department);
            SB = _footer.getfooter(_contents);
            return SB;
        }

        public StringBuilder getpagescripts()
        {
            StringBuilder SB = new StringBuilder();
            SB = _pagescripts.getPageScript();
            return SB;
        }
        public StringBuilder getcontents()
        {
            StringBuilder SB = new StringBuilder();
            return _contents.contents;
        }

    }
}
