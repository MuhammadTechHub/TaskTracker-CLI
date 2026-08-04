namespace TaskTracker_CLI.Models;

public class TaskItem
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Status { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}