﻿
using Microsoft.AspNetCore.Mvc;
using sample_api.Entities;
using sample_api.Models;

namespace sample_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoDb _dbContext;

        public TodoController(TodoDb dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetAllTodos()
        {
            return Ok(_dbContext.Todos.ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodoById(int id)
        {
            var todo = _dbContext.Todos.Find(id);
            if (todo == null) return NotFound();

            return Ok(todo);
        }

        [HttpPut("{id}")]
        public ActionResult<Todo> PutToggleStatus(int id, [FromBody] Todo todo)
        {
            var t = _dbContext.Todos.Find(id);
            if (t == null) return NotFound();

            t.Name = todo.Name;
            t.IsComplete = todo.IsComplete;
            _dbContext.SaveChanges();
            return Ok(todo);
        }

        [HttpPost]
        public ActionResult PostTodo(Todo todo)
        {
            _dbContext.Todos.Add(todo);
            _dbContext.SaveChanges();
            return Created($"/{todo.Id}", todo);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id)
        {
            var t = _dbContext.Todos.Find(id);
            if (t == null) return NotFound();

            _dbContext.Todos.Remove(t);
            _dbContext.SaveChanges();
            return Ok(t);
        }

    }
}
