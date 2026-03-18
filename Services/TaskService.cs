using TaskTracker_CLI.Models;
using TaskTracker_CLI.Storage;

namespace TaskTracker_CLI.Services;

public class TaskService
{
    private readonly JsonStorage storage = new JsonStorage();

    public void Add(string description)
    {
        var tasks = storage.Load();

        int newId = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;

        var task = new TaskItem
        {
            Id = newId,
            Description = description,
            Status = "todo",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        tasks.Add(task);
        storage.Save(tasks);

        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine($"Task added: (ID: {newId})");
    }

}
