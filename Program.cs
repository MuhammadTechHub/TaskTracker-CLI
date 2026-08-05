using TaskTracker_CLI.Services;
using TaskTracker_CLI.Models;

public class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No command provided.");
            return;
        }

        var taskService = new TaskService();

        switch (args[0])
        {
            case "add":

                if (args.Length != 2)
                {
                    Console.WriteLine("Please provide a task description.");
                    return;
                }

                TaskItem task = taskService.AddTask(args[1]);
                Console.WriteLine($"Task '{task.Description}' (ID: {task.Id}) added successfully.");
                break;

            case "list":

                List<TaskItem> tasks = taskService.GetAllTasks();
                
                if (tasks.Count == 0)
                {
                    Console.WriteLine("No tasks found.");
                }
                else
                {
                    foreach (var t in tasks)
                    {
                        Console.WriteLine($"ID: {t.Id}, Description: {t.Description}, Status: {t.Status}, Created At: {t.CreatedAt}, Updated At: {t.UpdatedAt}");
                    }
                }
                break;
            
            case "delete":

                if (args.Length != 2 || !int.TryParse(args[1], out int taskId))
                {
                    Console.WriteLine("Please provide a valid task ID to delete.");
                    return;
                }

                bool isDeleted = taskService.DeleteTask(taskId);
                
                if (isDeleted)
                {
                    Console.WriteLine($"Task with ID {taskId} deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Task with ID {taskId} not found.");
                }
                break;

            case "get":

                if (args.Length != 2 || !int.TryParse(args[1], out int getTaskId))
                {
                    Console.WriteLine("Please provide a valid task ID to retrieve.");
                    return;
                }

                TaskItem? retrievedTask = taskService.GetTaskById(getTaskId);
                if (retrievedTask != null)
                {
                    Console.WriteLine($"ID: {retrievedTask.Id}, Description: {retrievedTask.Description}, Status: {retrievedTask.Status}, Created At: {retrievedTask.CreatedAt}, Updated At: {retrievedTask.UpdatedAt}");
                }
                else
                {
                    Console.WriteLine($"No task found with ID {getTaskId}.");
                }
                break;

            default:
                Console.WriteLine("Invalid command. Use 'add <task description>' to add a task.");
                break;
        }
    }
}