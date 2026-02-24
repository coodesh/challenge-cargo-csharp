# 01 - API de Gestao de Cargas

## Contexto

API parcialmente implementada para controle de cargas e conteineres em ambiente portuario.
O candidato recebe o projeto com estrutura pronta e precisa completar, corrigir e melhorar.

## Stack

- C# (.NET 8+)
- ASP.NET Core (Minimal API ou Controllers)
- Entity Framework Core / Dapper
- Oracle (PL/SQL) - simulado via scripts SQL fornecidos
- Docker

## O que o candidato recebe

- Projeto .NET com solution configurada
- 2-3 endpoints ja implementados (com bugs intencionais)
- Model/entities definidos
- Script SQL com tabelas e stored procedure
- Dockerfile incompleto ou com erros
- README com instrucoes do desafio

## Tarefas do candidato

1. **Implementar endpoints faltantes** - CRUD de manifesto de carga (POST, GET by ID, GET paginado, PUT, DELETE)
2. **Corrigir bugs intencionais** - Query com N+1, paginacao quebrada, serializacao incorreta
3. **Middleware de validacao** - Adicionar tratamento global de erros e validacao de input
4. **Docker** - Corrigir/completar o Dockerfile para que a aplicacao suba corretamente
5. **PL/SQL** - Implementar endpoint que chama stored procedure Oracle (consulta de cargas por periodo)

## Criterios de avaliacao

| Criterio | Peso | O que observar |
|---|---|---|
| API REST | 25% | Verbos HTTP corretos, status codes, paginacao, versionamento |
| C# moderno | 25% | Records, pattern matching, nullable reference types, async/await |
| SQL/PL/SQL | 15% | Query correta, uso de parametros, chamada de stored procedure |
| Docker | 15% | Multi-stage build, imagem otimizada, .dockerignore |
| Qualidade | 20% | Tratamento de erros, validacao, organizacao de codigo |

## Tempo estimado

- 45-60 minutos

## Nivel de dificuldade

Avancado (Senior)

## Pontos fortes desta ideia

- Contexto portuario alinhado com o cliente (Supero)
- Avalia proficiencia pratica, nao so logica
- Mistura de implementacao nova + debugging
- Cobre todas as habilidades principais e secundarias da vaga
