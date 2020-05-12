using BaltaTodo.Domain.Entities;
using BaltaTodo.Domain.Queries;
using BaltaTodo.Tests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace BaltaTodo.Tests.Queries
{
    [TestClass]
    public class QueryTodoTest
    {
        private List<TodoItem> _items;

        public QueryTodoTest()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "UsuarioTeste"));
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "CaioPontalti"));
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "UsuarioTeste"));
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "CaioPontalti"));
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "UsuarioTeste"));
        }

        [TestMethod]
        public void DeveRetornarOsTodosApenasDoUsuarioCaioPontalti()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("CaioPontalti")).ToList();
            Assert.AreEqual(2, result.Count);
        }
    }
}
