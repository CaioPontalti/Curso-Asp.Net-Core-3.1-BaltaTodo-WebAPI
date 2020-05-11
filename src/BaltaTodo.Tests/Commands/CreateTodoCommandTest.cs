using BaltaTodo.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace BaltaTodo.Tests.Commands
{
    [TestClass]
    public class CreateTodoCommandTest
    {
        [TestMethod]
        public void DadoUmComandoInvalido()
        {
            var command = new CreateTodoCommand("", DateTime.Now, "");
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void DadoUmComandoValido()
        {
            var command = new CreateTodoCommand("Titulo Tarefa", DateTime.Now, "Usuário");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }
    }
}
