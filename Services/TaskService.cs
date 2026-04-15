using TaskTracker_CLI.Models;
using TaskTracker_CLI.Storage;

namespace TaskTracker_CLI.Services;

public class TaskService
{
    private readonly FileStorage _storage;

    public TaskService()
    {
        _storage = new FileStorage();
    }

    public List<TaskItem> GetAll()
    {
        return _storage.LoadTasks();
    }

    public void Add(string title)
    {
        var tasks = _storage.LoadTasks();

        var newTask = new TaskItem
        {
            Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1,
            Title = title,
            IsCompleted = false
        };

        tasks.Add(newTask);
        _storage.SaveTasks(tasks);
    }

    public void Delete(int id)
    {
        var tasks = _storage.LoadTasks();

        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            tasks.Remove(task);
            _storage.SaveTasks(tasks);
        }
    }

    public void MarkDone(int id)
    {
        var tasks = _storage.LoadTasks();

        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = true;
            _storage.SaveTasks(tasks);
        }
    }
}