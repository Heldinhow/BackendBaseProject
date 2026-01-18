namespace BackendBaseProject.Application.Commands;

public abstract class CommandHandlerOptions
{
    public CancellationToken CancellationToken { get; init; }
}
