using NetMud.DataStructure.Base.System;
using System.Collections.Generic;

namespace NetMud.DataStructure.Base.Usage
{
    /// <summary>
    /// A game registered by the user
    /// </summary>
    public interface IGame : IStoredData
    {
        string LongDescription { get; set; }
        string Link { get; set; }
        HashSet<string> Tags { get; set; }
    }
}
