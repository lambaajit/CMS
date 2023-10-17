using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{



    public partial class Updates_MainWebsites : ITrackedEntity, IEntity
    { }

    public class Updates_MainWebitesServices : TrackedEntityWithLogging<Updates_MainWebsites>, IDisposable
    {
        public void Dispose()
        {

        }
    }

}
