using System.Text.Json;
using TaskTracker_CLI.Models;

namespace TaskTracker_CLI.Storage;
public class FileStorage
{
    private readonly string _filePath = "Data/tasks.json";
    private List<TaskItem> listTasks;

    public void Save(Task taskItem)
    {
        var json = JsonSerializer.Serialize(taskItem, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(_filePath, json);
    }
}