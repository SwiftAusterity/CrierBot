﻿using NetMud.Commands.Attributes;
using NetMud.DataStructure.Base.System;
using NutMud.Commands.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NetMud.Commands.System
{
    [CommandKeyword("commands", false)]
    [CommandPermission(0)]
    [CommandRange(CommandRangeType.Touch, 0)]
    public class Commands : CommandPartial
    {
        /// <summary>
        /// All Commands require a generic constructor
        /// </summary>
        public Commands()
        {
            //Generic constructor for all IHelpfuls is needed
        }

        public override void Execute()
        {
            var returnStrings = new List<string>();
            var sb = new StringBuilder();

            var commandsAssembly = Assembly.GetAssembly(typeof(CommandParameterAttribute));

            var loadedCommands = commandsAssembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ICommand)));

            loadedCommands = loadedCommands.Where(comm => comm.GetCustomAttributes<CommandPermissionAttribute>().Any(att => att.MinimumRank <= 0));

            returnStrings.Add("Commands:");

            var commandNames = new HashSet<string>();
            foreach (var command in loadedCommands)
            {
                foreach(var commandName in command.GetCustomAttributes<CommandKeywordAttribute>().Where(key => key.DisplayInHelpAndCommands))
                    if(!commandNames.Contains(commandName.Keyword))
                        commandNames.Add(commandName.Keyword);

                if (!commandNames.Contains(command.Name) && command.GetCustomAttribute<CommandSuppressName>() != null)
                    commandNames.Add(command.Name);
            }

            if(sb.Length > 0)
                sb.Length -= 2;

            returnStrings.Add(sb.ToString());

            //TODO: Add returning values
        }

        public override IEnumerable<string> RenderSyntaxHelp()
        {
            var sb = new List<string>();

            sb.Add("Valid Syntax: commands");

            return sb;
        }

        /// <summary>
        /// The custom body of help text
        /// </summary>
        public override string HelpText
        {
            get
            {
                return string.Format("Commands lists possible commands for you to use in-game.");
            }
            set { }
        }
    }
}
