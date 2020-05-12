using BaltaTodo.Domain.Contracts;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BaltaTodo.Domain.Commands
{
    public class CreateTodoCommand : Notifiable,  ICommand
    {
        public CreateTodoCommand()
        {

        }

        public CreateTodoCommand(string title, DateTime data, string user)
        {
            Title = title;
            Data = data;
            User = user;
        }

        public string Title { get; set; }
        public DateTime Data { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
               new ValidationContract()
                    .Requires()
                    .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                    .HasMinLen(User, 6, "User", "Usuário inválido!")
            );
        }
    }
}
