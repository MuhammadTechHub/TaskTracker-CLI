using TaskTracker_CLI.Models;
using TaskTracker_CLI.StorageBroker;

namespace TaskTracker_CLI.Services;

public class TaskService : ITaskService
{
    private readonly string filePath = "tasks.json";
    private readonly IJsonTaskRepository taskRepository;
    private List<TaskItem> taskItems;

    public TaskService()
    {
        this.taskRepository = new JsonTaskRepository();
        this.taskItems = taskRepository.GetAllTasks(filePath);
    }

    public int AddTask(string description)
    {
        TaskItem newTask = new TaskItem(description);
        int maxId = 0;

        foreach (var task in taskItems)
        {
            if (task.Id > maxId)
            {
                maxId = task.Id;
            }
        }

        newTask.Id = maxId + 1;
        taskItems.Add(newTask);
        taskRepository.SaveTasks(filePath, taskItems);
        return newTask.Id;
    }

    public int UpdateTask(int currentTaskId, string newDescription)
    {
        foreach (var taskItem in taskItems)
        {
            if (currentTaskId == taskItem.Id)
            {
                taskItem.Description = newDescription;
                taskItem.UpdatedAt = DateTimeOffset.Now;
                taskRepository.SaveTasks(filePath, taskItems);
                return taskItem.Id;
            }
        }

        throw new ArgumentException($"Task with ID {currentTaskId} not found.");
    }

    public int DeleteTask(int currentTaskId)
    {
        for (int i = 0; i < taskItems.Count; i++)
        {
            if (currentTaskId == taskItems[i].Id)
            {
                taskItems.RemoveAt(i);
                taskRepository.SaveTasks(filePath, taskItems);
                return currentTaskId;
            }
        }

        throw new ArgumentException($"Task with ID {currentTaskId} not found.");
    }

    public List<TaskItem> GetAllTasks()
    {
        return taskItems;
    }

    public int MarkInProgress(int taskId)
    {
        var taskItem = taskItems.Find(taskItem => taskItem.Id == taskId);

        if (taskItem != null)
        {
            taskItem.Status = Status.InProgress;
            taskItem.UpdatedAt = DateTimeOffset.Now;
            taskRepository.SaveTasks(filePath, taskItems);
        }
        else
        {
            throw new ArgumentException($"Task with ID {taskId} not found.");
        }
        return taskId;
    }

    public int MarkDone(int taskId)
    {
        var taskItem = taskItems.Find(taskItem => taskItem.Id == taskId);

        if (taskItem != null)
        {
            taskItem.Status = Status.Done;
            taskItem.UpdatedAt = DateTimeOffset.Now;
            taskRepository.SaveTasks(filePath, taskItems);
        }
        else
        {
            throw new ArgumentException($"Task with ID {taskId} not found.");
        }
        return taskId;
    }

    public List<TaskItem> GetTasksByStatus(Status currentStatus)
    {
        return taskItems.FindAll(taskItem => taskItem.Status == currentStatus);
    }
}
