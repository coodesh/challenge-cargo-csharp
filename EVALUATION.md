# Evaluation Rubric - Technical Challenge

> **Internal document for evaluators. Do not share with candidates.**

## Scoring Summary

| Task | Weight | Max Score |
|---|---|---|
| Task 1 - Bug Fixes | 35% | 10 |
| Task 2 - ManifestsController | 30% | 10 |
| Task 3 - Dapper + Stored Procedure | 15% | 10 |
| Task 4 - GlobalExceptionHandler (bonus) | 10% | 10 |
| AI_CHALLENGE.md | 10% | 10 |

**Final score** = weighted sum of scores

---

## Task 1 - Bug Fixes (35%)

### 1.1 Pagination Bug (10 points)

**Where:** `CargosController.cs`, method `GetAll`
**Bug:** `_cargoService.GetAllAsync(page * pageSize, pageSize)` should be `_cargoService.GetAllAsync(page, pageSize)`
**What it evaluates:** Attention to detail, debugging ability

| Score | Criteria |
|---|---|
| 10 | Identified and fixed correctly. Explained the problem. |
| 8 | Fixed correctly without explanation. |
| 5 | Identified the problem but the fix is incomplete. |
| 0 | Did not identify. |

### 1.2 N+1 Bug (10 points)

**Where:** `CargoRepository.cs`, method `GetAllAsync`
**Bug:** Missing `.Include(c => c.Containers)` in the listing query
**What it evaluates:** EF Core knowledge, query performance

| Score | Criteria |
|---|---|
| 10 | Added Include. Explained the N+1 problem. Verified in SQL log. |
| 8 | Added Include correctly. |
| 5 | Noticed the problem but solution is incomplete (e.g., loaded elsewhere). |
| 0 | Did not identify. |

### 1.3 Date Serialization (5 points)

**Where:** `Program.cs` or `appsettings.json`
**Bug:** No `JsonSerializerOptions` configuration for ISO 8601 format
**What it evaluates:** ASP.NET Core configuration knowledge

| Score | Criteria |
|---|---|
| 5 | Configured `JsonSerializerOptions` with proper DateTime handling. |
| 3 | Partial solution (e.g., configured but not ideally). |
| 0 | Did not identify. |

### 1.4 Multi-stage Dockerfile (10 points)

**Where:** `Dockerfile`
**Bug:** Single stage with SDK image (~900MB)
**What it evaluates:** Docker, containerization best practices

| Score | Criteria |
|---|---|
| 10 | Correct multi-stage with `aspnet:8.0-jammy-chiseled`. Lean final image. |
| 8 | Correct multi-stage with another acceptable runtime image. |
| 5 | Attempted multi-stage but with errors. |
| 0 | Did not modify the Dockerfile. |

**Expected Dockerfile:**
```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-chiseled
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CargoManagement.Api.dll"]
```

---

## Task 2 - ManifestsController (30%)

### Implementation Checklist

| Item | Points | Criteria |
|---|---|---|
| ManifestDto complete | 2 | All properties mapped |
| ManifestValidator | 3 | Correct validation rules |
| ManifestRepository (EF Core) | 5 | Complete CRUD, correct queries |
| ManifestService | 5 | DTO-to-Entity mapping, correct logic |
| ManifestsController endpoints | 5 | All 6 endpoints functional |
| Validation integration | 2 | Uses FluentValidation on POST/PUT |
| Not found handling | 2 | Returns 404 when entity does not exist |
| Consistent pattern | 1 | Follows the reference controllers' pattern |

**What differentiates scores:**

| Score | Profile |
|---|---|
| 9-10 | Everything functional. Clean code. Correct async/await. Validation integrated. |
| 7-8 | Functional with minor flaws. May be missing validation or an endpoint. |
| 5-6 | Partially functional. Several endpoints missing or with errors. |
| < 5 | Could not implement or implementation has structural errors. |

---

## Task 3 - Dapper + Stored Procedure (15%)

### Checklist

| Item | Points | Criteria |
|---|---|---|
| NpgsqlConnection created correctly | 3 | Uses connection string, disposes connection |
| Correct Dapper call | 4 | QueryAsync with typed parameters |
| Mapping to CargoDto | 3 | Properties mapped (attention to snake_case to PascalCase) |

| Score | Profile |
|---|---|
| 9-10 | Dapper + SP working. Connection disposed. Correct mapping. |
| 7-8 | Functional with a minor adjustment needed. |
| 5-6 | Attempted but with mapping or connection errors. |
| < 5 | Did not implement or does not know Dapper. |

---

## Task 4 - GlobalExceptionHandler - Bonus (10%)

### Checklist

| Item | Points | Criteria |
|---|---|---|
| Try/catch in middleware | 3 | Catches exceptions correctly |
| Log with Serilog | 2 | Uses ILogger to log the exception |
| Standardized JSON response | 3 | Status 500, generic message, JSON content-type |
| Registration in Program.cs | 2 | `app.UseMiddleware<GlobalExceptionHandler>()` |

---

## AI_CHALLENGE.md (10%)

| Score | Criteria |
|---|---|
| 9-10 | Answers demonstrate real experience. Critical thinking about limitations. Concrete examples. |
| 7-8 | Reasonable answers. Shows knowledge of the tools. |
| 5-6 | Generic answers. Lacks depth. |
| < 5 | Superficial answers or did not respond. |

**Positive signals:**
- Mentions reviewing AI-generated code
- Cites common problems (hallucinations, outdated code, security)
- Differentiates tasks where AI helps more (boilerplate) vs less (complex business logic)
- Mentions providing project-specific context to the AI

**Negative signals:**
- Says they would use AI to do everything without reviewing
- Cannot articulate limitations
- Copied/generic answers unrelated to the challenge

---

## General Notes for the Evaluator

- **Time is limited (1h):** Do not expect all tasks to be completed. Prioritization is being evaluated.
- **Task 1 is mandatory:** If the candidate did not fix any bugs, it is a strong negative signal.
- **Task 4 is a bonus:** Candidates who reach it demonstrate speed and proficiency.
- **Quality > Quantity:** Better to have 2 tasks done well than 4 incomplete.
- **Process matters:** Observe whether the candidate read the existing code before implementing, whether they used the reference patterns, and whether they tested the solution.
