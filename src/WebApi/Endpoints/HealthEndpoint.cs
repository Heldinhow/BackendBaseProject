using Microsoft.AspNetCore.Mvc;

namespace BackendBaseProject.WebApi.Endpoints;

public static class HealthEndpoint
{
    public static IEndpointRouteBuilder MapHealthEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/health", () => Results.Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow }))
           .WithName("Health")
           .WithOpenApi();

        return app;
    }
}
