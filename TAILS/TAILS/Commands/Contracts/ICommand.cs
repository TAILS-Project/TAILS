using System.Collections.Generic;

namespace TAILS.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
