using BaltaTodo.Domain.Contracts;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaTodo.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand()
        {

        }
        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                 new ValidationContract()
                     .Requires()
                     .HasMinLen(Title, 6, "Title", "A descrição precisa ter no mínimo 6 caracteres")
                     .HasMinLen(User, 6, "User", "Usuário inválido!")
             );
        }
    }
}
