# Rubrica de Avaliação - Desafio Técnico

> **Documento interno para avaliadores. Não compartilhar com candidatos.**

## Resumo de Pontuação

| Tarefa | Peso | Nota Máxima |
|---|---|---|
| Tarefa 1 - Correção de Bugs | 35% | 10 |
| Tarefa 2 - ManifestsController | 30% | 10 |
| Tarefa 3 - Dapper + Stored Procedure | 15% | 10 |
| Tarefa 4 - GlobalExceptionHandler (bônus) | 10% | 10 |
| DESAFIO_IA.md | 10% | 10 |

**Nota final** = soma ponderada das notas

---

## Tarefa 1 - Correção de Bugs (35%)

### 1.1 Bug de Paginação (10 pontos)

**Onde:** `CargosController.cs`, método `GetAll`
**Bug:** `_cargoService.GetAllAsync(page * pageSize, pageSize)` deveria ser `_cargoService.GetAllAsync(page, pageSize)`
**O que avalia:** Atenção ao detalhe, capacidade de debugging

| Nota | Critério |
|---|---|
| 10 | Identificou e corrigiu corretamente. Explicou o problema. |
| 8 | Corrigiu corretamente sem explicação. |
| 5 | Identificou o problema mas a correção não está completa. |
| 0 | Não identificou. |

### 1.2 Bug N+1 (10 pontos)

**Onde:** `CargoRepository.cs`, método `GetAllAsync`
**Bug:** Falta `.Include(c => c.Containers)` na query de listagem
**O que avalia:** Conhecimento de EF Core, performance de queries

| Nota | Critério |
|---|---|
| 10 | Adicionou Include. Explicou o problema N+1. Verificou no log SQL. |
| 8 | Adicionou Include corretamente. |
| 5 | Percebeu o problema mas solução incompleta (ex: carregou em outro lugar). |
| 0 | Não identificou. |

### 1.3 Serialização de Datas (5 pontos)

**Onde:** `Program.cs` ou `appsettings.json`
**Bug:** Sem configuração de `JsonSerializerOptions` para formato ISO 8601
**O que avalia:** Conhecimento de configuração ASP.NET Core

| Nota | Critério |
|---|---|
| 5 | Configurou `JsonSerializerOptions` com tratamento adequado de DateTime. |
| 3 | Solução parcial (ex: configurou mas não de forma ideal). |
| 0 | Não identificou. |

### 1.4 Dockerfile Multi-stage (10 pontos)

**Onde:** `Dockerfile`
**Bug:** Single stage com imagem SDK (~900MB)
**O que avalia:** Docker, boas práticas de containerização

| Nota | Critério |
|---|---|
| 10 | Multi-stage correto com `aspnet:8.0-jammy-chiseled`. Imagem final enxuta. |
| 8 | Multi-stage correto com outra imagem de runtime aceitável. |
| 5 | Tentou multi-stage mas com erros. |
| 0 | Não alterou o Dockerfile. |

**Dockerfile esperado:**
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

## Tarefa 2 - ManifestsController (30%)

### Checklist de Implementação

| Item | Pontos | Critério |
|---|---|---|
| ManifestDto completo | 2 | Todas as propriedades mapeadas |
| ManifestValidator | 3 | Regras de validação corretas |
| ManifestRepository (EF Core) | 5 | CRUD completo, queries corretas |
| ManifestService | 5 | Mapeamento DTO→Entity, lógica correta |
| ManifestsController endpoints | 5 | Todos os 6 endpoints funcionais |
| Integração com validação | 2 | Usa FluentValidation no POST/PUT |
| Tratamento de not found | 2 | Retorna 404 quando entidade não existe |
| Padrão consistente | 1 | Segue o padrão dos controllers de referência |

**O que diferencia notas:**

| Nota | Perfil |
|---|---|
| 9-10 | Tudo funcional. Código limpo. Async/await correto. Validação integrada. |
| 7-8 | Funcional com pequenas falhas. Pode faltar validação ou um endpoint. |
| 5-6 | Parcialmente funcional. Vários endpoints faltando ou com erros. |
| < 5 | Não conseguiu implementar ou implementação com erros estruturais. |

---

## Tarefa 3 - Dapper + Stored Procedure (15%)

### Checklist

| Item | Pontos | Critério |
|---|---|---|
| NpgsqlConnection criada corretamente | 3 | Usa connection string, disposes connection |
| Chamada Dapper correta | 4 | QueryAsync com parâmetros tipados |
| Mapeamento para CargoDto | 3 | Propriedades mapeadas (atenção ao snake_case → PascalCase) |

| Nota | Perfil |
|---|---|
| 9-10 | Dapper + SP funcionando. Connection disposed. Mapeamento correto. |
| 7-8 | Funcional com pequeno ajuste necessário. |
| 5-6 | Tentou mas com erros de mapeamento ou conexão. |
| < 5 | Não implementou ou não conhece Dapper. |

---

## Tarefa 4 - GlobalExceptionHandler - Bônus (10%)

### Checklist

| Item | Pontos | Critério |
|---|---|---|
| Try/catch no middleware | 3 | Captura exceções corretamente |
| Log com Serilog | 2 | Usa ILogger para registrar a exceção |
| Resposta JSON padronizada | 3 | Status 500, mensagem genérica, content-type JSON |
| Registro no Program.cs | 2 | `app.UseMiddleware<GlobalExceptionHandler>()` |

---

## DESAFIO_IA.md (10%)

| Nota | Critério |
|---|---|
| 9-10 | Respostas demonstram experiência real. Senso crítico sobre limitações. Exemplos concretos. |
| 7-8 | Respostas razoáveis. Mostra conhecimento das ferramentas. |
| 5-6 | Respostas genéricas. Pouca profundidade. |
| < 5 | Respostas superficiais ou não respondeu. |

**Sinais positivos:**
- Menciona revisão de código gerado por IA
- Cita problemas comuns (alucinações, código desatualizado, segurança)
- Diferencia tarefas onde IA ajuda mais (boilerplate) vs menos (lógica de negócio complexa)
- Menciona dar contexto específico do projeto para a IA

**Sinais negativos:**
- Diz que usaria IA para fazer tudo sem revisar
- Não consegue articular limitações
- Respostas copiadas/genéricas sem relação com o desafio

---

## Observações Gerais para o Avaliador

- **Tempo é limitado (1h):** Não espere que todas as tarefas sejam completadas. Priorização é avaliada.
- **Tarefa 1 é obrigatória:** Se o candidato não corrigiu nenhum bug, é um sinal negativo forte.
- **Tarefa 4 é bônus:** Candidatos que chegam nela demonstram velocidade e proficiência.
- **Qualidade > Quantidade:** Melhor 2 tarefas bem feitas do que 4 incompletas.
- **Processo importa:** Observe se o candidato leu o código existente antes de implementar, se usou os padrões de referência, se testou a solução.
