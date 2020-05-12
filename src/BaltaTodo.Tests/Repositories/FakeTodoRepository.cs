using BaltaTodo.Domain.Entities;
using BaltaTodo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaTodo.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem model)
        {
        }
        
        public void Update(TodoItem model)
        {
        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("Descrição do Titulo", DateTime.Now, "Usuario");
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }
    }
}
