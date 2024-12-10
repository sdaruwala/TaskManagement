using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.Models;
using TaskManagement.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskService taskService) : ControllerBase
    {
       private readonly ITaskService _taskService = taskService;

        [HttpGet]
        public ActionResult<List<TaskModel>> GetAllTasks()
        {
            return Ok(_taskService.GetAllTasks());
        }

        [HttpGet("{id}")]
        public ActionResult<TaskModel> GetTaskById(int id)
        {
            var task = _taskService.GetTaskById(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] TaskModel task)
        {
            _taskService.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskModel task)
        {
            if (id != task.Id) return BadRequest();
            var existingTask = _taskService.GetTaskById(id);
            if (existingTask == null) return NotFound();

            _taskService.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var existingTask = _taskService.GetTaskById(id);
            if (existingTask == null) return NotFound();

            _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
