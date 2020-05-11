using BaltaTodo.Domain.Commands;
using BaltaTodo.Domain.Core;
using BaltaTodo.Domain.Handlers;
using BaltaTodo.Domain.Interfaces;
using BaltaTodo.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaTodo.Tests.Handlers
{
    [TestClass]
    public class CreateTodoHandlerTest
    {

        [TestMethod]
        public void DadoUmComandoInvalidoDeveInterromperExecucao()
        {
            var command = new CreateTodoCommand("", DateTime.Now, "");
            var handle = new TodoHandler(new FakeTodoRepository());
            ResponseCommand result = (ResponseCommand)handle.Handle(command);

            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void DadoUmComandoValidoDeveCriarTarefa()
        {
            var command = new CreateTodoCommand("Titulo da Descrição", DateTime.Now, "Usuário");
            var handle = new TodoHandler(new FakeTodoRepository());
            ResponseCommand result = (ResponseCommand)handle.Handle(command);

            Assert.AreEqual(result.Success, true);
        }
    }
}
