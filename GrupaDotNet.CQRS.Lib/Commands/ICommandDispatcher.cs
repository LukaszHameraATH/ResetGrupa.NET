namespace GrupaDotNet.CQRS.Lib.Commands
{
    public interface ICommandDispatcher
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
