using TAILS.Commands.Contracts;
using System.Collections.Generic;

namespace TAILS.Core.Providers
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
