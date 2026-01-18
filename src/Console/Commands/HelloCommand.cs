using System;
using FluentResults;
using Microsoft.Extensions.Logging;
using BackendBaseProject.Application.Commands;

namespace BackendBaseProject.Console.Commands;

public class HelloCommandOptions : CommandHandlerOptions
{
    public string? Name { get; init; }
}

public class HelloCommandHandler : CommandHandler<HelloCommandOptions>
{
    private readonly ILogger<HelloCommandHandler> _logger;

    public HelloCommandHandler(ILogger<HelloCommandHandler> logger)
    {
        _logger = logger;
    }

    protected override Task<Result> Handle(HelloCommandOptions options, CancellationToken cancellation)
    {
        var name = options.Name ?? "World";
        global::System.Console.WriteLine($"Hello, {name}!");
        _logger.LogInformation("Said hello to {Name}", name);
        return Task.FromResult(Result.Ok());
    }
}
