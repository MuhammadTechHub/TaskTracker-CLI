using TaskTracker_CLI.Models;

namespace TaskTracker_CLI.Services;

public class TaskService
{
    private static List<TaskItem> tasks = new List<TaskItem>();

    public TaskItem AddTask(string description)
    {
        var task = new TaskItem(description);
        tasks.Add(task);
        return task;
    }

    public List<TaskItem> GetAllTasks() => tasks;

    public TaskItem? GetTaskById(int id) =>
        tasks.FirstOrDefault(task => task.Id == id);

    public bool DeleteTask(int id)
    {
        var task = GetTaskById(id);

        if (task != null)
        {
            tasks.Remove(task);
            return true;
        }

        return false;
    }
}