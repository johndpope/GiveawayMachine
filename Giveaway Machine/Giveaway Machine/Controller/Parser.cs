﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Giveaway_Machine.Controller
{
    class Parser
    {
        private Dictionary<string, Command> commands;

        // Prepare the parser
        public Parser()
        {
            commands = Command.getAllCommandsDictionary();
        }

        public bool ParseCommand(string args)
        {
            // Split the arguments
            List<string> arguments = args.Split(' ').ToList();
            string commandName = arguments[0];
            arguments = arguments.Skip(1).ToList();

            // Execute the command
            Command currentCommand;
            if(commands.TryGetValue(commandName, out currentCommand))
            {
                currentCommand.Execute(arguments);
                return currentCommand.isExit;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Error.WriteLine($"Command with name: \"{commandName}\" was not found.");
                return false;
            }
        }
    }
}