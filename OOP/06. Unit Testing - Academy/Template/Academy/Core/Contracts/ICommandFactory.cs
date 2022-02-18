using Academy.Commands.Contracts;

namespace Academy.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string commandLine);
    }
}
