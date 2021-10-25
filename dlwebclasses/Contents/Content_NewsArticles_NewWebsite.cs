using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class Content_NewsArticles_NewWebsite:AContents
    {
        private int _id;
        IT_DatabaseEntities dbit = new IT_DatabaseEntities();
        public Content_NewsArticles_NewWebsite(int ID)
        {
            _id = ID;
            Department = dbit.Updates_MainWebsites.Where(x => x.ID == ID).Select(y => y.Department).FirstOrDefault();
            
        }
        public override void getcontents()
        {
            NewsArticles_NewWebsite sp = new NewsArticles_NewWebsite(this, _id);
            title = sp.Title;
            description = sp.Description;
            keywords = sp.Keywords;
            HeadingH1 = sp.HeadingH1;
            Department = sp.Department;
            contents = sp.Contents;
            filepath = sp.filepath;
            StringBuilder SB = new StringBuilder();
            SB.AppendLine(sp.duplicateid.ToString());
            rightcolcontents = SB;
        }
    }
}
