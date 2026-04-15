using TaskTracker_CLI.Services;

var service = new TaskService();

Console.WriteLine("1 - Add task");
Console.WriteLine("2 - Show tasks");

var input = Console.ReadLine();

if (input == "1")
{
    Console.Write("Enter title: ");
    var title = Console.ReadLine();

    service.Add(title!);
}
else if (input == "2")
{
    var tasks = service.GetAll();

    foreach (var task in tasks)
    {
        Console.WriteLine($"{task.Id}. {task.Title} - {(task.IsCompleted ? "Done" : "Pending")}");
    }
}