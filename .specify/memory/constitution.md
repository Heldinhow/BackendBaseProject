<!--
  SYNC IMPACT REPORT
  ==================
  Version change: 1.1.0 → 1.2.0 (MINOR)
  
  Modified principles: N/A (new additions)
  Added principles:
    - IX. Entity Framework Core for Database Access
  
  Updated section:
    - Architecture Standards expanded with EF Core patterns
  
  Templates requiring updates: N/A (no template changes needed)
  
  Deferred items: NONE
-->

# OpenCode Constitution

## Core Principles

### I. Domain-Driven Design (DDD)

All domain logic MUST reside in the domain layer with rich domain models encapsulating business rules. Use ubiquitous language consistently across code and documentation. Define bounded contexts with clear service boundaries. Aggregates enforce consistency boundaries and transactional integrity. Domain events capture and propagate business-significant state changes.

### II. SOLID Principles

Adhere to SOLID principles: Single Responsibility (one reason to change), Open/Closed (open for extension, closed for modification), Liskov Substitution (subtypes substitutable), Interface Segregation (no forced dependency on unused methods), and Dependency Inversion (depend on abstractions, not concretions). Validate designs against these principles before implementation.

### III. .NET Modern Practices

Use .NET 10+ features including primary constructors, records, pattern matching, and System.Text.Json. Implement asynchronous programming with async/await for all I/O-bound operations. Leverage built-in Dependency Injection with proper service lifetime management (Singleton, Scoped, Transient). Use LINQ for expressive data manipulation.

### IV. Architectural Patterns

Implement consistent design patterns: Command Pattern with generic base classes (`CommandHandler<TOptions>`) and `ICommandHandler<TOptions>` interface; Factory Pattern for complex object creation with service provider integration; Repository Pattern for async data access abstractions; Provider Pattern for external service abstractions (database, AI); Resource Pattern using ResourceManager for localized messages in separate .resx files.

### V. Fluent Results Pattern

Use FluentResults library instead of exceptions for expected failure scenarios. Return `Result<T>` or `Result` from methods that may fail predictably. Chain result operations fluently with `.OnSuccess()`, `.OnFailure()`, `.Map()`. Reserve exceptions for truly exceptional, unrecoverable conditions. Ensure all result objects include descriptive error messages with error codes.

### VI. Test-Driven Development

Write tests before implementing features (TDD mandatory). Test naming convention: `MethodName_Condition_ExpectedResult()`. Follow Red-Green-Refactor cycle strictly. Maintain minimum 85% test coverage for domain and application layers. Use AAA pattern (Arrange, Act, Assert). Mock external dependencies.

### VII. Security & Compliance

Implement authorization at aggregate level. Capture all significant operations as domain events for audit trails. Use parameterized queries for data access. Validate and sanitize all external inputs. Protect sensitive configuration values. Address compliance requirements (PCI-DSS, SOX, LGPD) in domain rules where applicable.

### VIII. WebAPI Minimal API with Endpoints Folder

Use ASP.NET Core Minimal API for HTTP endpoints. All endpoint definitions MUST reside in an `Endpoints` folder within the WebAPI project—NEVER define endpoints directly in `Program.cs`. Each endpoint should be a separate file following naming convention `{Feature}Endpoints.cs` or `{Action}{Entity}Endpoint.cs` (e.g., `OrderEndpoints.cs`, `CreateOrderEndpoint.cs`). Endpoint classes should be minimal, delegating to application services and returning appropriate `Results` helpers. Group related endpoints in the same file by feature for maintainability.

### IX. Entity Framework Core for Database Access

Use Entity Framework Core 10+ as the primary ORM for database access. Follow these patterns: (1) Define DbContext in Infrastructure layer with proper service lifetime (Scoped); (2) Use Fluent API for configuration instead of data annotations on entities; (3) Implement Repository pattern on top of DbSet for domain isolation; (4) Use AsNoTracking for read-only queries; (5) Implement Unit of Work pattern for transaction management; (6) Use raw SQL for complex queries with FromSqlRaw; (7) Apply migrations consistently and version control them; (8) Configure connection strings via IConfiguration with proper secret management.

## Architecture Standards

### Layer Responsibilities

**Domain Layer**: Aggregates (root entities), Value Objects (immutable domain concepts), Domain Services (stateless complex operations), Domain Events, Specifications. **Application Layer**: Application Services (orchestration), DTOs (data transfer), Input Validation, Constructor Injection. **Infrastructure Layer**: Repositories (persistence), Event Bus (publish/subscribe), External Service Adapters, Data Mappers/ORMs, DbContext and migrations. **WebAPI Layer**: Minimal API endpoints in `Endpoints/` folder, request validation, dependency injection configuration, middleware pipeline.

### Technical Standards

Use decimal type for all monetary calculations. Implement proper saga patterns for distributed transactions. Maintain strong consistency within aggregate boundaries. Design for testability with interface abstractions throughout. Use EF Core AsNoTracking for read operations. Configure cascading deletes explicitly. Use transaction scopes for atomic operations across aggregates.

## Development Workflow

### Mandatory Analysis Process

Before any implementation, explicitly state: (1) DDD patterns and SOLID principles applicable; (2) Which layers will be affected; (3) How solution aligns with ubiquitous language; (4) Security implications. Validate implementation plan: aggregates/entities involved, domain events to publish, interface/class structure per SOLID, test naming and coverage.

### Code Review Requirements

All PRs must verify constitution compliance. Complexity additions must be justified. Use result types for expected failures. Ensure consistent terminology (ubiquitous language). Validate against quality checklist before submission.

## Governance

This constitution supersedes all other development practices. Amendments require documentation of changes, rationale, and migration plan where applicable. All PRs/reviews must verify compliance with these principles. Complexity must be justified with simpler alternatives rejected explicitly.

**Version**: 1.2.0 | **Ratified**: 2026-01-18 | **Last Amended**: 2026-01-18
