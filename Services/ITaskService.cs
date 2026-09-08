
using TaskTracker_CLI.Models;

public interface ITaskService
{
    int AddTask(string description);
    int UpdateTask(int currentTaskId, string newDescription);
    int DeleteTask(int currentTaskId);
    List<TaskItem> GetAllTasks();
    int MarkInProgress(int taskId);
    int MarkDone(int taskId);
    List<TaskItem> GetTasksByStatus(Status currentStatus);
}