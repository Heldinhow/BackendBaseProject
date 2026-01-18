using System;
using BackendBaseProject.Application.Commands;
using BackendBaseProject.Console.Commands;
using BackendBaseProject.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddCommandHandler<HelloCommandHandler>();

var host = builder.Build();
var handler = host.Services.GetRequiredService<HelloCommandHandler>();

var options = new HelloCommandOptions { Name = args.FirstOrDefault() };
await handler.HandleAsync(options);

host.Dispose();
