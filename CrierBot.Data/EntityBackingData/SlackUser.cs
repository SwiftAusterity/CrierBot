using NetMud.Data.System;
using NetMud.DataStructure.Base.Usage;
using System;
using System.Collections.Generic;

namespace NetMud.Data.EntityBackingData
{
    /// <summary>
    /// Backing data for player characters
    /// </summary>
    [Serializable]
    public class SlackUser : BackingDataPartial, ISlackUser
    {
        public HashSet<string> Links { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public SlackUser()
        {

        }

        /// <summary>
        /// Gets the errors for data fitness
        /// </summary>
        /// <returns>a bunch of text saying how awful your data is</returns>
        public override IList<string> FitnessReport()
        {
            var dataProblems = base.FitnessReport();

            return dataProblems;
        }
    }
}
