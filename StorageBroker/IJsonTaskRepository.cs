
using TaskTracker_CLI.Models;

namespace TaskTracker_CLI.StorageBroker;

public interface IJsonTaskRepository
{
    List<TaskItem> GetAllTasks(string filePath);
    void SaveTasks(string filePath, List<TaskItem> tasks);
}
