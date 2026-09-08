using TaskTracker_CLI.Services;

class Program
{
    static void Main(string[] args)
    {
        var taskService = new TaskService();

        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a command: 'add' or 'list'.");
            return;
        }
        switch (args[0])
        {
            case "add":
                if (args.Length < 2)
                {
                    Console.WriteLine("Please provide a task description.");
                    return;
                }

                string descriptionAdd = string.Join(" ", args[1..]);
                int taskId = taskService.AddTask(descriptionAdd);
                Console.WriteLine($"Task added successfully (ID: {taskId}).");
                break;

            case "update":
                if (args.Length < 3)
                {
                    Console.WriteLine("Please provide a task ID and a new description.");
                    return;
                }

                if (!int.TryParse(args[1], out int foundTaskId))
                {
                    Console.WriteLine("Invalid task ID. Please provide a valid integer.");
                    return;
                }

                try
                {
                    string descriptionUpdate = string.Join(" ", args[2..]);
                    int updatedTaskId = taskService.UpdateTask(foundTaskId, descriptionUpdate);
                    Console.WriteLine($"Task updated successfully (ID: {updatedTaskId}).");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;

            case "delete":
                if (args.Length < 2)
                {
                    Console.WriteLine("Please provide a task ID to delete.");
                    return;
                }

                if (!int.TryParse(args[1], out int deleteTaskId))
                {
                    Console.WriteLine("Invalid task ID. Please provide a valid integer.");
                    return;
                }

                try
                {
                    int deletedTaskId = taskService.DeleteTask(deleteTaskId);
                    Console.WriteLine($"Task deleted successfully (ID: {deletedTaskId}).");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;

            case "list":
                var tasks = taskService.GetAllTasks();
                if (tasks.Count == 0)
                {
                    Console.WriteLine("No tasks found.");
                }
                else
                {
                    Console.WriteLine("Tasks:");
                    foreach (var task in tasks)
                    {
                        Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Created At: {task.CreatedAt}, Updated At: {task.UpdatedAt}");
                    }
                }
                break;
                
            default:
                Console.WriteLine("Invalid command. Use 'add', 'update', 'delete' or 'list'.");
                break;
        }
    }
}
