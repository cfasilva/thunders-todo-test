using Microsoft.AspNetCore.Mvc;
using Thunders.Domain.DTOs.TaskDTO;
using Thunders.Domain.Interfaces.IService;
using Thunders.Domain.Models;

namespace Thunders.Api.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetTasks()
        {
            var tasks = await _taskService.ListTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTask(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null)
                return NotFound("Task not found.");

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> CreateTask(TaskCreationDTO taskDto)
        {
            var task = await _taskService.CreateTask(taskDto);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut]
        public async Task<ActionResult<TaskModel>> UpdateTask(TaskEditDTO taskDto)
        {
            var task = await _taskService.UpdateTask(taskDto);
            if (task == null)
                return NotFound("Task not found.");

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var success = await _taskService.DeleteTask(id);
            if (!success)
                return NotFound("Task not found.");

            return NoContent();
        }

        [HttpPost("{id}/check")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var success = await _taskService.CompleteTask(id);
            if (!success)
                return NotFound("Task not found.");

            return NoContent();
        }

        [HttpPost("{id}/uncheck")]
        public async Task<IActionResult> ReopenTask(int id)
        {
            var success = await _taskService.ReopenTask(id);
            if (!success)
                return NotFound("Task not found.");

            return NoContent();
        }
    }
}
