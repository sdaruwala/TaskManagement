
using TaskManagement.API.Models;
using TaskManagement.API.Services;

namespace TaskManagement.API.Test
{
    public class TaskServiceTests
    {
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            // Initialize TaskService
            _taskService = new TaskService();
        }

        [Fact]
        public void GetAllTasks_ShouldReturnAllTasks()
        {
            // Act
            var tasks = _taskService.GetAllTasks();

            // Assert
            Assert.NotNull(tasks);
            Assert.Equal(2, tasks.Count); // Verify default list count
        }

        [Fact]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            var newTask = new TaskModel { Title = "New Task", Description = "New Description", IsCompleted = false };

            // Act
            _taskService.AddTask(newTask);

            // Assert
            var tasks = _taskService.GetAllTasks();
            Assert.Equal(3, tasks.Count); // Verify the count increases
            Assert.Contains(tasks, t => t.Title == "New Task" && t.Description == "New Description");
        }

        [Fact]
        public void DeleteTask_ShouldRemoveTask()
        {
            // Arrange
            var taskIdToDelete = 1;

            // Act
            _taskService.DeleteTask(taskIdToDelete);

            // Assert
            var tasks = _taskService.GetAllTasks();
            Assert.DoesNotContain(tasks, t => t.Id == taskIdToDelete);
        }

        [Fact]
        public void GetTaskById_ShouldReturnCorrectTask()
        {
            // Arrange
            var taskId = 1;

            // Act
            var task = _taskService.GetTaskById(taskId);

            // Assert
            Assert.NotNull(task);
            Assert.Equal("Task1", task.Title);
            Assert.Equal("Description1", task.Description);
        }

        [Fact]
        public void GetTaskById_ShouldReturnNull_WhenTaskNotFound()
        {
            // Arrange
            var invalidTaskId = 99;

            // Act
            var task = _taskService.GetTaskById(invalidTaskId);

            // Assert
            Assert.Null(task);
        }

        [Fact]
        public void UpdateTask_ShouldModifyTaskDetails()
        {
            // Arrange
            var updatedTask = new TaskModel { Id = 1, Title = "Updated Task", Description = "Updated Description", IsCompleted = true };

            // Act
            _taskService.UpdateTask(updatedTask);

            // Assert
            var task = _taskService.GetTaskById(1);
            Assert.NotNull(task);
            Assert.Equal("Updated Task", task.Title);
            Assert.Equal("Updated Description", task.Description);
            Assert.True(task.IsCompleted);
        }

        [Fact]
        public void UpdateTask_ShouldNotModifyAnything_WhenTaskNotFound()
        {
            // Arrange
            var updatedTask = new TaskModel { Id = 99, Title = "Nonexistent Task", Description = "Nonexistent Description", IsCompleted = true };

            // Act
            _taskService.UpdateTask(updatedTask);

            // Assert
            var tasks = _taskService.GetAllTasks();
            Assert.Equal(2, tasks.Count); // No new task should be added
            Assert.DoesNotContain(tasks, t => t.Title == "Nonexistent Task");
        }
    }
}
