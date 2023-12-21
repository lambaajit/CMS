using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public interface IKeyValuePair : ITrackedEntity
    {
        int Id { get; set; }
        string Description { get; set; }
    }


}
