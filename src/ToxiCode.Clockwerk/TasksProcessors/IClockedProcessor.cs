namespace ToxiCode.Clockwerk.TasksProcessors;

public interface IClockedProcessor
{
    Task StartProcessing(CancellationToken cancellationToken);
}