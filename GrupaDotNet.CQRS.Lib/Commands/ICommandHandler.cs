﻿namespace GrupaDotNet.CQRS.Lib.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
