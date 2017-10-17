using TAILS.Commands.Contracts;

namespace TAILS.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
