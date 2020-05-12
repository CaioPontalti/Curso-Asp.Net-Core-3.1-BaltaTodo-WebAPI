using BaltaTodo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BaltaTodo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll (string user)
        {
            return t => t.User == user;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return t => t.User == user && t.Done == true;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUnDone(string user)
        {
            return t => t.User == user && t.Done == false;
        }

        public static Expression<Func<TodoItem, bool>> GetById(Guid id, string user)
        {
            return t => t.Id == id &&
                        t.User == user;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return t => t.User == user &&
                        t.Done == done &&
                        t.Date.Date == date.Date;
        }
    }
}
