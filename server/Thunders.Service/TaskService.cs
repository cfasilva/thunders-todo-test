using Microsoft.EntityFrameworkCore;
using Thunders.Domain.DTOs.TaskDTO;
using Thunders.Domain.Interfaces.IService;
using Thunders.Domain.Models;
using Thunders.Infra.Context;

namespace Thunders.Service
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskModel>> ListTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TaskModel> CreateTask(TaskCreationDTO taskDto)
        {
            var task = new TaskModel
            {
                Title = taskDto.Title,
                CreatedAt = DateTime.Now
            };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskModel> UpdateTask(TaskEditDTO taskDto)
        {
            var task = await _context.Tasks.FindAsync(taskDto.Id);
            if (task == null) throw new ArgumentException("Task not found");

            task.Title = taskDto.Title;
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CompleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            task.IsCompleted = true;
            task.CompletedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ReopenTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            task.IsCompleted = false;
            task.CompletedAt = null;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
