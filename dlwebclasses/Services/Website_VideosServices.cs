using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public partial class Website_Videos : ITrackedEntity
    {

    }

    public class Website_VideosServices : TrackedEntity<Website_Videos>, IDisposable
    {
        public void Dispose()
        {
            
        }
    }
}
