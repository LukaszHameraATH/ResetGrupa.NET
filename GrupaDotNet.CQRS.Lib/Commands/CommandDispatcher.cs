using Microsoft.Extensions.DependencyInjection;

namespace GrupaDotNet.CQRS.Lib.Commands
{
    public class CommandDispatcher: ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        { 
            using var scope = _serviceProvider.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            handler.Handle(command);
        }
    }
}
