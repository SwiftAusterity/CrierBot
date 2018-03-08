using NetMud.DataStructure.Base.Usage;
using System.Collections.Generic;

namespace NetMud.DataStructure.Base.System
{
    /// <summary>
    /// Framework interface for commands
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute the command's actions
        /// </summary>
        void Execute();

        /// <summary>
        /// Renders syntactical help for command parsing
        /// </summary>
        /// <returns>help output</returns>
        IEnumerable<string> RenderSyntaxHelp();

        /* 
         * Syntax:
         *      command <subject> <target> <supporting>
         *  Location is derived from context
         *  Surroundings is derived from location
         */

        /// <summary>
        /// Acting entity that issued this command
        /// </summary>
        ISlackUser Actor { get; set; }

        /// <summary>
        /// The params for the command being issued
        /// </summary>
        object Parameters { get; set; }
    }
}
