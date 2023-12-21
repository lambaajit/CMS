using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace dlwebclasses
{
    public interface ISearch
    {
        string SortOn { get; set; }
        int PageIndex { get; set; }
        int NumberOfRecordsPerPages { get; set; }
        string OrderBy {  get; set; }
    }

    public abstract class AbstractSearch<T>: ISearch where T : class
    {
        public AbstractSearch()
        {
            this.NumberOfRecordsPerPages = 50;
            SortOn = null;
            this.OrderBy = "ASC";
            var temp = typeof(T).GetProperties();
            this.ClassProperties = temp.OrderBy(x => x.Name).Select(x => new CheckBoxListItem() { Name = x.Name, IsSelected = false }).ToList();
            if (this.ClassProperties.Count() > 7 && this.ClassProperties.Count() <= 10)
            {
                this.ClassProperties.ToList().ForEach(x => x.IsSelected = true);
                this.ClassProperties.Where(x => x.Name == "CreatedBy" || x.Name == "CreatedDate" || x.Name == "ModifiedBy" || x.Name == "ModifiedDate").ToList().ForEach(x => x.IsSelected = false);
            }
            else if (this.ClassProperties.Count() < 7)
            {
                this.ClassProperties.ForEach(x => x.IsSelected = true);
            }
            
        }

        public string SortOn { get; set; }
        public int PageIndex { get; set; }
        public int NumberOfRecordsPerPages { get; set; }
        public List<CheckBoxListItem> ClassProperties { get; set; }
        public string OrderBy { get; set; }
    }

    public class AllProperties
    {
        public List<CheckBoxListItem> ClassProperties { get; set; }
        public int NumberOfRecordsPerPages { get; set; }
    }

    public class CheckBoxListItem
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }


}
