using FluentResults;

namespace BackendBaseProject.Application.Commands;

public abstract class CommandHandler<TOptions, TOutput> : ICommandHandler<TOptions, TOutput>
    where TOptions : CommandHandlerOptions
{
    protected abstract Task<Result<TOutput>> Handle(TOptions options, CancellationToken cancellationToken);

    public Task<Result<TOutput>> HandleAsync(TOptions options, CancellationToken cancellationToken = default)
    {
        return Handle(options, cancellationToken);
    }
}

public abstract class CommandHandler<TOptions> : ICommandHandler<TOptions>
    where TOptions : CommandHandlerOptions
{
    protected abstract Task<Result> Handle(TOptions options, CancellationToken cancellationToken);

    public Task<Result> HandleAsync(TOptions options, CancellationToken cancellationToken = default)
    {
        return Handle(options, cancellationToken);
    }
}
