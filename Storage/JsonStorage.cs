using System.Text.Json;
using TaskTracker_CLI.Models;

namespace TaskTracker_CLI.Storage;

public class JsonStorage
{
    private readonly string filePath = "tasks.json";

    public List<TaskItem> Load()
    {
        if (!File.Exists(filePath))
        {
            return new List<TaskItem>();
        }

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }

    public void Save(List<TaskItem> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}
