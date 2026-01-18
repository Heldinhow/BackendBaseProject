using FluentResults;

namespace BackendBaseProject.Application.Commands;

public interface ICommandHandler<TOptions, TOutput> where TOptions : CommandHandlerOptions
{
    Task<Result<TOutput>> HandleAsync(TOptions options, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<TOptions> where TOptions : CommandHandlerOptions
{
    Task<Result> HandleAsync(TOptions options, CancellationToken cancellationToken = default);
}
