# Tasks: Base Project Template

**Input**: Design documents from `/specs/base-project/`
**Prerequisites**: plan.md (completed), spec.md (completed for user stories)

**Organization**: Tasks are grouped by user story to enable independent implementation and testing of each story.

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel (different files, no dependencies)
- **[Story]**: Which user story this task belongs to (e.g., US1, US2, US3)
- Include exact file paths in descriptions

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Solution and project initialization

- [ ] T001 Create solution file `BackendBaseProject.sln` at repository root
- [ ] T002 [P] Create `Core/` project with `BackendBaseProject.Core.csproj`
- [ ] T003 [P] Create `Application/` project with `BackendBaseProject.Application.csproj`
- [ ] T004 [P] Create `Infrastructure/` project with `BackendBaseProject.Infrastructure.csproj`
- [ ] T005 [P] Create `WebApi/` project with `BackendBaseProject.WebApi.csproj`
- [ ] T006 [P] Create `Console/` project with `BackendBaseProject.Console.csproj`
- [ ] T007 [P] Create `tests/Unit/` project with `BackendBaseProject.Core.Tests.csproj`
- [ ] T008 [P] Create `tests/Integration/` project with `BackendBaseProject.Integration.Tests.csproj`
- [ ] T009 [P] Create `tests/Contract/` project with `BackendBaseProject.Contract.Tests.csproj`
- [ ] T010 Add project references (Core referenced by all, Application referenced by Infrastructure/WebApi/Console, Infrastructure referenced by WebApi/Console)

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core domain models and interfaces that all user stories depend on

**CRITICAL**: No user story work can begin until this phase is complete

### Tests for Foundational ⚠️

> NOTE: Write these tests FIRST, ensure they FAIL before implementation

- [ ] T011 [P] [FOUNDATION] Unit test for aggregate creation in tests/Unit/Core/Aggregates/
- [ ] T012 [P] [FOUNDATION] Unit test for value object creation in tests/Unit/Core/ValueObjects/
- [ ] T013 [FOUNDATION] Contract test for domain event structure in tests/Contract/Core/

### Implementation for Foundational

- [ ] T014 [FOUNDATION] Create `Core/Entities/Entity.cs` - base entity with Id
- [ ] T015 [FOUNDATION] Create `Core/Aggregates/AggregateRoot.cs` - aggregate root base class
- [ ] T016 [FOUNDATION] Create `Core/ValueObjects/ValueObject.cs` - value object base class
- [ ] T017 [FOUNDATION] Create `Core/DomainEvents/IDomainEvent.cs` - domain event interface
- [ ] T018 [FOUNDATION] Create `Core/DomainEvents/DomainEventBase.cs` - base domain event class
- [ ] T019 [FOUNDATION] Create `Core/DomainServices/IDomainService.cs` - domain service interface
- [ ] T020 [FOUNDATION] Create `Core/Specifications/ISpecification.cs` - specification interface
- [ ] T021 [FOUNDATION] Create `Application/Interfaces/IRepository.cs` - repository interface (async)
- [ ] T022 [FOUNDATION] Create `Application/Interfaces/IProvider.cs` - provider interface
- [ ] T023 [FOUNDATION] Create `Application/Interfaces/IEventPublisher.cs` - event publisher interface

**Checkpoint**: Foundation ready - user story implementation can now begin in parallel

---

## Phase 3: User Story 1 - Base Project Structure (Priority: P1) 🎯 MVP

**Goal**: Well-structured .NET project template that builds successfully

**Independent Test**: `dotnet build` succeeds

### Tests for User Story 1 ⚠️

- [ ] T024 [US1] Integration test for solution build in tests/Integration/

### Implementation for User Story 1

- [ ] T025 [US1] Configure `Core/` with basic domain model classes
- [ ] T026 [US1] Configure `Application/` with empty application services
- [ ] T027 [US1] Configure `Infrastructure/` with basic persistence setup
- [ ] T028 [US1] Configure `WebApi/Program.cs` with Minimal API scaffolding
- [ ] T029 [US1] Create `WebApi/Endpoints/HealthEndpoint.cs` - health check endpoint
- [ ] T030 [US1] Configure `Console/Program.cs` with basic entry point
- [ ] T031 [US1] Add `Directory.Build.props` for shared properties
- [ ] T032 [US1] Add `nuget.config` if needed
- [ ] T033 [US1] Add `.gitignore` for .NET projects

**Checkpoint**: At this point, the solution should build successfully

---

## Phase 4: User Story 2 - Design Patterns Implemented (Priority: P1)

**Goal**: All five design patterns implemented with working examples

**Independent Test**: All patterns have passing unit tests

### Tests for User Story 2 ⚠️

- [ ] T034 [P] [US2] Unit test for CommandHandler pattern in tests/Unit/Application/
- [ ] T035 [P] [US2] Unit test for Factory pattern in tests/Unit/Application/
- [ ] T036 [P] [US2] Unit test for Repository pattern in tests/Unit/Infrastructure/
- [ ] T037 [P] [US2] Unit test for Provider pattern in tests/Unit/Infrastructure/
- [ ] T038 [P] [US2] Unit test for Resource pattern in tests/Unit/Infrastructure/

### Implementation for User Story 2

