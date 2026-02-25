# AGENTS.md - Cargo Management API

## About the project

Practical test for evaluating senior .NET/C# developers.
API for managing cargo and containers in a port context.
The candidate receives a ready-made structure and implements/fixes features within 1 hour.

## Stack

- C# (.NET 8+), ASP.NET Core Web API
- Entity Framework Core / Dapper
- Oracle PL/SQL (simulated via SQL scripts)
- Docker, Docker Compose
- xUnit for tests

## Project structure

```
src/Api/             -> Main API (controllers, services, repositories)
src/Api/Models/      -> Domain entities (all ready)
src/Api/DTOs/        -> Transfer objects (partial)
src/Api/Controllers/ -> 1-2 ready as reference, 1-2 for the candidate to implement
src/Api/Services/    -> Interfaces ready, partial implementations
src/Api/Data/        -> DbContext configured, partial repositories
scripts/             -> DDL, seed data, stored procedures
tests/               -> Sample unit tests
```

## Code conventions

- Use modern C#: records for DTOs, pattern matching, nullable reference types
- Async/await on every I/O operation
- Dependency injection via constructor
- Thin controllers: logic in services
- English naming in code, Portuguese comments when necessary

## Intentional bugs (DO NOT fix automatically)

There are bugs planted on purpose for the candidate to find:
- N+1 query in listing endpoint
- Broken pagination (offset calculated incorrectly)
- Incorrect date serialization
- Dockerfile without multi-stage build

These bugs are part of the evaluation. When assisting in building the project, keep these bugs as documented.

## Project decisions

Record here decisions made during the planning and construction of this test.
Whenever the user makes a decision about scope, format, technology, or evaluation criteria, note it below.

### Decision log

<!-- Format: - [YYYY-MM-DD] Decision: <description> | Reason: <justification> -->

### User planning style

<!--
Record here observations about how the user prefers to work:
- How they structure requests (detailed vs high level)
- Communication preferences (Portuguese, straight to the point, etc)
- How they make decisions (asks for options vs decides on their own)
- Level of detail expected in responses
- Recurring patterns in how they interact
-->
