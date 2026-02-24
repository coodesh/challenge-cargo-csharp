# AGENTS.md - API de Gestao de Cargas

## Sobre o projeto

Teste pratico para avaliacao de programadores senior .NET/C#.
API de controle de cargas e conteineres em contexto portuario.
O candidato recebe estrutura pronta e implementa/corrige funcionalidades em ate 1 hora.

## Stack

- C# (.NET 8+), ASP.NET Core Web API
- Entity Framework Core / Dapper
- Oracle PL/SQL (simulado via scripts SQL)
- Docker, Docker Compose
- xUnit para testes

## Estrutura do projeto

```
src/Api/             -> API principal (controllers, services, repositories)
src/Api/Models/      -> Entidades de dominio (todas prontas)
src/Api/DTOs/        -> Objetos de transferencia (parciais)
src/Api/Controllers/ -> 1-2 prontos como referencia, 1-2 para o candidato implementar
src/Api/Services/    -> Interfaces prontas, implementacoes parciais
src/Api/Data/        -> DbContext configurado, repositories parciais
scripts/             -> DDL, seed data, stored procedures
tests/               -> Testes unitarios de exemplo
```

## Convencoes de codigo

- Usar C# moderno: records para DTOs, pattern matching, nullable reference types
- Async/await em toda operacao de I/O
- Injecao de dependencia via constructor
- Controllers magros: logica nos services
- Nomenclatura em ingles no codigo, comentarios em portugues quando necessario

## Bugs intencionais (NAO corrigir automaticamente)

Existem bugs plantados propositalmente para o candidato encontrar:
- Query com N+1 em endpoint de listagem
- Paginacao quebrada (offset calculado errado)
- Serializacao incorreta de datas
- Dockerfile sem multi-stage build

Esses bugs fazem parte da avaliacao. Ao auxiliar na construcao do projeto, manter esses bugs conforme documentado.

## Decisoes do projeto

Registre aqui decisoes tomadas durante o planejamento e construcao deste teste.
Sempre que o usuario tomar uma decisao sobre escopo, formato, tecnologia ou criterio de avaliacao, anote abaixo.

### Registro de decisoes

<!-- Formato: - [YYYY-MM-DD] Decisao: <descricao> | Motivo: <justificativa> -->

### Estilo de planejamento do usuario

<!--
Registre aqui observacoes sobre como o usuario prefere trabalhar:
- Como ele estrutura pedidos (detalhado vs alto nivel)
- Preferencias de comunicacao (portugues, direto ao ponto, etc)
- Como toma decisoes (pede opcoes vs decide sozinho)
- Nivel de detalhe que espera nas respostas
- Padroes recorrentes na forma de interagir
-->
