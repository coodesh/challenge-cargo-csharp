# 01 - Cargo Management API

## Context

A partially implemented API for managing cargo and containers in a port environment.
The candidate receives the project with a ready-made structure and must complete, fix, and improve it.

## Stack

- C# (.NET 8+)
- ASP.NET Core (Minimal API or Controllers)
- Entity Framework Core / Dapper
- Oracle (PL/SQL) - simulated via provided SQL scripts
- Docker

## Repository Contents

- .NET project with a configured solution
- 2-3 endpoints already implemented (with intentional bugs)
- Models/entities defined
- SQL script with tables and stored procedure
- Incomplete or broken Dockerfile
- README with challenge instructions

## Candidate Tasks

1. **Implement missing endpoints** - Cargo manifest CRUD (POST, GET by ID, paginated GET, PUT, DELETE)
2. **Fix intentional bugs** - N+1 query, broken pagination, incorrect serialization
3. **Validation middleware** - Add global error handling and input validation
4. **Docker** - Fix/complete the Dockerfile so the application starts correctly
5. **PL/SQL** - Implement an endpoint that calls an Oracle stored procedure (cargo lookup by date range)
