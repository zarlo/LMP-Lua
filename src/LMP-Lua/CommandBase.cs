using Server.Command.Command.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Server.Command;

namespace LMP_Lua
{
    internal class CommandBase : SimpleCommand
    {

        string command;

        Plugin plugin;

        public CommandBase(Plugin plugin, string command, string func, string description)
        {

            plugin.RegisterHandler("COMMAND:" + command, func);
            this.plugin = plugin;
            this.command = command;
            RegisterCommand(command, this.Execute, description);

        }

        private static void RegisterCommand(string command, Func<string, bool> func, string description)
        {
            var cmd = new CommandDefinition(command, func, description);
            if (!Server.Command.CommandHandler.Commands.ContainsKey(command))
                Server.Command.CommandHandler.Commands.TryAdd(command, cmd);
        }

        public override bool Execute(string commandArgs)
        {

            plugin.CallHandler("COMMAND:" + command, commandArgs);
            return true;
        }


    }
}
