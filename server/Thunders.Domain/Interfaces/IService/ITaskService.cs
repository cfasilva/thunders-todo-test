using Thunders.Domain.DTOs.TaskDTO;
using Thunders.Domain.Models;

namespace Thunders.Domain.Interfaces.IService
{
    public interface ITaskService
    {
        Task<List<TaskModel>> ListTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> CreateTask(TaskCreationDTO taskDto);
        Task<TaskModel> UpdateTask(TaskEditDTO taskDto);
        Task<bool> DeleteTask(int id);
        Task<bool> CompleteTask(int id);
        Task<bool> ReopenTask(int id);
    }
}
