using BaltaTodo.Domain.Entities;
using BaltaTodo.Domain.Interfaces;
using BaltaTodo.Domain.Queries;
using BaltaTodo.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaltaTodo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext contex)
        {
            _context = contex;
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            var result = _context.Tarefas
                .AsNoTracking()
                .Where(TodoQueries.GetAll(user)) // TodoQueries.GetAll => Expressão 
                .OrderBy(x => x.Date);

            return result;
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            var result = _context.Tarefas
                .AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(x => x.Date);

            return result;
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            var result = _context.Tarefas
                .AsNoTracking()
                .Where(TodoQueries.GetAllUnDone(user))
                .OrderBy(x => x.Date);

            return result;
        }

        public TodoItem GetById(Guid id, string user)
        {
            var result = _context.Tarefas
                .AsNoTracking()
                .FirstOrDefault(TodoQueries.GetById(id, user));

            return result;
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            var result = _context.Tarefas
                .AsNoTracking()
                .Where(TodoQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);

            return result;
        }

        public void Create(TodoItem model)
        {
            _context.Tarefas.Add(model);
            _context.SaveChanges();
        }

        public void Update(TodoItem model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
