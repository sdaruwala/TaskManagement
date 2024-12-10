
using TaskManagement.UI.Data;

namespace TaskManagement.UI.Services
{
    public class TaskService(HttpClient httpClient) : ITaskService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task AddTaskAsync(TaskModel task)
        {
            var response = await _httpClient.PostAsJsonAsync("api/task", task);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/task/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<TaskModel?> GetTaskByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TaskModel>($"api/task/{id}");
        }

        public async Task<List<TaskModel>> GetTasksAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TaskModel>>("api/task") ?? new List<TaskModel>();
        }

        public async Task UpdateTaskAsync(TaskModel task)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/task/{task.Id}", task);
            response.EnsureSuccessStatusCode();
        }
    }
}
