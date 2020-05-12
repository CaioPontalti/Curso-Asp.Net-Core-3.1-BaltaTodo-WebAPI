using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaltaTodo.Domain.Commands;
using BaltaTodo.Domain.Contracts;
using BaltaTodo.Domain.Core;
using BaltaTodo.Domain.Entities;
using BaltaTodo.Domain.Handlers;
using BaltaTodo.Domain.Interfaces;
using BaltaTodo.Infra.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace BaltaTodo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoHandler _handler;
        private readonly ITodoRepository _todoRepository;

        public TodoController(TodoHandler handler, ITodoRepository todoRepository)
        {
            _handler = handler;
            _todoRepository = todoRepository;
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public IEnumerable<TodoItem> GetAll()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _todoRepository.GetAll(user);

            return result;
        }

        [HttpGet]
        [Route("done")]
        public IEnumerable<TodoItem> GetAllDone() 
        {
            var result = _todoRepository.GetAllDone("");
            return result;
        }

        [HttpGet]
        [Route("undone")]
        public IEnumerable<TodoItem> GetAllUnDone()
        {
            var result = _todoRepository.GetAllUndone("");

            return result;
        }

        [HttpGet]
        [Route("done/today")]
        public IEnumerable<TodoItem> GetDoneForToday()
        {
            var result = _todoRepository.GetByPeriod("", DateTime.Now.Date, true);

            return result;
        }

        [HttpGet]
        [Route("undone/today")]
        public IEnumerable<TodoItem> GetUndoneForToday()
        {
            var result = _todoRepository.GetByPeriod("", DateTime.Now.Date, false);

            return result;
        }

        [HttpPost]
        [Route("create")]
        public ICommandResult CreateTodo([FromBody] CreateTodoCommand command)
        {
            command.User = "CaioPontalti";
            var result = (ResponseCommand)_handler.Handle(command);

            return result;
        }

        [HttpPut]
        [Route("update")]
        public ICommandResult UpdateTodo([FromBody] UpdateTodoCommand command)
        {
            command.User = "CaioPontalti";
            var result = (ResponseCommand)_handler.Handle(command);

            return result;
        }

        [HttpPut]
        [Route("mark-as-done")]
        public ICommandResult UpdateTodo([FromBody] MarkTodoAsDoneCommand command)
        {
            command.User = "CaioPontalti";
            var result = (ResponseCommand)_handler.Handle(command);

            return result;
        }

        [HttpPut]
        [Route("mark-as-undone")]
        public ICommandResult UpdateTodo([FromBody] MarkTodoAsUndoneCommand command)
        {
            command.User = "CaioPontalti";
            var result = (ResponseCommand)_handler.Handle(command);

            return result;
        }
    }
}