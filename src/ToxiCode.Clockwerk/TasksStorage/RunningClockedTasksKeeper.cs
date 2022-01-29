using ToxiCode.Clockwerk.Models;

namespace ToxiCode.Clockwerk.TasksStorage;

public class RunningClockedTasksKeeper : IRunningClockedTasksKeeper
{
    private readonly List<ClockedTask> _runningTasks;

    public RunningClockedTasksKeeper()
        => _runningTasks = new List<ClockedTask>();

    public void RunClockedTask(ClockedTask taskToClocked)
    {
        _runningTasks.Add(taskToClocked);
        taskToClocked.Task.Start();
    }

    public IReadOnlyCollection<ClockedTask> GetRunningClockedTasks()
        => _runningTasks;

    public bool CancelRunningClockedTask(ClockedTask taskToCancel)
    {
        var task = _runningTasks.Find(x => x.Id == taskToCancel.Id);
        
        if (task is null)
            return false;
        if (task.Status != ClockedTaskStatus.Executing)
            return false;
        
        task.Cancel();
        return true;
    }
}