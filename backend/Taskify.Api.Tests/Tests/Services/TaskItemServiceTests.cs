using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Api.Models;
using Taskify.Api.Repository.Interfaces;
using Taskify.Api.Services.Implementation;

namespace Taskify.Api.Tests.Tests.Services
{
    public class TaskItemServiceTests
    {
        private readonly Mock<ITaskItemRepository> _mockRepo;
        private readonly TaskItemService _service;

        // ✅ Parameterless constructor
        public TaskItemServiceTests()
        {
            _mockRepo = new Mock<ITaskItemRepository>();
            _service = new TaskItemService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetTaskItemByIdAsync_ReturnsTask_WhenExists()
        {
            // Arrange
            var task = new TaskItem { Id = 1, Title = "Test Task" };
            _mockRepo.Setup(x => x.GetTaskItemByIdAsync(1))
                     .ReturnsAsync(task);

            // Act
            var result = await _service.GetTaskItemByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test Task", result.Title);
        }

        [Fact]
        public async Task AddTaskItemAsync_SetsCreatedAtAndCallsRepository()
        {
            // Arrange
            var task = new TaskItem { Title = "New Task" };

            // Act
            await _service.AddTaskItemAsync(task);

            // Assert
            Assert.NotNull(task.CreatedAt);
            _mockRepo.Verify(x => x.AddAsync(task), Times.Once);
        }

        [Fact]
        public async Task GetAllTaskItemsAsync_ReturnsAllTasks()
        {
            // Arrange
            var tasks = new List<TaskItem>
    {
        new TaskItem { Id = 1, Title = "Task 1" },
        new TaskItem { Id = 2, Title = "Task 2" }
    };
            _mockRepo.Setup(x => x.GetAllTaskItemsAsync()).ReturnsAsync(tasks);

            // Act
            var result = await _service.GetAllTaskItemsAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task UpdateTaskItemAsync_CallsRepository()
        {
            // Arrange
            var task = new TaskItem { Id = 1, Title = "Updated Title" };

            // Act
            await _service.UpdateTaskItemAsync(1, task);

            // Assert
            _mockRepo.Verify(x => x.UpdateAsync(1, task), Times.Once);
        }

        [Fact]
        public async Task DeleteTaskAsync_CallsRepository()
        {
            // Act
            await _service.DeleteTaskAsync(1);

            // Assert
            _mockRepo.Verify(x => x.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task GetTaskItemByIdAsync_ReturnsNull_WhenNotFound()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetTaskItemByIdAsync(99)).ReturnsAsync((TaskItem)null);

            // Act
            var result = await _service.GetTaskItemByIdAsync(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddTaskItemAsync_ThrowsException_WhenTitleIsEmpty()
        {
            // Arrange
            var task = new TaskItem { Title = "" }; // ❌ Invalid

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => _service.AddTaskItemAsync(task)
            );
        }

        [Fact]
        public async Task UpdateTaskItemAsync_AutoSetsUpdatedAt()
        {
            // Arrange
            var task = new TaskItem { Id = 1, Title = "Old" };

            // Act
            await _service.UpdateTaskItemAsync(1, task);

            // Assert
            Assert.NotNull(task.UpdateAt); // Business rule: UpdatedAt set ho gaya?
        }



    }
}