- [ ] T039 [US2] Create `Application/Commands/CommandHandler.cs` - generic base class
- [ ] T040 [US2] Create `Application/Commands/ICommandHandler.cs` - interface
- [ ] T041 [US2] Create `Application/Commands/CommandHandlerOptions.cs` - options base
- [ ] T042 [US2] Create `Application/Commands/SetupCommand.cs` - extension method
- [ ] T043 [US2] Create `Infrastructure/Repositories/RepositoryBase.cs` - async base
- [ ] T044 [US2] Create `Infrastructure/Providers/ProviderBase.cs` - provider base
- [ ] T045 [US2] Create `Infrastructure/Data/ExampleEntity.cs` - sample entity
- [ ] T046 [US2] Add FluentResults package to Application and Infrastructure
- [ ] T047 [US2] Create example command handler with Result<T> return

**Checkpoint**: All design patterns implemented and tested

---

## Phase 5: User Story 3 - FluentResults Integration (Priority: P1)

**Goal**: Consistent error handling using FluentResults

**Independent Test**: Application services return Result<T> with proper error handling

### Tests for User Story 3 ⚠️

- [ ] T048 [US3] Unit test for FluentResults success path in tests/Unit/Application/
- [ ] T049 [US3] Unit test for FluentResults failure path in tests/Unit/Application/

### Implementation for User Story 3

- [ ] T050 [US3] Create `Application/Services/ExampleService.cs` - demonstrates Result<T>
- [ ] T051 [US3] Update all application service interfaces to return `Result<T>`
- [ ] T052 [US3] Add error handling middleware in `WebApi/Middleware/`
- [ ] T053 [US3] Document FluentResults usage in README.md

**Checkpoint**: All application services use FluentResults consistently

---

## Phase 6: User Story 4 - Tests and Coverage (Priority: P1)

**Goal**: Comprehensive test coverage >85% on Core and Application

**Independent Test**: `dotnet test --coverage` shows >85% on Core and Application

### Implementation for Coverage

- [ ] T054 [P] [US4] Add xUnit, Moq, FluentAssertions to test projects
- [ ] T055 [P] [US4] Configure coverage in `Directory.Build.props`
- [ ] T056 [US4] Write unit tests for all Core entities and value objects
- [ ] T057 [US4] Write unit tests for all Application interfaces
- [ ] T058 [US4] Write unit tests for all Application services
- [ ] T059 [US4] Write integration tests for Infrastructure repositories
- [ ] T060 [US4] Write contract tests for API endpoints

**Checkpoint**: All tests pass with >85% coverage on Core and Application

---

## Phase 7: Polish & Cross-Cutting Concerns

**Purpose**: Documentation and final quality checks

- [ ] T061 Create `README.md` with setup instructions
- [ ] T062 Create `CONTRIBUTING.md` with contribution guidelines
- [ ] T063 Create `LICENSE` (MIT recommended)
- [ ] T064 Add XML documentation to all public APIs
- [ ] T065 Create resource files `LogMessages.resx` and `ErrorMessages.resx`
- [ ] T066 Configure CI/CD workflow (GitHub Actions)
- [ ] T067 Run final validation: build, test, coverage check
- [ ] T068 Update AGENTS.md with any additional patterns discovered

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies - can start immediately
- **Foundational (Phase 2)**: Depends on Setup completion - BLOCKS all user stories
- **User Stories (Phase 3-6)**: All depend on Foundational phase completion
  - User stories can proceed in parallel (if staffed)
  - Or sequentially in priority order
- **Polish (Phase 7)**: Depends on all desired user stories being complete

### User Story Dependencies

- **User Story 1 (P1)**: Can start after Foundational (Phase 2) - No dependencies on other stories
- **User Story 2 (P1)**: Can start after Foundational (Phase 2) - Can run in parallel with US1
- **User Story 3 (P1)**: Can start after Foundational (Phase 2) - Can run in parallel with US1, US2
- **User Story 4 (P1)**: Must start after US2 and US3 (needs patterns implemented)

### Within Each User Story

- Tests (if included) MUST be written and FAIL before implementation
- Foundation first, then user stories
- Story complete before moving to next priority

### Parallel Opportunities

- All Setup tasks marked [P] can run in parallel
- All Foundational tests marked [P] can run in parallel
- Once Foundational phase completes, all user stories can start in parallel
- Tests for patterns marked [P] can run in parallel
- Polish tasks can run in parallel

---

## Implementation Strategy

### MVP First (User Story 1 Only)

1. Complete Phase 1: Setup
2. Complete Phase 2: Foundational
3. Complete Phase 3: User Story 1
4. **STOP and VALIDATE**: Build succeeds
5. Deploy/demo if ready

### Incremental Delivery

1. Complete Setup + Foundational → Foundation ready
2. Add User Story 1 → Validate build → MVP!
3. Add User Story 2 → Validate patterns → Pattern reference
4. Add User Story 3 → Validate error handling → Consistent errors
5. Add User Story 4 → Validate coverage → Quality gate

### Parallel Team Strategy

With multiple developers:

1. Team completes Setup + Foundational together
2. Once Foundational is done:
   - Developer A: User Story 1 (structure)
   - Developer B: User Story 2 (patterns)
   - Developer C: User Story 3 (FluentResults)
3. Stories complete and integrate independently

---

## Notes

- [P] tasks = different files, no dependencies
- [Story] label maps task to specific user story for traceability
- Each user story should be independently completable and testable
- Verify tests fail before implementing
- Commit after each task or logical group
- Stop at any checkpoint to validate story independently
- Follow constitution principles throughout
