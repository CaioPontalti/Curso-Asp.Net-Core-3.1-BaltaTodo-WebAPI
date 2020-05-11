using BaltaTodo.Domain.Commands;
using BaltaTodo.Domain.Contracts;
using BaltaTodo.Domain.Core;
using BaltaTodo.Domain.Entities;
using BaltaTodo.Domain.Interfaces;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BaltaTodo.Domain.Handlers
{
    public class TodoHandler : Notifiable, ICommandHandler<CreateTodoCommand>,
                                           ICommandHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;
        public TodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new ResponseCommand(false, "Ops, para que sua tarefa está com problemas.", command.Notifications);

            var todo = new TodoItem(command.Title, command.Data, command.User);

            _todoRepository.Create(todo);

            return new ResponseCommand(true, "Tarefa Salva.", todo);
        }


        public ICommandResult Handle(UpdateTodoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
