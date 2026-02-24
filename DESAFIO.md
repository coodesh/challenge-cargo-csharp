# Desafio Técnico - API de Gestão de Cargas Portuárias

## Contexto

Você está assumindo um projeto em andamento de uma API para gestão de cargas em um terminal portuário. A equipe anterior deixou a estrutura base pronta, mas há funcionalidades por implementar e bugs para corrigir.

**Tempo disponível: 1 hora**

## Stack Tecnológica

- .NET 8 / C#
- Entity Framework Core (ORM principal)
- Dapper (consultas com stored procedures)
- PostgreSQL (banco de dados)
- FluentValidation (validação de entrada)
- Serilog (logging)
- Swagger/OpenAPI (documentação da API)
- Docker / Docker Compose

## Como Rodar

```bash
docker compose up --build
```

A API estará disponível em: **http://localhost:5000/swagger**

## O que já está pronto

- Estrutura completa do projeto (Controllers, Services, Repositories, Models)
- `ContainersController` - CRUD completo e funcional (use como referência)
- `CargosController` - Funcional, mas com bugs conhecidos
- `CargoService` e `CargoRepository` - Funcionais, com bugs
- `CargoValidator` - Validação completa (use como referência)
- Testes unitários de referência (`CargosControllerTests`)
- Scripts SQL (DDL, seed data, stored procedure)
- Docker Compose configurado

## Tarefas

### Tarefa 1 - Corrigir Bugs (obrigatória)

Há bugs plantados no código existente. Identifique e corrija:

1. **Bug de paginação** no `CargosController` - A listagem de cargas não pagina corretamente.
2. **Bug de performance (N+1)** no `CargoService`/`CargoRepository` - A listagem de cargas faz queries excessivas ao banco.
3. **Bug de serialização** - As datas retornadas pela API não estão no formato ISO 8601 adequado.
4. **Dockerfile** - O Dockerfile usa uma imagem desnecessariamente pesada. Corrija para usar multi-stage build com a imagem de runtime `aspnet:8.0-jammy-chiseled`.

### Tarefa 2 - Implementar ManifestsController

Implemente o CRUD completo do `ManifestsController` seguindo o padrão dos controllers existentes:

- `GET /api/manifests` - Listar todos os manifestos
- `GET /api/manifests/{id}` - Buscar por ID
- `GET /api/manifests/por-carga/{cargoId}` - Buscar por carga
- `POST /api/manifests` - Criar (com validação)
- `PUT /api/manifests/{id}` - Atualizar
- `DELETE /api/manifests/{id}` - Remover

**Arquivos a implementar:**
- `ManifestsController.cs` - Endpoints
- `ManifestService.cs` - Lógica de negócio
- `ManifestRepository.cs` - Acesso a dados (EF Core)
- `ManifestValidator.cs` - Regras de validação
- `ManifestDto.cs` - Completar o DTO

### Tarefa 3 - Implementar CargoQueryRepository com Dapper

Implemente o `CargoQueryRepository` usando Dapper para chamar a stored procedure `buscar_cargas_por_periodo`:

- O endpoint `GET /api/cargos/por-periodo` já existe no controller
- A stored procedure já existe no banco
- Use `Npgsql.NpgsqlConnection` como conexão
- O repository já tem a estrutura e dicas nos comentários

### Tarefa 4 - Implementar GlobalExceptionHandler (bônus)

Implemente o middleware de tratamento global de exceções:

- Capturar exceções não tratadas
- Logar com Serilog
- Retornar resposta JSON padronizada (status 500)
- Registrar o middleware no `Program.cs`

## Critérios de Avaliação

- Correção e completude das implementações
- Qualidade do código C#
- Uso correto de EF Core e Dapper
- Conhecimento de ASP.NET Core (DI, middleware, controllers)
- Boas práticas (tratamento de erros, validação, logging)
- Docker e boas práticas de containerização

## Dicas

- Os arquivos com `// TODO:` indicam onde você deve implementar
- Use os arquivos de referência (ContainersController, CargoValidator) como padrão
- O `appsettings.json` tem a connection string configurada
- Rode `docker compose logs api` para ver os logs da API
- Rode `docker compose logs db` para ver os logs do banco
