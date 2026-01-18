# AGENTS.md

This file contains guidelines and instructions for AI agents operating in this repository. All agents MUST comply with the project constitution at `.specify/memory/constitution.md`.

## Project Overview

This project uses GitHub Spec Kit for spec-driven development with Domain-Driven Design (DDD), SOLID principles, and .NET 10+ modern practices.

## Build, Lint, and Test Commands

### Build Commands

```bash
# .NET
dotnet restore
dotnet build --configuration Release

# Python
uv sync
uv run python -m pip install -e .

# Node.js
npm install
npm run build

# Rust
cargo build --release
```

### Linting and Formatting

```bash
# .NET
dotnet format                    # Format code
dotnet format style --severity error  # Style check
dotnet format analyzers --severity error  # Analyzer check

# Python
uv run ruff check .              # Lint
uv run ruff format .             # Format
uv run mypy .                    # Type check

# Shell
shellcheck .specify/scripts/*.sh
```

### Testing

```bash
# .NET
dotnet test                      # Run all tests
dotnet test --filter "FullyQualifiedName~TestClass.TestMethod"  # Single test
dotnet test --collect:"XPlat Code Coverage" --coverage  # With coverage

# Python
uv run pytest                    # All tests
uv run pytest tests/file.py::test_function_name  # Single test
uv run pytest --cov=. --cov-report=term-missing  # With coverage

# Node.js
npm test                         # All tests
npm test -- --testNamePattern="test name"  # Single test
npm test -- --coverage           # With coverage
```

## Code Style Guidelines

### General Principles

- Write clear, self-documenting code
- Follow the principle of least surprise
- Prefer explicit over implicit
- Keep functions small and focused (single responsibility)
- Avoid premature optimization
- **Write tests before implementing features (TDD mandatory)**

### DDD and SOLID Principles

**Domain-Driven Design**:
- Use ubiquitous language consistently across code and documentation
- Define bounded contexts with clear service boundaries
- Aggregates enforce consistency boundaries and transactional integrity
- Domain events capture and propagate business-significant state changes
- Rich domain models: business logic belongs in the domain layer

**SOLID Principles**:
- **S**ingle Responsibility: A class should have only one reason to change
- **O**pen/Closed: Open for extension, closed for modification
- **L**iskov Substitution: Subtypes must be substitutable for base types
- **I**nterface Segregation: No client forced to depend on unused methods
- **D**ependency Inversion: Depend on abstractions, not concretions

### .NET 10+ Practices

- Use **primary constructor** syntax in classes and records
- Use **records** for immutable data types
- Use **pattern matching** for expressive conditional logic
- Prefer **async/await** for all I/O-bound operations
- Leverage built-in **Dependency Injection** with proper service lifetimes
- Use **LINQ** for expressive data manipulation
- Use **System.Text.Json** for serialization

### Design Patterns

Implement these patterns consistently:

- **Command Pattern**: Generic base classes (`CommandHandler<TOptions>`), `ICommandHandler<TOptions>` interface, `CommandHandlerOptions` inheritance, static `SetupCommand(IHost host)` methods
- **Factory Pattern**: Complex object creation with service provider integration
- **Repository Pattern**: Async data access interfaces with provider abstractions
- **Provider Pattern**: External service abstractions (database, AI), clear contracts, configuration handling
- **Resource Pattern**: ResourceManager for localized messages in separate .resx files (LogMessages.resx, ErrorMessages.resx)
- **Minimal API Pattern**: Endpoints defined in `Endpoints/` folder, never in `Program.cs`

### FluentResults Pattern

Use FluentResults library instead of exceptions for expected failure scenarios:

- Return `Result<T>` or `Result` from methods that may fail predictably
- Chain operations fluently: `.OnSuccess()`, `.OnFailure()`, `.Map()`
- Include descriptive error messages with error codes
- Reserve exceptions for truly exceptional, unrecoverable conditions

```csharp
// Good: Using FluentResults for expected failures
public Result<Order> ProcessOrder(OrderRequest request)
{
    var validation = ValidateRequest(request);
    if (validation.IsFailed)
        return validation.ToResult();

    return CreateOrder(request)
        .Map(order => PublishOrderCreatedEvent(order));
}

// Bad: Throwing exceptions for expected failures
public Order ProcessOrder(OrderRequest request)
{
    if (!Validate(request))
        throw new ValidationException("Invalid request");
    // ...
}
```

### Imports and Dependencies

