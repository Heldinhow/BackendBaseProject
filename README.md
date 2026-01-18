# BackendBaseProject

A .NET 10 backend base project template following DDD, SOLID principles, and modern practices.

## Architecture

```
src/
├── Core/                    # Domain layer
│   ├── Aggregates/          # Aggregate roots
│   ├── ValueObjects/        # Immutable value objects
│   ├── DomainEvents/        # Domain event definitions
│   ├── DomainServices/      # Stateless domain services
│   ├── Specifications/      # Specification pattern
│   └── Entities/            # Base entity classes
├── Application/             # Application layer
│   ├── ApplicationServices/ # Orchestration services
│   ├── Commands/            # Command pattern implementation
│   ├── DTOs/                # Data transfer objects
│   ├── Interfaces/          # Abstractions (IRepository, IProvider)
│   └── Validation/          # Input validation
├── Infrastructure/          # Infrastructure layer
│   ├── Repositories/        # Repository implementations
│   ├── Providers/           # External service providers
│   ├── EventBus/            # Event publishing
│   └── Configuration/       # DI configuration extensions
├── WebApi/                  # Minimal API layer
│   ├── Endpoints/           # Endpoint definitions (NEVER in Program.cs)
│   └── Middleware/          # Custom middleware
└── Console/                 # CLI entry point

tests/
├── Unit/                    # Unit tests
├── Integration/             # Integration tests
└── Contract/                # Contract tests
```

## Getting Started

### Prerequisites

- .NET 10.0 SDK or later
- Visual Studio 2022+ or VS Code

### Building

```bash
dotnet restore
dotnet build
```

### Running Tests

```bash
dotnet test                    # Run all tests
dotnet test --filter "FullyQualifiedName~TestClass.TestMethod"  # Single test
dotnet test --collect:"XPlat Code Coverage" --coverage  # With coverage
```

### Running the Web API

```bash
cd src/WebApi
dotnet run
```

### Running the Console App

```bash
cd src/Console
dotnet run -- Hello
```

## Design Patterns

This project implements several design patterns:

- **Command Pattern**: `CommandHandler<TOptions>` with generic base classes
- **Factory Pattern**: Complex object creation with service provider integration
- **Repository Pattern**: Async data access with `IRepository<T>` interface
- **Provider Pattern**: External service abstractions with `IProvider<TOutput>`
- **Resource Pattern**: Localized messages with `.resx` files
- **Minimal API Pattern**: Endpoints in `Endpoints/` folder, never in `Program.cs`

## Error Handling

This project uses **FluentResults** for expected failure scenarios:

```csharp
public Result<Order> ProcessOrder(OrderRequest request)
{
    var validation = ValidateRequest(request);
    if (validation.IsFailed)
        return validation.ToResult();

    return CreateOrder(request)
        .Map(order => PublishOrderCreatedEvent(order));
}
```

## Test-Driven Development

All code follows TDD principles:

- Tests are written before implementation
- Test naming: `MethodName_Condition_ExpectedResult()`
- Minimum 85% coverage for Core and Application layers
- AAA pattern (Arrange, Act, Assert)

## Dependencies

Key NuGet packages:

- **FluentResults**: Result type for error handling
- **Ardalis.Specification**: Specification pattern for queries
- **Microsoft.EntityFrameworkCore**: Data access
- **Swashbuckle.AspNetCore**: OpenAPI/Swagger documentation

## License

MIT
