# Technical Challenge - Port Cargo Management API

## Context

You are taking over an in-progress project for a cargo management API at a port terminal. The previous team left the base structure ready, but there are features to implement and bugs to fix.

**Time available: 1 hour**

## Tech Stack

- .NET 8 / C#
- Entity Framework Core (primary ORM)
- Dapper (queries with stored procedures)
- PostgreSQL (database)
- FluentValidation (input validation)
- Serilog (logging)
- Swagger/OpenAPI (API documentation)
- Docker / Docker Compose

## How to Run

```bash
docker compose up --build
```

The API will be available at: **http://localhost:5000/swagger**

## What Is Already Done

- Complete project structure (Controllers, Services, Repositories, Models)
- `ContainersController` - Fully functional CRUD (use as reference)
- `CargosController` - Functional, but with known bugs
- `CargoService` and `CargoRepository` - Functional, with bugs
- `CargoValidator` - Complete validation (use as reference)
- Reference unit tests (`CargosControllerTests`)
- SQL scripts (DDL, seed data, stored procedure)
- Docker Compose configured

## Tasks

### Task 1 - Fix Bugs (mandatory)

There are planted bugs in the existing code. Identify and fix them:

1. **Pagination bug** in `CargosController` - The cargo listing does not paginate correctly.
2. **Performance bug (N+1)** in `CargoService`/`CargoRepository` - The cargo listing makes excessive queries to the database.
3. **Serialization bug** - The dates returned by the API are not in the proper ISO 8601 format.
4. **Dockerfile** - The Dockerfile uses an unnecessarily heavy image. Fix it to use a multi-stage build with the `aspnet:8.0-jammy-chiseled` runtime image.

### Task 2 - Implement ManifestsController

Implement the full CRUD for `ManifestsController` following the pattern of the existing controllers:

- `GET /api/manifests` - List all manifests
- `GET /api/manifests/{id}` - Get by ID
- `GET /api/manifests/por-carga/{cargoId}` - Get by cargo
- `POST /api/manifests` - Create (with validation)
- `PUT /api/manifests/{id}` - Update
- `DELETE /api/manifests/{id}` - Delete

**Files to implement:**
- `ManifestsController.cs` - Endpoints
- `ManifestService.cs` - Business logic
- `ManifestRepository.cs` - Data access (EF Core)
- `ManifestValidator.cs` - Validation rules
- `ManifestDto.cs` - Complete the DTO

### Task 3 - Implement CargoQueryRepository with Dapper

Implement `CargoQueryRepository` using Dapper to call the stored procedure `buscar_cargas_por_periodo`:

- The `GET /api/cargos/por-periodo` endpoint already exists in the controller
- The stored procedure already exists in the database
- Use `Npgsql.NpgsqlConnection` as the connection
- The repository already has the structure and hints in the comments

### Task 4 - Implement GlobalExceptionHandler (bonus)

Implement the global exception handling middleware:

- Catch unhandled exceptions
- Log with Serilog
- Return a standardized JSON response (status 500)
- Register the middleware in `Program.cs`

## Evaluation Criteria

- Correctness and completeness of implementations
- C# code quality
- Correct use of EF Core and Dapper
- ASP.NET Core knowledge (DI, middleware, controllers)
- Best practices (error handling, validation, logging)
- Docker and containerization best practices

## Tips

- Files with `// TODO:` indicate where you should implement
- Use the reference files (ContainersController, CargoValidator) as a pattern
- `appsettings.json` has the connection string configured
- Run `docker compose logs api` to see the API logs
- Run `docker compose logs db` to see the database logs
