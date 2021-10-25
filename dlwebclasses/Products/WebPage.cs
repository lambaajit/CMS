using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class WebPage : AWebPage
    {
        public override AContents CreateContent(AContents _DContent1)
        {
            return _DContent1;
        }

        public override APageHeader CreatePageHeader()
        {
            return new PageHeader();
        }

        public override AHeadSection createHeadSection()
        {
            return new HeadSection();
        }

        public override AHeaderContainer CreateHeaderContainer()
        {
            return new HeaderContainer();
        }
        public override AAreasOfLaw CreateAreasOfLaws()
        {
            return new areasoflaw();
        }
        public override ADepartmentNavigation CreateDepartmentNavigation()
        {
            return new DepartmentNavigation();
        }
        public override ARightColoumn CreateRightColoumn()
        {
            return new RightColoumn();
        }
        public override AFooter CreateFooter()
        {
            return new Footer();
        }
        public override APageScripts CreatePageScripts()
        {
            return new PageScripts();
        }
    }
}
