using ToxiCode.Clockwerk.Models;

namespace ToxiCode.Clockwerk.TasksStorage;

public interface IRunningClockedTasksKeeper
{
    void RunClockedTask(ClockedTask taskToClocked);
    IReadOnlyCollection<ClockedTask> GetRunningClockedTasks();
    bool CancelRunningClockedTask(ClockedTask taskToCancel);
}