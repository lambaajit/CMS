using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_NewsArticlesLandingPages:AContents
    {
        private string _dept;
        private int _Year1;
        private int _month1;
        private string _category;

        public Content_NewsArticlesLandingPages(string dept, string category, int Year1 = 0, int month1 = 0)
        {
            _dept = dept;
            _Year1 = Year1;
            _month1 = month1;
            _category =  category;
        }

        public override void getcontents()
        {
            NewsArticlesLandingPages sp = new NewsArticlesLandingPages(_dept, _category, _Year1, _month1);
            title = sp.Title;
            description = sp.Description;
            keywords = sp.Keywords;
            HeadingH1 = sp.HeadingH1;
            Department = sp.Department;
            contents = sp.Contents;
            filepath = sp.filepath;
            rightcolcontents = sp.rightcolcontent;
        }

    }
}
