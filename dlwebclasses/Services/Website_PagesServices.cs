using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public partial class Website_Pages : ITrackedEntity,IEntity
    {

    }

    public class Website_PagesServices : TrackedEntityWithLogging<Website_Pages>, IDisposable
    {
        public void Dispose()
        {
            
        }
    }
}
