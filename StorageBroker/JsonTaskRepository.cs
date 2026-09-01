using System.Text.Json;
using TaskTracker_CLI.Models;

namespace TaskTracker_CLI.StorageBroker;

public class JsonTaskRepository : IJsonTaskRepository
{
    public JsonTaskRepository() {}

    public List<TaskItem> GetAllTasks(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<TaskItem>();
        }

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }

    public void SaveTasks(string filePath, List<TaskItem> tasks)
    {
        string json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(filePath, json);
    }
}