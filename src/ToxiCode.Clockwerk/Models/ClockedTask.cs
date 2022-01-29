
namespace ToxiCode.Clockwerk.Models;

public sealed class ClockedTask
{

    public ClockedTask(Task task)
    {
        Task = task;
        CreateTokenSource();
    } 

    public ClockedTask(Task task, CancellationTokenSource cancellationTokenSource)
    {
        Task = task;
        CancellationTokenSource = cancellationTokenSource;
    } 

    public long Id => Task.Id;
    public Task Task { get; set; }
    public ClockedTaskStatus Status { get; set; } = ClockedTaskStatus.Created;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? CompletedAt { get; set; }
    public DateTime? CanceledAt { get; set; }
    public string? ErrorMessage => Task.Exception?.Message;
    private CancellationTokenSource CancellationTokenSource { get; set; } = null!;

    public void Cancel() 
        => CancellationTokenSource.Cancel();

    private void CreateTokenSource() 
        => CancellationTokenSource = new CancellationTokenSource();
}