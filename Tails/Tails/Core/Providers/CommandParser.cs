using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tails.Core.Factories;

namespace Tails.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory factory;

        public CommandParser(ICommandFactory factory)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.factory = factory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split()[0];

            return this.factory.CreateCommand(commandName);
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split().Skip(1).ToList();
            if (commandParts.Count == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
