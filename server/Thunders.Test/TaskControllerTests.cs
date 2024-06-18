using Microsoft.AspNetCore.Mvc;
using Moq;
using Thunders.Api.Controllers;
using Thunders.Domain.DTOs.TaskDTO;
using Thunders.Domain.Interfaces.IService;
using Thunders.Domain.Models;
using Xunit;

namespace TestThunders
{
    public class TaskControllerTests
    {
        private readonly Mock<ITaskService> _mockTaskService;
        private readonly TaskController _taskController;

        public TaskControllerTests()
        {
            _mockTaskService = new Mock<ITaskService>();
            _taskController = new TaskController(_mockTaskService.Object);
        }

        [Fact]
        public async Task GetTasks_ShouldReturnOkResult_WithListOfTasks()
        {
            var tasks = new List<TaskModel>
            {
                new TaskModel { Id = 1, Title = "Task 1" },
                new TaskModel { Id = 2, Title = "Task 2" }
            };
            _mockTaskService.Setup(service => service.ListTasks()).ReturnsAsync(tasks);

            var result = await _taskController.GetTasks();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<TaskModel>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetTask_ShouldReturnOkResult_WithTask()
        {
            var task = new TaskModel { Id = 1, Title = "Task 1" };
            _mockTaskService.Setup(service => service.GetTaskById(1)).ReturnsAsync(task);

            var result = await _taskController.GetTask(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<TaskModel>(okResult.Value);
            Assert.Equal(task.Id, returnValue.Id);
        }

        [Fact]
        public async Task CreateTask_ShouldReturnCreatedAtActionResult_WithTask()
        {
            var taskDto = new TaskCreationDTO { Title = "Task 1" };
            var task = new TaskModel { Id = 1, Title = "Task 1" };
            _mockTaskService.Setup(service => service.CreateTask(taskDto)).ReturnsAsync(task);

            var result = await _taskController.CreateTask(taskDto);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<TaskModel>(createdAtActionResult.Value);
            Assert.Equal(task.Id, returnValue.Id);
        }

        [Fact]
        public async Task UpdateTask_ShouldReturnOkResult_WithUpdatedTask()
        {
            var taskDto = new TaskEditDTO { Id = 1, Title = "Updated Task" };
            var task = new TaskModel { Id = 1, Title = "Updated Task" };
            _mockTaskService.Setup(service => service.UpdateTask(taskDto)).ReturnsAsync(task);

            var result = await _taskController.UpdateTask(taskDto);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<TaskModel>(okResult.Value);
            Assert.Equal(task.Id, returnValue.Id);
        }

        [Fact]
        public async Task DeleteTask_ShouldReturnNoContentResult()
        {
            _mockTaskService.Setup(service => service.DeleteTask(1)).ReturnsAsync(true);

            var result = await _taskController.DeleteTask(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task CompleteTask_ShouldReturnNoContentResult()
        {
            // Arrange
            _mockTaskService.Setup(service => service.CompleteTask(1)).ReturnsAsync(true);

            // Act
            var result = await _taskController.CompleteTask(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task ReopenTask_ShouldReturnNoContentResult()
        {
            // Arrange
            _mockTaskService.Setup(service => service.ReopenTask(1)).ReturnsAsync(true);

            // Act
            var result = await _taskController.ReopenTask(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
