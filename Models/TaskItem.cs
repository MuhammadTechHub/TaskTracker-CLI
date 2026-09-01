namespace TaskTracker_CLI.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public TaskItem(string description)
    {
        this.Description = description;
        this.Status = Status.ToDo;
        this.CreatedAt = DateTimeOffset.Now;
        this.UpdatedAt = DateTimeOffset.Now;
    }
}