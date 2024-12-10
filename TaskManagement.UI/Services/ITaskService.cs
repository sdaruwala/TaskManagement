using TaskManagement.UI.Data;

namespace TaskManagement.UI.Services
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetTasksAsync();
        Task<TaskModel?> GetTaskByIdAsync(int id);
        Task AddTaskAsync(TaskModel task);
        Task UpdateTaskAsync(TaskModel task);
        Task DeleteTaskAsync(int id);
    }
}
