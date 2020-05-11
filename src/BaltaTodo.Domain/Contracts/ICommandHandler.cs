using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaTodo.Domain.Contracts
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
