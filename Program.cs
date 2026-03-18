using TaskTracker_CLI.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var service = new TaskService();

        if (args.Length == 0)
        {
            Console.WriteLine("No command provided");
            return;
        }

        var command = args[0];

        switch (command)
        {
            case "add":
                service.Add(args[1]);
                break;
            default:
                Console.WriteLine("Unknown command");
                break;
        }
    }
}
