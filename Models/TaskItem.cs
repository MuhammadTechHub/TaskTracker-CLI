
namespace TaskTracker_CLI.Models;
public class TaskItem
{
    private static int _id = 0;
    public string Title { get; set; }
    public string? Description { get; set; }
    public int Id { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdateAt { get; }
    public string Status { get; set; } = "toDo";

    public TaskItem(string taskName)
    {
        this.Id = _id ++;
        _id = this.Id;

        this.Title = taskName;
        this.Description = "---";

        this.CreatedAt = DateTime.Now;
        this.UpdateAt = DateTime.Now;
    }
}