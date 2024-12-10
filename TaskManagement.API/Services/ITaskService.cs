using TaskManagement.API.Models;

namespace TaskManagement.API.Services
{
    public interface ITaskService
    {
        List<TaskModel> GetAllTasks();
        TaskModel? GetTaskById(int id);
        void AddTask(TaskModel task);
        void UpdateTask(TaskModel task);
        void DeleteTask(int id);
    }
}
