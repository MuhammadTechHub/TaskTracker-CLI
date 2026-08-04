public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No command provided");
            return;
        }

        if (args[0] == "add")
            Console.WriteLine("Add command selected");

        else if (args[0] == "delete")
            Console.WriteLine("Delete command selected");

        else if (args[0] == "list")
            Console.WriteLine("List command selected");

        else
            Console.WriteLine("Unknown command");    
    }
}