using BaltaTodo.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaTodo.Tests.Entities
{
    [TestClass]
    public class TodoItemTest
    {

        [TestMethod]
        public void DadoUmaNovaTarefaNaoPodeSerConcluido()
        {
            var todo = new TodoItem("Titulo da Tarefa", DateTime.Now, "Usuario");
            Assert.AreEqual(todo.Done, false);
        }
    }
}
