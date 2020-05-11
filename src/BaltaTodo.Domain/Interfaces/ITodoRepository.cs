using BaltaTodo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaTodo.Domain.Interfaces
{
    public interface ITodoRepository
    {
        void Create(TodoItem model);
        void Update(TodoItem model);

        TodoItem GetById(Guid id, string user);
    }
}
