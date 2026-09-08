using TaskTracker_CLI.Models;
using TaskTracker_CLI.Services;

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
        var taskItems = taskService.GetAllTasks();
        
        if (args.Length >= 3)
        {
            Console.WriteLine("Invalid command. The 'list' command can only have one optional argument for status.");
            return;
        }
        
        if (args.Length < 2)
        {
            if (taskItems.Count == 0)
            {
                Console.WriteLine("No tasks found.");
            }
            else
            {
                Console.WriteLine("\n\t\t\t\t\tTasks:\n");

                foreach (var taskItem in taskItems)
                {
                    Console.WriteLine($"{taskItem.Id} - {taskItem.Description} (Created: {taskItem.CreatedAt}, Updated: {taskItem.UpdatedAt}) - Status: {taskItem.Status}");
                }

                Console.WriteLine($"\nTotal tasks: {taskItems.Count}");
            }
            break;
        }

        if (!Enum.TryParse(args[1], true, out Status currentStatus))
        {
            Console.WriteLine("Invalid status. Please provide a valid status (ToDo, InProgress, Done).");
            return;
        }

        var filteredTasks = taskService.GetTasksByStatus(currentStatus);

        if (filteredTasks.Count == 0)
        {
            Console.WriteLine($"No tasks found with status: {currentStatus}.");
        }
        else
        {
            Console.WriteLine($"\n\t\t\t\t\tTasks with status {currentStatus}:\n");

            foreach (var taskItem in filteredTasks)
            {
                Console.WriteLine($"{taskItem.Id} - {taskItem.Description} (Created: {taskItem.CreatedAt}, Updated: {taskItem.UpdatedAt}) - Status: {taskItem.Status}");
            }

            Console.WriteLine($"\nTotal tasks with status {currentStatus}: {filteredTasks.Count}");
        }
        break;

    case "mark-in-progress":
        if (args.Length < 2)
        {
            Console.WriteLine("Please provide a task ID to mark as in progress.");
            return;
        }

        if (!int.TryParse(args[1], out int inProgressTaskId))
        {
            Console.WriteLine("Invalid task ID. Please provide a valid integer.");
            return;
        }

        try
        {
            int markedTaskId = taskService.MarkInProgress(inProgressTaskId);
            Console.WriteLine($"Task marked as in progress successfully (ID: {markedTaskId}).");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        break;

    case "mark-done":
        if (args.Length < 2)
        {
            Console.WriteLine("Please provide a task ID to mark as done.");
            return;
        }

        if (!int.TryParse(args[1], out int doneTaskId))
        {
            Console.WriteLine("Invalid task ID. Please provide a valid integer.");
            return;
        }

        try
        {
            int markedDoneTaskId = taskService.MarkDone(doneTaskId);
            Console.WriteLine($"Task marked as done successfully (ID: {markedDoneTaskId}).");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        break;

    default:
        Console.WriteLine("Unknown command. Please use 'add', 'update', 'delete', 'list', 'mark-in-progress', 'mark-done'.");
        break;
}