- Use explicit imports (avoid wildcard imports)
- Group imports: standard library → third-party → local
- Sort imports alphabetically within groups
- Remove unused imports immediately
- Pin dependency versions in production

### Formatting

- Use 4 spaces for indentation (C# convention)
- Limit line length to 100-120 characters
- Add blank lines between logical sections
- Use trailing commas in multi-line structures
- Follow language conventions (C# uses PascalCase for everything)

### Types

- Use explicit types for function parameters and return values
- Use `decimal` for all monetary calculations
- Prefer specific types over generic ones when possible
- Avoid `any` type; use `unknown` or explicit unions instead
- Validate external input types at boundaries

### Naming Conventions

- Variables/methods: `camelCase` (C#)
- Classes/records: `PascalCase`
- Interfaces: `I` prefix (e.g., `ICommandHandler`)
- Constants: `UPPER_SNAKE_CASE` or `PascalCase` for const
- Private members: prefix with `_` (C#)
- Use descriptive names reflecting domain concepts
- Avoid abbreviations except well-known ones (Id, config, async)

### Error Handling

- Use **FluentResults** for expected, recoverable failures
- Use **typed exceptions** with descriptive messages for exceptional conditions
- Never swallow exceptions without logging
- Fail fast with clear error messages
- Validate inputs at function entry
- Log errors with context before throwing

### Testing

**TDD Mandatory - Follow Red-Green-Refactor cycle**:

- Test naming: `MethodName_Condition_ExpectedResult()`
- Minimum 85% test coverage for domain and application layers
- Use AAA pattern: **Arrange, Act, Assert**
- Mock external dependencies
- Keep tests independent and deterministic
- Write tests first, ensure they FAIL before implementation

```csharp
[Fact(DisplayName = "Order total calculates correctly with tax")]
public void CalculateTotal_WithTaxRate_ReturnsCorrectTotal()
{
    // Arrange
    var order = CreateTestOrder();
    var taxRate = 0.08m;

    // Act
    var total = order.CalculateTotal(taxRate);

    // Assert
    Assert.Equal(expectedTotal, total);
}
```

### Documentation

- Document public APIs with XML docs (C#)
- Explain "why", not just "what"
- Update docs when changing behavior
- Use type signatures as documentation
- Add inline comments for complex logic
- Maintain resource files (.resx) for localized messages

## Spec Kit Commands

Available slash commands for AI agents:

- `/speckit.constitution` - Establish project principles
- `/speckit.specify` - Create baseline specification
- `/speckit.plan` - Create implementation plan
- `/speckit.tasks` - Generate actionable tasks
- `/speckit.implement` - Execute implementation
- `/speckit.clarify` (optional) - Ask structured questions to de-risk ambiguous areas
- `/speckit.analyze` (optional) - Cross-artifact consistency report
- `/speckit.checklist` (optional) - Generate quality checklists

## Mandatory Analysis Process

Before any implementation, you MUST explicitly state:

1. DDD patterns and SOLID principles applicable
2. Which layers will be affected (Domain/Application/Infrastructure)
3. How solution aligns with ubiquitous language
4. Security and compliance considerations
5. Aggregate boundaries and consistency requirements
6. Domain events to be published

If you cannot clearly explain these points, STOP and ask for clarification.

## Project Structure

```
.opencode/           # Spec Kit agent commands
.specify/            # Spec Kit configuration
├── memory/          # Constitution and project memory
├── scripts/         # Shell scripts for workflows
└── templates/       # Specification templates

src/                 # Source code
├── Core/            # Domain layer (aggregates, value objects, domain events)
├── Application/     # Application services, DTOs, interfaces
├── Infrastructure/  # Repositories, external services, adapters
├── WebApi/          # Minimal API with Endpoints/ folder
│   └── Endpoints/   # Endpoint definitions (NEVER in Program.cs)
└── Console/         # CLI, entry points

tests/               # Tests
├── Unit/            # Unit tests
├── Integration/     # Integration tests
└── Contract/        # Contract tests
```

## Security and Compliance

- Never commit secrets, tokens, or credentials
- Add `.env*` and sensitive files to `.gitignore`
- Validate and sanitize all external inputs
- Use parameterized queries for database operations
- Implement authorization at aggregate level
- Capture significant operations as domain events for audit trails
- Protect sensitive configuration values
- Address compliance requirements (PCI-DSS, SOX, LGPD) where applicable

## Communication

- Be concise and direct
- Explain decisions when relevant
- Ask clarifying questions when requirements are ambiguous
- Report progress and blockers clearly
- Before implementing, show your analysis and validation against constitution
