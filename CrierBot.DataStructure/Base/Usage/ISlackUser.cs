using NetMud.DataStructure.Base.System;
using System.Collections.Generic;

namespace NetMud.DataStructure.Base.Usage
{
    /// <summary>
    /// Slack users in the channels
    /// </summary>
    public interface ISlackUser : IStoredData
    {
        string LongDescription { get; set; }
        HashSet<string> Links { get; set; }
    }
}
