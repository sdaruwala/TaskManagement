using TaskManagement.API.Models;

namespace TaskManagement.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskModel> _tasks;

        public TaskService()
        {
            _tasks =
            [
                new TaskModel {Id = 1, Title ="Task1", Description ="Description1", IsCompleted = false},
                new TaskModel {Id = 2, Title ="Task2", Description ="Description2", IsCompleted = true},
            ];
        }

        public void AddTask(TaskModel task)
        {
            task.Id = _tasks.Max(t => t.Id) + 1;
            _tasks.Add(task);
        }
        public void DeleteTask(int id) => _tasks.RemoveAll(t => t.Id == id);

        public List<TaskModel> GetAllTasks() => _tasks;       

        public TaskModel? GetTaskById(int id) => _tasks.FirstOrDefault(x => x.Id == id);       

        public void UpdateTask(TaskModel task)
        {
            var existingTask = GetTaskById(task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.IsCompleted = task.IsCompleted;
            }
        }
    }
}
