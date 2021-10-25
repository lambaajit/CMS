using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public abstract class AWebPage
    {
        public abstract AContents CreateContent(AContents _Dcontent);
        public abstract AHeadSection createHeadSection();
        public abstract APageHeader CreatePageHeader();
        public abstract AHeaderContainer CreateHeaderContainer();
        public abstract AAreasOfLaw CreateAreasOfLaws();
        public abstract ADepartmentNavigation CreateDepartmentNavigation();
        public abstract ARightColoumn CreateRightColoumn();
        public abstract AFooter CreateFooter();
        public abstract APageScripts CreatePageScripts();
    }




    
}
