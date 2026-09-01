using TaskTracker_CLI.Models;
using TaskTracker_CLI.StorageBroker;

namespace TaskTracker_CLI.Services;

public class TaskService
{
    private readonly string filePath = "tasks.json";
    private readonly IJsonTaskRepository taskRepository;
    private List<TaskItem> tasks;

    public TaskService()
    {
        this.taskRepository = new JsonTaskRepository();
        this.tasks = taskRepository.GetAllTasks(filePath);
    }

    public int AddTask(string description)
    {
        TaskItem newTask = new TaskItem(description);
        int maxId = 0;

        foreach (var task in tasks)
        {
            if (task.Id > maxId)
            {
                maxId = task.Id;
            }
        }

        newTask.Id = maxId + 1;
        tasks.Add(newTask);
        taskRepository.SaveTasks(filePath, tasks);
        return newTask.Id;
    }

    public int UpdateTask(int currentTaskId, string newDescription)
    {
        foreach (var task in tasks)
        {
            if (currentTaskId == task.Id)
            {
                task.Description = newDescription;
                task.UpdatedAt = DateTimeOffset.Now;
                taskRepository.SaveTasks(filePath, tasks);
                return task.Id;
            }
        }

        throw new ArgumentException($"Task with ID {currentTaskId} not found.");
    }

    public int DeleteTask(int currentTaskId)
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            if (currentTaskId == tasks[i].Id)
            {
                tasks.RemoveAt(i);
                taskRepository.SaveTasks(filePath, tasks);
                return currentTaskId;
            }
        }

        throw new ArgumentException($"Task with ID {currentTaskId} not found.");
    }
}
