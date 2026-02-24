using System.Net;
using System.Text.Json;

namespace CargoManagement.Api.Middleware;

// TODO: Candidato deve implementar este middleware de tratamento global de exceções.
//
// O middleware deve:
//   1. Capturar exceções não tratadas
//   2. Logar a exceção usando ILogger
//   3. Retornar uma resposta JSON padronizada com:
//      - StatusCode 500
//      - Mensagem genérica (não expor detalhes internos)
//      - Em desenvolvimento, pode incluir detalhes da exceção
//
// Referência: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware
public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // TODO: Implementar try/catch que:
        // 1. Chama _next(context)
        // 2. Em caso de exceção, loga e retorna JSON de erro
        await _next(context);
    }
}
