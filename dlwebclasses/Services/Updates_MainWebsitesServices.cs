using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace dlwebclasses
{


    [CanBeEdited(true), NameToBeDisplayedOnUI("News/Articles Website")]
    public partial class Updates_MainWebsites : ITrackedEntity, IEntity
    {
        public HttpPostedFileBase fileUploaded { get; set; }
        public List<string> ExtraDepartments { get; set; }
    }

    public class Updates_MainWebitesServices : TrackedEntityWithLogging<Updates_MainWebsites>, IDisposable
    {
        public void Dispose()
        {

        }
    }

}
