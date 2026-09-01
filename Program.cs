
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

                int taskId = taskService.AddTask(args[1]);
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
                    int updatedTaskId = taskService.UpdateTask(foundTaskId, args[2]);
                    Console.WriteLine($"Task updated successfully (ID: {updatedTaskId}).");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;

            default:
                Console.WriteLine("Invalid command. Use 'add' or 'list'.");
                break;
        }
    }
}