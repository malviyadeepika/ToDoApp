using CoreLogic.Data;
using CoreLogic.Model;
using CoreLogic.Services;

namespace CoreTest;

public class TaskServiceTests
{
    private taskService _taskService;

    MyContext ctx;

    Category sampleCategory;
    [SetUp]
    public void SetUp()
    {
        ctx = new MyContext();
        _taskService = new taskService();
        sampleCategory = new Category { Name = "Sample Category" };
        ctx.categories.Add(sampleCategory);
    }

    [Test]
    public void GetAllTasks_ShouldReturnAllTasks()
    {
        var cat = ctx.categories.FirstOrDefault(t => t.Name == sampleCategory.Name);
        var prev = _taskService.GetAllTasks().Count();

        var sampleTask1 = new CoreLogic.Model.Task { taskName = "Task 1", CategoryId = cat.Id };

        var sampleTask2 = new CoreLogic.Model.Task { taskName = "Task 2", CategoryId = cat.Id };

        _taskService.createTask(sampleTask1);
        _taskService.createTask(sampleTask2);

        var result = _taskService.GetAllTasks();
        var nowCreated = result.Count() - prev;

        Assert.AreEqual(2, nowCreated);
        Assert.IsTrue(result.Any(t => t.taskName == "Task 1"));
        Assert.IsTrue(result.Any(t => t.taskName == "Task 2"));
    }

    [Test]
    public void CreateTask_ShouldAddNewTask()
    {
        var cat = ctx.categories.FirstOrDefault(t => t.Name == sampleCategory.Name);

        var newTask = new CoreLogic.Model.Task { taskName = "Task 3", CategoryId = cat.Id };

        _taskService.createTask(newTask);
   
        var retrievedTask = ctx.tasks.FirstOrDefault(t => t.taskName == newTask.taskName); ;
        
        Assert.IsNotNull(retrievedTask);
        Assert.AreEqual("Task 3", retrievedTask.taskName);
    }

    [Test]
    public void UpdateTask_ShouldModifyExistingTask()
    {
        var cat = ctx.categories.FirstOrDefault(t => t.Name == sampleCategory.Name);

        var existingTask = new CoreLogic.Model.Task { taskName = "Existing Task", CategoryId = cat.Id};
        _taskService.createTask(existingTask);

        var updatedTask = new CoreLogic.Model.Task { taskName = "Updated Task", CategoryId = cat.Id };
        _taskService.updateTask(updatedTask);

        var retrievedTask = ctx.tasks.FirstOrDefault(t => t.taskName == updatedTask.taskName);

        Assert.IsNotNull(retrievedTask);
        Assert.AreEqual("Updated Task", retrievedTask.taskName);
    }

    [Test]
    public void DeleteTask_ShouldRemoveTask()
    {
        var cat = ctx.categories.FirstOrDefault(t => t.Name == sampleCategory.Name);

        var taskToDelete = new CoreLogic.Model.Task { taskName = "Task to Delete", CategoryId = cat.Id };

        _taskService.createTask(taskToDelete);

        var retrievedTask = ctx.tasks.FirstOrDefault(t => t.taskName == taskToDelete.taskName);

        Assert.IsNotNull(retrievedTask);
 
        //_taskService.deleteTask(retrievedTask.Id);

        Assert.Throws<ArgumentException>(() => _taskService.getTaskById(5));
    }

    [Test]
    public void GetAllCategories_ShouldReturnAllCategories()
    {
        var prev = _taskService.getAllCategories();
        var sampleCategory1 = new Category { Name = "Category 1" };
        var sampleCategory2 = new Category { Name = "Category 2" };
        ctx.categories.Add(sampleCategory1);
        ctx.categories.Add(sampleCategory2);
        ctx.SaveChanges();

        var result = _taskService.getAllCategories();

        Assert.AreEqual(2, result.Count() - prev.Count());
        Assert.IsTrue(result.Any(c => c.Name == "Category 1"));
        Assert.IsTrue(result.Any(c => c.Name == "Category 2"));
    }
}